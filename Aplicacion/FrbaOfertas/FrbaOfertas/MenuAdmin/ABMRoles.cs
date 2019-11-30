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
    public partial class ABMRoles : Form
    {
        public ABMRoles()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
        }

        private void bt_modificar_rol_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form modificaciones = new AbmRol.Modificacion_Roles();
            modificaciones.Show();
        }

        private void bt_alta_rol_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form alta_rol = new AbmRol.alta_rol();
            alta_rol.Show();
        }
    }
}
