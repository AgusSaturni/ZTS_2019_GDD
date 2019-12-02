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

namespace FrbaOfertas.CrearOferta
{
    public partial class CargaOferta : Form
    {
        private string username = (Singleton_Usuario.getInstance()).get_username();

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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

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


        private void button1_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            conn.Open();

            SqlCommand command = new SqlCommand("confeccion_oferta", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter descripcion = new SqlParameter("@descripcion", SqlDbType.Char);
            descripcion.Direction = ParameterDirection.Input;
            command.Parameters.Add(descripcion);

            SqlParameter fecha_publi = new SqlParameter("@fecha_publicacion", SqlDbType.Date);
            fecha_publi.Direction = ParameterDirection.Input;
            command.Parameters.Add(fecha_publi);

            SqlParameter fecha_venc = new SqlParameter("@fecha_vencimiento", SqlDbType.Date);
            fecha_venc.Direction = ParameterDirection.Input;
            command.Parameters.Add(fecha_venc);

            SqlParameter precio_oferta = new SqlParameter("@precio_oferta", SqlDbType.Float);
            precio_oferta.Direction = ParameterDirection.Input;
            command.Parameters.Add(precio_oferta);

            SqlParameter precio_lista = new SqlParameter("@precio_lista", SqlDbType.Float);
            precio_lista.Direction = ParameterDirection.Input;
            command.Parameters.Add(precio_lista);

            SqlParameter cant_disponible = new SqlParameter("@cantidad_disponible", SqlDbType.Float);
            cant_disponible.Direction = ParameterDirection.Input;
            command.Parameters.Add(cant_disponible);

            SqlParameter cant_max = new SqlParameter("@cantidad_maxima_por_usuario", SqlDbType.Int);
            cant_max.Direction = ParameterDirection.Input;
            command.Parameters.Add(cant_max);


            SqlParameter codigo = new SqlParameter("@codigo", SqlDbType.Char);
            codigo.Direction = ParameterDirection.Input;
            command.Parameters.Add(codigo);

            SqlParameter proveedor_ref = new SqlParameter("@proveedor_referenciado", SqlDbType.Char);
            proveedor_ref.Direction = ParameterDirection.Input;
            command.Parameters.Add(proveedor_ref);


            descripcion.Value = Descripcion.Text;
            fecha_publi.Value = FechaPublicacion.Value;
            fecha_venc.Value = FechaVencimiento.Value;
            precio_oferta.Value = PrecioOferta.Text;
            precio_lista.Value = PrecioLista.Text;
            cant_disponible.Value = Cantidad.Value;
            codigo.Value = crear_codigo(10);
            cant_max.Value = CantMax.Value;
            proveedor_ref.Value = ProveedorUser.Text;
            if (verificar_parametros())
            {
                MessageBox.Show("Faltan completar campos");
                return;
            }
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Hecho");
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargaOferta_Load(object sender, EventArgs e)
        {
            Singleton_Usuario sesion = Singleton_Usuario.getInstance();
            if (sesion.verificar_rol_administrador())
            {
                ProveedorUser.ReadOnly = false;


            }
            else
            {
                ProveedorUser.ReadOnly = true;
                ProveedorUser.Text = username;
            }
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            Form menu = new Interfaces.menu_principal();
            menu.Show();
            this.Hide();

        }

        private void CargaOferta_Load_1(object sender, EventArgs e)
        {
            SqlConnection conn;
            conexionBD conexion = conexionBD.getConexion();
            conn = new SqlConnection(conexion.get_cadena());

            conn.Open();

            SqlCommand verificacion_proveedor = new SqlCommand("verificar_si_no_es_proveedor", conn);
            verificacion_proveedor.CommandType = CommandType.StoredProcedure;

            verificacion_proveedor.Parameters.AddWithValue("@username", SqlDbType.Char).Value = username;

            try
            {
                verificacion_proveedor.ExecuteNonQuery();
                ProveedorUser.Text = username;
                ProveedorUser.ReadOnly = true;
            }
            catch
            {
               

            }
            conn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ProveedorUser_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }


}