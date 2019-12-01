using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Manejo_Logico;
using System.Data.SqlClient;

namespace FrbaOfertas.Facturar
{
    public partial class FacturarProveedor : Form
    {
        private string username = (Singleton_Usuario.getInstance()).get_username();
        public FacturarProveedor()
        {
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void btn_facturar_Click(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open();

            verificar_campos(conexion_sql);

            conexion_sql.Close();
        }

        private void verificar_campos(SqlConnection conexion_sql)
        {
            if (string.IsNullOrEmpty(txt_proveedor.Text))
            {
                MessageBox.Show("El campo PROVEEDOR es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!rango_correcto())
            {
                MessageBox.Show("La fecha DESDE no puede ser mayor que la fecha HASTA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!proveedor_existente())
            {
                MessageBox.Show("El proveedor ingresado no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                facturar_proveedor();
                MessageBox.Show("okey", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------------------VERIFICACIONES---------------------------------

        private Boolean rango_correcto()
        {
            if (dtp_desde.Value.Date <= dtp_hasta.Value.Date) return true;
            else return false;
        }

        private Boolean proveedor_existente()
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open();

            SqlCommand proveedor_existente = new SqlCommand("proveedor_existente", conexion_sql);
            proveedor_existente.CommandType = CommandType.StoredProcedure;
            proveedor_existente.Parameters.AddWithValue("@proveedor", SqlDbType.Char).Value = txt_proveedor.Text;

            try
            {
                proveedor_existente.ExecuteNonQuery();
                conexion_sql.Close();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                conexion_sql.Close();
                return false;
            }

        }

        //----------------------------FACTURAR PROVEEDOR---------------------------------

        private void facturar_proveedor()
        {
            string query = creacion_query();
        
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion_sql);

            DataTable tabla_facturas = new DataTable();

            adapter.Fill(tabla_facturas);

            dgv_facturas.DataSource = tabla_facturas;

            conexion_sql.Close();
        }

        private string creacion_query()
        {
            string proveedor_id = proveedor_Id();

            string query = "SELECT * FROM FACTURAS WHERE Proveedor_Id = '" + proveedor_id + "' AND Fecha BETWEEN '2015-01-31' AND '2022-01-31'";
            return query;
        }

        private string proveedor_Id()
        {
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
            conexion_sql.Open();

            string proveedor_Id = "";
            string query = "SELECT Proveedor_Id FROM PROVEEDORES WHERE username = '" + txt_proveedor.Text + "'";
            SqlCommand pedir_proveedorID = new SqlCommand(query, conexion_sql);

            SqlDataReader readIn = pedir_proveedorID.ExecuteReader();
            while (readIn.Read())
            {
                proveedor_Id = readIn[0].ToString();
            }
            conexion_sql.Close();

            return proveedor_Id;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
            this.Close();
        }
    }
}
