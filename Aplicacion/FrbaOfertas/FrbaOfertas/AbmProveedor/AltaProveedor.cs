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
        private Form formulario_anterior;

        public AltaProveedor()
        {
            InitializeComponent();
        }

        public AltaProveedor(string usuario, string password, string rol, Form form)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            MaximizeBox = false;
            this.usuario = usuario;
            this.password = password;
            this.rol = rol;
            formulario_anterior = form;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            string razonSocial = RS.Text;
            string telefono = Telefono.Text;
            string cuit = CUIT.Text;
            string rubro = Rubro.Text;
            string mail = Mail.Text;
            string contacto = Contacto.Text;

            if (this.verificar_tipo_datos()) { return; }

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            if (razonSocial != "" && telefono != "" && cuit != "" && rubro != "" && mail != "")
            {
                try
                {


                    SqlCommand command = new SqlCommand("verificar_existencia_proveedor_existente", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();


                    SqlParameter cuit_verif = new SqlParameter("@cuit", SqlDbType.Char);
                    cuit_verif.Direction = ParameterDirection.Input;
                    command.Parameters.Add(cuit_verif);


                    SqlParameter razon_social = new SqlParameter("@razon_social", SqlDbType.Char);
                    razon_social.Direction = ParameterDirection.Input;
                    command.Parameters.Add(razon_social);

                    cuit_verif.Value = cuit;
                    razon_social.Value = razonSocial;

                    command.ExecuteNonQuery();

                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                    return;

                }

                conn.Close();

                this.Hide();
                CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(usuario, password, rol, null, null, null, telefono, null, mail, razonSocial, cuit, rubro, contacto, this);
                direccion.Show();
            }
            else
            {
                MessageBox.Show("Faltan completar campos");
            }


        }

        private bool verificar_tipo_datos()
        {
            if (RS.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Razon Social Invalida. No se permite ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Rubro.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Rubro Invalido. No se permite ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (CUIT.Text.Trim().Length != 13) //VERIFICAR QUE TENGA 2 GUIONES
            {
                MessageBox.Show("Cuit Invalido. Cadena Numerica de 13 caracteres unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Telefono.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("Telefono Invalido. Cadena Numerica unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Contacto.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Contacto Invalido. No se permite ingresar Numeros. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formulario_anterior.Show();

        }
    }
}