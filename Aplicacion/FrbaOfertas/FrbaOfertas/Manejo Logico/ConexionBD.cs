using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class conexionBD
    {
        private static conexionBD instance = null;
        string cadena_conexion = @"Data Source=DESKTOP-8FI0R6N\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=agustin2424";

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
