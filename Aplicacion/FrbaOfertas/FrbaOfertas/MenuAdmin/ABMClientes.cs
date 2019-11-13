using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.MenuAdmin
{
   
    public partial class ABMClientes : Form
    {
        public ABMClientes()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form bajas_modificiaciones = new AbmCliente.frm_listado_clientes();
            bajas_modificiaciones.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new RegistroUsuario("Cliente");
            alta.Show();
        }
    }
}
