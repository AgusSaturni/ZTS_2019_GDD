﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class MenuABM : Form
    {
        public MenuABM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form altaCliente = new AbmCliente.AltaCliente();
            altaCliente.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form listado = new AbmCliente.frm_listado_clientes();
            listado.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form listado = new AbmCliente.frm_listado_clientes();
            listado.Show();
        }
    }
}
