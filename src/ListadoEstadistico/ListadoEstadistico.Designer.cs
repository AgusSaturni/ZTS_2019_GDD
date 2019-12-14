namespace FrbaOfertas.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_año = new System.Windows.Forms.DateTimePicker();
            this.rbt_segundo_semestre = new System.Windows.Forms.RadioButton();
            this.rbt_primer_semestre = new System.Windows.Forms.RadioButton();
            this.PorcentajeDescuento = new System.Windows.Forms.CheckBox();
            this.MayorFacturacion = new System.Windows.Forms.CheckBox();
            this.bt_limpiar = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.contenedor_proveedores = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_proveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_limpiar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.PorcentajeDescuento);
            this.groupBox1.Controls.Add(this.MayorFacturacion);
            this.groupBox1.Controls.Add(this.bt_limpiar);
            this.groupBox1.Controls.Add(this.bt_buscar);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(603, 192);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_limpiar.Location = new System.Drawing.Point(403, 125);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(176, 31);
            this.btn_limpiar.TabIndex = 13;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtp_año);
            this.groupBox2.Controls.Add(this.rbt_segundo_semestre);
            this.groupBox2.Controls.Add(this.rbt_primer_semestre);
            this.groupBox2.Location = new System.Drawing.Point(17, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 72);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar Semestre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Año:";
            // 
            // dtp_año
            // 
            this.dtp_año.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_año.Location = new System.Drawing.Point(222, 30);
            this.dtp_año.Name = "dtp_año";
            this.dtp_año.Size = new System.Drawing.Size(78, 20);
            this.dtp_año.TabIndex = 14;
            // 
            // rbt_segundo_semestre
            // 
            this.rbt_segundo_semestre.AutoSize = true;
            this.rbt_segundo_semestre.Location = new System.Drawing.Point(20, 49);
            this.rbt_segundo_semestre.Name = "rbt_segundo_semestre";
            this.rbt_segundo_semestre.Size = new System.Drawing.Size(115, 17);
            this.rbt_segundo_semestre.TabIndex = 13;
            this.rbt_segundo_semestre.TabStop = true;
            this.rbt_segundo_semestre.Text = "Segundo Semestre";
            this.rbt_segundo_semestre.UseVisualStyleBackColor = true;
            // 
            // rbt_primer_semestre
            // 
            this.rbt_primer_semestre.AutoSize = true;
            this.rbt_primer_semestre.Location = new System.Drawing.Point(20, 19);
            this.rbt_primer_semestre.Name = "rbt_primer_semestre";
            this.rbt_primer_semestre.Size = new System.Drawing.Size(101, 17);
            this.rbt_primer_semestre.TabIndex = 12;
            this.rbt_primer_semestre.TabStop = true;
            this.rbt_primer_semestre.Text = "Primer Semestre";
            this.rbt_primer_semestre.UseVisualStyleBackColor = true;
            // 
            // PorcentajeDescuento
            // 
            this.PorcentajeDescuento.AutoSize = true;
            this.PorcentajeDescuento.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PorcentajeDescuento.Location = new System.Drawing.Point(17, 21);
            this.PorcentajeDescuento.Name = "PorcentajeDescuento";
            this.PorcentajeDescuento.Size = new System.Drawing.Size(252, 20);
            this.PorcentajeDescuento.TabIndex = 0;
            this.PorcentajeDescuento.Text = "Mayor Porcentaje de Descuento";
            this.PorcentajeDescuento.UseVisualStyleBackColor = true;
            this.PorcentajeDescuento.CheckedChanged += new System.EventHandler(this.PorcentajeDescuento_CheckedChanged_1);
            // 
            // MayorFacturacion
            // 
            this.MayorFacturacion.AutoSize = true;
            this.MayorFacturacion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.MayorFacturacion.Location = new System.Drawing.Point(17, 47);
            this.MayorFacturacion.Name = "MayorFacturacion";
            this.MayorFacturacion.Size = new System.Drawing.Size(157, 20);
            this.MayorFacturacion.TabIndex = 1;
            this.MayorFacturacion.Text = "Mayor Facturacion";
            this.MayorFacturacion.UseVisualStyleBackColor = true;
            this.MayorFacturacion.CheckedChanged += new System.EventHandler(this.MayorFacturacion_CheckedChanged_1);
            // 
            // bt_limpiar
            // 
            this.bt_limpiar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_limpiar.Location = new System.Drawing.Point(403, 75);
            this.bt_limpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_limpiar.Name = "bt_limpiar";
            this.bt_limpiar.Size = new System.Drawing.Size(176, 31);
            this.bt_limpiar.TabIndex = 6;
            this.bt_limpiar.Text = "Volver";
            this.bt_limpiar.UseVisualStyleBackColor = true;
            this.bt_limpiar.Click += new System.EventHandler(this.bt_limpiar_Click_1);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_buscar.Location = new System.Drawing.Point(403, 27);
            this.bt_buscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(176, 28);
            this.bt_buscar.TabIndex = 5;
            this.bt_buscar.Text = "Generar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // contenedor_proveedores
            // 
            this.contenedor_proveedores.AllowUserToAddRows = false;
            this.contenedor_proveedores.AllowUserToDeleteRows = false;
            this.contenedor_proveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.contenedor_proveedores.BackgroundColor = System.Drawing.Color.White;
            this.contenedor_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contenedor_proveedores.Enabled = false;
            this.contenedor_proveedores.Location = new System.Drawing.Point(8, 197);
            this.contenedor_proveedores.MultiSelect = false;
            this.contenedor_proveedores.Name = "contenedor_proveedores";
            this.contenedor_proveedores.ReadOnly = true;
            this.contenedor_proveedores.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.contenedor_proveedores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.contenedor_proveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contenedor_proveedores.Size = new System.Drawing.Size(607, 152);
            this.contenedor_proveedores.TabIndex = 44;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 353);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.contenedor_proveedores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListadoEstadistico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_proveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox PorcentajeDescuento;
        private System.Windows.Forms.CheckBox MayorFacturacion;
        private System.Windows.Forms.Button bt_limpiar;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.DataGridView contenedor_proveedores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_año;
        private System.Windows.Forms.RadioButton rbt_segundo_semestre;
        private System.Windows.Forms.RadioButton rbt_primer_semestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_limpiar;
    }
}