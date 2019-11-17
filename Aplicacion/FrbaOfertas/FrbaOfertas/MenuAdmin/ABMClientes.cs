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
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new Interfaces.menu_principal();
            menu.Show();
        }
    }
}
