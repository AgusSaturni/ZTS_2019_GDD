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

        public AltaProveedor()
        {
            InitializeComponent();
        }

        public AltaProveedor(string usuario, string password, string rol)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            MaximizeBox = false;
            this.usuario = usuario;
            this.password = password;
            this.rol = rol;
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

            if ( Telefono.Text.Any(x => !char.IsNumber(x)) || Rubro.Text.Any(x => char.IsNumber(x)) || cuit.Length < 13 || Contacto.Text.Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Datos erroneos.");
                return;
            }

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            if (razonSocial != "" && telefono != "" && cuit != "" && rubro != "" && mail != "")
            {
                try {
                  

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

                this.Visible = false;
                CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(usuario, password,rol, null, null, null, telefono, null, mail,razonSocial,cuit,rubro,contacto);
                direccion.Show();
            }
            else
            {
                MessageBox.Show("Faltan completar campos");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form alta = new RegistroUsuario("Proveedor");
            alta.Show();

        }
    }
}
