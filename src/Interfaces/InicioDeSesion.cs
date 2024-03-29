﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using FrbaOfertas.Manejo_Logico;

namespace FrbaOfertas
{
    public partial class InicioDeSesion : Form
    {
        //Para intentos de login
        private int contador = 0;

        public InicioDeSesion()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form registroUsuario = new RegistroUsuario("", this,0);
            registroUsuario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            SqlCommand verificacion_usuario = new SqlCommand("ZTS_DB.verificar_usuario", conexion_sql);
            verificacion_usuario.CommandType = CommandType.StoredProcedure;
            verificacion_usuario.Parameters.AddWithValue("@username", SqlDbType.Char).Value = Usuario.Text;

            SqlCommand verificacion_password = new SqlCommand("ZTS_DB.verificar_password", conexion_sql);
            verificacion_password.CommandType = CommandType.StoredProcedure;
            verificacion_password.Parameters.AddWithValue("@username", SqlDbType.Char).Value = Usuario.Text;
            verificacion_password.Parameters.AddWithValue("@password", SqlDbType.Char).Value = Password.Text;

            conexion_sql.Open();

            try
            {
                verificacion_usuario.ExecuteNonQuery();                       
                //verifico contraseña, si le error resto una chance
                try 
                {
                    verificacion_password.ExecuteNonQuery();
                              
                }
                catch (SqlException exepcion)
                {

                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString(),"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    contador++;
                    if (contador == 3)
                    {
                        contador = 0;
                        SqlCommand inhabilitar_usuario = new SqlCommand("ZTS_DB.inhabilitacion_usuario", conexion_sql);
                        inhabilitar_usuario.CommandType = CommandType.StoredProcedure;

                        SqlParameter username = new SqlParameter("@username", SqlDbType.Char);
                        username.Direction = ParameterDirection.Input;
                        inhabilitar_usuario.Parameters.Add(username);

                        username.Value = Usuario.Text;

                        inhabilitar_usuario.ExecuteNonQuery();
                    }
                    return;
                }

                contador = 0;

                //Ahora, cargamos el usuario y sus permisos. Al ser un singleton, se crea una sola vez, y
                // cuando cerramo sesion lo dejamos nulo. Patron en donde solo existe 1 objeto posible.
                this.crear_sesion(Usuario.Text.ToString());

                Form menu_principal = new Interfaces.menu_principal();
                menu_principal.Show();

                this.Visible = false;

              
            }
            catch (SqlException exepcion)
            {

                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            conexion_sql.Close();
        }

        private void InicioDeSesion_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void crear_sesion(string username)
        {
            Singleton_Usuario sesion = Singleton_Usuario.getInstance();
            sesion.set_username(username);
            sesion.cargar_usuario();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form cambiarContraseña = new AbmUsuarios.CambioContraseña();
            cambiarContraseña.Show();
            this.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }


}