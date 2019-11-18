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

namespace FrbaOfertas.CargaDireccion
{
    public partial class CargarDireccion : Form
    {
        private string usuario;
        private string password;
        private string rol;
        private string nombre;
        private string apellido;
        private string DNI;
        private string telefono;
        private object fechaDeNacimiento;
        private string mail;
        private string razonSocial;
        private string rubro;
        private string cuit;
        private string contacto;

        public CargarDireccion()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public CargarDireccion(string usuario, string password, string rol, string nombre, string apellido, string DNI, string telefono, object fechaDeNacimiento, string mail,string rs,string cuit,string rubro, string contacto)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.password = password;
            this.rol = rol;
            this.nombre = nombre;
            this.apellido = apellido;
            this.DNI = DNI;
            this.telefono = telefono;
            this.fechaDeNacimiento = fechaDeNacimiento;
            this.mail = mail;
            this.razonSocial = rs;
            this.cuit = cuit;
            this.rubro = rubro;
            this.contacto = contacto;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conn = new SqlConnection(conexion.get_cadena());

            conn.Open();

            switch (rol)
            {
                case "Cliente":

                    SqlCommand command = new SqlCommand("registrar_usuario_cliente",conn);
                    command.CommandType = CommandType.StoredProcedure;


                    SqlParameter username1 = new SqlParameter("@Username", SqlDbType.Char);
                    username1.Direction = ParameterDirection.Input;
                    command.Parameters.Add(username1);


                    SqlParameter password1 = new SqlParameter("@Password", SqlDbType.Char);
                    password1.Direction = ParameterDirection.Input;
                    command.Parameters.Add(password1);

                    SqlParameter rol1 = new SqlParameter("@Rol", SqlDbType.Char);
                    rol1.Direction = ParameterDirection.Input;
                    command.Parameters.Add(rol1);
     

                    SqlParameter nombre_cliente = new SqlParameter("@nombre", SqlDbType.Char);
                    nombre_cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(nombre_cliente);


                    SqlParameter apellido_cliente = new SqlParameter("@apellido", SqlDbType.Char);
                    apellido_cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(apellido_cliente);

                    SqlParameter DNI_cliente = new SqlParameter("@DNI", SqlDbType.Float);
                    DNI_cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(DNI_cliente);

                    SqlParameter telefono_cliente = new SqlParameter("@Telefono", SqlDbType.Float);
                    telefono_cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(telefono_cliente);

                    SqlParameter mail_cliente = new SqlParameter("@Mail", SqlDbType.Char);
                    mail_cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(mail_cliente);

                    SqlParameter fechaNacimiento_cliente = new SqlParameter("@Fecha_nacimiento", SqlDbType.Date);
                    fechaNacimiento_cliente.Direction = ParameterDirection.Input;
                    command.Parameters.Add(fechaNacimiento_cliente);


                    SqlParameter direccion = new SqlParameter("@Direccion", SqlDbType.Char);
                    direccion.Direction = ParameterDirection.Input;
                    command.Parameters.Add(direccion);

                    SqlParameter codPostal = new SqlParameter("@codigo_Postal", SqlDbType.Float);
                    codPostal.Direction = ParameterDirection.Input;
                    command.Parameters.Add(codPostal);

                    SqlParameter localidad = new SqlParameter("@Localidad", SqlDbType.Char);
                    localidad.Direction = ParameterDirection.Input;
                    command.Parameters.Add(localidad);

                    SqlParameter ciudad = new SqlParameter("@ciudad", SqlDbType.Char);
                    direccion.Direction = ParameterDirection.Input;
                    command.Parameters.Add(ciudad);

                    SqlParameter nroPiso = new SqlParameter("@nro_Piso", SqlDbType.Int);
                    nroPiso.Direction = ParameterDirection.Input;
                    command.Parameters.Add(nroPiso);

                    SqlParameter dpto = new SqlParameter("@Depto", SqlDbType.Char);
                    dpto.Direction = ParameterDirection.Input;
                    command.Parameters.Add(dpto);

                    username1.Value = usuario;
                    password1.Value = password;
                    rol1.Value = rol;   
                    nombre_cliente.Value = nombre;
                    apellido_cliente.Value = apellido;
                    DNI_cliente.Value = DNI;
                    telefono_cliente.Value = telefono;
                    fechaNacimiento_cliente.Value = fechaDeNacimiento;
                    mail_cliente.Value = mail;
                    direccion.Value = Direccion.Text;
                    codPostal.Value = CodigoPostal.Text;
                    localidad.Value = Localidad.Text;
                    ciudad.Value = Ciudad.Text;
                    nroPiso.Value = NroPiso.Text;
                    dpto.Value = Departamento.Text;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Hecho");
                    conn.Close();

                break;

                case "Proveedor":
                     SqlCommand command1 = new SqlCommand("registrar_usuario_proveedor",conn);
                    command1.CommandType = CommandType.StoredProcedure;


                    SqlParameter username3 = new SqlParameter("@Username", SqlDbType.Char);
                    username3.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(username3);


                    SqlParameter password3 = new SqlParameter("@Password", SqlDbType.Char);
                    password3.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(password3);

                    SqlParameter rol2 = new SqlParameter("@Rol", SqlDbType.Char);
                    rol2.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(rol2);

                    SqlParameter razon_social1 = new SqlParameter("@Razon_Social", SqlDbType.Char);
                    razon_social1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(razon_social1);


                    SqlParameter mail_Proveedor = new SqlParameter("@Mail", SqlDbType.Char);
                    mail_Proveedor.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(mail_Proveedor);

                    SqlParameter telefono_proveedor = new SqlParameter("@Telefono", SqlDbType.Float);
                    telefono_proveedor.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(telefono_proveedor);

                    SqlParameter cuit1 = new SqlParameter("@CUIT", SqlDbType.Char);
                    cuit1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(cuit1);

                    SqlParameter rubro1 = new SqlParameter("@Rubro", SqlDbType.Char);
                    rubro1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(rubro1);

                    SqlParameter contacto1 = new SqlParameter("@Nombre_contacto", SqlDbType.Char);
                    contacto1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(contacto1);

                    
                    SqlParameter direccion1 = new SqlParameter("@Direccion", SqlDbType.Char);
                    direccion1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(direccion1);

                    SqlParameter codPostal1 = new SqlParameter("@codigo_Postal", SqlDbType.Float);
                    codPostal1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(codPostal1);

                    SqlParameter localidad1 = new SqlParameter("@Localidad", SqlDbType.Char);
                    localidad1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(localidad1);

                    SqlParameter ciudad1 = new SqlParameter("@Ciudad", SqlDbType.Char);
                    ciudad1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(ciudad1);

                    SqlParameter nroPiso1 = new SqlParameter("@Nro_Piso", SqlDbType.Int);
                    nroPiso1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(nroPiso1);

                    SqlParameter dpto1 = new SqlParameter("@Depto", SqlDbType.Char);
                    dpto1.Direction = ParameterDirection.Input;
                    command1.Parameters.Add(dpto1);

                    username3.Value = usuario;
                    password3.Value = password;
                    rol2.Value = rol;
                    razon_social1.Value = razonSocial;
                    cuit1.Value = cuit;  
                    telefono_proveedor.Value = telefono;
                    rubro1.Value = rubro;
                    mail_Proveedor.Value = mail; 
                    contacto1.Value = contacto;
                    direccion1.Value = Direccion.Text;
                    codPostal1.Value = CodigoPostal.Text;
                    localidad1.Value = Localidad.Text;
                    ciudad1.Value = Ciudad.Text;
                    nroPiso1.Value = NroPiso.Text;
                    dpto1.Value = Departamento.Text;


                    command1.ExecuteNonQuery();
                    MessageBox.Show("Hecho");
                    conn.Close();
                    this.Visible = false;
                   

                break;
            }    
    }

        private void Direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarDireccion_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        } 
    }
}
