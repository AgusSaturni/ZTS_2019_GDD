﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Manejo_Logico;

namespace FrbaOfertas.Interfaces
{
    public partial class menu_principal : Form
    {
        private string username;
        private string[] vec_funciones;

        public menu_principal()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public menu_principal(string usuario)
        {
            InitializeComponent();
            this.username = usuario;
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {
            Singleton_Usuario sesion = Singleton_Usuario.getInstance();
            this.cargar_comboBox(sesion);
            this.cargar_bienvenida(sesion);
        }

        private void cargar_comboBox(Singleton_Usuario sesion) 
        {

            List<String> lista_permisos = sesion.get_permisos();

            for(int i=0; i < lista_permisos.Count(); i++)
            {
                comboBox_funciones.Items.Add(lista_permisos.ElementAt(i).ToString());
            }
        }
        private void cargar_bienvenida(Singleton_Usuario sesion) 
        {
            lbl_bienvenida.Text = "Bienvenido " + sesion.get_username();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
           
        }

        private void bt_ejecutar_Click(object sender, EventArgs e)
        {
            int indice = comboBox_funciones.SelectedIndex;
            if (indice != -1)
            {
                switch (comboBox_funciones.SelectedItem.ToString())
                {
                    case "ABM Roles":
                        break;
                    case "ABM Clientes":
                        Form formulario = new MenuAdmin.ABMClientes();
                        formulario.Show();
                        break;
                    case "ABM Proveedores":
                        Form formulario2 = new MenuAdmin.ABMProveedores();
                        formulario2.Show();
                        break;
                    case "Listado Estadistico":
                        break;
                    case "Comprar Oferta":
                        break;
                    case "Cargar Credito":
                        Form credito = new CragaCredito.CargaDeCredito(username);
                        credito.Show();
                        break;
                    case "Confeccion y Publicacion de Ofertas":
                        this.Hide();
                        Form carga_oferta = new CrearOferta.CargaOferta(username);
                        carga_oferta.Show();
                        break;
                    case "Comprar Ofertas":
                        break;
                    case "Entrega/Consumo de Ofertas":
                        break;
                    case "Facturar a Proveedor":
                        break;
                    case "Registrar Usuarios":
                        Form registro = new RegistroUsuario();
                        registro.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Elija una acción a realizar");
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void bt_cerrar_Click(object sender, EventArgs e)
        {
            Singleton_Usuario sesion = Singleton_Usuario.getInstance();
            sesion.cerrar_sesion();
            this.Hide();
            Form inicio_sesion = new InicioDeSesion();
            inicio_sesion.Show();
        }

        private void comboBox_funciones_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}