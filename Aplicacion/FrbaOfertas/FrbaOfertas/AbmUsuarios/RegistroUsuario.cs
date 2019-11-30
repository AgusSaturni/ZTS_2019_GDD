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
        Form formulario_anterior;

        public RegistroUsuario()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public RegistroUsuario(object rol_recibido, Form formulario_ant) //Se utiliza para difierenciar cuando se viene de ABM cliente, ABM proveedor, o Login
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            rol = rol_recibido;
            formulario_anterior = formulario_ant;
        }

        private void label1_Click(object sender, EventArgs e)
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
            //Esto es para que cuando viene de una ABM no te deje registrar otro usuario que no sea de esa ABM
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
            int indice = ComboBox_Rol.SelectedIndex;
            if (indice == -1 || Usuario.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            SqlCommand verificacion_usuario = new SqlCommand("verificar_existencia_de_usuario", conexion_sql);
            verificacion_usuario.CommandType = CommandType.StoredProcedure;

            verificacion_usuario.Parameters.AddWithValue("@username", SqlDbType.Char).Value = Usuario.Text;
            conexion_sql.Open();
            try
            {

                verificacion_usuario.ExecuteNonQuery();

                switch (ComboBox_Rol.SelectedItem.ToString())
                {
                    case "Cliente":
                        Form registroCliente = new AbmCliente.AltaCliente(Usuario.Text, Password.Text, ComboBox_Rol.SelectedItem.ToString(), this);
                        this.Hide();
                        registroCliente.Show();
                        break;
                    case "Proveedor":
                        Form registroProveedor = new AbmProveedor.AltaProveedor(Usuario.Text, Password.Text, ComboBox_Rol.SelectedItem.ToString(), this);
                        this.Hide();
                        registroProveedor.Show();
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nombre de Usuario ya existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion_sql.Close();

        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            formulario_anterior.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}