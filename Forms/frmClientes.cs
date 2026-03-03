using System;
using System.Windows.Forms;
using BarrioTecApp.Models;
using BarrioTecApp.Controllers;

namespace BarrioTecApp.Forms
{
    public class frmClientes : Form
    {
        private TextBox txtNombre;
        private TextBox txtNIT;
        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView dgvClientes;

        public frmClientes()
        {
            InicializarComponentes();
            CargarClientes();
        }
        private void CargarClientes()
        {
           ClienteController controller = new ClienteController();
           dgvClientes.DataSource = controller.ObtenerTodos();
        }

        private void InicializarComponentes()
        {
            this.Text = "Gestión de Clientes";
            this.Width = 400;
            this.Height = 400;

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Top = 20;
            lblNombre.Left = 20;

            txtNombre = new TextBox();
            txtNombre.Top = 40;
            txtNombre.Left = 20;
            txtNombre.Width = 300;

            Label lblNIT = new Label();
            lblNIT.Text = "NIT:";
            lblNIT.Top = 80;
            lblNIT.Left = 20;

            txtNIT = new TextBox();
            txtNIT.Top = 100;
            txtNIT.Left = 20;
            txtNIT.Width = 300;

            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Top = 150;
            btnGuardar.Left = 20;
            btnGuardar.Click += BtnGuardar_Click;

            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblNIT);
            this.Controls.Add(txtNIT);
            this.Controls.Add(btnGuardar);

            btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.Top = 150;
            btnEliminar.Left = 120;
            btnEliminar.Click += BtnEliminar_Click;

            this.Controls.Add(btnEliminar);

            dgvClientes = new DataGridView();
            dgvClientes.Top = 190;
            dgvClientes.Left = 20;
            dgvClientes.Width = 340;
            dgvClientes.Height = 150;

            this.Controls.Add(dgvClientes);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
          try
          {
           Cliente cliente = new Cliente
           {
            Nombre = txtNombre.Text,
            NIT = txtNIT.Text
           };

           ClienteController controller = new ClienteController();
           controller.Insertar(cliente);

           MessageBox.Show("Cliente guardado correctamente");

           txtNombre.Clear();
           txtNIT.Clear();
           CargarClientes();
           }
            catch (Exception ex)
           {
            MessageBox.Show("Error: " + ex.Message);
           }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
          {
             int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;

               ClienteController controller = new ClienteController();
               controller.Eliminar(id);

               MessageBox.Show("Cliente eliminado correctamente");

              CargarClientes();
          }
        }
    }
}
