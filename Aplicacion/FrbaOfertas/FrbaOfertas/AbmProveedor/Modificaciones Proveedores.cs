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
            conexionBD cadena_conexion = new conexionBD();
            SqlConnection conexion = new SqlConnection(cadena_conexion.get_conexion());

            try
            {
                SqlCommand command = new SqlCommand("habilitar_proveedor", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cuit", SqlDbType.Int).Value = (txt_CUIT.Text);

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();

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
    }
}
