using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class conexionBD
    {
        private static conexionBD instance = null;
        string cadena_conexion = (ConfigurationManager.AppSettings["string_conexion"].ToString());
        private conexionBD() { }

        public static conexionBD getConexion()
        {
            if(instance == null) {
                instance = new conexionBD();
            }

            return instance;
        }
        public string get_cadena()
        {
            return cadena_conexion;
        }

   }
}
