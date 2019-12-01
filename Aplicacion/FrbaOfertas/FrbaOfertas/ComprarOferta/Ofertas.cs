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
        private string username = (Singleton_Usuario.getInstance()).get_username();

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
                conexionBD conexion = conexionBD.getConexion();
                SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
                
               try
               {
                    var row = contenedor_ofertas.CurrentRow;

                    SqlCommand command = new SqlCommand("comprar_oferta", conexion_sql);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlCommand command2 = new SqlCommand("obtener_codigo", conexion_sql);
                    command2.CommandType = CommandType.StoredProcedure;


                    SqlParameter codigo_oferta = new SqlParameter("@codigoOferta", SqlDbType.Char);
                    codigo_oferta.Direction = ParameterDirection.Input;
                    command.Parameters.Add(codigo_oferta);

                    SqlParameter precio_lista = new SqlParameter("@precioLista", SqlDbType.Float);
                    precio_lista.Direction = ParameterDirection.Input;
                    command.Parameters.Add(precio_lista);

                    SqlParameter precio_oferta = new SqlParameter("@precio_oferta", SqlDbType.Float);
                    precio_oferta.Direction = ParameterDirection.Input;
                    command.Parameters.Add(precio_oferta);

                    SqlParameter cliente = new SqlParameter("@clienteUsuario", SqlDbType.Char);
                    cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(cliente);

                    SqlParameter cantidadDispo = new SqlParameter("@cantidadDisponible", SqlDbType.Int);
                    cantidadDispo.Direction = ParameterDirection.Input;
                    command.Parameters.Add(cantidadDispo);


                    SqlParameter cantMaxUser = new SqlParameter("@cantidadMaxUsuario", SqlDbType.Int);
                    cantMaxUser.Direction = ParameterDirection.Input;
                    command.Parameters.Add(cantMaxUser);

                    SqlParameter proveedor_semilla = new SqlParameter("@proveedor_id", SqlDbType.Char);
                    proveedor_semilla.Direction = ParameterDirection.Input;
                    command2.Parameters.Add(proveedor_semilla);

                    SqlParameter descripcion_semilla = new SqlParameter("@descripcion", SqlDbType.Char);
                    descripcion_semilla.Direction = ParameterDirection.Input;
                    command2.Parameters.Add(descripcion_semilla);


                    SqlParameter precio_oferta_semilla = new SqlParameter("@precio_oferta", SqlDbType.Char);
                    precio_oferta_semilla.Direction = ParameterDirection.Input;
                    command2.Parameters.Add(precio_oferta_semilla);


                    SqlParameter precio_lista_semilla = new SqlParameter("@precio_lista", SqlDbType.Char);
                    precio_lista_semilla.Direction = ParameterDirection.Input;
                    command2.Parameters.Add(precio_lista_semilla);


                    descripcion_semilla.Value = row.Cells[1].Value.ToString();
                    proveedor_semilla.Value = row.Cells[7].Value.ToString();
                    precio_lista_semilla.Value = float.Parse(row.Cells[3].Value.ToString());
                    precio_oferta_semilla.Value = precio_oferta.Value = float.Parse(row.Cells[2].Value.ToString());
                    precio_lista.Value = float.Parse(row.Cells[3].Value.ToString());  
                    precio_oferta.Value = float.Parse(row.Cells[2].Value.ToString());
                    cliente.Value = username;
                    cantidadDispo.Value = Int32.Parse(row.Cells[5].Value.ToString());
                    cantMaxUser.Value = Int32.Parse(row.Cells[6].Value.ToString());


                    conexion_sql.Open();

                                     try {
                                       command2.ExecuteNonQuery();
                                    }
                                     catch (SqlException exepcion)
                                     {
                                        string message = "Desea comprar" + row.Cells[1].Value.ToString() + " ?";
                                        string caption = "Validar compra";
                                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                        DialogResult result;
                                        result = MessageBox.Show(message, caption, buttons);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            SqlError codigo = exepcion.Errors[0];
                                            codigo_oferta.Value = codigo.Message.ToString();
                                            command.ExecuteNonQuery();
                                            MessageBox.Show("Compra realizada, su codigo es: " + codigo.Message.ToString());
                                            limpiar_form();
                                        }
                                     }
                    conexion_sql.Close();
               }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
               }
            }

        }

        private void txt_apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            string query = crear_query_oferta(Descripcion.Text, minimo.Text, maximo.Text);
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



