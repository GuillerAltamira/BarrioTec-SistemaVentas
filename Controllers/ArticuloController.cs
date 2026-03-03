using System.Collections.Generic;
using System.Data.SqlClient;
using BarrioTecApp.Models;
using BarrioTecApp.Data;

namespace BarrioTecApp.Controllers
{
    public class ArticuloController
    {
        public void Insertar(Articulo articulo)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "INSERT INTO Articulos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                cmd.Parameters.AddWithValue("@Precio", articulo.Precio);
                cmd.Parameters.AddWithValue("@Stock", articulo.Stock);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Articulo> ObtenerTodos()
        {
            List<Articulo> lista = new List<Articulo>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT * FROM Articulos";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Articulo
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString() ?? "",
                        Precio = (decimal)reader["Precio"],
                        Stock = (int)reader["Stock"]
                    });
                }

                conn.Close();
            }

            return lista;
        }
    }
}
