using System;
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
        Singleton_Usuario sesion = Singleton_Usuario.getInstance();

        public menu_principal()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {

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
                        Form menu_rol = new MenuAdmin.ABMRoles();
                        menu_rol.Show();
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
                        Form oferta = new ComprarOferta.Ofertas();
                        oferta.Show();
                        this.Hide();
                        break;
                    case "Cargar Credito":
                        Form credito = new CragaCredito.CargaDeCredito();
                        credito.Show();
                        break;
                    case "Confeccion y Publicacion de Ofertas":
                        this.Hide();
                        Form carga_oferta = new CrearOferta.CargaOferta();
                        carga_oferta.Show();
                        break;
                    case "Entrega/Consumo de Oferta":
                        this.Hide();
                        Form entrega_ConsumoOferta = new Entrega_ConsumoOferta.Entrega_ConsumoOferta();
                        entrega_ConsumoOferta.Show();
                        break;
                    case "Facturar a Proveedor":
                        this.Hide();
                        Form facturarProveedor = new Facturar.FacturarProveedor();
                        facturarProveedor.Show();
                        break;
                    case "Registrar Usuarios":
                        Form registro = new RegistroUsuario();
                        registro.Show();
                        break;
                }
                this.Hide();
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
