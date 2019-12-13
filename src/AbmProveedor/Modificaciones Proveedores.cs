using FrbaOfertas.Manejo_Logico;
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
    public partial class Modificaciones_Proveedores : Form
    {
        conexionBD conexion = conexionBD.getConexion();
        CommonQueries commonQueries_instance = CommonQueries.getInstance();
        SqlConnection conexion_sql;
        string rubro_seleccionado;

        public Modificaciones_Proveedores(string rubro)
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.rubro_seleccionado = rubro;
        }

        private void Modificaciones_Proveedores_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
            this.cargar_combobox_rubros(conexion_sql);
        }

        private void cargar_combobox_rubros(SqlConnection conexion_sql)
        {
            conexion_sql.Open();
            SqlDataReader reader = commonQueries_instance.select_rubros_disponibles(conexion_sql);

            while (reader.Read())
            {
                cb_rubros.Items.Add(reader[0]);
            }
            conexion_sql.Close();

            int index_seleccionado = cb_rubros.Items.IndexOf(rubro_seleccionado);
            cb_rubros.SelectedIndex = index_seleccionado;
        }

        private void bt_habilitar_Click(object sender, EventArgs e)
        {

            conexion_sql.Open();
            try
            {
                commonQueries_instance.vereificar_estado_rol("Proveedor", conexion_sql);

                try
                {
                    SqlCommand command = new SqlCommand("ZTS_DB.habilitar_proveedor", conexion_sql);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CUIT", SqlDbType.Int).Value = (txt_CUIT.Text);
                    command.Parameters.AddWithValue("@Username", SqlDbType.Int).Value = txt_username.Text;

                    command.ExecuteNonQuery();


                    MessageBox.Show("Proveedor Habilitado", "Modificacion de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_estado.Text = "Habilitado";
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Modificacion de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion_sql.Close();

        }

        private void bt_modificar_Click(object sender, EventArgs e)
        {
            txt_RazonSoc.ReadOnly = false;
            txt_CUIT.ReadOnly = false;
            cb_rubros.Enabled = true;
            txt_email.ReadOnly = false;
            txt_telefono.ReadOnly = false;
            txt_Contacto.ReadOnly = false;

            txt_direccion.ReadOnly = false;
            txt_ciudad.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_depto.ReadOnly = false;
            txt_piso.ReadOnly = false;
            txt_localidad.ReadOnly = false;
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form listado = new listado_proveedores();
            listado.Show();
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (txt_RazonSoc.ReadOnly == true)
            {
                MessageBox.Show("Modifique algun parametro", "Modificacion de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.verificar_txts_vacios())
            {
                MessageBox.Show("Todos los campos son obligatorios menos el nombre de contacto, la localidad, el piso, el codigo postal y el departamento", "Modificacion de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.verificar_parametro()) { return; }

            conexion_sql.Open();
            try
            {
                SqlCommand command = new SqlCommand("ZTS_DB.actualizar_proveedor", conexion_sql);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = (txt_username.Text);
                command.Parameters.AddWithValue("@razonSocial", SqlDbType.Char).Value = (txt_RazonSoc.Text);
                command.Parameters.AddWithValue("@rubro", SqlDbType.Char).Value = (cb_rubros.SelectedItem.ToString());
                command.Parameters.AddWithValue("@CUIT", SqlDbType.Char).Value = txt_CUIT.Text;
                command.Parameters.AddWithValue("@telefono", SqlDbType.Float).Value = Int64.Parse(txt_telefono.Text);
                command.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = (txt_email.Text);
                command.Parameters.AddWithValue("@direccion", SqlDbType.Char).Value = (txt_direccion.Text);
                command.Parameters.AddWithValue("@ciudad", SqlDbType.Char).Value = (txt_ciudad.Text);

                commonQueries_instance.filtrar_nulos(command, txt_codigopostal.Text, txt_localidad.Text, txt_piso.Text, txt_depto.Text);

                if (!string.IsNullOrEmpty(txt_Contacto.Text.Trim()))
                {
                    command.Parameters.AddWithValue("@contacto", SqlDbType.Char).Value = (txt_Contacto.Text);
                }

                command.ExecuteNonQuery();

                MessageBox.Show("Proveedor Modificado", "Modificacion de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Modificacion de Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conexion_sql.Close();


        }

        private bool verificar_parametro()
        {
            if (txt_CUIT.Text.Trim().Substring(2, 1) != "-" || txt_CUIT.Text.Trim().Substring(11, 1) != "-")
            {
                MessageBox.Show("Cuit Invalido. Ejemplo de un cuit valido: 30-12104111-4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (cb_rubros.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rubro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_telefono.Text.Trim().Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("Telefono Invalido. Cadena Numerica unicamente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!string.IsNullOrEmpty(txt_Contacto.Text.Trim()))
            {
                if (txt_Contacto.Text.Trim().Any(x => char.IsNumber(x)))
                {
                    MessageBox.Show("Nombre de contacto Invalido. Solo se permiten letras ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
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
                MessageBox.Show("Ciudad Invalida. No se permiten ingresar Numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (!string.IsNullOrEmpty(txt_piso.Text.Trim()))
            {
                if (txt_piso.Text.Any(x => !char.IsNumber(x)))
                {
                    MessageBox.Show("Número de piso Invalido. No se permiten ingresar Letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            if (!string.IsNullOrEmpty(txt_depto.Text.Trim()))
            {
                if (txt_depto.Text.Any(x => char.IsNumber(x)))
                {
                    MessageBox.Show("Departamento Invalido. Solo se permiten ingresar Letras (Departamento A, B C, etc)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;
        }

        private bool verificar_txts_vacios()
        {
            List<TextBox> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).ToList();
            List<TextBox> lista_filtrada = lista_textBoxs.Where(txt => txt != txt_localidad && txt != txt_piso && txt != txt_depto && txt != txt_codigopostal && txt != txt_Contacto).ToList();
            List<String> lista_convertida = lista_filtrada.Select(x => x.Text).ToList();

            if (lista_convertida.Any(cadena => cadena == String.Empty))
            {
                return true;
            }

            return false;
        }

        private void txt_estado_TextChanged(object sender, EventArgs e)
        {

        }

        private void contenedor_estado_Enter(object sender, EventArgs e)
        {

        }

    }
}