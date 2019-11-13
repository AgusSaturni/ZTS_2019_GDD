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
        private string usuario;
        private string password;
        private string rol;

      

        public AltaCliente()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public AltaCliente(string usuario, string password, string rol)
        {
            InitializeComponent();
            this.usuario = usuario;
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

      
            if (nombre != "" && apellido != "" && DNI != "" && telefono != "" && mail != "")
            {
                this.Visible = false;
                CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(usuario, password, rol, nombre, apellido, DNI, telefono, fechaDeNacimiento, mail,null, null, null, null);
                direccion.Show();
            }
            else {
                MessageBox.Show("Faltan completar campos");
            }

            /*
            string cadenaConex = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
            SqlConnection conn = new SqlConnection(cadenaConex);

            SqlCommand command = new SqlCommand("registrar_usuario_cliente", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter nombre = new SqlParameter("@Nombre", SqlDbType.Char);
            nombre.Direction = ParameterDirection.Input;
            command.Parameters.Add(nombre);


            SqlParameter apellido = new SqlParameter("@Apellido", SqlDbType.Char);
            apellido.Direction = ParameterDirection.Input;
            command.Parameters.Add(apellido);

            SqlParameter DNI = new SqlParameter("@DNI", SqlDbType.Float);
            DNI.Direction = ParameterDirection.Input;
            command.Parameters.Add(DNI);

            SqlParameter telefono = new SqlParameter("@Telefono", SqlDbType.Float);
            telefono.Direction = ParameterDirection.Input;
            command.Parameters.Add(telefono);

            SqlParameter fechaNacimiento = new SqlParameter("@Fecha_nacimiento", SqlDbType.Date);
            fechaNacimiento.Direction = ParameterDirection.Input;
            command.Parameters.Add(fechaNacimiento);

            SqlParameter mail = new SqlParameter("@Mail", SqlDbType.Char);
            mail.Direction = ParameterDirection.Input;
            command.Parameters.Add(mail);

          

            nombre.Value = Nombre.Text;
            apellido.Value = Apellido.Text;
            DNI.Value = Dni.Text;
            telefono.Value = Telefono.Text;
            fechaNacimiento.Value = FechaNacimiento.Value;

     */    

     
           
            
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