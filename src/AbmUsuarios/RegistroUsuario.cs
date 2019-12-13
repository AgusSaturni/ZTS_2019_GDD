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
using FrbaOfertas.Manejo_Logico;

namespace FrbaOfertas
{
    public partial class RegistroUsuario : Form
    {
        conexionBD conexion = conexionBD.getConexion();
        private CommonQueries common_queries_instance = CommonQueries.getInstance();
        SqlConnection conexion_sql;
        object rol = "";
        Form formulario_anterior;
        private int bit_Accion;

        public RegistroUsuario()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public RegistroUsuario(object rol_recibido, Form formulario_ant, int bit) //Se utiliza para difierenciar cuando se viene de ABM cliente, ABM proveedor, o Login
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            rol = rol_recibido;
            formulario_anterior = formulario_ant;
            this.bit_Accion = bit;
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
            conexion_sql = new SqlConnection(conexion.get_cadena());
            
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
            if (this.verificar_estado_rol()) { return; }

            SqlCommand verificacion_usuario = new SqlCommand("ZTS_DB.verificar_existencia_de_usuario", conexion_sql);
            verificacion_usuario.CommandType = CommandType.StoredProcedure;

            verificacion_usuario.Parameters.AddWithValue("@username", SqlDbType.Char).Value = Usuario.Text;
            conexion_sql.Open();
            try
            {

                verificacion_usuario.ExecuteNonQuery();

                switch (ComboBox_Rol.SelectedItem.ToString())
                {
                    case "Cliente":
                        Form registroCliente = new AbmCliente.AltaCliente(Usuario.Text, Password.Text, ComboBox_Rol.SelectedItem.ToString(), this,bit_Accion);
                        this.Hide();
                        registroCliente.Show();
                        break;
                    case "Proveedor":
                        Form registroProveedor = new AbmProveedor.AltaProveedor(Usuario.Text, Password.Text, ComboBox_Rol.SelectedItem.ToString(), this,bit_Accion);
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

        private bool verificar_estado_rol()
        {
            conexion_sql.Open();
            try
            {
                common_queries_instance.vereificar_estado_rol(ComboBox_Rol.SelectedItem.ToString(), conexion_sql);
                conexion_sql.Close();
                return false;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion_sql.Close();
                return true;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}