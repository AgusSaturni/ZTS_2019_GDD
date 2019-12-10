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
using System.Configuration;
using FrbaOfertas.Manejo_Logico;



namespace FrbaOfertas.ComprarOferta
{
    public partial class Ofertas : Form
    {
      

        public Ofertas()
        {
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void contenedor_ofertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (contenedor_ofertas.Rows.Count == 0)
            {
                MessageBox.Show("Aplique algun filtro.");
                return;
            }
            if (contenedor_ofertas.CurrentCell.ColumnIndex == 0)
            {
                var row = contenedor_ofertas.CurrentRow;

                string descripcion_semilla = row.Cells[1].Value.ToString();
                string proveedor_semilla = row.Cells[7].Value.ToString();
                float precio_lista_semilla = float.Parse(row.Cells[3].Value.ToString());
                float precio_oferta_semilla = float.Parse(row.Cells[2].Value.ToString());
                float precio_oferta = float.Parse(row.Cells[2].Value.ToString());
                float precio_lista = float.Parse(row.Cells[3].Value.ToString());       
                int cantidadDispo = Int32.Parse(row.Cells[5].Value.ToString());
                int cantMaxUser = Int32.Parse(row.Cells[6].Value.ToString());

                Form comprar = new ComprarOferta.CantidadAComprar(descripcion_semilla,proveedor_semilla,precio_lista_semilla,precio_oferta_semilla,precio_oferta,precio_lista,cantidadDispo,cantMaxUser);
                comprar.Show();

            }

        }

        private void txt_apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            string query = crear_query_oferta(Descripcion.Text, minimo.Text, maximo.Text);

            if (minimo.Text.Any(x => !char.IsNumber(x)) || maximo.Text.Any(x => !char.IsNumber(x)))
            {
                MessageBox.Show("Valores de precios erroneos. Solo se permiten numeros ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            if (query == "") { MessageBox.Show("Ingrese Parametros"); }
            else
            {
                conexionBD conexion = conexionBD.getConexion();

                SqlConnection conn = new SqlConnection(conexion.get_cadena());

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                conn.Open();

                DataTable tabla_clientes = new DataTable();

                adapter.Fill(tabla_clientes);

                contenedor_ofertas.DataSource = tabla_clientes;
                conn.Close();
            }

        }

        private string crear_query_oferta(String descripcion, string minimo, string maximo)
        {
            StringBuilder sb = new StringBuilder();

            string fecha = ConfigurationManager.AppSettings["fecha"].ToString();


            sb.Append("SELECT DISTINCT Descripcion, precio_oferta,Precio_lista,fecha_vencimiento,Cantidad_disponible,cantidad_maxima_por_usuario,proveedor_referenciado from ofertas where fecha_vencimiento >= " + "'" + fecha + "'" + " AND " + "fecha_publicacion <= " + "'" + fecha + "'" + " AND Cantidad_disponible > 0 AND ");

            ArrayList Query = new ArrayList();

            if (descripcion != "")
            {
                Query.Add("Descripcion LIKE '%" + descripcion + "%'");
            }
            if (minimo != "" && maximo != "")
            {
                string cadena = "precio_lista between " + minimo + "and " + maximo;
                Query.Add(cadena);
            }

            if (Query.Count == 0) { return ""; }
            else
            {
                string[] vector_query = Query.ToArray(typeof(string)) as string[];
                string query_final = string.Join(" AND ", vector_query);

                sb.Append(query_final);

                return sb.ToString();
                
            }
            
        }

        private void bt_limpiar_Click(object sender, EventArgs e)
        {
            limpiar_form();
        }

        private void limpiar_form() //Verificar alternativas
        {
            Form compraOferta = new ComprarOferta.Ofertas();
            compraOferta.Show();
            this.Close();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
            this.Close();
        }


    }
}



