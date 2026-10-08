namespace CRUDClientesSQLServer.Models;

public class Cliente
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public DateTime FechaRegistro { get; set; }
    public bool Activo { get; set; }
    public byte[]? RowVersion { get; set; }
}