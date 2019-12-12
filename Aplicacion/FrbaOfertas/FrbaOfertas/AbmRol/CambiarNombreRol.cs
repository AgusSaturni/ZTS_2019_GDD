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
    public partial class CambiarNombreRol : Form
    {

        private conexionBD conexion_sql = conexionBD.getConexion();
        private SqlConnection conexion;

        public CambiarNombreRol(string nombre)
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            txt_rol.Text = nombre;
        }

        private void bt_cambiar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("ZTS_DB.Actulizar_nombre_rol", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_rol_nuevo", SqlDbType.Char).Value = txt_nombre.Text.Trim();
            cmd.Parameters.AddWithValue("@nombre_rol_viejo", SqlDbType.Char).Value = txt_rol.Text;

            conexion.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }
            conexion.Close();

            Form mod = new Modificacion_Roles();
            mod.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CambiarNombreRol_Load(object sender, EventArgs e)
        {
            conexion = new SqlConnection(conexion_sql.get_cadena());
        }
    }
}
