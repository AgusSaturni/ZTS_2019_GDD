using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class MenuCliente : Form
    {
        public MenuCliente()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form inicio_sesion = new InicioDeSesion();
            inicio_sesion.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form cargaCredito = new FrbaOfertas.CragaCredito.CargaDeCredito();
            cargaCredito.Show();
        }
    }
}
