namespace CRUDClientesSQLServer.Forms
{
    partial class FrmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIdCliente = new Label();
            txtIdCliente = new TextBox();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            dgvClientes = new DataGridView();
            progressCarga = new ProgressBar();
            lblEstado = new Label();
            lblRegistros = new Label();
            lblClientesRegistrados = new Label();
            grpDatosCliente = new GroupBox();
            grpListado = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            grpDatosCliente.SuspendLayout();
            grpListado.SuspendLayout();
            SuspendLayout();
            // 
            // lblIdCliente
            // 
            lblIdCliente.AutoSize = true;
            lblIdCliente.Location = new Point(23, 21);
            lblIdCliente.Name = "lblIdCliente";
            lblIdCliente.Size = new Size(26, 19);
            lblIdCliente.TabIndex = 0;
            lblIdCliente.Text = "ID:";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(104, 18);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(536, 25);
            txtIdCliente.TabIndex = 1;
            txtIdCliente.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(104, 60);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(536, 25);
            txtNombre.TabIndex = 3;
            txtNombre.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(23, 63);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(62, 19);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(104, 104);
            txtApellido.MaxLength = 60;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(536, 25);
            txtApellido.TabIndex = 5;
            txtApellido.TabStop = false;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = SystemColors.Control;
            lblApellido.Location = new Point(23, 107);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(61, 19);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(104, 198);
            txtCorreo.MaxLength = 120;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(536, 25);
            txtCorreo.TabIndex = 9;
            txtCorreo.TabStop = false;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.BackColor = SystemColors.Control;
            lblCorreo.Location = new Point(23, 201);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(54, 19);
            lblCorreo.TabIndex = 8;
            lblCorreo.Text = "Correo:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(104, 148);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(536, 25);
            txtTelefono.TabIndex = 7;
            txtTelefono.TabStop = false;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(23, 151);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(63, 19);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono:";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = SystemColors.ScrollBar;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Location = new Point(27, 240);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(105, 35);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ScrollBar;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(169, 240);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 35);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = SystemColors.ScrollBar;
            btnActualizar.Enabled = false;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Location = new Point(310, 240);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(105, 35);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.ScrollBar;
            btnEliminar.Enabled = false;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(453, 240);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 35);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ScrollBar;
            btnCancelar.Enabled = false;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(594, 240);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(149, 35);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar Carga";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(23, 59);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(780, 205);
            dgvClientes.TabIndex = 15;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // progressCarga
            // 
            progressCarga.Location = new Point(246, 614);
            progressCarga.Name = "progressCarga";
            progressCarga.Size = new Size(372, 23);
            progressCarga.Style = ProgressBarStyle.Marquee;
            progressCarga.TabIndex = 16;
            progressCarga.Visible = false;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(28, 618);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(86, 19);
            lblEstado.TabIndex = 17;
            lblEstado.Text = "Estado: Listo";
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Location = new Point(773, 618);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(84, 19);
            lblRegistros.TabIndex = 18;
            lblRegistros.Text = "Registros: 0 ";
            // 
            // lblClientesRegistrados
            // 
            lblClientesRegistrados.AutoSize = true;
            lblClientesRegistrados.BackColor = SystemColors.Control;
            lblClientesRegistrados.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClientesRegistrados.Location = new Point(352, 27);
            lblClientesRegistrados.Name = "lblClientesRegistrados";
            lblClientesRegistrados.Size = new Size(157, 17);
            lblClientesRegistrados.TabIndex = 19;
            lblClientesRegistrados.Text = "CLIENTES REGISTRADOS";
            // 
            // grpDatosCliente
            // 
            grpDatosCliente.Controls.Add(lblIdCliente);
            grpDatosCliente.Controls.Add(txtIdCliente);
            grpDatosCliente.Controls.Add(lblNombre);
            grpDatosCliente.Controls.Add(txtNombre);
            grpDatosCliente.Controls.Add(lblApellido);
            grpDatosCliente.Controls.Add(txtApellido);
            grpDatosCliente.Controls.Add(btnCancelar);
            grpDatosCliente.Controls.Add(lblTelefono);
            grpDatosCliente.Controls.Add(btnEliminar);
            grpDatosCliente.Controls.Add(btnActualizar);
            grpDatosCliente.Controls.Add(txtTelefono);
            grpDatosCliente.Controls.Add(btnGuardar);
            grpDatosCliente.Controls.Add(lblCorreo);
            grpDatosCliente.Controls.Add(btnNuevo);
            grpDatosCliente.Controls.Add(txtCorreo);
            grpDatosCliente.Location = new Point(28, 23);
            grpDatosCliente.Name = "grpDatosCliente";
            grpDatosCliente.Size = new Size(829, 292);
            grpDatosCliente.TabIndex = 20;
            grpDatosCliente.TabStop = false;
            grpDatosCliente.Text = "Datos Clientes";
            // 
            // grpListado
            // 
            grpListado.Controls.Add(dgvClientes);
            grpListado.Controls.Add(lblClientesRegistrados);
            grpListado.Location = new Point(28, 318);
            grpListado.Name = "grpListado";
            grpListado.Size = new Size(829, 281);
            grpListado.TabIndex = 21;
            grpListado.TabStop = false;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 656);
            Controls.Add(grpListado);
            Controls.Add(grpDatosCliente);
            Controls.Add(lblRegistros);
            Controls.Add(lblEstado);
            Controls.Add(progressCarga);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 600);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            Load += FrmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            grpDatosCliente.ResumeLayout(false);
            grpDatosCliente.PerformLayout();
            grpListado.ResumeLayout(false);
            grpListado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdCliente;
        private TextBox txtIdCliente;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnCancelar;
        private DataGridView dgvClientes;
        private ProgressBar progressCarga;
        private Label lblEstado;
        private Label lblRegistros;
        private Label lblClientesRegistrados;
        private GroupBox grpDatosCliente;
        private GroupBox grpListado;
    }
}