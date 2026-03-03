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

        public frmClientes()
        {
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.Text = "Gestión de Clientes";
            this.Width = 400;
            this.Height = 250;

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
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
}
    }
}
