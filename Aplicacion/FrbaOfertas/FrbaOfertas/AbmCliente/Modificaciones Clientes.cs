using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace FrbaOfertas.AbmCliente
{
    public partial class frm_clie_bajas : Form
    {
        public bool boleano = false;
        public frm_clie_bajas()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void frm_clie_bajas_Load(object sender, EventArgs e)
        {

        }

        private void contenedor_info_cliente_Enter(object sender, EventArgs e)
        {

        }

        private void contenedor_estado_Enter(object sender, EventArgs e)
        {

        }



        private void bt_habilitar_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            try
            {
                SqlCommand command = new SqlCommand("habilitar_cliente", conexion_sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DNI_CLIENTE", SqlDbType.Int).Value = Int32.Parse(txt_dni.Text);
                command.Parameters.AddWithValue("@username", SqlDbType.Int).Value = txt_username.Text;

                conexion_sql.Open();
                command.ExecuteNonQuery();
                conexion_sql.Close();

                MessageBox.Show("Cliente Habilitado");

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            this.Hide();
        }

        //este es guardar, no me deja borrarlo
        private void bt_deshabilitar_Click(object sender, EventArgs e){}

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bt_modificar_Click(object sender, EventArgs e)
        {
            txt_nombre.ReadOnly = false;
            txt_dni.ReadOnly = false;
            txt_apellido.ReadOnly = false;
            txt_email.ReadOnly = false;
            txt_fecha.ReadOnly = false;
            txt_telefono.ReadOnly = false;
            txt_nombre.ReadOnly = false;

            txt_direccion.ReadOnly = false;
            txt_ciudad.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_depto.ReadOnly = false;
            txt_piso.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_localidad.ReadOnly = false;
        }

        private void txt_estado_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_modificar_Click_1(object sender, EventArgs e)
        {
            txt_nombre.ReadOnly = false;
            txt_dni.ReadOnly = false;
            txt_apellido.ReadOnly = false;
            txt_email.ReadOnly = false;
            txt_fecha.ReadOnly = false;
            txt_telefono.ReadOnly = false;
            txt_nombre.ReadOnly = false;

            txt_direccion.ReadOnly = false;
            txt_ciudad.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_depto.ReadOnly = false;
            txt_piso.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_localidad.ReadOnly = false;

        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.ReadOnly == true) 
            {
                MessageBox.Show("Primero Inicie alguna Modificacion");
                return;
            }


            if (this.verificar_parametros())
            {
                MessageBox.Show("Complete Todos los Campos");
                return;
            };

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            try
            {
                SqlCommand command = new SqlCommand("actualizar_cliente", conexion_sql);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = (txt_username.Text);
                command.Parameters.AddWithValue("@nombre", SqlDbType.Char).Value = (txt_nombre.Text);
                command.Parameters.AddWithValue("@apellido", SqlDbType.Char).Value = (txt_apellido.Text);
                command.Parameters.AddWithValue("@DNI", SqlDbType.Int).Value = Int32.Parse(txt_dni.Text);
                command.Parameters.AddWithValue("@telefono", SqlDbType.Int).Value = Int32.Parse(txt_telefono.Text);
                command.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = (txt_email.Text);
                command.Parameters.AddWithValue("@fecha", SqlDbType.Char).Value = (txt_fecha.Text);
                command.Parameters.AddWithValue("@direccion", SqlDbType.Char).Value = (txt_direccion.Text);
                command.Parameters.AddWithValue("@CP", SqlDbType.Int).Value = Int32.Parse(txt_codigopostal.Text);
                command.Parameters.AddWithValue("@Loc", SqlDbType.Char).Value = (txt_localidad.Text);
                command.Parameters.AddWithValue("@Npiso", SqlDbType.Int).Value = Int32.Parse(txt_piso.Text);
                command.Parameters.AddWithValue("@depto", SqlDbType.Char).Value = (txt_depto.Text);

                conexion_sql.Open();
                command.ExecuteNonQuery();
                conexion_sql.Close();
                
                MessageBox.Show("Cliente Modificado");

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            this.Hide();
        }

        private void bt_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
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

        private void frm_clie_bajas_Load_1(object sender, EventArgs e)
        {

        }




        
     }



    

}
