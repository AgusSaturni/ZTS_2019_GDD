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

namespace FrbaOfertas
{
    public partial class InicioDeSesion : Form
    {
        public InicioDeSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form registroUsuario = new RegistroUsuario();
            registroUsuario.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  string usuario;

         //   string strcomando = "Select username from USUARIOS";
          //  string conexion = @"Data Source=LAPTOP-3SMJF7AG\SQLSERVER2012;Initial Catalog=GD2C2019;Persist Security Info=True;User ID=gdCupon2019;Password=gd2019";
         //   SqlConnection conn = new SqlConnection(conexion);
          //  SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(strcomando,conexion);
          //  conn.Open();
         //   DataSet tabla_clientes = new DataSet();
            //adapter.Fill(tabla_clientes);

            Form menuABM = new MenuABM();
            menuABM.Show();
            this.Visible = false;


        }
    }
}
