namespace FrbaOfertas.CragaCredito
{
    partial class CargaDeCredito
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combobox_tipopago = new System.Windows.Forms.ComboBox();
            this.bt_cargar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_num_tarjeta = new System.Windows.Forms.TextBox();
            this.txt_cod_segu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_saldo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // txt_monto
            // 
            this.txt_monto.Location = new System.Drawing.Point(339, 100);
            this.txt_monto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(265, 26);
            this.txt_monto.TabIndex = 1;
            this.txt_monto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Pago";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // combobox_tipopago
            // 
            this.combobox_tipopago.FormattingEnabled = true;
            this.combobox_tipopago.Location = new System.Drawing.Point(339, 35);
            this.combobox_tipopago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.combobox_tipopago.Name = "combobox_tipopago";
            this.combobox_tipopago.Size = new System.Drawing.Size(265, 28);
            this.combobox_tipopago.TabIndex = 11;
            this.combobox_tipopago.Text = "Seleccione";
            // 
            // bt_cargar
            // 
            this.bt_cargar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_cargar.Location = new System.Drawing.Point(652, 177);
            this.bt_cargar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_cargar.Name = "bt_cargar";
            this.bt_cargar.Size = new System.Drawing.Size(455, 54);
            this.bt_cargar.TabIndex = 12;
            this.bt_cargar.Text = "Cargar";
            this.bt_cargar.UseVisualStyleBackColor = true;
            this.bt_cargar.Click += new System.EventHandler(this.bt_cargar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 225);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 33);
            this.label3.TabIndex = 15;
            this.label3.Text = "Código de Seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 33);
            this.label4.TabIndex = 14;
            this.label4.Text = "Número de la Tarjeta";
            // 
            // txt_num_tarjeta
            // 
            this.txt_num_tarjeta.Location = new System.Drawing.Point(339, 165);
            this.txt_num_tarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_num_tarjeta.Name = "txt_num_tarjeta";
            this.txt_num_tarjeta.Size = new System.Drawing.Size(265, 26);
            this.txt_num_tarjeta.TabIndex = 16;
            // 
            // txt_cod_segu
            // 
            this.txt_cod_segu.Location = new System.Drawing.Point(339, 232);
            this.txt_cod_segu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_cod_segu.Name = "txt_cod_segu";
            this.txt_cod_segu.Size = new System.Drawing.Size(265, 26);
            this.txt_cod_segu.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_cod_segu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_num_tarjeta);
            this.groupBox1.Controls.Add(this.txt_monto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.combobox_tipopago);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 293);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga";
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar.Location = new System.Drawing.Point(653, 251);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(455, 54);
            this.bt_cancelar.TabIndex = 18;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_saldo);
            this.groupBox2.Location = new System.Drawing.Point(652, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 155);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldo Actual";
            // 
            // txt_saldo
            // 
            this.txt_saldo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldo.Location = new System.Drawing.Point(23, 32);
            this.txt_saldo.Multiline = true;
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.ReadOnly = true;
            this.txt_saldo.Size = new System.Drawing.Size(404, 105);
            this.txt_saldo.TabIndex = 20;
            // 
            // CargaDeCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 325);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.bt_cargar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CargaDeCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga de Credito";
            this.Load += new System.EventHandler(this.CargaDeCredito_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_monto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combobox_tipopago;
        private System.Windows.Forms.Button bt_cargar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_num_tarjeta;
        private System.Windows.Forms.TextBox txt_cod_segu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_saldo;
    }
}