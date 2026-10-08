namespace CRUDClientesSQLServer.Data;

public static class ConexionBD
{
    public static string CadenaConexion =>
        "Server=localhost\\SQL2026;Database=CRUDClientesDB;Trusted_Connection=True;TrustServerCertificate=True;";
}