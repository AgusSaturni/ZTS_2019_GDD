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
using System.Security.Cryptography;

namespace FrbaOfertas
{
    public partial class RegistroUsuario : Form
    {
        
        object rol = "";

        public RegistroUsuario()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public RegistroUsuario(object rol_recibido) //Se utiliza para difierenciar cuando se viene de ABM cliente, ABM proveedor, o Login
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            rol = rol_recibido;
        }

        private  void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            if (rol.ToString() == "Proveedor")
            {
                ComboBox_Rol.SelectedIndex = 1;
                ComboBox_Rol.Enabled = false;
            }
            if (rol.ToString() == "Cliente")
            {
                ComboBox_Rol.SelectedIndex = 0;
                ComboBox_Rol.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            SqlCommand verificacion_usuario = new SqlCommand("verificar_existencia_de_usuario", conexion_sql);
            verificacion_usuario.CommandType = CommandType.StoredProcedure;

            verificacion_usuario.Parameters.AddWithValue("@username", SqlDbType.Char).Value = Usuario.Text;

            int indice =  ComboBox_Rol.SelectedIndex;
            string usuario;
            string password;
            
            usuario = Usuario.Text;        
            password = Password.Text;


            try
            {
                conexion_sql.Open();
                verificacion_usuario.ExecuteNonQuery();

                if (indice != -1 && usuario != "" && password != "")
                {
                    switch (ComboBox_Rol.SelectedItem.ToString())
                    {
                        case "Cliente":
                            Form registroCliente = new AbmCliente.AltaCliente(usuario, password, ComboBox_Rol.SelectedItem.ToString());
                            this.Hide();
                            registroCliente.Show();
                            break;
                        case "Proveedor":
                            Form registroProveedor = new AbmProveedor.AltaProveedor(usuario, password, ComboBox_Rol.SelectedItem.ToString());
                            this.Hide();
                            registroProveedor.Show();
                            break;
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Faltan completar campos");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Nombre de Usuario ya existente.");
            }

            
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            switch (rol.ToString())
            {
                case "Cliente":
                    Form menu_cliente = new MenuAdmin.ABMClientes();
                    menu_cliente.Show();
                    this.Hide();
                    break;
                case "Proveedor":
                    Form menu_proveedor = new MenuAdmin.ABMProveedores();
                    menu_proveedor.Show();
                    this.Hide();
                    break;
                default:
                    Form inicio_sesion = new InicioDeSesion();
                    inicio_sesion.Show();
                    this.Hide();
                    break;
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
   
    }
}
