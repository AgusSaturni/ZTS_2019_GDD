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

            if (this.oferta_disponible(conexion_sql) && this.cupon_utilizado(conexion_sql)) 
            {
                utilizar_cupon(conexion_sql);
            }

        }

        private bool oferta_disponible(SqlConnection conexion_sql)
        {
            SqlCommand oferta_disponible = new SqlCommand("ZTS_DB.oferta_disponible", conexion_sql);
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
            SqlCommand cupon_utilizado = new SqlCommand("ZTS_DB.cupon_utilizado", conexion_sql);
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

        private void utilizar_cupon(SqlConnection conexion_sql)
        {

            SqlCommand utilizar_cupon = new SqlCommand("ZTS_DB.utilizar_cupon", conexion_sql);
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
