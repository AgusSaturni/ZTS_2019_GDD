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
using System.Configuration;

namespace FrbaOfertas.Facturar
{
    public partial class FacturarProveedor : Form
    {
        private conexionBD conexion = conexionBD.getConexion();
        private SqlConnection conexion_sql;

        private string username = (Singleton_Usuario.getInstance()).get_username();
        private string proveedor_id;

        public FacturarProveedor()
        {
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
            conexion_sql = new SqlConnection(conexion.get_cadena());
            btn_facturar.Enabled = false;
            dtp_desde.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
            dtp_hasta.Value = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
        }

        private void btn_facturar_Click(object sender, EventArgs e)
        {
            facturar_proveedor();
            btn_facturar.Enabled = false;
        }

        private void btn_visualizar_Click(object sender, EventArgs e)
        {
            lbl_facturado.Text = "0";

            conexion_sql.Open();

            verificar_campos();

            conexion_sql.Close();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
            this.Close();
        }

        private void verificar_campos()
        {
            if (string.IsNullOrEmpty(txt_proveedor.Text))
            {
                MessageBox.Show("El campo PROVEEDOR es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(cbo_visualizacion.Text))
            {
                MessageBox.Show("Debe ingresar un modo para VISUALIZAR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                conexion_sql.Close();
                visualizar();
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
            SqlCommand proveedor_existente = new SqlCommand("ZTS_DB.proveedor_existente", conexion_sql);
            proveedor_existente.CommandType = CommandType.StoredProcedure;
            proveedor_existente.Parameters.AddWithValue("@proveedor", SqlDbType.Char).Value = txt_proveedor.Text;

            try
            {
                proveedor_existente.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                return false;
            }
        }

        //----------------------------FACTURAR PROVEEDOR---------------------------------

        private void facturar_proveedor()
        {
            decimal sumatoria = 0;
            decimal facturado = 0;
            string compra_id;
            int factura_id;
            for (int i = 0; i < dgv_facturas.RowCount; i++)
            {
                factura_id = columna_numero();
                facturado = Convert.ToDecimal(dgv_facturas.Rows[i].Cells[3].Value);
                compra_id = dgv_facturas.Rows[i].Cells[2].Value.ToString();
                sumatoria += facturado;
                insertar_factura(factura_id, facturado);
                actualizar_compra(factura_id, compra_id);
            }
            lbl_facturado.Visible = true;
            lbl_facturado.Text = sumatoria.ToString();
            MessageBox.Show("Total Facturado: " + sumatoria.ToString(), "Facturado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void insertar_factura(int numero_id, decimal importe)
        {
            DateTime Fecha_Config = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            conexion_sql.Open();

            SqlCommand insertar_factura = new SqlCommand("ZTS_DB.insertar_factura", conexion_sql);
            insertar_factura.CommandType = CommandType.StoredProcedure;
            insertar_factura.Parameters.AddWithValue("@proveedor_id", SqlDbType.Char).Value = proveedor_id;
            insertar_factura.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = Fecha_Config;
            insertar_factura.Parameters.AddWithValue("@numero_id", SqlDbType.Int).Value = numero_id;
            insertar_factura.Parameters.AddWithValue("@importe", SqlDbType.Float).Value = importe;
            try
            {
               
                insertar_factura.ExecuteNonQuery();
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
            conexion_sql.Close();
        }

        private void actualizar_compra(int factura_id, string compra_id)
        {
            conexion_sql.Open();

            string query = "UPDATE ZTS_DB.COMPRAS SET Factura_id = '" + factura_id + "' WHERE Compra_Id = '" + compra_id + "'";
            SqlCommand actualizar_compra = new SqlCommand(query, conexion_sql);

            try
            {
                actualizar_compra.ExecuteNonQuery();
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conexion_sql.Close();
        }

        //----------------------------VISUALIZAR COMPRAS PROVEEDOR---------------------------------

        private void visualizar()
        {
            string query = creacion_query();

            conexion_sql.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion_sql);

            DataTable tabla_facturas = new DataTable();

            adapter.Fill(tabla_facturas);

            dgv_facturas.DataSource = tabla_facturas;

            conexion_sql.Close();
        }

        private string creacion_query()
        {
            proveedor_id = proveedor_Id();
            string fecha_desde = String.Format("{0:yyyy-MM-dd}", dtp_desde.Value);
            string fecha_hasta = String.Format("{0:yyyy-MM-dd}", dtp_hasta.Value);
            string visualizacion = "";

            if (cbo_visualizacion.Text == "No Facturado") {visualizacion = " AND com.Factura_Id IS NULL";}
            else if (cbo_visualizacion.Text == "Facturado") {visualizacion = " AND com.Factura_Id IS NOT NULL";}
            else if (cbo_visualizacion.Text == "Ambos") { visualizacion = ""; }

            //string query = "SELECT o.Codigo_Oferta, o.Descripcion, com.Compra_Id, Cantidad*Precio_oferta AS Facturado, com.Fecha_compra FROM COMPRAS com JOIN OFERTAS o ON o.Codigo_oferta = com.Codigo_oferta WHERE o.Proveedor_referenciado = '" + proveedor_id + "' AND com.Fecha_compra BETWEEN '" + fecha_desde + "' AND '" + fecha_hasta + "' AND com.Factura_Id IS NULL";
            string query = "SELECT o.Codigo_Oferta, o.Descripcion, com.Compra_Id, Cantidad*Precio_oferta AS Facturado, com.Fecha_compra FROM zts_db.COMPRAS com JOIN zts_db.OFERTAS o ON o.Codigo_oferta = com.Codigo_oferta WHERE o.Proveedor_referenciado = '" + proveedor_id + "' AND com.Fecha_compra BETWEEN '" + fecha_desde + "' AND '" + fecha_hasta + "'" + visualizacion;
            
            return query;
        }

        //--------------------------------AUXILIAR---------------------------------

        private string proveedor_Id()
        {
            conexion_sql.Open();

            string proveedor_Id = "";
            string query = "SELECT Proveedor_Id FROM ZTS_DB.PROVEEDORES WHERE username = '" + txt_proveedor.Text + "'";
            SqlCommand get_proveedorID = new SqlCommand(query, conexion_sql);

            SqlDataReader readIn = get_proveedorID.ExecuteReader();
            while (readIn.Read())
            {
                proveedor_Id = readIn[0].ToString();
            }
            conexion_sql.Close();

            return proveedor_Id;
        }

        private int columna_numero()
        {
            conexion_sql.Open();

            int numero_id = 0;
            string query = "SELECT MAX(Numero) FROM ZTS_DB.FACTURAS";
            SqlCommand get_facturaId_Max = new SqlCommand(query, conexion_sql);

            SqlDataReader readIn = get_facturaId_Max.ExecuteReader();
            while (readIn.Read())
            {
                numero_id = Convert.ToInt32(readIn[0].ToString());
            }
            conexion_sql.Close();

            return numero_id +1;
        }

        private void dgv_facturas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (cbo_visualizacion.Text == "No Facturado")
            {
                btn_facturar.Enabled = true;
            }
        }

        private void dgv_facturas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btn_facturar.Enabled = false;
        }

        private void cbo_visualizacion_TextChanged(object sender, EventArgs e)
        {
            dgv_facturas.DataSource = null;
            dgv_facturas.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
