using FrbaOfertas.Manejo_Logico;
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

namespace FrbaOfertas.Entrega_ConsumoOferta
{
    public partial class ListadoCupones : Form
    {
        conexionBD conexion = conexionBD.getConexion();
        private Singleton_Usuario sesion = Singleton_Usuario.getInstance();
        SqlConnection conexion_sql;

        public ListadoCupones()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void ListadoCupones_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            string query = this.crear_query_listadoCupones();

            if (query == "") { MessageBox.Show("Ingrese Algun Parametro. Puede buscar por cualquiera de las opciones en pantalla.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion_sql);

                conexion_sql.Open();

                DataTable tabla_clientes = new DataTable();

                adapter.Fill(tabla_clientes);

                contenedor_cupones.DataSource = tabla_clientes;
                conexion_sql.Close();

                this.contenedor_cupones.Columns[7].Visible = false;
            }

            if (contenedor_cupones.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron cupones para los filtros aplicados", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string crear_query_listadoCupones()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select C.codigo_cupon, C.Codigo_oferta, CL.username ,O.Descripcion ,C.Fecha_Consumo AS 'Fecha Consumo', O.Fecha_Vencimiento as 'Fecha de Vecimiento Oferta',C.Cupon_Id, C.Cantidad_disponible from CUPONES C JOIN COMPRAS COMP on COMP.Compra_Id = C.Compra_Id JOIN CLIENTES CL on CL.Cliente_Id = COMP.Cliente_Id JOIN OFERTAS O on O.Codigo_Oferta = comp.Codigo_oferta AND O.Codigo_Oferta = C.Codigo_oferta JOIN PROVEEDORES P on P.Proveedor_Id = O.Proveedor_referenciado WHERE ");

            ArrayList Query = new ArrayList();

            if (txt_cuponid.Text != "")
            {
                Query.Add("C.codigo_cupon LIKE '%" + txt_cuponid.Text.Trim() + "%'");
            }
            if (txt_ofertaid.Text != "")
            {
                Query.Add("C.Codigo_oferta LIKE '%" + txt_ofertaid.Text + "%'");
            }
            if (txt_cliente.Text != "")
            {
                Query.Add("CL.username LIKE '%" + txt_cliente.Text + "%'");
            }
            if (checkBox_consumidos.Checked == false)
            {
                Query.Add(" C.Fecha_Consumo IS NULL");
            }
            else 
            {
                Query.Add(" 1 = 1"); // ya que si no tengo ningun campo lleno, y toco el checkbox, me queda where solo
            }
            

            if(!sesion.verificar_rol_administrador())
            {
                Query.Add(" P.username = '" + sesion.get_username() + "'");
            }

            string[] vector_query = Query.ToArray(typeof(string)) as string[];
            string query_final = string.Join(" AND ", vector_query);

            sb.Append(query_final);

            return sb.ToString();
            
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form menu_principal = new Interfaces.menu_principal();
            menu_principal.Show();
        }

        private void bt_limpiar_Click(object sender, EventArgs e)
        {
            txt_cliente.Text = "";
            txt_cuponid.Text = "";
            txt_ofertaid.Text = "";
            checkBox_consumidos.Checked = false;
        }

        private void contenedor_cupones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (contenedor_cupones.Rows.Count == 0)
            {
                MessageBox.Show("Aplique algun filtro.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (contenedor_cupones.CurrentCell.ColumnIndex == 0)
            {
                var row = contenedor_cupones.CurrentRow;

                if (row.Cells[5].Value.ToString() != "")
                {
                    MessageBox.Show("El cupon ya fue Canejado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else 
                {
                    this.Hide();
                    Form consumo = new Entrega_ConsumoOferta(this, row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[7].Value.ToString());
                    consumo.Show();
                }
            }        
        }    
    }
}
