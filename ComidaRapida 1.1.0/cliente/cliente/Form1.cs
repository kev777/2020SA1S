using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            WcfESB.Service1Client cliente = new WcfESB.Service1Client();
            menu men = new menu();

            int respuesta=cliente.Acceso(txtUsuario.Text, txtPass.Text);
            if (respuesta == 1)
            {
                MessageBox.Show("Acceso permitido, ¡BIENVENIDO!");
                men.Show();
                this.Visible = false;
            }
            else
                MessageBox.Show("Acceso denegado");

        }
    }
}
