namespace FrbaOfertas.ComprarOferta
{
    partial class Ofertas
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
            this.btn_volver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_limpiar = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.Descripcion = new System.Windows.Forms.TextBox();
            this.contenedor_ofertas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.minimo = new System.Windows.Forms.NumericUpDown();
            this.maximo = new System.Windows.Forms.NumericUpDown();
            this.rango = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_ofertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rango);
            this.groupBox1.Controls.Add(this.maximo);
            this.groupBox1.Controls.Add(this.minimo);
            this.groupBox1.Controls.Add(this.btn_volver);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_limpiar);
            this.groupBox1.Controls.Add(this.bt_buscar);
            this.groupBox1.Controls.Add(this.Descripcion);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(785, 131);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_volver.Location = new System.Drawing.Point(497, 84);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(267, 30);
            this.btn_volver.TabIndex = 11;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(217, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Desde";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Descripcion";
            // 
            // bt_limpiar
            // 
            this.bt_limpiar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_limpiar.Location = new System.Drawing.Point(497, 50);
            this.bt_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_limpiar.Name = "bt_limpiar";
            this.bt_limpiar.Size = new System.Drawing.Size(267, 28);
            this.bt_limpiar.TabIndex = 5;
            this.bt_limpiar.Text = "Limpiar";
            this.bt_limpiar.UseVisualStyleBackColor = true;
            this.bt_limpiar.Click += new System.EventHandler(this.bt_limpiar_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_buscar.Location = new System.Drawing.Point(497, 16);
            this.bt_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(267, 28);
            this.bt_buscar.TabIndex = 4;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // Descripcion
            // 
            this.Descripcion.Location = new System.Drawing.Point(111, 22);
            this.Descripcion.Margin = new System.Windows.Forms.Padding(2);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(282, 20);
            this.Descripcion.TabIndex = 0;
            // 
            // contenedor_ofertas
            // 
            this.contenedor_ofertas.AllowUserToAddRows = false;
            this.contenedor_ofertas.AllowUserToDeleteRows = false;
            this.contenedor_ofertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contenedor_ofertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.contenedor_ofertas.Location = new System.Drawing.Point(11, 147);
            this.contenedor_ofertas.Name = "contenedor_ofertas";
            this.contenedor_ofertas.ReadOnly = true;
            this.contenedor_ofertas.Size = new System.Drawing.Size(786, 281);
            this.contenedor_ofertas.TabIndex = 11;
            this.contenedor_ofertas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contenedor_ofertas_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Comprar";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // minimo
            // 
            this.minimo.DecimalPlaces = 2;
            this.minimo.Location = new System.Drawing.Point(64, 98);
            this.minimo.Name = "minimo";
            this.minimo.Size = new System.Drawing.Size(120, 20);
            this.minimo.TabIndex = 12;
            // 
            // maximo
            // 
            this.maximo.DecimalPlaces = 2;
            this.maximo.Location = new System.Drawing.Point(259, 98);
            this.maximo.Name = "maximo";
            this.maximo.Size = new System.Drawing.Size(120, 20);
            this.maximo.TabIndex = 13;
            // 
            // rango
            // 
            this.rango.AutoSize = true;
            this.rango.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.rango.Location = new System.Drawing.Point(20, 63);
            this.rango.Name = "rango";
            this.rango.Size = new System.Drawing.Size(122, 18);
            this.rango.TabIndex = 14;
            this.rango.Text = "Rango de Precios";
            this.rango.UseVisualStyleBackColor = true;
            this.rango.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Ofertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 443);
            this.Controls.Add(this.contenedor_ofertas);
            this.Controls.Add(this.groupBox1);
            this.Name = "Ofertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ofertas";
            this.Load += new System.EventHandler(this.Ofertas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_ofertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_limpiar;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.TextBox Descripcion;
        private System.Windows.Forms.DataGridView contenedor_ofertas;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.NumericUpDown maximo;
        private System.Windows.Forms.NumericUpDown minimo;
        private System.Windows.Forms.CheckBox rango;
    }
}