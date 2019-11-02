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
         string username;

        public CargaDeCredito()
        {
            InitializeComponent();
        }

        public CargaDeCredito(string username_recibido)
        {
            InitializeComponent();
            this.username = username_recibido;
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
            this.Visible = false;
            Form menuCliente = new AbmCliente.MenuCliente();
            menuCliente.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadenaConex = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
            SqlConnection conn = new SqlConnection(cadenaConex);
            
           try
            {
                conn.Open();
                string nroTarjeta = NroTarjeta.Text;
                string codSegu = CodSegu.Text;
                string monto = Monto.Text;
                int indice =TipoPago.SelectedIndex;
                string fecha = GetEntradaConfig("fecha");
                
                    if (indice != -1 && monto != "" && nroTarjeta != "" && codSegu != "")
                          {
                           if(nroTarjeta.Length == 16 && codSegu.Length == 3)
                           {
                            object TipoDePago = TipoPago.Items[indice];
                            int monto_entero = Int32.Parse(monto);

                            SqlCommand command = new SqlCommand("cargar_saldo", conn);
                            command.CommandType = CommandType.StoredProcedure;

                            SqlParameter username1 = new SqlParameter("@username", SqlDbType.Char);
                            username1.Direction = ParameterDirection.Input;
                            command.Parameters.Add(username1);

                            SqlParameter tarjetaNro = new SqlParameter("@tarjeta_nro", SqlDbType.Float);
                            tarjetaNro.Direction = ParameterDirection.Input;
                            command.Parameters.Add(tarjetaNro);

                            SqlParameter codsegu1 = new SqlParameter("@cod_segu", SqlDbType.Float);
                            codsegu1.Direction = ParameterDirection.Input;
                            command.Parameters.Add(codsegu1);

                            SqlParameter tipo_pago1 = new SqlParameter("@tipo_pago", SqlDbType.Char);
                            tipo_pago1.Direction = ParameterDirection.Input;
                            command.Parameters.Add(tipo_pago1);

                            SqlParameter monto1 = new SqlParameter("@monto", SqlDbType.Int);
                            monto1.Direction = ParameterDirection.Input;
                            command.Parameters.Add(monto1);

                            SqlParameter fecha1 = new SqlParameter("@fecha", SqlDbType.Char);
                            username1.Direction = ParameterDirection.Input;
                            command.Parameters.Add(fecha1);

                            username1.Value = username;
                            tarjetaNro.Value = nroTarjeta;
                            codsegu1.Value = codSegu;
                            tipo_pago1.Value = TipoDePago.ToString();
                            monto1.Value = monto;
                            fecha1.Value = fecha;

                          
                            command.ExecuteNonQuery();
                            MessageBox.Show("Carga realizada con éxito");

                           }else
                           {
                               MessageBox.Show("Datos de la tarjeta Invalidos");
                             }
                    }
                    else {
                    MessageBox.Show("Faltan completar campos.");
                }
                    conn.Close();
           }

           catch (System.FormatException)
           {
                MessageBox.Show("El monto debe ser un numero entero");
          }
           catch (System.Data.SqlClient.SqlException)
           {
               MessageBox.Show("Error datos de tarjeta inválidos");
           }
        }
    }
}
