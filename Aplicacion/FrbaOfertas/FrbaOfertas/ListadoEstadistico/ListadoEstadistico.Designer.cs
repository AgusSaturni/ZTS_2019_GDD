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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Hasta = new System.Windows.Forms.DateTimePicker();
            this.Desde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.PorcentajeDescuento = new System.Windows.Forms.CheckBox();
            this.MayorFacturacion = new System.Windows.Forms.CheckBox();
            this.bt_limpiar = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.contenedor_proveedores = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_proveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Hasta);
            this.groupBox1.Controls.Add(this.Desde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PorcentajeDescuento);
            this.groupBox1.Controls.Add(this.MayorFacturacion);
            this.groupBox1.Controls.Add(this.bt_limpiar);
            this.groupBox1.Controls.Add(this.bt_buscar);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(603, 148);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Hasta
            // 
            this.Hasta.Location = new System.Drawing.Point(239, 111);
            this.Hasta.Name = "Hasta";
            this.Hasta.Size = new System.Drawing.Size(202, 20);
            this.Hasta.TabIndex = 9;
            // 
            // Desde
            // 
            this.Desde.Location = new System.Drawing.Point(17, 111);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(202, 20);
            this.Desde.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "+Seleccione el semestre:";
            // 
            // PorcentajeDescuento
            // 
            this.PorcentajeDescuento.AutoSize = true;
            this.PorcentajeDescuento.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PorcentajeDescuento.Location = new System.Drawing.Point(17, 18);
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
            this.MayorFacturacion.Location = new System.Drawing.Point(17, 44);
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
            this.bt_limpiar.Location = new System.Drawing.Point(423, 55);
            this.bt_limpiar.Margin = new System.Windows.Forms.Padding(2);
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
            this.bt_buscar.Location = new System.Drawing.Point(423, 13);
            this.bt_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(176, 28);
            this.bt_buscar.TabIndex = 5;
            this.bt_buscar.Text = "Generar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // contenedor_proveedores
            // 
            this.contenedor_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contenedor_proveedores.Location = new System.Drawing.Point(4, 153);
            this.contenedor_proveedores.Name = "contenedor_proveedores";
            this.contenedor_proveedores.Size = new System.Drawing.Size(607, 257);
            this.contenedor_proveedores.TabIndex = 44;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.contenedor_proveedores);
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_proveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker Hasta;
        private System.Windows.Forms.DateTimePicker Desde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PorcentajeDescuento;
        private System.Windows.Forms.CheckBox MayorFacturacion;
        private System.Windows.Forms.Button bt_limpiar;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.DataGridView contenedor_proveedores;
    }
}