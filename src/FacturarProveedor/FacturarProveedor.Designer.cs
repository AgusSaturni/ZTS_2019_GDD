namespace FrbaOfertas.Facturar
{
    partial class FacturarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturarProveedor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_proveedores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_visualizacion = new System.Windows.Forms.ComboBox();
            this.btn_visualizar = new System.Windows.Forms.Button();
            this.lbl_total_facturado = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.lbl_facturado = new System.Windows.Forms.Label();
            this.btn_facturar = new System.Windows.Forms.Button();
            this.dgv_facturas = new System.Windows.Forms.DataGridView();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.lbl_hasta = new System.Windows.Forms.Label();
            this.lbl_desde = new System.Windows.Forms.Label();
            this.lbl_proveedor = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_proveedores);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_visualizacion);
            this.groupBox1.Controls.Add(this.btn_visualizar);
            this.groupBox1.Controls.Add(this.lbl_total_facturado);
            this.groupBox1.Controls.Add(this.btn_volver);
            this.groupBox1.Controls.Add(this.lbl_facturado);
            this.groupBox1.Controls.Add(this.btn_facturar);
            this.groupBox1.Controls.Add(this.dgv_facturas);
            this.groupBox1.Controls.Add(this.dtp_hasta);
            this.groupBox1.Controls.Add(this.dtp_desde);
            this.groupBox1.Controls.Add(this.lbl_hasta);
            this.groupBox1.Controls.Add(this.lbl_desde);
            this.groupBox1.Controls.Add(this.lbl_proveedor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 474);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbo_proveedores
            // 
            this.cbo_proveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_proveedores.FormattingEnabled = true;
            this.cbo_proveedores.Items.AddRange(new object[] {
            "Elegir un proveedor..."});
            this.cbo_proveedores.Location = new System.Drawing.Point(132, 35);
            this.cbo_proveedores.Name = "cbo_proveedores";
            this.cbo_proveedores.Size = new System.Drawing.Size(200, 21);
            this.cbo_proveedores.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Visualizacion";
            // 
            // cbo_visualizacion
            // 
            this.cbo_visualizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_visualizacion.FormattingEnabled = true;
            this.cbo_visualizacion.Items.AddRange(new object[] {
            "No Facturado",
            "Facturado",
            "Ambos"});
            this.cbo_visualizacion.Location = new System.Drawing.Point(132, 190);
            this.cbo_visualizacion.Name = "cbo_visualizacion";
            this.cbo_visualizacion.Size = new System.Drawing.Size(200, 21);
            this.cbo_visualizacion.TabIndex = 14;
            this.cbo_visualizacion.TextChanged += new System.EventHandler(this.cbo_visualizacion_TextChanged);
            // 
            // btn_visualizar
            // 
            this.btn_visualizar.Location = new System.Drawing.Point(393, 32);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Size = new System.Drawing.Size(199, 31);
            this.btn_visualizar.TabIndex = 13;
            this.btn_visualizar.Text = "Visualizar";
            this.btn_visualizar.UseVisualStyleBackColor = true;
            this.btn_visualizar.Click += new System.EventHandler(this.btn_visualizar_Click);
            // 
            // lbl_total_facturado
            // 
            this.lbl_total_facturado.AutoSize = true;
            this.lbl_total_facturado.Location = new System.Drawing.Point(415, 193);
            this.lbl_total_facturado.Name = "lbl_total_facturado";
            this.lbl_total_facturado.Size = new System.Drawing.Size(85, 13);
            this.lbl_total_facturado.TabIndex = 12;
            this.lbl_total_facturado.Text = "Total Facturado:";
            // 
            // btn_volver
            // 
            this.btn_volver.Location = new System.Drawing.Point(393, 134);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(199, 30);
            this.btn_volver.TabIndex = 11;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // lbl_facturado
            // 
            this.lbl_facturado.AutoSize = true;
            this.lbl_facturado.Location = new System.Drawing.Point(543, 193);
            this.lbl_facturado.Name = "lbl_facturado";
            this.lbl_facturado.Size = new System.Drawing.Size(13, 13);
            this.lbl_facturado.TabIndex = 10;
            this.lbl_facturado.Text = "0";
            // 
            // btn_facturar
            // 
            this.btn_facturar.Location = new System.Drawing.Point(393, 85);
            this.btn_facturar.Name = "btn_facturar";
            this.btn_facturar.Size = new System.Drawing.Size(199, 31);
            this.btn_facturar.TabIndex = 9;
            this.btn_facturar.Text = "Facturar";
            this.btn_facturar.UseVisualStyleBackColor = true;
            this.btn_facturar.Click += new System.EventHandler(this.btn_facturar_Click);
            // 
            // dgv_facturas
            // 
            this.dgv_facturas.AllowUserToAddRows = false;
            this.dgv_facturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_facturas.Location = new System.Drawing.Point(29, 238);
            this.dgv_facturas.MultiSelect = false;
            this.dgv_facturas.Name = "dgv_facturas";
            this.dgv_facturas.ReadOnly = true;
            this.dgv_facturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_facturas.Size = new System.Drawing.Size(607, 221);
            this.dgv_facturas.TabIndex = 8;
            this.dgv_facturas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_facturas_RowsAdded);
            this.dgv_facturas.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_facturas_RowsRemoved);
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Location = new System.Drawing.Point(132, 137);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(200, 20);
            this.dtp_hasta.TabIndex = 7;
            // 
            // dtp_desde
            // 
            this.dtp_desde.Location = new System.Drawing.Point(132, 88);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(200, 20);
            this.dtp_desde.TabIndex = 6;
            // 
            // lbl_hasta
            // 
            this.lbl_hasta.AutoSize = true;
            this.lbl_hasta.Location = new System.Drawing.Point(26, 137);
            this.lbl_hasta.Name = "lbl_hasta";
            this.lbl_hasta.Size = new System.Drawing.Size(35, 13);
            this.lbl_hasta.TabIndex = 4;
            this.lbl_hasta.Text = "Hasta";
            // 
            // lbl_desde
            // 
            this.lbl_desde.AutoSize = true;
            this.lbl_desde.Location = new System.Drawing.Point(26, 88);
            this.lbl_desde.Name = "lbl_desde";
            this.lbl_desde.Size = new System.Drawing.Size(38, 13);
            this.lbl_desde.TabIndex = 3;
            this.lbl_desde.Text = "Desde";
            // 
            // lbl_proveedor
            // 
            this.lbl_proveedor.AutoSize = true;
            this.lbl_proveedor.Location = new System.Drawing.Point(26, 38);
            this.lbl_proveedor.Name = "lbl_proveedor";
            this.lbl_proveedor.Size = new System.Drawing.Size(56, 13);
            this.lbl_proveedor.TabIndex = 0;
            this.lbl_proveedor.Text = "Proveedor";
            // 
            // FacturarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 495);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FacturarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación a Proveedor";
            this.Load += new System.EventHandler(this.FacturarProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_total_facturado;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Label lbl_facturado;
        private System.Windows.Forms.Button btn_facturar;
        private System.Windows.Forms.DataGridView dgv_facturas;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.Label lbl_hasta;
        private System.Windows.Forms.Label lbl_desde;
        private System.Windows.Forms.Label lbl_proveedor;
        private System.Windows.Forms.Button btn_visualizar;
        private System.Windows.Forms.ComboBox cbo_visualizacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_proveedores;
    }
}