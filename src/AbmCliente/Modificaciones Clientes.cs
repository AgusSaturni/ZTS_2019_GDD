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
using FrbaOfertas.Manejo_Logico;
using System.Configuration;
namespace FrbaOfertas.AbmCliente
{
    public partial class frm_clie_bajas : Form
    {
        public bool boleano = false;
        conexionBD conexion = conexionBD.getConexion();
        CommonQueries commonQueries_instance = CommonQueries.getInstance();
        SqlConnection conexion_sql;
        private DateTime Fecha_Config = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

        public frm_clie_bajas()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void frm_clie_bajas_Load_1(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
        }


        private void contenedor_info_cliente_Enter(object sender, EventArgs e)
        {

        }

        private void contenedor_estado_Enter(object sender, EventArgs e)
        {

        }



        private void bt_habilitar_Click(object sender, EventArgs e)
        {
            conexion_sql.Open();
            try 
            {
                commonQueries_instance.vereificar_estado_rol("Cliente", conexion_sql);

                try
                {
                    SqlCommand command = new SqlCommand("ZTS_DB.habilitar_cliente", conexion_sql);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DNI_CLIENTE", SqlDbType.Int).Value = Int32.Parse(txt_dni.Text);
                    command.Parameters.AddWithValue("@username", SqlDbType.Int).Value = txt_username.Text;


                    command.ExecuteNonQuery();

                    MessageBox.Show("Cliente Habilitado", "Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_estado.Text = "Habilitado";
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString(), "Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion_sql.Close();

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
            date_fecha_nacimiento.Enabled = true;
            txt_telefono.ReadOnly = false;

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

        private bool verificar_parametros() 
        {
            if (txt_nombre.Text.Trim().Any(x => char.IsNumber(x)) || txt_apellido.Text.Any(x => char.IsNumber(x))) 
            {
                MessageBox.Show("Nombre y/o apellido Invalido. Solo se permiten letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_dni.Text.Trim().Any(x => !char.IsNumber(x)) || txt_dni.Text.Length != 8) 
            {
                MessageBox.Show("DNI Invalido. Solo se permiten 8 caracteres numericos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_telefono.Text.Trim().Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("Telefono Invalido. Cadena Numerica unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (!string.IsNullOrEmpty(txt_codigopostal.Text.Trim()))
            {
                if (txt_codigopostal.Text.Any(x => !char.IsNumber(x)) || txt_codigopostal.Text.Length != 4)
                {
                    MessageBox.Show("Codigo Postal Invalido. Cadena de 4 numeros unicamenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(txt_localidad.Text.Trim()))
            {
                if (txt_localidad.Text.Any(x => char.IsNumber(x)))
                {
                    MessageBox.Show("Localidad Invalida. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            if (txt_ciudad.Text.Trim().Any(x => char.IsNumber(x)))
            {
                MessageBox.Show("Ciudad Erronea. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!string.IsNullOrEmpty(txt_piso.Text.Trim()))
            {
                if (txt_piso.Text.Any(x => !char.IsNumber(x)))
                {
                    MessageBox.Show("Número de piso erroneo. No se permiten ingresar Letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(txt_depto.Text.Trim()))
            {
                if (txt_depto.Text.Any(x => char.IsNumber(x)))
                {
                    MessageBox.Show("Departamento erroneo. Solo se permiten ingresar Letras (Departamento A, B C, etc)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            if (date_fecha_nacimiento.Value >= Fecha_Config)
            {
                MessageBox.Show("Fecha de nacimiento invalida, debe ser menor a la fecha actual. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

        
            return false;
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.ReadOnly == true) 
            {
                MessageBox.Show("Primero Inicie alguna Modificacion","Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.verificar_txts_vacios())
            {
                MessageBox.Show("Todos los campos son obligatorios menos la localidad, el codigo postal, el numero de piso y el departamento", "Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.verificar_parametros()) { return; }
            


            conexion_sql.Open();
            try
            {
                SqlCommand command = new SqlCommand("ZTS_DB.actualizar_cliente", conexion_sql);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = (txt_username.Text);
                command.Parameters.AddWithValue("@nombre", SqlDbType.Char).Value = (txt_nombre.Text);
                command.Parameters.AddWithValue("@apellido", SqlDbType.Char).Value = (txt_apellido.Text);
                command.Parameters.AddWithValue("@DNI", SqlDbType.Int).Value = Int32.Parse(txt_dni.Text);
                command.Parameters.AddWithValue("@telefono", SqlDbType.Int).Value = Int64.Parse(txt_telefono.Text);
                command.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = (txt_email.Text);
                command.Parameters.AddWithValue("@fecha", SqlDbType.Char).Value = (date_fecha_nacimiento.Value);

                command.Parameters.AddWithValue("@direccion", SqlDbType.Char).Value = (txt_direccion.Text);
                command.Parameters.AddWithValue("@ciudad", SqlDbType.Char).Value = (txt_ciudad.Text);

                commonQueries_instance.filtrar_nulos(command, txt_codigopostal.Text, txt_localidad.Text, txt_piso.Text, txt_depto.Text);

                command.ExecuteNonQuery();

                
                MessageBox.Show("Cliente Modificado", "Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Modificacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion_sql.Close();

        }

        private void bt_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form listado = new frm_listado_clientes();
            listado.Show();
        }

        private bool verificar_txts_vacios()
        {
            List<TextBox> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).ToList();
            List<TextBox> lista_filtrada = lista_textBoxs.Where(txt => txt != txt_localidad && txt != txt_piso && txt != txt_depto && txt != txt_codigopostal).ToList();
            List<String> lista_convertida = lista_filtrada.Select(x => x.Text).ToList();

            if (lista_convertida.Any(cadena => cadena == String.Empty))
            {
                return true;
            }
           
            return false;
        }


     }

}
