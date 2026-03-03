using System.Data.SqlClient;
using BarrioTecApp.Models;
using BarrioTecApp.Data;

namespace BarrioTecApp.Controllers
{
    public class ClienteController
    {
        public void Insertar(Cliente cliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "INSERT INTO Clientes (Nombre, NIT) VALUES (@Nombre, @NIT)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@NIT", cliente.NIT);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
