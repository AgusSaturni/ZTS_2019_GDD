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
        public frm_clie_bajas()
        {
            InitializeComponent();
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
            conexionBD cadena_conexion = new conexionBD();
            SqlConnection conexion = new SqlConnection(cadena_conexion.get_conexion());

            try
            {
                SqlCommand command = new SqlCommand("habilitar_cliente", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DNI_CLIENTE", SqlDbType.Int).Value = Int32.Parse(txt_dni.Text);

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Cliente Habilitado");

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            this.Hide();
        }

        //este es guardar, no me deja cambiarle el nombre
        private void bt_deshabilitar_Click(object sender, EventArgs e)
        {
            conexionBD cadena_conexion = new conexionBD();
            SqlConnection conexion = new SqlConnection(cadena_conexion.get_conexion());


            if (txt_nombre.ReadOnly == true)
            {
                MessageBox.Show("Modifique algun parametro");
                return;
            }
            try
            {
                SqlCommand command = new SqlCommand("actualizar_cliente", conexion);
                command.CommandType = CommandType.StoredProcedure;


                //Si dejo espacios vacios en los TXT, el Int32.parse me tira error (Esto sucede para los datos numericos). Hay q revisar eso

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

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Cliente Modificado");

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            this.Hide();
        }

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




    }
}
