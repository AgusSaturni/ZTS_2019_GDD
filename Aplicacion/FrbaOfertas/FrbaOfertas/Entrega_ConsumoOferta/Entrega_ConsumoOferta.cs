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
using System.Configuration;

namespace FrbaOfertas.Entrega_ConsumoOferta
{
    public partial class Entrega_ConsumoOferta : Form
    {
        private string username = (Singleton_Usuario.getInstance()).get_username();
        private string indice_cupon;
        private Form formulario_anterior;
        private DateTime Fecha_Config = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

        public Entrega_ConsumoOferta()
        {
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.fecha_consumo_dtp.Value = (Fecha_Config);
        }

        public Entrega_ConsumoOferta(Form form_anterior, string codigo_cupon, string cliente_username, string indice )
        {
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
            cliente_txt.Text = cliente_username;
            codigo_cupon_txt.Text = codigo_cupon;
            this.formulario_anterior = form_anterior;
            this.indice_cupon = indice;
            this.fecha_consumo_dtp.Value = (Fecha_Config);
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

            formulario_anterior.Show();
            this.Close();

        }


        private void verificar_campos(conexionBD conexion, SqlConnection conexion_sql)
        {

            //else if (!cupon_existente(conexion_sql))
            //{
            //    MessageBox.Show("El cupon ingresado no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
         //   if (!proveedor_correcto(conexion_sql))
         //   {
                // MessageBox.Show("El cupon de esta oferta no le pertenece", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //  }
           // else if (!cupon_cliente(conexion_sql))
           // {
           //     MessageBox.Show("La oferta no pertenece a este cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
          //  else if (!oferta_disponible(conexion_sql))
          //  {
                //MessageBox.Show("La oferta ha vencido. No se puede canjear el Cupon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //  }
          //  else if (!cupon_utilizado(conexion_sql))
          //  {
                //MessageBox.Show("El cupon ya fue utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //  }
          //  else
          //  {
          //      utilizar_cupon(conexion_sql);
          //  }
            if (this.oferta_disponible(conexion_sql) && this.cupon_utilizado(conexion_sql)) 
            {
                utilizar_cupon(conexion_sql);
            }

        }

        private bool oferta_disponible(SqlConnection conexion_sql)
        {
            SqlCommand oferta_disponible = new SqlCommand("oferta_disponible", conexion_sql);
            oferta_disponible.CommandType = CommandType.StoredProcedure;
            oferta_disponible.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = indice_cupon;
            oferta_disponible.Parameters.AddWithValue("@ofertaFecha", SqlDbType.Char).Value = fecha_consumo_dtp.Value;

            try
            {
                oferta_disponible.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool cupon_utilizado(SqlConnection conexion_sql)
        {
            SqlCommand cupon_utilizado = new SqlCommand("cupon_utilizado", conexion_sql);
            cupon_utilizado.CommandType = CommandType.StoredProcedure;
            cupon_utilizado.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = indice_cupon;

            try
            {
                cupon_utilizado.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                return false;
            }
        }

        private bool proveedor_correcto(SqlConnection conexion_sql)
        {
            SqlCommand verificar_proveedor = new SqlCommand("verificar_proveedor", conexion_sql);
            verificar_proveedor.CommandType = CommandType.StoredProcedure;
            verificar_proveedor.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = indice_cupon;
            verificar_proveedor.Parameters.AddWithValue("@proveedor", SqlDbType.Char).Value = username;

            try
            {
                verificar_proveedor.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void utilizar_cupon(SqlConnection conexion_sql)
        {

            SqlCommand utilizar_cupon = new SqlCommand("utilizar_cupon", conexion_sql);
            utilizar_cupon.CommandType = CommandType.StoredProcedure;
            utilizar_cupon.Parameters.AddWithValue("@cuponId", SqlDbType.Char).Value = indice_cupon;
            utilizar_cupon.Parameters.AddWithValue("@fecha", SqlDbType.Char).Value = fecha_consumo_dtp.Value;
            utilizar_cupon.ExecuteNonQuery();
            MessageBox.Show("Oferta Entregada correctamente", "Canje Cupon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar_form();
        }

        private void limpiar_form()
        {
            codigo_cupon_txt.Clear();
            fecha_consumo_dtp.Value = fecha_consumo_dtp.Value;
            cliente_txt.Clear();
        }

        private void atras_btn_Click(object sender, EventArgs e)
        {
            formulario_anterior.Show();
            this.Close();
        }
    }
}
