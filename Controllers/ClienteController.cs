using System.Collections.Generic;
using System.Data.SqlClient;
using BarrioTecApp.Models;
using BarrioTecApp.Data;

namespace BarrioTecApp.Controllers
{
    public class ClienteController
    {
        // INSERTAR CLIENTE
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

        // OBTENER TODOS LOS CLIENTES
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT * FROM Clientes";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString() ?? "",
                        NIT = reader["NIT"].ToString() ?? ""
                    });
                }

                conn.Close();
            }

            return lista;
        }

        // ELIMINAR CLIENTE
        public void Eliminar(int id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "DELETE FROM Clientes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}