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
        private int bit_accion;
        private Form formulario_anterior;
        private CommonQueries common_queries_instance = CommonQueries.getInstance();
        conexionBD conexion = conexionBD.getConexion();
        SqlConnection conn;

        public CargarDireccion()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public CargarDireccion(string usuario, string password, string rol, string nombre, string apellido, string DNI, string telefono, object fechaDeNacimiento, string mail, string rs, string cuit, string rubro, string contacto, Form form_ant, int bit)
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
            this.bit_accion = bit;
            formulario_anterior = form_ant;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //BOTON FINALIZAR
        {
            conn.Open();

            switch (rol)
            {
                case "Cliente":

                    if (this.verificar_datos_direccion()) { return; }
                   
                    //----------------------DATOS PARA REGISTRO----------------------------
                    SqlCommand command = new SqlCommand("ZTS_DB.registrar_usuario_cliente", conn);
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
                    command.Parameters.AddWithValue("@ciudad", SqlDbType.Char).Value = Ciudad.Text;

                    common_queries_instance.filtrar_nulos(command, CodigoPostal.Text, Localidad.Text, NroPiso.Text, Departamento.Text);


                    command.ExecuteNonQuery();
                    MessageBox.Show("Registro de Cliente Finalizado", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case "Proveedor":

                    if (this.verificar_datos_direccion()) { return; }

                    SqlCommand command1 = new SqlCommand("ZTS_DB.registrar_usuario_proveedor", conn);
                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.AddWithValue("@Username", SqlDbType.Char).Value = usuario;
                    command1.Parameters.AddWithValue("@Password", SqlDbType.Char).Value = password;
                    command1.Parameters.AddWithValue("@Rol", SqlDbType.Char).Value = rol;
                    command1.Parameters.AddWithValue("@Razon_social", SqlDbType.Char).Value = razonSocial;
                    command1.Parameters.AddWithValue("@Mail", SqlDbType.Char).Value = mail;
                    command1.Parameters.AddWithValue("@Telefono", SqlDbType.Float).Value = Int64.Parse(telefono);
                    command1.Parameters.AddWithValue("@CUIT", SqlDbType.Char).Value = cuit;
                    command1.Parameters.AddWithValue("@Rubro", SqlDbType.Char).Value = rubro;

                    if (!string.IsNullOrEmpty(contacto.Trim()))
                    {
                        command1.Parameters.AddWithValue("@Nombre_contacto", SqlDbType.Char).Value = contacto;
                    }

                    command1.Parameters.AddWithValue("@Direccion", SqlDbType.Char).Value = Direccion.Text;
                    command1.Parameters.AddWithValue("@Ciudad", SqlDbType.Char).Value = Ciudad.Text;

                    common_queries_instance.filtrar_nulos(command1, CodigoPostal.Text, Localidad.Text, NroPiso.Text, Departamento.Text);

                    command1.ExecuteNonQuery();

                    MessageBox.Show("Registro de Proveedor Finalizado", "Registro de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
            }

            conn.Close();

            this.determinar_accion_final();
        }

        private void determinar_accion_final() 
        {
            switch (bit_accion) 
            {
                case 0:
                    Form inicio = new InicioDeSesion();
                    inicio.Show();
                    this.Close();
                    break;
                case 1:
                    Form menu_cliente = new MenuAdmin.ABMClientes();
                    menu_cliente.Show();
                    this.Close();
                    break;
                case 2:
                    Form menu_proveedor = new MenuAdmin.ABMProveedores();
                    menu_proveedor.Show();
                    this.Close();
                    break;
            }
        
        }

        private bool verificar_datos_direccion() 
        {
            if (verificar_txts_vacios())
            {
                MessageBox.Show("Los campos de direccion y ciudad son obligatorios.", "Carga de Direccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            if (!string.IsNullOrEmpty(CodigoPostal.Text.Trim()))
            {
                if (CodigoPostal.Text.Any(x => !char.IsNumber(x)) || CodigoPostal.Text.Length != 4)
                {
                    MessageBox.Show("Codigo Postal Invalido. Cadena de 4 numeros unicamenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            
            if (!string.IsNullOrEmpty(Localidad.Text.Trim())) 
            {
                if (Localidad.Text.Any(x => char.IsNumber(x)))
                {
                    MessageBox.Show("Localidad Invalida. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            if (Ciudad.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Ciudad Erronea. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!string.IsNullOrEmpty(NroPiso.Text.Trim())) 
            {
                if (NroPiso.Text.Any(x => !char.IsNumber(x)))
                {
                    MessageBox.Show("Número de piso erroneo. No se permiten ingresar Letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(Departamento.Text.Trim()))
            {
                if (Departamento.Text.Any(x => char.IsNumber(x))) 
                {
                    MessageBox.Show("Departamento erroneo. Solo se permiten ingresar Letras (Departamento A, B C, etc)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }


            return false;
        }

        private bool verificar_txts_vacios()
        {
            List<TextBox> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).ToList();
            List<TextBox> lista_filtrada = lista_textBoxs.Where(txt => txt != Localidad && txt != NroPiso && txt != Departamento && txt != CodigoPostal).ToList();
            List<String> lista_convertida = lista_filtrada.Select(x => x.Text).ToList();

            if (lista_convertida.Any(cadena => cadena == String.Empty))
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
            conn = new SqlConnection(conexion.get_cadena());

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