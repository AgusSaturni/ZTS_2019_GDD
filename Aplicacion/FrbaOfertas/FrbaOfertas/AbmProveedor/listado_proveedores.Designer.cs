﻿namespace FrbaOfertas.AbmProveedor
{
    partial class listado_proveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contenedor_proveedores = new System.Windows.Forms.DataGridView();
            this.dgv_eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgv_modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_RazonS = new System.Windows.Forms.TextBox();
            this.txt_CUIT = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.bt_limpiar = new System.Windows.Forms.Button();
            this.asd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Rubro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_proveedores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contenedor_proveedores
            // 
            this.contenedor_proveedores.AllowUserToAddRows = false;
            this.contenedor_proveedores.AllowUserToDeleteRows = false;
            this.contenedor_proveedores.AllowUserToResizeRows = false;
            this.contenedor_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contenedor_proveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_eliminar,
            this.dgv_modificar});
            this.contenedor_proveedores.Location = new System.Drawing.Point(16, 218);
            this.contenedor_proveedores.Name = "contenedor_proveedores";
            this.contenedor_proveedores.ReadOnly = true;
            this.contenedor_proveedores.RowTemplate.Height = 28;
            this.contenedor_proveedores.Size = new System.Drawing.Size(1311, 428);
            this.contenedor_proveedores.TabIndex = 10;
            this.contenedor_proveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contenedor_clientes_CellContentClick);
            // 
            // dgv_eliminar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_eliminar.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_eliminar.HeaderText = "Eliminar";
            this.dgv_eliminar.Name = "dgv_eliminar";
            this.dgv_eliminar.ReadOnly = true;
            this.dgv_eliminar.Width = 50;
            // 
            // dgv_modificar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.dgv_modificar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_modificar.HeaderText = "Modificar";
            this.dgv_modificar.Name = "dgv_modificar";
            this.dgv_modificar.ReadOnly = true;
            this.dgv_modificar.Width = 55;
            // 
            // txt_RazonS
            // 
            this.txt_RazonS.Location = new System.Drawing.Point(146, 34);
            this.txt_RazonS.Name = "txt_RazonS";
            this.txt_RazonS.Size = new System.Drawing.Size(632, 26);
            this.txt_RazonS.TabIndex = 0;
            // 
            // txt_CUIT
            // 
            this.txt_CUIT.Location = new System.Drawing.Point(146, 71);
            this.txt_CUIT.Name = "txt_CUIT";
            this.txt_CUIT.Size = new System.Drawing.Size(632, 26);
            this.txt_CUIT.TabIndex = 2;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(146, 111);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(632, 26);
            this.txt_email.TabIndex = 3;
            // 
            // bt_buscar
            // 
            this.bt_buscar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_buscar.Location = new System.Drawing.Point(828, 51);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(450, 43);
            this.bt_buscar.TabIndex = 4;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // bt_limpiar
            // 
            this.bt_limpiar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_limpiar.Location = new System.Drawing.Point(828, 111);
            this.bt_limpiar.Name = "bt_limpiar";
            this.bt_limpiar.Size = new System.Drawing.Size(450, 43);
            this.bt_limpiar.TabIndex = 5;
            this.bt_limpiar.Text = "Limpiar";
            this.bt_limpiar.UseVisualStyleBackColor = true;
            this.bt_limpiar.Click += new System.EventHandler(this.bt_limpiar_Click);
            // 
            // asd
            // 
            this.asd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.asd.Location = new System.Drawing.Point(26, 38);
            this.asd.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(106, 26);
            this.asd.TabIndex = 7;
            this.asd.Text = "Razon Social";
            this.asd.Click += new System.EventHandler(this.asd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(26, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "CUIT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(26, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "EMAIL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Rubro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.asd);
            this.groupBox1.Controls.Add(this.bt_limpiar);
            this.groupBox1.Controls.Add(this.bt_buscar);
            this.groupBox1.Controls.Add(this.txt_email);
            this.groupBox1.Controls.Add(this.txt_CUIT);
            this.groupBox1.Controls.Add(this.txt_RazonS);
            this.groupBox1.Location = new System.Drawing.Point(16, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1311, 209);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(26, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rubro";
            // 
            // txt_Rubro
            // 
            this.txt_Rubro.Location = new System.Drawing.Point(146, 148);
            this.txt_Rubro.Name = "txt_Rubro";
            this.txt_Rubro.Size = new System.Drawing.Size(632, 26);
            this.txt_Rubro.TabIndex = 9;
            // 
            // listado_proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 660);
            this.Controls.Add(this.contenedor_proveedores);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "listado_proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "listado_proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_proveedores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView contenedor_proveedores;
        private System.Windows.Forms.DataGridViewButtonColumn dgv_eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn dgv_modificar;
        private System.Windows.Forms.TextBox txt_RazonS;
        private System.Windows.Forms.TextBox txt_CUIT;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.Button bt_limpiar;
        private System.Windows.Forms.Label asd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Rubro;

    }
}