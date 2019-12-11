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
using System.Configuration;

namespace FrbaOfertas.CrearOferta
{
    public partial class CargaOferta : Form
    {
        Singleton_Usuario sesion = Singleton_Usuario.getInstance();
        conexionBD conexion = conexionBD.getConexion();
        SqlConnection conn;
        private DateTime Fecha_Config = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        private bool bit_admin = false;

        public string crear_codigo(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        public CargaOferta()
        {
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void CargaOferta_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conexion.get_cadena());

            if (sesion.verificar_rol_administrador())
            {
                ProveedorUser.ReadOnly = false;
                bit_admin = true;
            }
            else
            {
                ProveedorUser.ReadOnly = true;
                ProveedorUser.Text = sesion.get_username();
            }

            FechaPublicacion.Value = Fecha_Config;
            FechaVencimiento.Value = Fecha_Config;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool verificar_txts_vacios()
        {
            List<String> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).Select(p => p.Text).ToList();

            if (lista_textBoxs.Any(cadena => cadena == String.Empty))
            {
                return true;
            }

            return false;
        }


        private void bt_volver_Click(object sender, EventArgs e)
        {
            Form menu = new Interfaces.menu_principal();
            menu.Show();
            this.Close();

        }

        private bool verificar_datos()
        {
            if (Convert.ToDecimal(PrecioLista.Text) < Convert.ToDecimal(PrecioOferta.Text))
            {
                MessageBox.Show("El precio de oferta debe ser menor al de lista", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Cantidad.Value.ToString() == "0" || CantMax.Value.ToString() == "0" || Convert.ToDecimal(Cantidad.Value.ToString()) < Convert.ToDecimal(CantMax.Value.ToString()))
            {
                MessageBox.Show("La cantidad disponible debe ser mayor a la cantidad maxima por usuario, y ambas distintas de 0.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (FechaPublicacion.Value < Fecha_Config || FechaVencimiento.Value < Fecha_Config)
            {
                MessageBox.Show("Las fechas deben ser mayores o iguales a la actual.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }


        private void bt_publicar_Click(object sender, EventArgs e)
        {
            if (this.verificar_txts_vacios())
            {
                MessageBox.Show("Todos los campos son obligatorios", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //verificar fecha, precio de oferta rebajado al de lista

            if (this.verificar_datos()) { return; }

            conn.Open();

            SqlCommand command = new SqlCommand("confeccion_oferta", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@descripcion", SqlDbType.Char).Value = Descripcion.Text;
            command.Parameters.AddWithValue("@fecha_publicacion", SqlDbType.Date).Value = FechaPublicacion.Value;
            command.Parameters.AddWithValue("@fecha_vencimiento", SqlDbType.Date).Value = FechaVencimiento.Value;
            command.Parameters.AddWithValue("@precio_oferta", SqlDbType.Float).Value = Convert.ToDecimal(PrecioOferta.Text);
            command.Parameters.AddWithValue("@precio_lista", SqlDbType.Float).Value = Convert.ToDecimal(PrecioLista.Text);
            command.Parameters.AddWithValue("@cantidad_disponible", SqlDbType.Float).Value = Int32.Parse(Cantidad.Value.ToString());
            command.Parameters.AddWithValue("@cantidad_maxima_por_usuario", SqlDbType.Float).Value = Int32.Parse(CantMax.Value.ToString());
            command.Parameters.AddWithValue("@codigo", SqlDbType.Char).Value = this.crear_codigo(10);

            if (this.bit_admin)
            {
                command.Parameters.AddWithValue("@proveedor_referenciado", SqlDbType.Char).Value = ProveedorUser.Text;
            }
            else
            {
                command.Parameters.AddWithValue("@proveedor_referenciado", SqlDbType.Char).Value = sesion.get_username();
            }


            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Oferta Publicada", "Publicacion de Ofertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.limpiar_datos();
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        private void limpiar_datos()
        {
            FechaPublicacion.Value = Fecha_Config;
            FechaVencimiento.Value = Fecha_Config;
            Descripcion.Text = "";
            PrecioLista.Text = "";
            PrecioOferta.Text = "";
            Cantidad.Value = 0;
            CantMax.Value = 0;
            if (this.bit_admin)
            {
                ProveedorUser.Text = "";
            }
        }

        private void PrecioOferta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void PrecioLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}