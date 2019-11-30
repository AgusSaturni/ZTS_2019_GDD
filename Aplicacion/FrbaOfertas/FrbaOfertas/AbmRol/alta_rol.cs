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

namespace FrbaOfertas.AbmRol
{
    public partial class alta_rol : Form
    {
        private CommonQueries commonQueries_instance = CommonQueries.getInstance();
        private SqlConnection conn;
        private ArrayList Id_Funciones = new ArrayList();

        public alta_rol()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void alta_rol_Load(object sender, EventArgs e)
        {
            conexionBD conexion = conexionBD.getConexion();
            conn = new SqlConnection(conexion.get_cadena());
            this.cargar_funciones_totales_sistema();
        }

        private void cargar_funciones_totales_sistema()
        {
            conn.Open();

            SqlDataReader reader2 = commonQueries_instance.get_all_funciones(conn);

            while (reader2.Read())
            {
                list_totales.Items.Add(reader2[0].ToString());
            }

            conn.Close();
        }

        private void carga_logica_funciones_nuevas(SqlConnection conexion)
        {
            String query = "select Funcion_Id, Descripcion from Funciones";
            SqlCommand cmd = new SqlCommand(query, conexion);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (list_rol.Items.Contains(reader[1].ToString()))
                {
                    Id_Funciones.Add(reader[0].ToString());
                }

            }
        }
        private void bt_izq_a_der_Click(object sender, EventArgs e)
        {
            int indice = list_totales.SelectedIndex;
            if (indice != -1)
            {
                if (!list_rol.Items.Contains(list_totales.SelectedItem))
                {
                    list_rol.Items.Add(list_totales.SelectedItem);
                    list_totales.Items.Remove(list_totales.SelectedItem);
                }
                else { MessageBox.Show("La funcion ya se encuentra asignada al Rol"); }
            }
            else { MessageBox.Show("Seleccione una funcion del sistema para agregar al rol"); }
        }

        private void bt_der_a_izq_Click(object sender, EventArgs e)
        {
            int indice = list_rol.SelectedIndex;
            if (indice != -1)
            {
                if (!list_totales.Items.Contains(list_rol.SelectedItem))
                {
                    list_totales.Items.Add(list_rol.SelectedItem);
                    list_rol.Items.Remove(list_rol.SelectedItem);
                }
                else { MessageBox.Show("La funcion ya se encuentra asignada al Rol"); }
            }
            else { MessageBox.Show("Seleccione una funcion asignada al rol para removerla"); }
        }

        private void bt_finalizar_Click(object sender, EventArgs e)
        {
            if (list_rol.Items.Count == 0) 
            {
                MessageBox.Show("Agregue al menos una funcion");
                return;
            }
            if (txt_nombre_rol.Text == "") 
            {
                MessageBox.Show("Introduzca el nombre del nuevo Rol");
                return;
            }
            
            
            conn.Open();
            //Esta no puede tirar error, por eso la saco del try
            this.carga_logica_funciones_nuevas(conn);
            conn.Close();

            conn.Open();
            try
            {
                //Primero inserto el rol nuevo, si tira error significa qu ya existe ese rol por lo que me sale al primer catch
                this.insert_into_roles(txt_nombre_rol.Text.ToString(), conn);
                
                //Si paso esa parte, meto todas las funciones que seleccione
                try 
                {
                    for (int i = 0; i < Id_Funciones.Count; i++)
                    {
                        commonQueries_instance.insert_funciones_por_rol(txt_nombre_rol.Text.ToString(), Id_Funciones[i].ToString(), conn);
                    }
                    
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString());
                }

                MessageBox.Show("Creacion del Rol Finalizada");
               
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            conn.Close();
            Id_Funciones.Clear();
        }

        public void insert_into_roles(string rol, SqlConnection conexion_actual) 
        {
            SqlCommand command = new SqlCommand("INSERTAR_ROL", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Rol_Id", txt_nombre_rol.Text.ToString());

            command.ExecuteNonQuery();
      
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new MenuAdmin.ABMRoles();
            menu.Show();
        }
    
    

    }
}
