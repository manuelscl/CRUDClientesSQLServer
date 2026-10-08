using Microsoft.Data.SqlClient;
using CRUDClientesSQLServer.Data;
using CRUDClientesSQLServer.Models;

namespace CRUDClientesSQLServer.Repositories;

public class ClienteRepository
{
    // 1. OBTENER TODOS LOS CLIENTES ACTIVOS (READ)
    public async Task<List<Cliente>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        var lista = new List<Cliente>();
        const string sql = @"
            SELECT IdCliente, Nombre, Apellido, Telefono, Correo,
                   FechaRegistro, Activo, RowVersion
            FROM Clientes
            WHERE Activo = 1
            ORDER BY Apellido, Nombre;";

        await using var cn = new SqlConnection(ConexionBD.CadenaConexion);
        await using var cmd = new SqlCommand(sql, cn);

        await cn.OpenAsync(cancellationToken);
        await using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            lista.Add(new Cliente
            {
                IdCliente = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Telefono = reader.IsDBNull(3) ? null : reader.GetString(3),
                Correo = reader.IsDBNull(4) ? null : reader.GetString(4),
                FechaRegistro = reader.GetDateTime(5),
                Activo = reader.GetBoolean(6),
                RowVersion = (byte[])reader[7]
            });
        }

        return lista;
    }

    // 2. INSERTAR NUEVO CLIENTE (CREATE)
    public async Task<int> InsertarAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            INSERT INTO Clientes (Nombre, Apellido, Telefono, Correo)
            VALUES (@Nombre, @Apellido, @Telefono, @Correo);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        await using var cn = new SqlConnection(ConexionBD.CadenaConexion);
        await using var cmd = new SqlCommand(sql, cn);

        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 60).Value = cliente.Nombre;
        cmd.Parameters.Add("@Apellido", System.Data.SqlDbType.NVarChar, 60).Value = cliente.Apellido;
        cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar, 20).Value = (object?)cliente.Telefono ?? DBNull.Value;
        cmd.Parameters.Add("@Correo", System.Data.SqlDbType.NVarChar, 120).Value = (object?)cliente.Correo ?? DBNull.Value;

        await cn.OpenAsync(cancellationToken);
        return Convert.ToInt32(await cmd.ExecuteScalarAsync(cancellationToken));
    }

    // 3. ACTUALIZAR CLIENTE CON VALIDACIÓN DE ROWVERSION (UPDATE)
    public async Task<bool> ActualizarAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            UPDATE Clientes
            SET Nombre = @Nombre,
                Apellido = @Apellido,
                Telefono = @Telefono,
                Correo = @Correo
            WHERE IdCliente = @IdCliente
              AND RowVersion = @RowVersion;";

        await using var cn = new SqlConnection(ConexionBD.CadenaConexion);
        await using var cmd = new SqlCommand(sql, cn);

        cmd.Parameters.Add("@IdCliente", System.Data.SqlDbType.Int).Value = cliente.IdCliente;
        cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 60).Value = cliente.Nombre;
        cmd.Parameters.Add("@Apellido", System.Data.SqlDbType.NVarChar, 60).Value = cliente.Apellido;
        cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar, 20).Value = (object?)cliente.Telefono ?? DBNull.Value;
        cmd.Parameters.Add("@Correo", System.Data.SqlDbType.NVarChar, 120).Value = (object?)cliente.Correo ?? DBNull.Value;
        cmd.Parameters.Add("@RowVersion", System.Data.SqlDbType.Binary, 8).Value = cliente.RowVersion!;

        await cn.OpenAsync(cancellationToken);
        int filas = await cmd.ExecuteNonQueryAsync(cancellationToken);
        return filas == 1;
    }

    // 4. ELIMINACIÓN LÓGICA (DELETE)
    public async Task<bool> EliminarAsync(int idCliente, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            UPDATE Clientes
            SET Activo = 0
            WHERE IdCliente = @IdCliente;";

        await using var cn = new SqlConnection(ConexionBD.CadenaConexion);
        await using var cmd = new SqlCommand(sql, cn);

        cmd.Parameters.Add("@IdCliente", System.Data.SqlDbType.Int).Value = idCliente;

        await cn.OpenAsync(cancellationToken);
        return await cmd.ExecuteNonQueryAsync(cancellationToken) == 1;
    }
}