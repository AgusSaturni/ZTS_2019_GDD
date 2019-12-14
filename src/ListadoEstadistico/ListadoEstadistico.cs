using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        private string fecha_desde;
        private string fecha_hasta;

        public ListadoEstadistico()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            dtp_año.Format = DateTimePickerFormat.Custom;
            dtp_año.CustomFormat = "yyyy";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
        private string crear_query_PorcentajeDescuentos()
        {
            StringBuilder sb = new StringBuilder();

            cargar_fechas();

            sb.Append("select top 5 proveedor_id ,coalesce(ZTS_DB.suma_porcentajes_de_ofertas(proveedor_Id,'" + fecha_desde + "','" + fecha_hasta + "'),0)Porcentaje_de_Descuento,count(o.codigo_oferta) AS 'Cantidad Ofertas Publicadas', SUM(c.Cantidad) AS 'Cantidad de Ofertas Vendidas' from ZTS_DB.PROVEEDORES p join ZTS_DB.ofertas o on p.Proveedor_Id = o.Proveedor_referenciado join ZTS_DB.COMPRAS c on o.codigo_oferta=c.codigo_oferta where Fecha_publicacion between '" + fecha_desde + "' and  '" + fecha_hasta + "' group by p.proveedor_id order by 2 desc");
            
            return sb.ToString();
        }

        private string crear_query_MayorFacturacion()
        {
            StringBuilder sb = new StringBuilder();

            cargar_fechas();

            sb.Append("select top 5 Proveedor_referenciado,sum(Precio_oferta * cantidad)FacturacionTotal, count(Factura_Id)Cantidad_De_facturas from ZTS_DB.COMPRAS c join ZTS_DB.OFERTAS o on c.Codigo_oferta=o.Codigo_Oferta where Factura_Id is not null and Fecha_compra between '" + fecha_desde + "' and '" + fecha_hasta + "' group by Proveedor_referenciado order by 2 desc");

            return sb.ToString();
        }
        

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            if (MayorFacturacion.Checked == false && PorcentajeDescuento.Checked == false) { MessageBox.Show("Seleccione un tipo de Listado.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            else if (rbt_primer_semestre.Checked == false && rbt_segundo_semestre.Checked == false) { MessageBox.Show("Seleccione un semestre.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            conexionBD conexion = conexionBD.getConexion();

            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            conn.Open();

            try
            {
                if (PorcentajeDescuento.Checked == true)
                {

                    string query = crear_query_PorcentajeDescuentos();
         
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                   
                    DataTable tabla_proveedores = new DataTable();

                    adapter.Fill(tabla_proveedores);

                    contenedor_proveedores.DataSource = tabla_proveedores;

                }
                if (MayorFacturacion.Checked == true)
                {
                    string query = crear_query_MayorFacturacion();


                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                   
                    DataTable tabla_proveedores = new DataTable();

                    adapter.Fill(tabla_proveedores);

                    contenedor_proveedores.DataSource = tabla_proveedores;
                   
                }
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        
        private void PorcentajeDescuento_CheckedChanged_1(object sender, EventArgs e)
        {
            if (PorcentajeDescuento.Checked == true)
            {
                MayorFacturacion.Checked = false;
            }
        }

        private void MayorFacturacion_CheckedChanged_1(object sender, EventArgs e)
        {
            if (MayorFacturacion.Checked == true)
            {
                PorcentajeDescuento.Checked = false;
            }
        }

        private void bt_limpiar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new Interfaces.menu_principal();
            menu.Show();
        }

        private void cargar_fechas()
        {
            if (rbt_primer_semestre.Checked == true)
            {
                fecha_desde = dtp_año.Value.Year.ToString() + "-01-01";
                fecha_hasta = dtp_año.Value.Year.ToString() + "-06-30";
            }
            else
            {
                fecha_desde = dtp_año.Value.Year.ToString() + "-07-01";
                fecha_hasta = dtp_año.Value.Year.ToString() + "-12-31";
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            PorcentajeDescuento.Checked = false;
            MayorFacturacion.Checked = false;
            rbt_primer_semestre.Checked = false;
            rbt_segundo_semestre.Checked = false;
            dtp_año.Refresh();

            contenedor_proveedores.DataSource = null;
            contenedor_proveedores.Refresh();

        }
    }
}
