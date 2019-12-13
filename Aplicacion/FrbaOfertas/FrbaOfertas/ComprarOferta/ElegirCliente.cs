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
        private List<String> lista_clientes = new List<String>();

        public ElegirCliente()
        {
            InitializeComponent();
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
            actualizar_lista_clientes();

            for (int i = 0; i < lista_clientes.Count(); i++)
            {
                cmb_clientes.Items.Add(lista_clientes.ElementAt(i).ToString());
            }
        }

        private void actualizar_lista_clientes()
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open(); 
            
            string consulta_clientes = "SELECT DISTINCT username FROM zts_db.CLIENTES";

            SqlCommand cmd = new SqlCommand(consulta_clientes, conexion_sql);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[0].ToString() != "")
                {
                    lista_clientes.Add(reader[0].ToString().Trim());

                }
            }
            conexion_sql.Close();
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
