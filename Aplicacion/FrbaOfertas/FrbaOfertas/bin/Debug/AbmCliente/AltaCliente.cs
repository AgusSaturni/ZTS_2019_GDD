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

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : Form
    {
        private string username;
        private string password;
        private string rol;
        SqlConnection conexion_sql;
        conexionBD conexion = conexionBD.getConexion();

        public AltaCliente()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public AltaCliente(string username, string password, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;   
            this.rol = rol;
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand verificacion_cliente = new SqlCommand("verificar_existencia_cliente_gemelo", conexion_sql);
            verificacion_cliente.CommandType = CommandType.StoredProcedure;

            verificacion_cliente.Parameters.AddWithValue("@nombre", SqlDbType.Char).Value = Nombre.Text;
            verificacion_cliente.Parameters.AddWithValue("@apellido", SqlDbType.Char).Value = Apellido.Text;
            verificacion_cliente.Parameters.AddWithValue("@DNI", SqlDbType.Float).Value = Dni.Text;
            verificacion_cliente.Parameters.AddWithValue("@telefono", SqlDbType.Float).Value = Telefono.Text;
            verificacion_cliente.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = Mail.Text;
            verificacion_cliente.Parameters.AddWithValue("@fecha_nacimiento", SqlDbType.Date).Value = FechaNacimiento.Value;

            if (Nombre.Text.Any(x => char.IsNumber(x)) || Apellido.Text.Any(x => char.IsNumber(x)) || Dni.Text.Any(x => !char.IsNumber(x)) || Telefono.Text.Any(x => !char.IsNumber(x)) || Dni.Text.Length != 8)
            {
                MessageBox.Show("Datos erroneos.");
                return;
            }


            if (this.verificar_parametros())
            {
                MessageBox.Show("Todos los Campos son Obligatorios");
            }
            else 
            {
                try
                {
                    conexion_sql.Open();
                    verificacion_cliente.ExecuteNonQuery();
                    this.Visible = false;
                    CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(username, password, rol, Nombre.Text, Apellido.Text, Dni.Text, Telefono.Text, FechaNacimiento.Value, Mail.Text, null, null, null, null);
                    direccion.Show();
                    conexion_sql.Close();

                }
                catch
                {
                    MessageBox.Show("El cliente que intenta crear, ya esta registrado en el sistema");
                }
            }
            
        }

        private bool verificar_parametros()
        {
            List<String> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).Select(p => p.Text).ToList();

            if (lista_textBoxs.Any(cadena => cadena == String.Empty))
            {
                return true;
            }

            return false;
        }


        private void Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void FechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Dni_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form alta = new RegistroUsuario("Cliente");
            alta.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}