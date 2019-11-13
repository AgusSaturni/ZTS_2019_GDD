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
    public partial class ABMProveedores : Form
    {
        public ABMProveedores()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form baja_modificacion = new AbmProveedor.listado_proveedores();
            baja_modificacion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new RegistroUsuario("Proveedor");
            alta.Show();
        }
    }
}
