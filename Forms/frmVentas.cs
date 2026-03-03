using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BarrioTecApp.Data;
using BarrioTecApp.Controllers;
using BarrioTecApp.Models;

namespace BarrioTecApp.Forms
{
    public class frmVentas : Form
    {
        ComboBox cmbClientes = new ComboBox();
        ComboBox cmbArticulos = new ComboBox();
        TextBox txtCantidad = new TextBox();
        Button btnGuardar = new Button();
        DataGridView dgvVentas = new DataGridView();

        VentaController controller = new VentaController();

        public frmVentas()
        {
            this.Text = "Módulo Ventas";
            this.Width = 900;
            this.Height = 600;

            // Posiciones
            cmbClientes.Top = 20;
            cmbClientes.Left = 20;
            cmbClientes.Width = 200;

            cmbArticulos.Top = 60;
            cmbArticulos.Left = 20;
            cmbArticulos.Width = 200;

            txtCantidad.Top = 100;
            txtCantidad.Left = 20;
            txtCantidad.Width = 200;

            btnGuardar.Top = 140;
            btnGuardar.Left = 20;
            btnGuardar.Width = 200;
            btnGuardar.Text = "Guardar Venta";
            btnGuardar.Click += btnGuardar_Click;

            dgvVentas.Top = 200;
            dgvVentas.Left = 20;
            dgvVentas.Width = 840;
            dgvVentas.Height = 330;

            this.Controls.Add(cmbClientes);
            this.Controls.Add(cmbArticulos);
            this.Controls.Add(txtCantidad);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(dgvVentas);

            try
            {
                CargarClientes();
                CargarArticulos();
                CargarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void CargarClientes()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nombre FROM Clientes", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbClientes.DataSource = dt;
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "Id";
            }
        }

        private void CargarArticulos()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Nombre, Precio FROM Articulos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbArticulos.DataSource = dt;
                cmbArticulos.DisplayMember = "Nombre";
                cmbArticulos.ValueMember = "Id";
            }
        }

        private void CargarVentas()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = @"SELECT V.Id,
                                C.Nombre AS Cliente,
                                A.Nombre AS Articulo,
                                V.Cantidad,
                                V.Total,
                                V.Fecha
                         FROM Ventas V
                         INNER JOIN Clientes C ON V.ClienteId = C.Id
                         INNER JOIN Articulos A ON V.ArticuloId = A.Id";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVentas.DataSource = dt;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
{
    try
    {
        int articuloId = Convert.ToInt32(cmbArticulos.SelectedValue);
        int clienteId = Convert.ToInt32(cmbClientes.SelectedValue);
        int cantidad = Convert.ToInt32(txtCantidad.Text);

        decimal precio = 0;

        using (SqlConnection conn = Conexion.ObtenerConexion())
        {
            string query = "SELECT Precio FROM Articulos WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", articuloId);

            conn.Open();
            precio = (decimal)cmd.ExecuteScalar();
        }

        Venta venta = new Venta
        {
            ClienteId = clienteId,
            ArticuloId = articuloId,
            Cantidad = cantidad,
            Total = precio * cantidad
        };

        controller.Guardar(venta);

        MessageBox.Show("Venta registrada correctamente");

        CargarVentas();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al guardar venta: " + ex.Message);
    }
}
    }
}

