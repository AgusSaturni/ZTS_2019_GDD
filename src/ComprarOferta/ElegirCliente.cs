using FrbaOfertas.Manejo_Logico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ElegirCliente : Form
    {
        private CommonQueries commonQueries_instance = CommonQueries.getInstance();
        private List<String> lista_clientes = new List<String>();

        public ElegirCliente()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            cargar_cmb_clientes();
        }

        //---------------------------CARGAR COMBOBOX CLIENTES-----------------------------

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (cmb_clientes.Text == "")
            {
                MessageBox.Show("Debe elegir un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form oferta = new ComprarOferta.Ofertas(cmb_clientes.Text);
                oferta.Show();
                this.Hide();
            }
        }

        private void cargar_cmb_clientes()
        {
            commonQueries_instance.cargar_objeto(this.cmb_clientes, "CLIENTES");
        }

        //---------------------------AUXILIARES--------------------------------

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
            this.Close();
        }
    }
}
