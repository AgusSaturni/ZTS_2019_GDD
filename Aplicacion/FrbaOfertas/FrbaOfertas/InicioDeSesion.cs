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

namespace FrbaOfertas
{
    public partial class InicioDeSesion : Form
    {
        public InicioDeSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form registroUsuario = new RegistroUsuario();
            registroUsuario.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadenaConex = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
            SqlConnection conn = new SqlConnection(cadenaConex);

            conn.Open();

            SqlCommand command = new SqlCommand("verificar", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlCommand command1 = new SqlCommand("verificar_rol_administrador", conn);
            command1.CommandType = CommandType.StoredProcedure;

            SqlCommand command2 = new SqlCommand("verificar_rol_cliente", conn);
            command2.CommandType = CommandType.StoredProcedure;

            SqlCommand command3 = new SqlCommand("verificar_rol_proveedor", conn);
            command3.CommandType = CommandType.StoredProcedure;



            SqlParameter username = new SqlParameter("@Username", SqlDbType.Char);
            username.Direction = ParameterDirection.Input;
            command.Parameters.Add(username);

            SqlParameter username1 = new SqlParameter("@Username", SqlDbType.Char);
            username.Direction = ParameterDirection.Input;
            command1.Parameters.Add(username1);

            SqlParameter username2 = new SqlParameter("@Username", SqlDbType.Char);
            username.Direction = ParameterDirection.Input;
            command2.Parameters.Add(username2);

            SqlParameter username3 = new SqlParameter("@Username", SqlDbType.Char);
            username.Direction = ParameterDirection.Input;
            command3.Parameters.Add(username3);

            SqlParameter password = new SqlParameter("@Password", SqlDbType.Char);
            password.Direction = ParameterDirection.Input;
            command.Parameters.Add(password);

            username.Value = Usuario.Text;
            username1.Value = Usuario.Text;
            username2.Value = Usuario.Text;
            username3.Value = Usuario.Text;
            password.Value = Password.Text;

            try
            {
                command.ExecuteNonQuery();

                try
                {
                    command1.ExecuteNonQuery();
                    Form menuABM = new MenuABM();
                    menuABM.Show();
                    this.Visible = false;
                    return;
                }
                catch
                {
                    try
                    {
                       
                        command2.ExecuteNonQuery();
                        Form menuCliente = new AbmCliente.MenuCliente(Usuario.Text);
                        menuCliente.Show();
                        this.Visible = false;
                        return;

                    }
                    catch { }
                }
            }
            catch {
                MessageBox.Show("Error de logueo, Usuario o Contraseña INVALIDOS");
            }

            conn.Close();
        }
    }
    
}
