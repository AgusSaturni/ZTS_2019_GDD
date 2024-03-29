﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Manejo_Logico
{
    class CommonQueries
    {
        private static CommonQueries instance = null;
        private CommonQueries() { }

        public static CommonQueries getInstance()
        {
            if(instance == null) {
                instance = new CommonQueries();
            }
        
            return instance;
        }

        public SqlDataReader get_all_roles(SqlConnection conexion_actual) 
        {
            String query = "SELECT * FROM ZTS_DB.ROLES";
            SqlCommand cmd = new SqlCommand(query, conexion_actual);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public SqlDataReader get_all_funciones(SqlConnection conexion_actual)
        {
            String query = "select Descripcion from ZTS_DB.Funciones";
            SqlCommand cmd = new SqlCommand(query, conexion_actual);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void insert_funciones_por_rol(string rol, string funcionId, SqlConnection conexion_actual) 
        {
            SqlCommand cmd = new SqlCommand("ZTS_DB.insertar_funciones_por_rol", conexion_actual);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol_Id", rol);
            cmd.Parameters.AddWithValue("@funcionID", funcionId);

            cmd.ExecuteNonQuery();
        }

        public void vereificar_estado_rol(String Rol, SqlConnection conexion_actual) 
        {
            SqlCommand cmd = new SqlCommand("ZTS_DB.verificar_estado_rol", conexion_actual);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol_Id", Rol);

            cmd.ExecuteNonQuery();
        }

        //Dado que los procedures pueden tener algunos valores nulos, asigno solo los que se ingresaron
        public void filtrar_nulos(SqlCommand procedure, string codigo_postal, string localidad, string piso, string depto)
        {
            if (!string.IsNullOrEmpty(codigo_postal.Trim()))
            {
                procedure.Parameters.AddWithValue("@CP", SqlDbType.Int).Value = Int32.Parse(codigo_postal);
            }
            if (!string.IsNullOrEmpty(localidad.Trim()))
            {
                procedure.Parameters.AddWithValue("@Loc", SqlDbType.Char).Value = (localidad);
            }
            if (!string.IsNullOrEmpty(piso.Trim()))
            {
                procedure.Parameters.AddWithValue("@Npiso", SqlDbType.Int).Value = Int32.Parse(piso);
            }
            if (!string.IsNullOrEmpty(depto.Trim()))
            {
                procedure.Parameters.AddWithValue("@depto", SqlDbType.Char).Value = (depto);
            }

        }

        public SqlDataReader select_rubros_disponibles(SqlConnection conexion_actual) 
        {
            String query = "select rubro_descripcion from ZTS_DB.RUBROS";
            SqlCommand cmd = new SqlCommand(query, conexion_actual);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void cargar_objeto(ComboBox cmb_objeto, string tabla) 
        {
            List<String> listado = new List<String>();

            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open();

            string consulta_clientes = "SELECT DISTINCT username FROM zts_db." + tabla;

            SqlCommand cmd = new SqlCommand(consulta_clientes, conexion_sql);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[0].ToString() != "")
                {
                    listado.Add(reader[0].ToString().Trim());

                }
            }
            conexion_sql.Close();

            for (int i = 0; i < listado.Count(); i++)
            {
                cmb_objeto.Items.Add(listado.ElementAt(i).ToString());
            }
        }    
    }
}
