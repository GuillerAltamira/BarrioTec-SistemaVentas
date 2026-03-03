using System.Collections.Generic;
using System.Data.SqlClient;
using BarrioTecApp.Data;
using BarrioTecApp.Models;

namespace BarrioTecApp.Controllers
{
    public class VentaController
    {
        public void Guardar(Venta venta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Ventas (ClienteId, ArticuloId, Cantidad, Total) VALUES (@ClienteId, @ArticuloId, @Cantidad, @Total)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ClienteId", venta.ClienteId);
                cmd.Parameters.AddWithValue("@ArticuloId", venta.ArticuloId);
                cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                cmd.Parameters.AddWithValue("@Total", venta.Total);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
