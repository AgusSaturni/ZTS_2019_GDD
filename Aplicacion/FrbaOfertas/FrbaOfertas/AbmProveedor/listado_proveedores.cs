﻿using System;
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

namespace FrbaOfertas.AbmProveedor
{
    public partial class listado_proveedores : Form
    {

     

        public listado_proveedores()
        {
            InitializeComponent();
            MaximizeBox = false;
 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {

            string query = crear_query_listadoC(txt_RazonS.Text,txt_CUIT.Text, txt_email.Text,txt_Rubro.Text);

            if (query == "") { MessageBox.Show("Ingrese Parametros"); }
            else
            {
                conexionBD conexion = conexionBD.getConexion();

                SqlConnection conn = new SqlConnection(conexion.get_cadena());

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                conn.Open();

                DataTable tabla_clientes = new DataTable();

                adapter.Fill(tabla_clientes);

                contenedor_proveedores.DataSource = tabla_clientes;
                conn.Close();
            }

        }

        private string crear_query_listadoC(String RazonSocial, String CUIT, String EMAIL,String Rubro)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select p.proveedor_id,Razon_Social,username,d.Direccion,Telefono,CUIT,Mail,Nombre_contacto, r.rubro_descripcion,Codigo_Postal, Localidad, Ciudad, Numero_Piso, Depto, estado from PROVEEDORES p join DIRECCION d on p.Direccion = d.Id_Direccion join rubros r on p.Proveedor_Id = r.Proveedor_Id where ");

            ArrayList Query = new ArrayList();

            if (RazonSocial != "")
            {
                Query.Add("Razon_Social LIKE '%" + RazonSocial + "%'");
            }
         
            if (CUIT != "")
            {
                Query.Add("CUIT = '" + CUIT + "'");
            }
            if (EMAIL != "")
            {
                Query.Add("Mail LIKE '%" + EMAIL + "%'");
            }
            if (Rubro != "")
            {
                Query.Add("Rubro_Descripcion LIKE '%" + Rubro + "%'");
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
            txt_RazonS.Text = "";
            txt_Rubro.Text = "";
            txt_CUIT.Text = "";
            txt_email.Text = "";
        }

        private void contenedor_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (contenedor_proveedores.Rows.Count == 0)
            {
                MessageBox.Show("Aplique algun filtro.");
                return;
            }
            if (contenedor_proveedores.CurrentCell.ColumnIndex == 0)
            {
                conexionBD conexion = conexionBD.getConexion();
                SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());

                try
                {
                    var row = contenedor_proveedores.CurrentRow;

                    SqlCommand command = new SqlCommand("baja_logica_proveedor", conexion_sql);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CUIT", SqlDbType.Char).Value = row.Cells[7].Value.ToString();
                    command.Parameters.AddWithValue("@username", SqlDbType.Char).Value = row.Cells[4].Value.ToString();

                    conexion_sql.Open();
                    command.ExecuteNonQuery();
                    conexion_sql.Close();

                    MessageBox.Show("Proveedor Inhabilitado");
                    //Hacer un refresh

                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                }
            }

                if (contenedor_proveedores.CurrentCell.ColumnIndex == 1)
                {
                    var row = contenedor_proveedores.CurrentRow;


                    Modificaciones_Proveedores formulario_bajas = new AbmProveedor.Modificaciones_Proveedores();



                    formulario_bajas.txt_id.Text = row.Cells[2].Value.ToString();
                    formulario_bajas.txt_username.Text = row.Cells[4].Value.ToString();
                    formulario_bajas.txt_RazonSoc.Text = row.Cells[3].Value.ToString();            
                    formulario_bajas.txt_CUIT.Text = row.Cells[7].Value.ToString();
                    formulario_bajas.txt_telefono.Text = row.Cells[6].Value.ToString();
                    formulario_bajas.txt_email.Text = row.Cells[8].Value.ToString();
                    formulario_bajas.txt_Contacto.Text = row.Cells[9].Value.ToString();
                    formulario_bajas.txt_Rubro.Text = row.Cells[10].Value.ToString();

                    formulario_bajas.txt_direccion.Text = row.Cells[5].Value.ToString();
                    formulario_bajas.txt_codigopostal.Text = row.Cells[11].Value.ToString();
                    formulario_bajas.txt_localidad.Text = row.Cells[12].Value.ToString();
                    formulario_bajas.txt_ciudad.Text = row.Cells[13].Value.ToString();
                    formulario_bajas.txt_piso.Text = row.Cells[14].Value.ToString();
                    formulario_bajas.txt_depto.Text = row.Cells[15].Value.ToString();
                    formulario_bajas.txt_estado.Text = row.Cells[16].Value.ToString();



                    formulario_bajas.Show();
                }
              
            }

        private void asd_Click(object sender, EventArgs e)
        {

        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new MenuAdmin.ABMProveedores();
            menu.Show();
        }

        }
    }

