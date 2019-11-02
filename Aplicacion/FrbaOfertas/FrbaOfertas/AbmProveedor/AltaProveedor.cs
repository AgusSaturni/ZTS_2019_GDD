using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        private string usuario;
        private string password;
        private string rol;

        public AltaProveedor()
        {
            InitializeComponent();
        }

        public AltaProveedor(string usuario, string password, string rol)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.usuario = usuario;
            this.password = password;
            this.rol = rol;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void Siguiente_Click(object sender, EventArgs e)
        {
            string razonSocial = RS.Text;
            string telefono = Telefono.Text;
            string cuit = CUIT.Text;
            string rubro = Rubro.Text;
            string mail = Mail.Text;
            string contacto = Contacto.Text;



            if (razonSocial != "" && telefono != "" && cuit != "" && rubro != "" && mail != "" && contacto != "")
            {
                this.Visible = false;
                CargaDireccion.CargarDireccion direccion = new CargaDireccion.CargarDireccion(usuario, password,rol, null, null, null, telefono, null, mail,razonSocial,cuit,rubro,contacto);
                direccion.Show();
            }
            else
            {
                MessageBox.Show("Faltan completar campos");
            }


        }
    }
}
