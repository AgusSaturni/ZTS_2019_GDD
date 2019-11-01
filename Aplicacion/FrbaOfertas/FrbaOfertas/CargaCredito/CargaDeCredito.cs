using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CragaCredito
{
    public partial class CargaDeCredito : Form
    {
        public CargaDeCredito()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form menuCliente = new AbmCliente.MenuCliente();
            menuCliente.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string monto = Monto.Text;
                int indice =TipoPago.SelectedIndex;;
                if (indice != -1 && monto != "")
                {
                    object TipoDePago = TipoPago.Items[indice];
                    int monto_entero = Int32.Parse(monto);
                    this.Visible = false;
                    Form datosTarjeta = new FrbaOfertas.CargaCredito.DatosTarjeta(monto_entero,TipoDePago);
                    datosTarjeta.Show();
                }
                else {
                    MessageBox.Show("Faltan completar campos.");
                }

            }
            catch {
                MessageBox.Show("El monto debe ser un numero entero");
            }
        }
    }
}
