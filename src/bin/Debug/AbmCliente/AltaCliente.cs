using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private int bit_accion;
        private Form formulario_anterior;
        private DateTime Fecha_Config = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        SqlConnection conexion_sql;
        conexionBD conexion = conexionBD.getConexion();

        public AltaCliente()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public AltaCliente(string username, string password, string rol, Form formulario, int bit)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.rol = rol;
            this.formulario_anterior = formulario;
            this.bit_accion = bit;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.verificar_parametros())
            {
                MessageBox.Show("Todos los Campos son Obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.verificar_tipo_datos()) { return; }
            else
            {
                conexion_sql.Open();
                SqlCommand verificacion_cliente = new SqlCommand("ZTS_DB.verificar_existencia_cliente_gemelo", conexion_sql);
                verificacion_cliente.CommandType = CommandType.StoredProcedure;

                SqlCommand verificacion_fecha = new SqlCommand("ZTS_DB.verificar_fecha_nacimiento", conexion_sql);
                verificacion_fecha.CommandType = CommandType.StoredProcedure;


                string fecha = ConfigurationManager.AppSettings["fecha"].ToString();

                verificacion_cliente.Parameters.AddWithValue("@nombre", SqlDbType.Char).Value = Nombre.Text;
                verificacion_cliente.Parameters.AddWithValue("@apellido", SqlDbType.Char).Value = Apellido.Text;
                verificacion_cliente.Parameters.AddWithValue("@DNI", SqlDbType.Float).Value = Dni.Text;
                verificacion_cliente.Parameters.AddWithValue("@telefono", SqlDbType.Float).Value = Telefono.Text;
                verificacion_cliente.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = Mail.Text;
                verificacion_cliente.Parameters.AddWithValue("@fecha_nacimiento", SqlDbType.Date).Value = FechaNacimiento.Value;

                verificacion_fecha.Parameters.AddWithValue("@fechaNacimiento", SqlDbType.Char).Value = FechaNacimiento.Value.ToString();
                verificacion_fecha.Parameters.AddWithValue("@FechaActual", SqlDbType.Char).Value = fecha;
                try
                {

                    verificacion_cliente.ExecuteNonQuery();
                    verificacion_cliente.ExecuteNonQuery();

                    this.determinar_accion();
                }
                catch (SqlException excepcion1)
                {
                    SqlError errores = excepcion1.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                    return;
                }

                conexion_sql.Close();
            }

        }

        private void determinar_accion() 
        {
            this.Hide();
            if (bit_accion == 0)  //mando un 0 devuelta, significa que vengo de registro de usuario
            {
                Form direccion = new CargaDireccion.CargarDireccion(username, password, rol, Nombre.Text, Apellido.Text, Dni.Text, Telefono.Text, FechaNacimiento.Value, Mail.Text, null, null, null, null, this, 0);
                direccion.Show();
            }
            else 
            {                   //MANDO UN 1, significa que vengo de alta de cliente
                Form direccion = new CargaDireccion.CargarDireccion(username, password, rol, Nombre.Text, Apellido.Text, Dni.Text, Telefono.Text, FechaNacimiento.Value, Mail.Text, null, null, null, null, this, 1);
                direccion.Show();
            }

        }

        private bool verificar_tipo_datos()
        {
            if (Nombre.Text.Any(x => char.IsNumber(x)) || Apellido.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Nombre y/o Apellido Invalido. No se permite ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Dni.Text.Any(x => !char.IsNumber(x)) || Dni.Text.Length != 8)
            {
                MessageBox.Show("DNI Invalido. Cadena Numerica de 8 caracteres unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Telefono.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("Telefono Invalido. Cadena Numerica unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (FechaNacimiento.Value >= Fecha_Config)
            {
                MessageBox.Show("Fecha de nacimiento invalida, debe ser menor a la fecha actual. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;

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
            this.Close();
            formulario_anterior.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}