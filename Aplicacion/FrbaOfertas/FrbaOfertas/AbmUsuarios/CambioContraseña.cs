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

namespace FrbaOfertas.AbmUsuarios
{
    public partial class CambioContraseña : Form
    {
        public CambioContraseña()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

            conn.Open();

            SqlCommand command = new SqlCommand("modificar_password", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter username = new SqlParameter("@username", SqlDbType.Char);
            username.Direction = ParameterDirection.Input;
            command.Parameters.Add(username);


            SqlParameter password_vieja = new SqlParameter("@vieja_password", SqlDbType.Char);
            password_vieja.Direction = ParameterDirection.Input;
            command.Parameters.Add(password_vieja);

            SqlParameter password_nueva= new SqlParameter("@nueva_password", SqlDbType.Char);
            password_nueva.Direction = ParameterDirection.Input;
            command.Parameters.Add(password_nueva);

            username.Value = Usuario.Text;
            password_vieja.Value = passwordV.Text;
            password_nueva.Value = passwordN.Text;

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Hecho");
                this.Visible = false;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }
           
            conn.Close();
            

        }
    }
}
