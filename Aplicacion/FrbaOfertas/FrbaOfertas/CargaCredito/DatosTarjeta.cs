using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CargaCredito
{
    public partial class DatosTarjeta : Form
    {
        private int monto_entero;
        private object TipoDePago;

        public DatosTarjeta()
        {
            InitializeComponent();
        }

        public DatosTarjeta(int monto_entero, object TipoDePago)
        {
            InitializeComponent();
            this.monto_entero = monto_entero;
            this.TipoDePago = TipoDePago;
        }
    }
}
