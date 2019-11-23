﻿using FrbaOfertas.Manejo_Logico;
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

namespace FrbaOfertas.AbmRol
{
    public partial class Modificacion_Roles : Form
    {
        public Modificacion_Roles()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void Modificacion_Roles_Load(object sender, EventArgs e)
        {
            
            this.cargar_comboBox();
        }

        private void cargar_estado(String item_seleccionado) 
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            string query = "SELECT Estado FROM ROLES where Rol_Id = '" + item_seleccionado + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txt_estado.Text = (reader[0].ToString());
            }
            conn.Close();
            
        }

        private void cargar_comboBox()
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            String query = "SELECT * FROM ROLES";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox_roles.Items.Add(reader[0].ToString());
            }
            conn.Close();

        }

        private void cargar_funciones_totales_disponibles() 
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            //CARGA DE PRIMERA LISTA

            String query = "select Descripcion from FUNCIONES_POR_ROL FPR join FUNCIONES F on FPR.Funcion_Id = F.Funcion_Id where Rol_Id = '" + comboBox_roles.SelectedItem.ToString() + "'"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader1 = cmd.ExecuteReader();

            while (reader1.Read())
            {
                list_rol.Items.Add(reader1[0].ToString());
            }

            conn.Close();
        }

        private void cargar_funciones_totales_sistema()
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            //CARGA DE SEGUNDA LISTA

            String query = "select Descripcion from Funciones";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader2 = cmd.ExecuteReader();

            while (reader2.Read())
            {
                if (!list_rol.Items.Contains(reader2[0].ToString())) 
                {
                    list_totales.Items.Add(reader2[0].ToString());
                }

            }

            conn.Close();
        }

        private void bt_seleccionar_Click(object sender, EventArgs e)
        {
            int indice = comboBox_roles.SelectedIndex;
            if (indice != -1)
            {
                list_rol.Items.Clear();
                list_totales.Items.Clear();
                this.cargar_funciones_totales_disponibles();
                this.cargar_funciones_totales_sistema();
                this.cargar_estado(comboBox_roles.SelectedItem.ToString());
            }
            else { MessageBox.Show("Seleccione un Rol"); }
            
            
        }

        private void bt_izq_a_der_Click(object sender, EventArgs e)
        {
            int indice = list_totales.SelectedIndex;
            if (indice != -1)
            {
                if (!list_rol.Items.Contains(list_totales.SelectedItem))
                {
                    list_rol.Items.Add(list_totales.SelectedItem);
                    list_totales.Items.Remove(list_totales.SelectedItem);
                }
                else { MessageBox.Show("La funcion ya se encuentra asignada al Rol seleccionado"); }
            }
            else { MessageBox.Show("Seleccione una funcion del sistema para agregar al rol");  }

        }

        private void bt_der_a_izq_Click(object sender, EventArgs e)
        {
            int indice = list_rol.SelectedIndex;
            if (indice != -1)
            {
                if (!list_totales.Items.Contains(list_rol.SelectedItem))
                {
                    list_totales.Items.Add(list_rol.SelectedItem);
                    list_rol.Items.Remove(list_rol.SelectedItem);
                }
                else { MessageBox.Show("La funcion ya se encuentra asignada al Rol seleccionado"); }
            }
            else { MessageBox.Show("Seleccione una funcion asignada al rol para removerla"); }
        }

        private void bt_finalizar_Click(object sender, EventArgs e)
        {

        }

        private void bt_deshabilitar_rol_Click(object sender, EventArgs e)
        {
            if (txt_estado.Text == "") 
            {
                MessageBox.Show("Seleccione un Rol");
                return;
            }

            DialogResult result = MessageBox.Show("Seguro que desea dar de baja al Rol seleccionado?", "WARNING", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                conexionBD conexion = conexionBD.getConexion();
                SqlConnection conn = new SqlConnection(conexion.get_cadena());

                SqlCommand command = new SqlCommand("deshabilitar_rol", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Rol_Id", SqlDbType.Char).Value = comboBox_roles.SelectedItem.ToString();

                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rol Deshabilitado");
                    txt_estado.Text = "Deshabilitado";
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                }
                conn.Close();


            } 

        }

        private void bt_habilitar_rol_Click(object sender, EventArgs e)
        {
            if (txt_estado.Text == "")
            {
                MessageBox.Show("Seleccione un Rol");
                return;
            }

            DialogResult result = MessageBox.Show("Seguro que desea dar de alta al Rol seleccionado?", "WARNING", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                conexionBD conexion = conexionBD.getConexion();
                SqlConnection conn = new SqlConnection(conexion.get_cadena());

                SqlCommand command = new SqlCommand("habilitar_rol", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Rol_Id", SqlDbType.Char).Value = comboBox_roles.SelectedItem.ToString();

                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rol Habilitado");
                    txt_estado.Text = "Habilitado";
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                }
                conn.Close();


            }
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu_roles = new MenuAdmin.ABMRoles();
            menu_roles.Show();

        }
    }
}