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

namespace FrbaOfertas.AbmCliente
{
    public partial class frm_listado_clientes : Form
    {
        conexionBD conexion = conexionBD.getConexion();
        SqlConnection conexion_sql;

        public frm_listado_clientes()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void frm_listado_clientes_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {

            string query = crear_query_listadoC(txt_nombre.Text, txt_apellido.Text, txt_DNI.Text, txt_email.Text);

            if (query == "") { MessageBox.Show("Ingrese Parametros"); }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion_sql);

                conexion_sql.Open();

                DataTable tabla_clientes = new DataTable();

                adapter.Fill(tabla_clientes);

                contenedor_clientes.DataSource = tabla_clientes;
                conexion_sql.Close();
            }

        }

        private string crear_query_listadoC(String nombre, String Apellido, String DNI, String EMAIL)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT Cliente_Id, username, nombre, apellido, DNI, telefono, mail, Fecha_Nacimiento, DineroDisponible, estado, d.Direccion, Codigo_Postal, Localidad, Ciudad, Numero_Piso, Depto FROM CLIENTES c join DIRECCION d on c.direccion = d.id_direccion WHERE ");

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

        private void bt_limpiar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_DNI.Text = "";
            txt_email.Text = "";
        }

        private void contenedor_clientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void contenedor_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void contenedor_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (contenedor_clientes.Rows.Count == 0) 
            {
                MessageBox.Show("Aplique algun filtro.");
                return;
            }
            if (contenedor_clientes.CurrentCell.ColumnIndex == 0)
            {

                conexion_sql.Open();
                try
                {
                    var row = contenedor_clientes.CurrentRow;

                    SqlCommand command = new SqlCommand("baja_logica_cliente", conexion_sql);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DNI_CLIENTE", SqlDbType.Float).Value = Int32.Parse(row.Cells[6].Value.ToString());
                    command.Parameters.AddWithValue("@username", SqlDbType.Float).Value = row.Cells[3].Value.ToString();

                    command.ExecuteNonQuery();

        
                    MessageBox.Show("Cliente Inhabilitado");
                    //Hacer un refresh

                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                }
                conexion_sql.Close();
            }


            if (contenedor_clientes.CurrentCell.ColumnIndex == 1)
            {
                var row = contenedor_clientes.CurrentRow;

                frm_clie_bajas formulario_bajas = new frm_clie_bajas();

                formulario_bajas.txt_id.Text = row.Cells[2].Value.ToString();
                formulario_bajas.txt_username.Text = row.Cells[3].Value.ToString();
                formulario_bajas.txt_nombre.Text = row.Cells[4].Value.ToString();
                formulario_bajas.txt_apellido.Text = row.Cells[5].Value.ToString();
                formulario_bajas.txt_dni.Text = row.Cells[6].Value.ToString();
                formulario_bajas.txt_telefono.Text = row.Cells[7].Value.ToString();
                formulario_bajas.txt_email.Text = row.Cells[8].Value.ToString();
                formulario_bajas.txt_fecha.Text = row.Cells[9].Value.ToString();

                formulario_bajas.txt_estado.Text = row.Cells[11].Value.ToString();

                formulario_bajas.txt_direccion.Text = row.Cells[12].Value.ToString();
                formulario_bajas.txt_codigopostal.Text = row.Cells[13].Value.ToString();
                formulario_bajas.txt_localidad.Text = row.Cells[14].Value.ToString();
                formulario_bajas.txt_ciudad.Text = row.Cells[15].Value.ToString();
                formulario_bajas.txt_piso.Text = row.Cells[16].Value.ToString();
                formulario_bajas.txt_depto.Text = row.Cells[17].Value.ToString();

                formulario_bajas.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new MenuAdmin.ABMClientes();
            menu.Show();
        }
    }
}
