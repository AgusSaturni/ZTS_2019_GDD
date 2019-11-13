﻿using System;
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
        public Modificaciones_Proveedores()
        {
            InitializeComponent();
        }

        private void bt_habilitar_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            try
            {
                SqlCommand command = new SqlCommand("habilitar_proveedor", conexion_sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cuit", SqlDbType.Int).Value = (txt_CUIT.Text);

                conexion_sql.Open();
                command.ExecuteNonQuery();
                conexion_sql.Close();

                MessageBox.Show("Proveedor Habilitado");

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            this.Hide();
        }

        private void bt_modificar_Click(object sender, EventArgs e)
        {
            txt_RazonSoc.ReadOnly = false;
            txt_CUIT.ReadOnly = false;
            txt_Rubro.ReadOnly = false;
            txt_email.ReadOnly = false;      
            txt_telefono.ReadOnly = false;
            txt_Contacto.ReadOnly = false;

            txt_direccion.ReadOnly = false;
            txt_ciudad.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_depto.ReadOnly = false;
            txt_piso.ReadOnly = false;
            txt_codigopostal.ReadOnly = false;
            txt_localidad.ReadOnly = false;
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());


            if (txt_RazonSoc.ReadOnly == true)
            {
                MessageBox.Show("Modifique algun parametro");
                return;
            }
            try
            {
                SqlCommand command = new SqlCommand("actualizar_proveedor", conexion_sql);
                command.CommandType = CommandType.StoredProcedure;


                //Si dejo espacios vacios en los TXT, el Int32.parse me tira error (Esto sucede para los datos numericos). Hay q revisar eso
                command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = (txt_username.Text);
                command.Parameters.AddWithValue("@razonSocial", SqlDbType.Char).Value = (txt_RazonSoc.Text);
                command.Parameters.AddWithValue("@rubro", SqlDbType.Char).Value = (txt_Rubro.Text);
                command.Parameters.AddWithValue("@CUIT", SqlDbType.Char).Value = txt_CUIT.Text;
                command.Parameters.AddWithValue("@telefono", SqlDbType.Float).Value = Int64.Parse(txt_telefono.Text);
                command.Parameters.AddWithValue("@mail", SqlDbType.Char).Value = (txt_email.Text);
                command.Parameters.AddWithValue("@contacto", SqlDbType.Char).Value = (txt_Contacto.Text);

                command.Parameters.AddWithValue("@direccion", SqlDbType.Char).Value = (txt_direccion.Text);
                command.Parameters.AddWithValue("@CP", SqlDbType.Int).Value = Int32.Parse(txt_codigopostal.Text);
                command.Parameters.AddWithValue("@Loc", SqlDbType.Char).Value = (txt_localidad.Text);
                command.Parameters.AddWithValue("@Npiso", SqlDbType.Int).Value = Int32.Parse(txt_piso.Text);
                command.Parameters.AddWithValue("@depto", SqlDbType.Char).Value = (txt_depto.Text);

                conexion_sql.Open();
                command.ExecuteNonQuery();
                conexion_sql.Close();

                MessageBox.Show("Proveedor Modificado");

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            this.Hide();
        }

        private void txt_estado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
