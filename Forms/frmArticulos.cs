using System;
using System.Windows.Forms;
using BarrioTecApp.Models;
using BarrioTecApp.Controllers;

namespace BarrioTecApp.Forms
{
    public class frmArticulos : Form
    {
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private Button btnGuardar;
        private DataGridView dgvArticulos;

        public frmArticulos()
        {
            InicializarComponentes();
            CargarArticulos();
        }

        private void InicializarComponentes()
        {
            this.Text = "Gestión de Artículos";
            this.Width = 450;
            this.Height = 450;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Top = 20;
            lblNombre.Left = 20;

            txtNombre = new TextBox();
            txtNombre.Top = 40;
            txtNombre.Left = 20;
            txtNombre.Width = 350;

            Label lblPrecio = new Label();
            lblPrecio.Text = "Precio:";
            lblPrecio.Top = 80;
            lblPrecio.Left = 20;

            txtPrecio = new TextBox();
            txtPrecio.Top = 100;
            txtPrecio.Left = 20;
            txtPrecio.Width = 150;

            Label lblStock = new Label();
            lblStock.Text = "Stock:";
            lblStock.Top = 140;
            lblStock.Left = 20;

            txtStock = new TextBox();
            txtStock.Top = 160;
            txtStock.Left = 20;
            txtStock.Width = 150;

            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Top = 200;
            btnGuardar.Left = 20;
            btnGuardar.Click += BtnGuardar_Click;

            dgvArticulos = new DataGridView();
            dgvArticulos.Top = 240;
            dgvArticulos.Left = 20;
            dgvArticulos.Width = 380;
            dgvArticulos.Height = 150;

            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(txtPrecio);
            this.Controls.Add(lblStock);
            this.Controls.Add(txtStock);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(dgvArticulos);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = new Articulo
                {
                    Nombre = txtNombre.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                ArticuloController controller = new ArticuloController();
                controller.Insertar(articulo);

                MessageBox.Show("Artículo guardado correctamente");

                txtNombre.Clear();
                txtPrecio.Clear();
                txtStock.Clear();

                CargarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarArticulos()
        {
            ArticuloController controller = new ArticuloController();
            dgvArticulos.DataSource = controller.ObtenerTodos();
        }
    }
}
