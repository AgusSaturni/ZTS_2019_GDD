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

namespace FrbaOfertas.CrearOferta
{
    public partial class CargaOferta : Form
    {
        string username;

        public string CrearPassword(int longitud)
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
            InitializeComponent();
        }

        public CargaOferta(string username_recibido)
        {
            InitializeComponent();
            username = username_recibido;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

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

            SqlParameter codigo = new SqlParameter("@codigo", SqlDbType.Char);
            codigo.Direction = ParameterDirection.Input;
            command.Parameters.Add(codigo);

            SqlParameter proveedor_ref = new SqlParameter("@proveedor_referenciado", SqlDbType.Char);
            proveedor_ref.Direction = ParameterDirection.Input;
            command.Parameters.Add(proveedor_ref );

            descripcion.Value = Descripcion.Text;
            fecha_publi.Value = FechaPublicacion.Value;
            fecha_venc.Value = FechaVencimiento.Value;
            precio_oferta.Value = PrecioOferta.Text;
            precio_lista.Value = PrecioLista.Text;
            cant_disponible.Value = Cantidad.Value;
            codigo.Value = CrearPassword(50);
            proveedor_ref.Value = username;

            command.ExecuteNonQuery();
            MessageBox.Show("Hecho");
            conn.Close();
        }
    }


}
