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
using System.Security.Cryptography;

namespace FrbaOfertas
{
    public partial class RegistroUsuario : Form
    {
        
        object rol;

        public RegistroUsuario()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public RegistroUsuario(object rol_recibido)
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            rol = rol_recibido;
            if (rol.ToString() == "Proveedor")
            {
                Rol.SelectedIndex = 1;
                Rol.Enabled = false;
            }
            if (rol.ToString() == "Cliente")
            {
                Rol.SelectedIndex = 0;
                Rol.Enabled = false;
            }
        }

        private  void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int indice =  Rol.SelectedIndex;
            string usuario;
            string password;
            

            usuario = Usuario.Text;        
            password = Password.Text;

           

            if (indice != -1 && usuario != "" && password != "")
            {
                rol = Rol.Items[indice];
                
                switch (rol.ToString())
                {
                    case "Cliente":
                        Form registroCliente = new AbmCliente.AltaCliente(usuario, password, rol.ToString());
                        this.Visible = false;
                        registroCliente.Show();
                        break;
                    case "Proveedor":
                        Form registroProveedor = new AbmProveedor.AltaProveedor(usuario, password, rol.ToString());
                        this.Visible = false;
                        registroProveedor.Show();
                        break;
                }
            }
            else {
                MessageBox.Show("Faltan completar campos");
            }
          
        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
   
    }
}
