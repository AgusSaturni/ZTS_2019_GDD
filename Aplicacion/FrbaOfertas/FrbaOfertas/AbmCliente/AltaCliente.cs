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
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            SqlCommand verificacion_cliente = new SqlCommand("verificar_existencia_cliente_gemelo", conexion_sql);
            verificacion_cliente.CommandType = CommandType.StoredProcedure;


            string nombre;
            string apellido;
            string DNI;
            string telefono;
            object fechaDeNacimiento;
            string mail;


            nombre = Nombre.Text;
            apellido = Apellido.Text;
            DNI = Dni.Text;
            telefono = Telefono.Text;
            fechaDeNacimiento = FechaNacimiento.Value;
            mail = Mail.Text;

            verificacion_cliente.Parameters.AddWithValue("@nombre", SqlDbType.Char).Value = Nombre.Text;
            verificacion_cliente.Parameters.AddWithValue("@apellido", SqlDbType.Char).Value = Apellido.Text;
            verificacion_cliente.Parameters.AddWithValue("@DNI", SqlDbType.Float).Value = Dni.Text;
            verificacion_cliente.Parameters.AddWithValue("@telefono", SqlDbType.Float).Value = Telefono.Text;
            verificacion_cliente.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = Mail.Text;
            verificacion_cliente.Parameters.AddWithValue("@fecha_nacimiento", SqlDbType.Date).Value = FechaNacimiento.Value;

            if (nombre != "" && apellido != "" && DNI != "" && telefono != "" && mail != "")
            {
               try
                {
                    conexion_sql.Open();
                    verificacion_cliente.ExecuteNonQuery();
                    this.Visible = false;
                    CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(username, password, rol, nombre, apellido, DNI, telefono, fechaDeNacimiento, mail, null, null, null, null);
                    direccion.Show();
                    conexion_sql.Close();

              }
                catch {
                    MessageBox.Show("El cliente que intenta crear, ya esta registrado en el sistema");
                }
            }
            else {
                MessageBox.Show("Faltan completar campos");
            }
            
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
            Form registro = new RegistroUsuario();
            registro.Show();
        }
    }
}