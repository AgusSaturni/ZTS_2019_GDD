using FrbaOfertas.Manejo_Logico;
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
            private   int cantMaxUser2;
            private string username = (Singleton_Usuario.getInstance()).get_username();

        public CantidadAComprar()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

public    CantidadAComprar(string descripcion_semilla,string proveedor_semilla,float precio_lista_semilla,float precio_oferta_semilla,float precio_oferta,float precio_lista,int cantidadDispo,int cantMaxUser)
    {
        // TODO: Complete member initialization
        InitializeComponent();
        MaximizeBox = false;
        this.descripcion_semilla2 = descripcion_semilla;
        this.proveedor_semilla2 = proveedor_semilla;
        this.precio_lista_semilla2 = precio_lista_semilla;
        this.precio_oferta_semilla2 = precio_oferta_semilla;
        this.precio_oferta2 = precio_oferta;
        this.precio_lista2 = precio_lista;
        this.cantidadDispo2 = cantidadDispo;
        this.cantMaxUser2 = cantMaxUser;
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            
                 conexionBD conexion = conexionBD.getConexion();
                 SqlConnection conexion_sql = new SqlConnection(conexion.get_cadena());
                
          

                     SqlCommand command = new SqlCommand("comprar_oferta", conexion_sql);
                     command.CommandType = CommandType.StoredProcedure;

                     SqlCommand command2 = new SqlCommand("obtener_codigo", conexion_sql);
                     command2.CommandType = CommandType.StoredProcedure;


                     SqlParameter codigo_oferta = new SqlParameter("@codigoOferta", SqlDbType.Char);
                     codigo_oferta.Direction = ParameterDirection.Input;
                     command.Parameters.Add(codigo_oferta);

                     SqlParameter precio_lista = new SqlParameter("@precioLista", SqlDbType.Float);
                     precio_lista.Direction = ParameterDirection.Input;
                     command.Parameters.Add(precio_lista);

                     SqlParameter precio_oferta = new SqlParameter("@precio_oferta", SqlDbType.Float);
                     precio_oferta.Direction = ParameterDirection.Input;
                     command.Parameters.Add(precio_oferta);

                     SqlParameter cliente = new SqlParameter("@clienteUsuario", SqlDbType.Char);
                     cliente.Direction = ParameterDirection.Input;
                     command.Parameters.Add(cliente);

                     SqlParameter cantidadDispo = new SqlParameter("@cantidadDisponible", SqlDbType.Int);
                     cantidadDispo.Direction = ParameterDirection.Input;
                     command.Parameters.Add(cantidadDispo);

                     SqlParameter cantidadCompra = new SqlParameter("@cantidadCompra", SqlDbType.Int);
                     cantidadCompra.Direction = ParameterDirection.Input;
                     command.Parameters.Add(cantidadCompra);


                     SqlParameter cantMaxUser = new SqlParameter("@cantidadMaxUsuario", SqlDbType.Int);
                     cantMaxUser.Direction = ParameterDirection.Input;
                     command.Parameters.Add(cantMaxUser);

                     SqlParameter proveedor_semilla = new SqlParameter("@proveedor_id", SqlDbType.Char);
                     proveedor_semilla.Direction = ParameterDirection.Input;
                     command2.Parameters.Add(proveedor_semilla);

                     SqlParameter descripcion_semilla = new SqlParameter("@descripcion", SqlDbType.Char);
                     descripcion_semilla.Direction = ParameterDirection.Input;
                     command2.Parameters.Add(descripcion_semilla);


                     SqlParameter precio_oferta_semilla = new SqlParameter("@precio_oferta", SqlDbType.Char);
                     precio_oferta_semilla.Direction = ParameterDirection.Input;
                     command2.Parameters.Add(precio_oferta_semilla);


                     SqlParameter precio_lista_semilla = new SqlParameter("@precio_lista", SqlDbType.Char);
                     precio_lista_semilla.Direction = ParameterDirection.Input;
                     command2.Parameters.Add(precio_lista_semilla);

                     descripcion_semilla.Value = descripcion_semilla2;
                     proveedor_semilla.Value = proveedor_semilla2;
                     precio_lista_semilla.Value = precio_lista_semilla2;
                     precio_oferta_semilla.Value =precio_oferta_semilla2 ;
                     precio_oferta.Value = precio_oferta2;
                     precio_lista.Value = precio_lista2;
                     cantidadDispo.Value = cantidadDispo2;
                     cantMaxUser.Value = cantMaxUser2;
                     cantidadCompra.Value = Cantidad.Value;
                     cliente.Value = username;
                      conexion_sql.Open();

                try {
                command2.ExecuteNonQuery();
                MessageBox.Show("No hay stock de la oferta que desea comprar.");
                }
                catch (SqlException exepcion)
                {          
                        SqlError codigo = exepcion.Errors[0];
                        codigo_oferta.Value = codigo.Message.ToString();

                        try
                        {
                            command.ExecuteNonQuery();


                            string cmd = "SELECT top 1 codigo_cupon FROM CUPONES  WHERE Codigo_oferta = '" + codigo_oferta.Value.ToString() + "' order by 1 desc "; 
                            SqlCommand command1 = new SqlCommand(cmd, conexion_sql);
                          
                            SqlDataReader reader = command1.ExecuteReader();

                            while (reader.Read())
                            {       
                                   string codigoCupon = (reader[0].ToString());
                                   MessageBox.Show(codigoCupon);

                            }
                        }
                        catch (SqlException excepcion1)
                        {
                            SqlError errores = excepcion1.Errors[0];
                            MessageBox.Show(errores.Message.ToString());
                        }
                        
                }
                         
          conexion_sql.Close();
          this.Hide();
        }            
   }
}

