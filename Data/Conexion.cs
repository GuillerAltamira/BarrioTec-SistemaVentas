using System.Data.SqlClient;

namespace BarrioTecApp.Data
{
    public class Conexion
    {
        private static string connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=TiendaDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
