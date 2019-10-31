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
            string cadenaConex = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
            SqlConnection conn = new SqlConnection(cadenaConex);

            conn.Open();


        //-------------datos usuario---------------


            SqlCommand command = new SqlCommand("registrar_usuario",conn);
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

            username1.Value = usuario;
            password1.Value = password;
            rol1.Value = rol;

            //----------Direccion----------------------
            SqlCommand command2 = new SqlCommand("registrar_Domicilio", conn);
            command2.CommandType = CommandType.StoredProcedure;

           SqlParameter direccion = new SqlParameter("@Direccion", SqlDbType.Char);
            direccion.Direction = ParameterDirection.Input;
            command2.Parameters.Add(direccion);

            SqlParameter codPostal = new SqlParameter("@codigo_Postal", SqlDbType.Float);
            codPostal.Direction = ParameterDirection.Input;
            command2.Parameters.Add(codPostal);

            SqlParameter localidad = new SqlParameter("@Localidad", SqlDbType.Char);
            localidad.Direction = ParameterDirection.Input;
            command2.Parameters.Add(localidad);

            SqlParameter ciudad = new SqlParameter("@Ciudad", SqlDbType.Char);
            direccion.Direction = ParameterDirection.Input;
            command2.Parameters.Add(ciudad);

            SqlParameter nroPiso = new SqlParameter("@Nro_Piso", SqlDbType.Int);
            nroPiso.Direction = ParameterDirection.Input;
            command2.Parameters.Add(nroPiso);

            SqlParameter dpto = new SqlParameter("@Depto", SqlDbType.Char);
            dpto.Direction = ParameterDirection.Input;
            command2.Parameters.Add(dpto);

            direccion.Value = Direccion.Text;
            codPostal.Value = CodigoPostal.Text;
            localidad.Value = Localidad.Text;
            ciudad.Value = Ciudad.Text;
            nroPiso.Value = NroPiso.Text;
            dpto.Value = Departamento.Text;
           

      //-------------Datos cliente------------

            if (rol.ToString() == "Cliente")
            {
                SqlCommand command3 = new SqlCommand("registrar_usuario_cliente", conn);
                command3.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre_cliente = new SqlParameter("@Nombre", SqlDbType.Char);
                nombre_cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(nombre_cliente);


                SqlParameter apellido_cliente = new SqlParameter("@Apellido", SqlDbType.Char);
                apellido_cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(apellido_cliente);

                SqlParameter DNI_cliente = new SqlParameter("@DNI", SqlDbType.Float);
                DNI_cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(DNI_cliente);

                SqlParameter telefono_cliente = new SqlParameter("@Telefono", SqlDbType.Float);
                telefono_cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(telefono_cliente);

                SqlParameter fechaNacimiento_cliente = new SqlParameter("@Fecha_nacimiento", SqlDbType.Date);
                fechaNacimiento_cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(fechaNacimiento_cliente);

                SqlParameter mail_cliente = new SqlParameter("@Mail", SqlDbType.Char);
                mail_cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(mail_cliente);

                SqlParameter direccion_Cliente = new SqlParameter("@Direccion", SqlDbType.Char);
                direccion_Cliente.Direction = ParameterDirection.Input;
                command3.Parameters.Add(direccion_Cliente);

                nombre_cliente.Value = nombre;
                apellido_cliente.Value = apellido;
                DNI_cliente.Value = DNI;
                telefono_cliente.Value = telefono;
                fechaNacimiento_cliente.Value = fechaDeNacimiento;
                mail_cliente.Value = mail;
                direccion_Cliente.Value = Direccion.Text;

                if (direccion.Value.ToString() != "" && codPostal.Value.ToString() != "" && localidad.Value.ToString() != "" && ciudad.Value.ToString() != "" && nroPiso.Value.ToString() != "" && dpto.Value.ToString() != "")
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        command3.ExecuteNonQuery();

                        MessageBox.Show("Hecho");
                        this.Visible = false;
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Faltan completar campos");
                }
            }
            else
            {
                SqlCommand command3 = new SqlCommand("registrar_usuario_proveedor", conn);
                command3.CommandType = CommandType.StoredProcedure;

                SqlParameter razon_social1 = new SqlParameter("@Razon_Social", SqlDbType.Char);
                razon_social1.Direction = ParameterDirection.Input;
                command3.Parameters.Add(razon_social1);


                SqlParameter mail_Proveedor = new SqlParameter("@Mail", SqlDbType.Char);
                mail_Proveedor.Direction = ParameterDirection.Input;
                command3.Parameters.Add(mail_Proveedor);

                SqlParameter telefono_proveedor = new SqlParameter("@Telefono", SqlDbType.Float);
                telefono_proveedor.Direction = ParameterDirection.Input;
                command3.Parameters.Add(telefono_proveedor);

                SqlParameter cuit1 = new SqlParameter("@CUIT", SqlDbType.Char);
                cuit1.Direction = ParameterDirection.Input;
                command3.Parameters.Add(cuit1);

                SqlParameter rubro1 = new SqlParameter("@Rubro", SqlDbType.Char);
                rubro1.Direction = ParameterDirection.Input;
                command3.Parameters.Add(rubro1);

                SqlParameter contacto1 = new SqlParameter("@Nombre_contacto", SqlDbType.Char);
                contacto1.Direction = ParameterDirection.Input;
                command3.Parameters.Add(contacto1);

                SqlParameter direccion_Proveedor = new SqlParameter("@Direccion", SqlDbType.Char);
                direccion_Proveedor.Direction = ParameterDirection.Input;
                command3.Parameters.Add(direccion_Proveedor);


                razon_social1.Value = razonSocial;
                cuit1.Value = cuit;  
                telefono_proveedor.Value = telefono;
                rubro1.Value = rubro;
                mail_Proveedor.Value = mail;
                direccion_Proveedor.Value = Direccion.Text;
                contacto1.Value = contacto;


                if (direccion.Value.ToString() != "" && codPostal.Value.ToString() != "" && localidad.Value.ToString() != "" && ciudad.Value.ToString() != "" && nroPiso.Value.ToString() != "" && dpto.Value.ToString() != "")
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        command2.ExecuteNonQuery();
                        command3.ExecuteNonQuery();

                        MessageBox.Show("Hecho");
                        this.Visible = false;
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Faltan completar campos");
                }

            }
        }

        private void Direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarDireccion_Load(object sender, EventArgs e)
        {

        } 
    }
}
