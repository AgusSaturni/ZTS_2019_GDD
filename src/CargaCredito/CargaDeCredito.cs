using FrbaOfertas.Manejo_Logico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CragaCredito
{
    public partial class CargaDeCredito : Form
    {
        private CommonQueries commonQueries_instance = CommonQueries.getInstance();
        private string username = (Singleton_Usuario.getInstance()).get_username();
        conexionBD conexion_class = conexionBD.getConexion();
        SqlConnection conexion_sql;
        Singleton_Usuario sesion = Singleton_Usuario.getInstance();

        private int saldo;


        public CargaDeCredito()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void CargaDeCredito_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion_class.get_cadena());

            if (!sesion.verificar_rol_administrador())
            {
                cbo_usuarios.Text = username;
                this.cargar_saldoactual();
            }
            else
            {
                txt_saldo.Text = "No Disponible";
            }
            this.cargar_combobox();

            commonQueries_instance.cargar_objeto(cbo_usuarios, "CLIENTES");
            cbo_usuarios.SelectedIndex = 0;
        }

        private void cargar_combobox()
        {
            combobox_tipopago.Items.Add("Credito");
            combobox_tipopago.Items.Add("Debito");
        }

        private void cargar_saldoactual()
        {
            string query = "SELECT DineroDisponible FROM ZTS_DB.Clientes where username = '" + sesion.get_username() + "'";
            SqlCommand cmd = new SqlCommand(query, conexion_sql);

            conexion_sql.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txt_saldo.Text = "$" + (reader[0].ToString());
                this.saldo = Int32.Parse(reader[0].ToString());
            }

            conexion_sql.Close();
        }


        public static string GetEntradaConfig(string Key, string DefaultValue = "")
        {
            string s = ConfigurationManager.AppSettings[Key];
            if (!string.IsNullOrEmpty(s))
            {
                return s;
            }
            else
            {
                return DefaultValue;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_cargar_Click(object sender, EventArgs e)
        {
            string Fecha = GetEntradaConfig("fecha");

            if (this.verificar_parametros()) { return; }

            conexion_sql.Open();
            try
            {
                SqlCommand persistir_carga = new SqlCommand("ZTS_DB.persistir_carga", conexion_sql);
                persistir_carga.CommandType = CommandType.StoredProcedure;

                if (!sesion.verificar_rol_administrador())
                {
                    persistir_carga.Parameters.AddWithValue("@username", SqlDbType.Char).Value = sesion.get_username();
                }
                else
                {
                    persistir_carga.Parameters.AddWithValue("@username", SqlDbType.Char).Value = cbo_usuarios.Text;
                }

                persistir_carga.Parameters.AddWithValue("@tarjeta_nro", SqlDbType.Float).Value = Int64.Parse(txt_num_tarjeta.Text);
                persistir_carga.Parameters.AddWithValue("@cod_segu", SqlDbType.Float).Value = Int32.Parse(txt_cod_segu.Text);
                persistir_carga.Parameters.AddWithValue("@tipo_tarj", SqlDbType.Char).Value = combobox_tipopago.SelectedItem.ToString();
                persistir_carga.Parameters.AddWithValue("@monto", SqlDbType.Float).Value = Int32.Parse(txt_monto.Text);
                persistir_carga.Parameters.AddWithValue("@fecha", SqlDbType.Char).Value = Fecha;

                persistir_carga.ExecuteNonQuery();

                MessageBox.Show("Carga Realizada con Exito", "Carga de Saldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!sesion.verificar_rol_administrador())
                {
                    txt_saldo.Text = "$" + (this.saldo + Int32.Parse(txt_monto.Text)).ToString();
                }
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion_sql.Close();


        }

        private bool verificar_parametros()
        {
            List<String> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).Select(p => p.Text).ToList();
            int index = combobox_tipopago.SelectedIndex;

            if (lista_textBoxs.Any(cadena => cadena == String.Empty))
            {
                MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (string.IsNullOrEmpty(cbo_usuarios.Text))
            {
                MessageBox.Show("Seleccione un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (index == -1)
            {
                MessageBox.Show("Seleccione el tipo de Tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_num_tarjeta.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("El Numero de tarjeta es un campo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_cod_segu.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("El código de seguridad es un campo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_monto.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("El monto es un campo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_num_tarjeta.Text.Length != 16)
            {
                MessageBox.Show("El Numero de tarjeta debe ser unicamente de 16 digitos numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (txt_cod_segu.Text.Length != 3)
            {
                MessageBox.Show("El Codigo de seguridad debe ser unicamente de 3 digitos numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (Int32.Parse(txt_monto.Text) <= 0)
            {
                MessageBox.Show("El monto debe ser numerico y mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
        }

        private void txt_saldo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}