﻿using FrbaOfertas.Manejo_Logico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.MenuAdmin
{

    public partial class ABMClientes : Form
    {
        SqlConnection conexion_sql;
        conexionBD conexion = conexionBD.getConexion();
        CommonQueries commonQueries_instance = CommonQueries.getInstance();

        public ABMClientes()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        }

        private void button3_Click(object sender, EventArgs e) //MODIFICACION
        {
            this.Hide();
            Form bajas_modificiaciones = new AbmCliente.frm_listado_clientes();
            bajas_modificiaciones.Show();

        }

        private void button1_Click(object sender, EventArgs e) //ALTA
        {
            conexion_sql.Open();
            try
            {
                commonQueries_instance.vereificar_estado_rol("Cliente", conexion_sql);


                this.Hide();
                Form alta = new RegistroUsuario("Cliente", this,1);
                alta.Show();

            }
            catch (SqlException exepcion)
            {
                SqlError errores = exepcion.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion_sql.Close();

        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form menu = new Interfaces.menu_principal();
            menu.Show();
        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {
            conexion_sql = new SqlConnection(conexion.get_cadena());
        }
    }
}