using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            String query = "SELECT * FROM ROLES";
            SqlCommand cmd = new SqlCommand(query, conexion_actual);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public SqlDataReader get_all_funciones(SqlConnection conexion_actual)
        {
            String query = "select Descripcion from Funciones";
            SqlCommand cmd = new SqlCommand(query, conexion_actual);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void insert_funciones_por_rol(string rol, string funcionId, SqlConnection conexion_actual) 
        {
            SqlCommand cmd = new SqlCommand("insertar_funciones_por_rol", conexion_actual);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol_Id", rol);
            cmd.Parameters.AddWithValue("@funcionID", funcionId);

            cmd.ExecuteNonQuery();
        }

        public void vereificar_estado_rol(String Rol, SqlConnection conexion_actual) 
        {
            SqlCommand cmd = new SqlCommand("verificar_estado_rol", conexion_actual);
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
            String query = "select rubro_descripcion from RUBROS";
            SqlCommand cmd = new SqlCommand(query, conexion_actual);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
    
    }
}
