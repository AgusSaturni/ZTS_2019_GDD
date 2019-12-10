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
using System.Collections;
using System.Collections.Generic;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
        private string crear_query_PorcentajeDescuentos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select top 5 proveedor_id ,coalesce(dbo.suma_porcentajes_de_ofertas(proveedor_Id,'" + Convert.ToDateTime(Desde.Value).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(Hasta.Value).ToString("yyyy-MM-dd") + "'),0)Porcentaje_de_Descuento,count(codigo_oferta) Cantidad_Ofertas_Publicadas from PROVEEDORES p join ofertas o on p.Proveedor_Id = o.Proveedor_referenciado where Fecha_publicacion between '" + Convert.ToDateTime(Desde.Value).ToString("yyyy-MM-dd") + "' and  '" + Convert.ToDateTime(Hasta.Value).ToString("yyyy-MM-dd") + "' group by p.proveedor_id order by 2 desc");


            return sb.ToString();

        }

        private string crear_query_MayorFacturacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select top 5 Proveedor_referenciado,sum(Precio_oferta * cantidad)FacturacionTotal, count(Factura_Id)Cantidad_De_facturas from COMPRAS c join OFERTAS o on c.Codigo_oferta=o.Codigo_Oferta where Factura_Id is not null and Fecha_compra between '" + Convert.ToDateTime(Desde.Value).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(Hasta.Value).ToString("yyyy-MM-dd") + "' group by Proveedor_referenciado order by 2 desc");

            return sb.ToString();

        }
        

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            if (MayorFacturacion.Checked == false && PorcentajeDescuento.Checked == false) { MessageBox.Show("Seleccione un tipo de Listado."); return; }
          
            conexionBD conexion = conexionBD.getConexion();

            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            conn.Open();

            try
            {
         

                SqlCommand command = new SqlCommand("verificar_Semestre", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fecha1", SqlDbType.Date).Value = Desde.Value;
                command.Parameters.AddWithValue("@fecha2", SqlDbType.Date).Value = Hasta.Value;

             
                command.ExecuteNonQuery();
           

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
                return;
            }

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
                MessageBox.Show(errores.Message.ToString());
            }
            conn.Close();
        }

 
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PorcentajeDescuento_CheckedChanged_1(object sender, EventArgs e)
        {
            if (PorcentajeDescuento.Checked == true)
            {
                MayorFacturacion.Enabled = false;
            }
            if (PorcentajeDescuento.Checked == false)
            {
                MayorFacturacion.Enabled = true;
            }
        }

        private void MayorFacturacion_CheckedChanged_1(object sender, EventArgs e)
        {
            if (MayorFacturacion.Checked == true)
            {
                PorcentajeDescuento.Enabled = false;
            }
            if (MayorFacturacion.Checked == false)
            {
                PorcentajeDescuento.Enabled = true;
            }
        }

        private void bt_limpiar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new Interfaces.menu_principal();
            menu.Show();
        }
    }
}
