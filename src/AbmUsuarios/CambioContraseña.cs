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
using FrbaOfertas.Manejo_Logico;

namespace FrbaOfertas.AbmUsuarios
{
    public partial class CambioContraseña : Form
    {
        public CambioContraseña()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private bool verificar_txts_vacios()
        {
            List<String> lista_textBoxs = Manejo_Logico.helperControls.GetControls<TextBox>(this).Select(p => p.Text).ToList();

            if (lista_textBoxs.Any(cadena => cadena == String.Empty))
            {
                return true;
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form inicioSesion = new InicioDeSesion();
            inicioSesion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());


            if (this.verificar_txts_vacios())
            {
                MessageBox.Show("Todos los campos son obligatorios", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            conn.Open();

            SqlCommand command = new SqlCommand("ZTS_DB.modificar_password", conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = Usuario.Text;
            command.Parameters.AddWithValue("@vieja_password", SqlDbType.Char).Value = passwordV.Text;
            command.Parameters.AddWithValue("@nueva_password", SqlDbType.Char).Value = passwordN.Text; 

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Contraseña Modificada.", "Modificacion de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                Form iniciar = new InicioDeSesion();
                iniciar.Show();

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordV.Text = "";
                passwordN.Text = "";
            }
           
            conn.Close();
            

        }

        private void CambioContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
