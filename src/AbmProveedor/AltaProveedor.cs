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

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        private string usuario;
        private string password;
        private string rol;
        private int bit_accion;
        private Form formulario_anterior;

        public AltaProveedor()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        public AltaProveedor(string usuario, string password, string rol, Form form, int bit)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            MaximizeBox = false;
            this.usuario = usuario;
            this.password = password;
            this.rol = rol;
            formulario_anterior = form;
            this.bit_accion = bit;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void Siguiente_Click(object sender, EventArgs e)
        {

            if (this.verificar_tipo_datos()) { return; }

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());


            conn.Open();
            try
            {
                SqlCommand verificacion_proveedor = new SqlCommand("ZTS_DB.verificar_existencia_proveedor_gemelo", conn);
                verificacion_proveedor.CommandType = CommandType.StoredProcedure;

                verificacion_proveedor.Parameters.AddWithValue("@cuit", SqlDbType.Char).Value = CUIT.Text;
                verificacion_proveedor.Parameters.AddWithValue("@razon_social", SqlDbType.Char).Value = RS.Text;

                verificacion_proveedor.ExecuteNonQuery();

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
                return;

            }

            conn.Close();

            this.determinar_accion();


        }

        private void determinar_accion()
        {
            if (bit_accion == 0) //vengo de registro de usuario
            {
                this.Hide();
                CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(usuario, password, rol, null, null, null, Telefono.Text, null, Mail.Text, RS.Text, CUIT.Text, Rubro.Text, Contacto.Text, this, 0);
                direccion.Show();
            }
            else  //Vengo de alta de proveedor
            {
                this.Hide();
                CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(usuario, password, rol, null, null, null, Telefono.Text, null, Mail.Text, RS.Text, CUIT.Text, Rubro.Text, Contacto.Text, this, 2);
                direccion.Show();
            }
        }

        private bool verificar_tipo_datos()
        {
            if (this.verificar_txts_vacios())
            {
                MessageBox.Show("Todos los campos son obligatorios menos el nombre de contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Rubro.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Rubro Invalido. No se permite ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (CUIT.Text.Trim().Length != 13) //VERIFICAR QUE TENGA 2 GUIONES
            {
                MessageBox.Show("Cuit Invalido. El CUIT debe contener 13 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if ((CUIT.Text.Trim().Substring(2, 1) != "-" || CUIT.Text.Trim().Substring(11, 1) != "-"))
            {
                MessageBox.Show("Cuit Invalido. Ejemplo de un cuit valido: 30-12104111-4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Telefono.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("Telefono Invalido. Cadena Numerica unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (!string.IsNullOrEmpty(Contacto.Text.Trim()))
            {
                if (Contacto.Text.Any(x => char.IsNumber(x)))
                {
                    MessageBox.Show("Contacto Invalido. No se permite ingresar Numeros. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;
        }

        private bool verificar_txts_vacios()
        {
            List<TextBox> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).ToList();
            List<TextBox> lista_filtrada = lista_textBoxs.Where(txt => txt != Contacto).ToList();
            List<String> lista_convertida = lista_filtrada.Select(x => x.Text).ToList();

            if (lista_convertida.Any(cadena => cadena == String.Empty))
            {
                return true;
            }

            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            formulario_anterior.Show();

        }
    }
}