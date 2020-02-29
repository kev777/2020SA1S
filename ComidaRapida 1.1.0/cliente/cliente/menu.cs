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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            WcfESB.Service1Client esb = new WcfESB.Service1Client(); //se manda a llamar al ESB encargado de la orquestación de los servicios

            //Form1 form = new Form1();

            string respuesta = string.Empty;
            respuesta = esb.Asigna_Pedido_Repartidor(20, comboBox1.SelectedItem.ToString()); //asigna un pedido mediante al llamado al ESB.
            if (!respuesta.Equals(string.Empty)) //si recibe como respuesta un valor en la cadena, es porque se ingresó el pedido y recibe el´nombre del repartidor.
            {
                lblRepartidor.Text = "";
                lblRepartidor.Text = respuesta;
                MessageBox.Show(" Orden creada - Nombre de repartidor: " + respuesta);
            }
            else
                MessageBox.Show(" Orden falló - Error en el sistema... ");



        }
    }
}
