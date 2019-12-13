using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas.Manejo_Logico
{
    class Singleton_Usuario
    {
        conexionBD conexion = conexionBD.getConexion();
        private static Singleton_Usuario instance = null;
        private List<String> Roles = new List<String>();
        private List<String> Permisos = new List<String>();
        private String username;

        private Singleton_Usuario() { }

        public static Singleton_Usuario getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton_Usuario();
            }

            return instance;
        }

        public void cerrar_sesion()
        {
            username = "";
            Roles.Clear();
            Permisos.Clear();
            instance = null;
        }

        public void cargar_usuario()
        {

            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

            conexion_sql.Open();
            //------------------------------------------------------------Ojo si tira error hacer trim del username
            string consulta_roles = "SELECT DISTINCT RPU.Rol_Id, F.Descripcion  FROM ZTS_DB.ROLES_POR_USUARIO RPU JOIN ZTS_DB.FUNCIONES_POR_ROL FPR on RPU.Rol_Id = FPR.Rol_Id JOIN ZTS_DB.FUNCIONES F on F.Funcion_Id = FPR.Funcion_Id where RPU.Username = '" + username + "'";

            SqlCommand cmd = new SqlCommand(consulta_roles, conexion_sql);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader[0].ToString() != "")
                {
                    if (!Roles.Any(x => x == reader[0].ToString().Trim()))
                    {
                        Roles.Add(reader[0].ToString().Trim());
                    }
                    Permisos.Add(reader[1].ToString().Trim());

                }
            }
            conexion_sql.Close();
        }

        public void set_username(string user)
        {
            this.username = user;
        }

        public bool verificar_rol_administrador()
        {
            if (Roles.Any(x => x == "Administrador"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<String> get_permisos() { return this.Permisos; }
        public List<String> get_roles() { return this.Roles; }
        public String get_username() { return this.username; }
    }

}