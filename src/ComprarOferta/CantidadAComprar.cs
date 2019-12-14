using FrbaOfertas.Manejo_Logico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class CantidadAComprar : Form
    {
            private   string descripcion_semilla2;
            private   string proveedor_semilla2;
            private   float precio_lista_semilla2;
            private   float precio_oferta_semilla2;
            private   float precio_oferta2;
            private   float precio_lista2;
            private   int cantidadDispo2;
            private int cantMaxUser2;
            private DateTime fecha_publicacion;
            private DateTime fecha_vencimiento;
            private string codigo_oferta;
            private string username = (Singleton_Usuario.getInstance()).get_username();
            private DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

        public CantidadAComprar()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public CantidadAComprar(string descripcion_semilla, string proveedor_semilla, float precio_lista_semilla, float precio_oferta_semilla, float precio_oferta, float precio_lista, int cantidadDispo, int cantMaxUser, DateTime fecha_publicacion, DateTime fecha_vencimiento, string codigo_oferta)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.descripcion_semilla2 = descripcion_semilla;
            this.proveedor_semilla2 = proveedor_semilla;
            this.precio_lista_semilla2 = precio_lista_semilla;
            this.precio_oferta_semilla2 = precio_oferta_semilla;
            this.precio_oferta2 = precio_oferta;
            this.precio_lista2 = precio_lista;
            this.cantidadDispo2 = cantidadDispo;
            this.cantMaxUser2 = cantMaxUser;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_vencimiento = fecha_vencimiento;
            this.codigo_oferta = codigo_oferta;
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        public CantidadAComprar(string sesion_username, string descripcion_semilla, string proveedor_semilla, float precio_lista_semilla, float precio_oferta_semilla, float precio_oferta, float precio_lista, int cantidadDispo, int cantMaxUser, DateTime fecha_publicacion, DateTime fecha_vencimiento, string codigo_oferta)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.descripcion_semilla2 = descripcion_semilla;
            this.proveedor_semilla2 = proveedor_semilla;
            this.precio_lista_semilla2 = precio_lista_semilla;
            this.precio_oferta_semilla2 = precio_oferta_semilla;
            this.precio_oferta2 = precio_oferta;
            this.precio_lista2 = precio_lista;
            this.cantidadDispo2 = cantidadDispo;
            this.cantMaxUser2 = cantMaxUser;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_vencimiento = fecha_vencimiento;
            this.codigo_oferta = codigo_oferta;
            username = sesion_username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            
            conexionBD conexion = conexionBD.getConexion();
            SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());



            SqlCommand command = new SqlCommand("ZTS_DB.comprar_oferta", conexion_sql);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@precioLista", SqlDbType.Float).Value = (precio_lista2);
            command.Parameters.AddWithValue("@precio_oferta", SqlDbType.Float).Value =(precio_oferta2);
            command.Parameters.AddWithValue("@clienteUsuario", SqlDbType.Char).Value = (username);
            command.Parameters.AddWithValue("@cantidadDisponible", SqlDbType.Int).Value =(cantidadDispo2);
            command.Parameters.AddWithValue("@cantidadCompra", SqlDbType.Int).Value = (Cantidad.Value);
            command.Parameters.AddWithValue("@cantidadMaxUsuario", SqlDbType.Int).Value = (cantMaxUser2);
            command.Parameters.AddWithValue("@codigoOferta", SqlDbType.Int).Value = (codigo_oferta);
            command.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = (fecha);

            conexion_sql.Open();
                    
                      
            try
            {
                command.ExecuteNonQuery();


                string cmd = "SELECT top 1 codigo_cupon FROM ZTS_DB.CUPONES  WHERE Codigo_oferta = '" + codigo_oferta + "' order by 1 desc "; 
                SqlCommand command1 = new SqlCommand(cmd, conexion_sql);
                          
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {       
                        string codigoCupon = (reader[0].ToString());
                        MessageBox.Show("Compra realizada con Éxito. Su código de cupón es: " + codigoCupon);

                }
            }
            catch (SqlException excepcion1)
            {
                SqlError errores = excepcion1.Errors[0];
                MessageBox.Show(errores.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion_sql.Close();
                return;
            }
                 
            conexion_sql.Close();
            bt_volver.PerformClick();
           
        }

        private void bt_volver_Click(object sender, EventArgs e)
        {
            Form ofertas = new Ofertas();
            ofertas.Show();
            this.Close();
        }            

        

   }
}

