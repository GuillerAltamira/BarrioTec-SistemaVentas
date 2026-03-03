using System.Data.SqlClient;

namespace BarrioTecApp.Data
{
    public class Conexion
    {
        private static SqlConnection _conexion;
        private static string _cadena = 
            "Server=(localdb)\\MSSQLLocalDB;Database=TiendaDb;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            if (_conexion == null)
            {
                _conexion = new SqlConnection(_cadena);
            }

            return _conexion;
        }
    }
}
