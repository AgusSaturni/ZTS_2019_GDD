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
    public partial class Modificacion_Roles : Form
    {

        private ArrayList Id_Funciones = new ArrayList();
        private Singleton_Usuario sesion = Singleton_Usuario.getInstance();
        private CommonQueries commonQueries_instance = CommonQueries.getInstance();
        private SqlConnection conn;
        private conexionBD conexion = conexionBD.getConexion();


        public Modificacion_Roles()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void Modificacion_Roles_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conexion.get_cadena());

            this.cargar_comboBox();
        }

        private void cargar_estado(String item_seleccionado)
        {

            string query = "SELECT Estado FROM ZTS_DB.ROLES where Rol_Id = '" + item_seleccionado + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txt_estado.Text = (reader[0].ToString());
            }
            conn.Close();

        }

        private void cargar_comboBox()
        {
            conn.Open();
            SqlDataReader reader = commonQueries_instance.get_all_roles(conn);

            while (reader.Read())
            {
                comboBox_roles.Items.Add(reader[0].ToString());
            }

            conn.Close();
        }

        private void cargar_funciones_totales_disponibles()
        {
            //CARGA DE PRIMERA LISTA

            String query = "select Descripcion from ZTS_DB.FUNCIONES_POR_ROL FPR join ZTS_DB.FUNCIONES F on FPR.Funcion_Id = F.Funcion_Id where Rol_Id = '" + comboBox_roles.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader1 = cmd.ExecuteReader();

            while (reader1.Read())
            {
                list_rol.Items.Add(reader1[0].ToString());
            }

            conn.Close();

        }

        private void cargar_funciones_totales_sistema()
        {
            conn.Open();

            SqlDataReader reader2 = commonQueries_instance.get_all_funciones(conn);

            while (reader2.Read())
            {
                if (!list_rol.Items.Contains(reader2[0].ToString()))
                {
                    list_totales.Items.Add(reader2[0].ToString());
                }
            }

            conn.Close();
        }

        private void bt_seleccionar_Click(object sender, EventArgs e)
        {
            if (comboBox_roles.SelectedIndex != -1)
            {
                this.Close();
                Form cambiar_nombre = new CambiarNombreRol(comboBox_roles.SelectedItem.ToString());
                cambiar_nombre.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un Rol", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                else { MessageBox.Show("La funcion ya se encuentra asignada al Rol seleccionado", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("Seleccione una funcion del sistema para agregar al rol", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
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
                else { MessageBox.Show("La funcion ya se encuentra asignada al Rol seleccionado", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("Seleccione una funcion asignada al rol para removerla", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void bt_finalizar_Click(object sender, EventArgs e)
        {
            //Cierro y abro la conexion 2 veces porque no se puede utilizar 2 DataReaders en 1 conexion sola
            conn.Open();
            this.remover_funciones_viejas(comboBox_roles.SelectedItem.ToString(), conn);
            this.carga_logica_funciones_nuevas(conn);
            conn.Close();

            conn.Open();

            try
            {
                for (int i = 0; i < Id_Funciones.Count; i++)
                {
                    commonQueries_instance.insert_funciones_por_rol(comboBox_roles.SelectedItem.ToString(), Id_Funciones[i].ToString(), conn);
                }
            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString());
            }

            conn.Close();

            Id_Funciones.Clear();

            MessageBox.Show("Rol Modificado", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Actualizo sesion para que se me carguen los nuevos permisos en caso de haber modificado el ROL de administrador
            this.actualizar_sesion();
        }

        private void actualizar_sesion()
        {
            string username = sesion.get_username();
            sesion.cerrar_sesion();

            Singleton_Usuario sesion_nueva = Singleton_Usuario.getInstance();

            sesion_nueva.set_username(username);
            sesion_nueva.cargar_usuario();
        }

        private void remover_funciones_viejas(string Rol, SqlConnection conexion)
        {
            SqlCommand cmd = new SqlCommand("ZTS_DB.eliminar_funciones_por_rol", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol_Id", SqlDbType.Char).Value = Rol;

            cmd.ExecuteNonQuery();
        }

        private void carga_logica_funciones_nuevas(SqlConnection conexion)
        {
            String query = "select Funcion_Id, Descripcion from ZTS_DB.Funciones";
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


        private void bt_deshabilitar_rol_Click(object sender, EventArgs e)
        {
            if (txt_estado.Text == "")
            {
                MessageBox.Show("Seleccione un Rol", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show("Seguro que desea dar de baja al Rol seleccionado?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                SqlCommand command = new SqlCommand("ZTS_DB.deshabilitar_rol", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Rol_Id", SqlDbType.Char).Value = comboBox_roles.SelectedItem.ToString();

                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rol Deshabilitado", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_estado.Text = "Deshabilitado";
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

            }

        }

        private void bt_habilitar_rol_Click(object sender, EventArgs e)
        {
            if (txt_estado.Text == "")
            {
                MessageBox.Show("Seleccione un Rol", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show("Seguro que desea dar de alta al Rol seleccionado?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                SqlCommand command = new SqlCommand("ZTS_DB.habilitar_rol", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Rol_Id", SqlDbType.Char).Value = comboBox_roles.SelectedItem.ToString();

                conn.Open();
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rol Habilitado", "Modificacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_estado.Text = "Habilitado";
                }
                catch (SqlException exepcion)
                {
                    SqlError errores = exepcion.Errors[0];
                    MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();


            }
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu_roles = new MenuAdmin.ABMRoles();
            menu_roles.Show();

        }

        private void comboBox_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_rol.Items.Clear();
            list_totales.Items.Clear();
            this.cargar_funciones_totales_disponibles();
            this.cargar_funciones_totales_sistema();
            this.cargar_estado(comboBox_roles.SelectedItem.ToString());
        }
    }
}