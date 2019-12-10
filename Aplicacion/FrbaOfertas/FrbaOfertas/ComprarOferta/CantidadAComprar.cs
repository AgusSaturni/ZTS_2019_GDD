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


                     command.Parameters.AddWithValue("@precioLista", SqlDbType.Float).Value = (precio_lista2);
                     command.Parameters.AddWithValue("@precio_oferta", SqlDbType.Float).Value =(precio_oferta2);
                     command.Parameters.AddWithValue("@clienteUsuario", SqlDbType.Char).Value = (username);
                     command.Parameters.AddWithValue("@cantidadDisponible", SqlDbType.Int).Value =(cantidadDispo2);
                     command.Parameters.AddWithValue("@cantidadCompra", SqlDbType.Int).Value = (Cantidad.Value);
                     command.Parameters.AddWithValue("@cantidadMaxUsuario", SqlDbType.Int).Value = (cantMaxUser2);

                     command2.Parameters.AddWithValue("@proveedor_id", SqlDbType.Char).Value = (proveedor_semilla2);
                     command2.Parameters.AddWithValue("@descripcion", SqlDbType.Char).Value = (descripcion_semilla2);
                     command2.Parameters.AddWithValue("@precio_oferta", SqlDbType.Char).Value = (precio_oferta_semilla2);
                     command2.Parameters.AddWithValue("@precio_lista", SqlDbType.Char).Value = (precio_lista_semilla2);

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
                                   MessageBox.Show("Compra realizada con Éxito. Su código de cupón es: " + codigoCupon);

                            }
                        }
                        catch (SqlException excepcion1)
                        {
                            SqlError errores = excepcion1.Errors[0];
                            MessageBox.Show(errores.Message.ToString());
                            return;
                        }
                        
                }
                         
          conexion_sql.Close();
          this.Hide();
        }            
   }
}

