using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace FrbaOfertas.AbmCliente
{
    public partial class frm_listado_clientes : Form
    {
        public frm_listado_clientes()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {


        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {

            string query = crear_query_listadoC(txt_nombre.Text, txt_apellido.Text, txt_DNI.Text, txt_email.Text);

            if (query == "") { MessageBox.Show("Ingrese Parametros"); }
            else
            {
                string cadena_conexion = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
                SqlConnection conn = new SqlConnection(cadena_conexion);


                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                conn.Open();

                DataTable tabla_clientes = new DataTable();
                adapter.Fill(tabla_clientes);

                contenedor_clientes.DataSource = tabla_clientes;
                conn.Close();
            }

        }

        private string crear_query_listadoC(String nombre, String Apellido, String DNI, String EMAIL)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM CLIENTES WHERE ");

            ArrayList Query = new ArrayList();

            if (nombre != "")
            {
                Query.Add("Nombre LIKE '%" + nombre + "%'");
            }
            if (Apellido != "")
            {
                string cadena = "Apellido LIKE '%" + Apellido + "%'";
                Query.Add(cadena);
            }
            if (DNI != "")
            {
                Query.Add("DNI = '" + DNI + "'");
            }
            if (EMAIL != "")
            {
                Query.Add("Mail LIKE '%" + EMAIL + "%'");
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

     

        private void contenedor_clientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }


        private void bt_limpiar_Click_1(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_DNI.Text = "";
            txt_email.Text = "";
        }

        private void contenedor_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (contenedor_clientes.CurrentCell.ColumnIndex == 0)
            {
                var row = contenedor_clientes.CurrentRow;

                bajasClientes formulario_bajas = new bajasClientes();

                formulario_bajas.txt_id.Text = row.Cells[2].Value.ToString();
                formulario_bajas.txt_nombre.Text = row.Cells[3].Value.ToString();
                formulario_bajas.txt_apellido.Text = row.Cells[4].Value.ToString();
                formulario_bajas.txt_dni.Text = row.Cells[5].Value.ToString();
                formulario_bajas.txt_direccion.Text = row.Cells[6].Value.ToString();
                formulario_bajas.txt_telefono.Text = row.Cells[7].Value.ToString();
                formulario_bajas.txt_email.Text = row.Cells[8].Value.ToString();
                formulario_bajas.txt_fecha.Text = row.Cells[9].Value.ToString();
                formulario_bajas.txt_estado.Text = row.Cells[10].Value.ToString();


                formulario_bajas.Show();

            }
        }
    }
}
