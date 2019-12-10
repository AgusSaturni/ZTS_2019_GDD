namespace FrbaOfertas.Entrega_ConsumoOferta
{
    partial class ListadoCupones
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
            this.contenedor_cupones = new System.Windows.Forms.DataGridView();
            this.Entregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_consumidos = new System.Windows.Forms.CheckBox();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.bt_limpiar = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.txt_cliente = new System.Windows.Forms.TextBox();
            this.txt_ofertaid = new System.Windows.Forms.TextBox();
            this.txt_cuponid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_cupones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contenedor_cupones
            // 
            this.contenedor_cupones.AllowUserToAddRows = false;
            this.contenedor_cupones.AllowUserToDeleteRows = false;
            this.contenedor_cupones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contenedor_cupones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entregar});
            this.contenedor_cupones.Location = new System.Drawing.Point(12, 258);
            this.contenedor_cupones.Name = "contenedor_cupones";
            this.contenedor_cupones.ReadOnly = true;
            this.contenedor_cupones.RowTemplate.Height = 28;
            this.contenedor_cupones.Size = new System.Drawing.Size(808, 407);
            this.contenedor_cupones.TabIndex = 0;
            this.contenedor_cupones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contenedor_cupones_CellContentClick);
            // 
            // Entregar
            // 
            this.Entregar.HeaderText = "EntregarCupon";
            this.Entregar.Name = "Entregar";
            this.Entregar.ReadOnly = true;
            this.Entregar.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_consumidos);
            this.groupBox1.Controls.Add(this.bt_cancelar);
            this.groupBox1.Controls.Add(this.bt_limpiar);
            this.groupBox1.Controls.Add(this.bt_buscar);
            this.groupBox1.Controls.Add(this.txt_cliente);
            this.groupBox1.Controls.Add(this.txt_ofertaid);
            this.groupBox1.Controls.Add(this.txt_cuponid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // checkBox_consumidos
            // 
            this.checkBox_consumidos.AutoSize = true;
            this.checkBox_consumidos.Location = new System.Drawing.Point(29, 195);
            this.checkBox_consumidos.Name = "checkBox_consumidos";
            this.checkBox_consumidos.Size = new System.Drawing.Size(254, 24);
            this.checkBox_consumidos.TabIndex = 2;
            this.checkBox_consumidos.Text = "Incluir Cupones ya consumidos";
            this.checkBox_consumidos.UseVisualStyleBackColor = true;
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar.Location = new System.Drawing.Point(556, 145);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(206, 38);
            this.bt_cancelar.TabIndex = 8;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // bt_limpiar
            // 
            this.bt_limpiar.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_limpiar.Location = new System.Drawing.Point(556, 92);
            this.bt_limpiar.Name = "bt_limpiar";
            this.bt_limpiar.Size = new System.Drawing.Size(206, 38);
            this.bt_limpiar.TabIndex = 7;
            this.bt_limpiar.Text = "Limpiar Filtros";
            this.bt_limpiar.UseVisualStyleBackColor = true;
            this.bt_limpiar.Click += new System.EventHandler(this.bt_limpiar_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_buscar.Location = new System.Drawing.Point(556, 36);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(206, 38);
            this.bt_buscar.TabIndex = 6;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // txt_cliente
            // 
            this.txt_cliente.Location = new System.Drawing.Point(273, 149);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(199, 26);
            this.txt_cliente.TabIndex = 5;
            // 
            // txt_ofertaid
            // 
            this.txt_ofertaid.Location = new System.Drawing.Point(273, 95);
            this.txt_ofertaid.Name = "txt_ofertaid";
            this.txt_ofertaid.Size = new System.Drawing.Size(199, 26);
            this.txt_ofertaid.TabIndex = 4;
            // 
            // txt_cuponid
            // 
            this.txt_cuponid.Location = new System.Drawing.Point(273, 39);
            this.txt_cuponid.Name = "txt_cuponid";
            this.txt_cuponid.Size = new System.Drawing.Size(199, 26);
            this.txt_cuponid.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID Oferta Asociado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Cupon";
            // 
            // ListadoCupones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.contenedor_cupones);
            this.Name = "ListadoCupones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListadoCupones";
            this.Load += new System.EventHandler(this.ListadoCupones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contenedor_cupones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView contenedor_cupones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button bt_limpiar;
        private System.Windows.Forms.Button bt_buscar;
        private System.Windows.Forms.TextBox txt_cliente;
        private System.Windows.Forms.TextBox txt_ofertaid;
        private System.Windows.Forms.TextBox txt_cuponid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Entregar;
        private System.Windows.Forms.CheckBox checkBox_consumidos;
    }
}