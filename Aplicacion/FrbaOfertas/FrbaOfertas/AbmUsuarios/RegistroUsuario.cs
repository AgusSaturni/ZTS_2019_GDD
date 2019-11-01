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
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indice =  Rol.SelectedIndex;
            string usuario;
            string password;
            object rol;

            usuario = Usuario.Text;        
            password = Password.Text;
            

            if (indice != -1 && usuario != "" && password != "")
            {
                rol = Rol.Items[indice];
                switch (rol.ToString())
                {
                    case "Cliente":
                        Form registroCliente = new AbmCliente.AltaCliente(usuario, password, rol.ToString());
                        this.Visible = false;
                        registroCliente.Show();
                        break;
                    case "Proveedor":
                        Form registroProveedor = new AbmProveedor.AltaProveedor(usuario, password, rol.ToString());
                        this.Visible = false;
                        registroProveedor.Show();
                        break;
                }
            }
            else {
                MessageBox.Show("Faltan completar campos");
            }
            /*          
         
                      string cadenaConex = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
                      SqlConnection conn= new SqlConnection(cadenaConex);

                      SqlCommand command = new SqlCommand("registrar_usuario",conn);
                      command.CommandType = CommandType.StoredProcedure;

                      SqlParameter username = new SqlParameter("@Username", SqlDbType.Char);
                      username.Direction = ParameterDirection.Input;
                      command.Parameters.Add(username);
         
                      SqlParameter password = new SqlParameter("@Password", SqlDbType.Char);
                      password.Direction = ParameterDirection.Input;
                      command.Parameters.Add(password);

                      SqlParameter rol = new SqlParameter("@Rol", SqlDbType.Char);
                      rol.Direction = ParameterDirection.Input;
                      command.Parameters.Add(rol);
      

                          username.Value = Usuario.Text;
                          password.Value = Password.Text;
     
                          if (indice == -1 || username.Value is Nullable || password.Value is Nullable)
                          {
                              MessageBox.Show("Faltan completar Campos");

                          }
                          else
                          {
                              rol.Value = Rol.Items[indice];
            
                              try
                              {
    
                                  string rolSeleccionado = rol.Value.ToString();                   
                                  switch (rolSeleccionado)
                                  {
                                      case "Cliente":
                                          Form registroCliente = new  AbmCliente.AltaCliente(username.Value,password.Value,rol.Value);
                                          registroCliente.Show();
                                          break;
                                  }
                              }
                              catch
                              {
                                  MessageBox.Show("Usuario ya existente, elija otro por favor");
                              }
                          }

                       */
                


        //    switch (1)
          //  {
          //      case "Administrativo":
                 
             //       break;
             //   case "Cliente":
                   
             //       break;
             //   case "Proveedor":

              //      break;
         //   }
        }

    }
}
