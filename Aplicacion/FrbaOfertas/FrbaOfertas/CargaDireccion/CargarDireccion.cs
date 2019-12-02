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
using FrbaOfertas.Manejo_Logico;

namespace FrbaOfertas.CargaDireccion
{
    public partial class CargarDireccion : Form
    {
        private string usuario;
        private string password;
        private string rol;
        private string nombre;
        private string apellido;
        private string DNI;
        private string telefono;
        private object fechaDeNacimiento;
        private string mail;
        private string razonSocial;
        private string rubro;
        private string cuit;
        private string contacto;
        private Form formulario_anterior;

        public CargarDireccion()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public CargarDireccion(string usuario, string password, string rol, string nombre, string apellido, string DNI, string telefono, object fechaDeNacimiento, string mail, string rs, string cuit, string rubro, string contacto, Form form_ant)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.password = password;
            this.rol = rol;
            this.nombre = nombre;
            this.apellido = apellido;
            this.DNI = DNI;
            this.telefono = telefono;
            this.fechaDeNacimiento = fechaDeNacimiento;
            this.mail = mail;
            this.razonSocial = rs;
            this.cuit = cuit;
            this.rubro = rubro;
            this.contacto = contacto;
            formulario_anterior = form_ant;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            conn.Open();

            switch (rol)
            {
                case "Cliente":

                    if (verificar_parametros())
                    {
                        MessageBox.Show("Faltan completar campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (CodigoPostal.Text.Any(x => !char.IsNumber(x)))
                    {
                     MessageBox.Show("Codigo Postal Erroneo. No se permite ingresar Letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                    }

                    if (CodigoPostal.Text.Length != 4)
                    {
                        MessageBox.Show("Codigo Postal Erroneo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Localidad.Text.Any(x => char.IsNumber(x)))
                    {
                        MessageBox.Show("Localidad Erronea. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (Ciudad.Text.Any(x => char.IsNumber(x)))
                    {
                        MessageBox.Show("Ciudad Erronea. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if ( NroPiso.Text.Any(x => !char.IsNumber(x)))
                    {
                        MessageBox.Show("Número de piso erroneo. No se permiten ingresar Letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                   

                    //----------------------DATOS PARA REGISTRO----------------------------
                    SqlCommand command = new SqlCommand("registrar_usuario_cliente", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = usuario;
                    command.Parameters.AddWithValue("@Password", SqlDbType.Char).Value = password;
                    command.Parameters.AddWithValue("@Rol", SqlDbType.Char).Value = rol;
                    command.Parameters.AddWithValue("@nombre", SqlDbType.Char).Value = nombre;
                    command.Parameters.AddWithValue("@apellido", SqlDbType.Char).Value = apellido;
                    command.Parameters.AddWithValue("@DNI", SqlDbType.Float).Value = DNI;
                    command.Parameters.AddWithValue("@Telefono", SqlDbType.Float).Value = Int64.Parse(telefono);
                    command.Parameters.AddWithValue("@Mail", SqlDbType.Char).Value = mail;
                    command.Parameters.AddWithValue("@Fecha_nacimiento", SqlDbType.Date).Value = fechaDeNacimiento;
                    command.Parameters.AddWithValue("@Direccion", SqlDbType.Char).Value = Direccion.Text;
                    command.Parameters.AddWithValue("@codigo_Postal", SqlDbType.Float).Value = Int32.Parse(CodigoPostal.Text);
                    command.Parameters.AddWithValue("@Localidad", SqlDbType.Char).Value = Localidad.Text;
                    command.Parameters.AddWithValue("@ciudad", SqlDbType.Char).Value = Ciudad.Text;
                    command.Parameters.AddWithValue("@nro_piso", SqlDbType.Int).Value = Int32.Parse(NroPiso.Text);
                    command.Parameters.AddWithValue("@Depto", SqlDbType.Char).Value = Departamento.Text;


                    command.ExecuteNonQuery();
                    MessageBox.Show("Registro de Cliente Finalizado");

                    break;

                case "Proveedor":

                    if (verificar_parametros())
                    {
                        MessageBox.Show("Faltan completar campos");
                        return;
                    }

                    if (CodigoPostal.Text.Any(x => !char.IsNumber(x)) || CodigoPostal.Text.Length != 4 || Localidad.Text.Any(x => char.IsNumber(x)) || Ciudad.Text.Any(x => char.IsNumber(x)) || NroPiso.Text.Any(x => !char.IsNumber(x)))
                    {
                        MessageBox.Show("Datos erroneos.");
                        return;
                    }

                    SqlCommand command1 = new SqlCommand("registrar_usuario_proveedor", conn);
                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.AddWithValue("@Username", SqlDbType.Char).Value = usuario;
                    command1.Parameters.AddWithValue("@Password", SqlDbType.Char).Value = password;
                    command1.Parameters.AddWithValue("@Rol", SqlDbType.Char).Value = rol;
                    command1.Parameters.AddWithValue("@Razon_social", SqlDbType.Char).Value = razonSocial;
                    command1.Parameters.AddWithValue("@Mail", SqlDbType.Char).Value = mail;
                    command1.Parameters.AddWithValue("@Telefono", SqlDbType.Float).Value = Int64.Parse(telefono);
                    command1.Parameters.AddWithValue("@CUIT", SqlDbType.Char).Value = cuit;
                    command1.Parameters.AddWithValue("@Rubro", SqlDbType.Char).Value = rubro;
                    command1.Parameters.AddWithValue("@Nombre_contacto", SqlDbType.Char).Value = contacto;
                    command1.Parameters.AddWithValue("@Direccion", SqlDbType.Char).Value = Direccion.Text;
                    command1.Parameters.AddWithValue("@codigo_Postal", SqlDbType.Float).Value = Int32.Parse(CodigoPostal.Text);
                    command1.Parameters.AddWithValue("@Localidad", SqlDbType.Char).Value = Localidad.Text;
                    command1.Parameters.AddWithValue("@Ciudad", SqlDbType.Char).Value = Ciudad.Text;
                    command1.Parameters.AddWithValue("@Nro_Piso", SqlDbType.Int).Value = Int32.Parse(NroPiso.Text);
                    command1.Parameters.AddWithValue("@Depto", SqlDbType.Char).Value = Departamento.Text;


                    command1.ExecuteNonQuery();

                    MessageBox.Show("Registro de Proveedor Finalizado");

                    break;
            }

            this.insertar_rol(rol, usuario, conn);
            conn.Close();

            this.volver_login();
        }

        private void volver_login()
        {
            Form inicio = new InicioDeSesion();
            inicio.Show();
            this.Hide();
        }

        private void insertar_rol(string rol, string username, SqlConnection conexion)
        {
            SqlCommand command = new SqlCommand("insertar_rol_por_usuario", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Rol_Id", SqlDbType.Char).Value = rol;
            command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = username;

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


        private void Direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarDireccion_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            this.Close();
            formulario_anterior.Show();
        }
    }
}