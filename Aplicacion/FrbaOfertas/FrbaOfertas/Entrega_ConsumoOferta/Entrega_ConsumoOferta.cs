using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Manejo_Logico;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FrbaOfertas.Entrega_ConsumoOferta
{
    public partial class Entrega_ConsumoOferta : Form
    {
        private string username;
        public Entrega_ConsumoOferta()
        {
            InitializeComponent();
        }

        public Entrega_ConsumoOferta(string usuario)
        {
            InitializeComponent();
            this.username = usuario;
            fecha_consumo_dtp.Value = DateTime.Now;
        }

        private void Entrega_ConsumoOferta_Load(object sender, EventArgs e)
        {

        }

        private void eliminar_oferta_btn_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open();

            verificar_campos(conexion, conexion_sql);

            conexion_sql.Close();
        }


        private void verificar_campos(conexionBD conexion, SqlConnection conexion_sql)
        {
            if ((string.IsNullOrEmpty(codigo_cupon_txt.Text)) || (string.IsNullOrEmpty(cliente_txt.Text)))
            {
                MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!cupon_existente(conexion_sql))
            {
                MessageBox.Show("El cupon ingresado no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!proveedor_correcto(conexion_sql))
            {
                MessageBox.Show("La oferta no coincide con este proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!cupon_cliente(conexion_sql))
            {
                MessageBox.Show("La oferta no pertenece a este cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!oferta_disponible(conexion_sql))
            {
                MessageBox.Show("La oferta no esta disponible en esta fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!cupon_utilizado(conexion_sql))
            {
                MessageBox.Show("El cupon ya fue utilizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                utilizar_cupon(conexion_sql);
            }

        }

        private bool cupon_existente(SqlConnection conexion_sql)
        {
            SqlCommand cupon_existente = new SqlCommand("cupon_existente", conexion_sql);
            cupon_existente.CommandType = CommandType.StoredProcedure;
            cupon_existente.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = codigo_cupon_txt.Text;

            try
            {
                cupon_existente.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                //MessageBox.Show(errores.Message.ToString());  
                return false;
            }
        }

        private bool proveedor_correcto(SqlConnection conexion_sql)
        {
            SqlCommand verificar_proveedor = new SqlCommand("verificar_proveedor", conexion_sql);
            verificar_proveedor.CommandType = CommandType.StoredProcedure;
            verificar_proveedor.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = codigo_cupon_txt.Text;
            verificar_proveedor.Parameters.AddWithValue("@proveedor", SqlDbType.Char).Value = username;

            try
            {
                verificar_proveedor.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                //MessageBox.Show(errores.Message.ToString());
                return false;
            }
        }

        private bool cupon_cliente(SqlConnection conexion_sql)//Verificar si la oferta pertenece al cliente idicado
        {
            SqlCommand cupon_cliente = new SqlCommand("cupon_cliente", conexion_sql);
            cupon_cliente.CommandType = CommandType.StoredProcedure;
            cupon_cliente.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = codigo_cupon_txt.Text;
            cupon_cliente.Parameters.AddWithValue("@cliente", SqlDbType.Char).Value = cliente_txt.Text;

            try
            {
                cupon_cliente.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                //MessageBox.Show(errores.Message.ToString());
                return false;
            }
        }

        private bool oferta_disponible(SqlConnection conexion_sql)
        {
            SqlCommand oferta_disponible = new SqlCommand("oferta_disponible", conexion_sql);
            oferta_disponible.CommandType = CommandType.StoredProcedure;
            oferta_disponible.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = codigo_cupon_txt.Text;
            oferta_disponible.Parameters.AddWithValue("@ofertaFecha", SqlDbType.Char).Value = fecha_consumo_dtp.Value;

            try
            {
                oferta_disponible.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                //MessageBox.Show(errores.Message.ToString());
                return false;
            }
        }

        private bool cupon_utilizado(SqlConnection conexion_sql)
        {
            SqlCommand cupon_utilizado = new SqlCommand("cupon_utilizado", conexion_sql);
            cupon_utilizado.CommandType = CommandType.StoredProcedure;
            cupon_utilizado.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = codigo_cupon_txt.Text;

            try
            {
                cupon_utilizado.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                //MessageBox.Show(errores.Message.ToString());
                return false;
            }
        }

        private void utilizar_cupon(SqlConnection conexion_sql)
        {
            SqlCommand utilizar_cupon = new SqlCommand("utilizar_cupon", conexion_sql);
            utilizar_cupon.CommandType = CommandType.StoredProcedure;
            utilizar_cupon.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = codigo_cupon_txt.Text;
            utilizar_cupon.Parameters.AddWithValue("@fecha", SqlDbType.Char).Value = fecha_consumo_dtp.Value;
            utilizar_cupon.ExecuteNonQuery();
            MessageBox.Show("Oferta utilizada correctamente");
            limpiar_form();
        }

        private void limpiar_form()
        {
            codigo_cupon_txt.Clear();
            fecha_consumo_dtp.Value = DateTime.Now;
            cliente_txt.Clear();
        }

        private void atras_btn_Click(object sender, EventArgs e)
        {
            Form menu_principal = new Interfaces.menu_principal(username);
            menu_principal.Show();
            this.Close();
        }
    }
}
