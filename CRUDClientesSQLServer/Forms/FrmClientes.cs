using Microsoft.Data.SqlClient;
using CRUDClientesSQLServer.Models;
using CRUDClientesSQLServer.Repositories;

namespace CRUDClientesSQLServer.Forms;

public partial class FrmClientes : Form
{
    private readonly ClienteRepository _repository = new();
    private readonly SemaphoreSlim _operacionLock = new(1, 1);
    private CancellationTokenSource? _cancellationTokenSource;
    private Cliente? _clienteSeleccionado;

    public FrmClientes()
    {
        InitializeComponent();

        // Configuración inicial del DataGridView
        dgvClientes.AutoGenerateColumns = true;
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClientes.MultiSelect = false;
        dgvClientes.ReadOnly = true;
        dgvClientes.AllowUserToAddRows = false;

        // Suscripción de eventos
        Load += FrmClientes_Load;
        dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
        btnNuevo.Click += btnNuevo_Click;
        btnGuardar.Click += btnGuardar_Click;
        btnActualizar.Click += btnActualizar_Click;
        btnEliminar.Click += btnEliminar_Click;
        btnCancelar.Click += btnCancelar_Click;
    }

    // 1. CARGA INICIAL DEL FORMULARIO
    private async void FrmClientes_Load(object? sender, EventArgs e)
    {
        await CargarClientesAsync();
    }

    private async Task CargarClientesAsync()
    {
        if (!await _operacionLock.WaitAsync(0))
            return;

        try
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();

            CambiarEstadoCarga(true);

            var clientes = await _repository.ObtenerTodosAsync(_cancellationTokenSource.Token);
            dgvClientes.DataSource = clientes;

            // OCULTAR COLUMNAS INTERNAS QUE NO DEBEN MOSTRARSE AL USUARIO
            if (dgvClientes.Columns["RowVersion"] != null)
                dgvClientes.Columns["RowVersion"].Visible = false;

            if (dgvClientes.Columns["Activo"] != null)
                dgvClientes.Columns["Activo"].Visible = false;

            lblRegistros.Text = $"Registros: {clientes.Count}";
            lblEstado.Text = "Estado: Datos cargados";
        }
        catch (OperationCanceledException)
        {
            lblEstado.Text = "Estado: Carga cancelada";
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error de SQL Server: {ex.Message}", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CambiarEstadoCarga(false);
            _operacionLock.Release();
        }
    }

    // 2. BOTÓN GUARDAR (INSERTAR)
    private async void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (!ValidarFormulario())
            return;

        if (!await _operacionLock.WaitAsync(0))
        {
            MessageBox.Show("Ya existe una operación en ejecución.", "Operación en curso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            CambiarEstadoCarga(true);
            var cliente = ObtenerClienteDesdeFormulario();
            int id = await _repository.InsertarAsync(cliente, CancellationToken.None);

            MessageBox.Show($"Cliente registrado con ID {id}.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            await CargarClientesInternamenteAsync();
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"No fue posible guardar el cliente.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CambiarEstadoCarga(false);
            _operacionLock.Release();
        }
    }

    // 3. BOTÓN ACTUALIZAR (CON CONCURRENCIA OPTIMISTA)
    private async void btnActualizar_Click(object? sender, EventArgs e)
    {
        if (_clienteSeleccionado is null)
        {
            MessageBox.Show("Seleccione un cliente.");
            return;
        }

        if (!ValidarFormulario())
            return;

        if (!await _operacionLock.WaitAsync(0))
        {
            MessageBox.Show("Ya existe una operación en ejecución.");
            return;
        }

        try
        {
            CambiarEstadoCarga(true);
            var cliente = ObtenerClienteDesdeFormulario();
            cliente.IdCliente = _clienteSeleccionado.IdCliente;
            cliente.RowVersion = _clienteSeleccionado.RowVersion;

            bool actualizado = await _repository.ActualizarAsync(cliente, CancellationToken.None);

            if (!actualizado)
            {
                MessageBox.Show(
                    "El registro fue modificado por otro proceso o usuario. Vuelva a cargar los datos antes de actualizar.",
                    "Conflicto de concurrencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            await CargarClientesInternamenteAsync();
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CambiarEstadoCarga(false);
            _operacionLock.Release();
        }
    }

    // 4. BOTÓN ELIMINAR (DESACTIVACIÓN LÓGICA)
    private async void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (_clienteSeleccionado is null)
        {
            MessageBox.Show("Seleccione un cliente.");
            return;
        }

        var respuesta = MessageBox.Show(
            "¿Desea desactivar el cliente seleccionado?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        if (!await _operacionLock.WaitAsync(0))
        {
            MessageBox.Show("Ya existe una operación en ejecución.");
            return;
        }

        try
        {
            CambiarEstadoCarga(true);
            bool eliminado = await _repository.EliminarAsync(_clienteSeleccionado.IdCliente);

            if (eliminado)
            {
                MessageBox.Show("Cliente desactivado.");
                LimpiarFormulario();
                await CargarClientesInternamenteAsync();
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CambiarEstadoCarga(false);
            _operacionLock.Release();
        }
    }

    // CARGA DE REFRESCO REUTILIZANDO EL BLOQUEO (LOCK)
    private async Task CargarClientesInternamenteAsync()
    {
        var clientes = await _repository.ObtenerTodosAsync();
        dgvClientes.DataSource = clientes;
        lblRegistros.Text = $"Registros: {clientes.Count}";
    }

    // SELECCIÓN EN EL DATAGRIDVIEW
    private void dgvClientes_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvClientes.CurrentRow?.DataBoundItem is not Cliente cliente)
            return;

        _clienteSeleccionado = cliente;
        txtIdCliente.Text = cliente.IdCliente.ToString();
        txtNombre.Text = cliente.Nombre;
        txtApellido.Text = cliente.Apellido;
        txtTelefono.Text = cliente.Telefono ?? "";
        txtCorreo.Text = cliente.Correo ?? "";

        btnActualizar.Enabled = true;
        btnEliminar.Enabled = true;
    }

    // MÉTODOS AUXILIARES DE INTERFAZ Y VALIDACIÓN
    private Cliente ObtenerClienteDesdeFormulario()
    {
        return new Cliente
        {
            Nombre = txtNombre.Text.Trim(),
            Apellido = txtApellido.Text.Trim(),
            Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
            Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim()
        };
    }

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("Ingrese el nombre.");
            txtNombre.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtApellido.Text))
        {
            MessageBox.Show("Ingrese el apellido.");
            txtApellido.Focus();
            return false;
        }

        if (!string.IsNullOrWhiteSpace(txtCorreo.Text) && !txtCorreo.Text.Contains("@"))
        {
            MessageBox.Show("Ingrese un correo válido.");
            txtCorreo.Focus();
            return false;
        }

        return true;
    }

    private void LimpiarFormulario()
    {
        _clienteSeleccionado = null;
        txtIdCliente.Clear();
        txtNombre.Clear();
        txtApellido.Clear();
        txtTelefono.Clear();
        txtCorreo.Clear();

        btnActualizar.Enabled = false;
        btnEliminar.Enabled = false;
        txtNombre.Focus();
    }

    private void btnNuevo_Click(object? sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    private void btnCancelar_Click(object? sender, EventArgs e)
    {
        _cancellationTokenSource?.Cancel();
    }

    private void CambiarEstadoCarga(bool cargando)
    {
        progressCarga.Visible = cargando;
        btnGuardar.Enabled = !cargando;
        btnActualizar.Enabled = !cargando && _clienteSeleccionado is not null;
        btnEliminar.Enabled = !cargando && _clienteSeleccionado is not null;
        btnNuevo.Enabled = !cargando;
        btnCancelar.Enabled = cargando;
        lblEstado.Text = cargando ? "Estado: Procesando..." : "Estado: Listo";
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _operacionLock.Dispose();
        base.OnFormClosed(e);
    }
}