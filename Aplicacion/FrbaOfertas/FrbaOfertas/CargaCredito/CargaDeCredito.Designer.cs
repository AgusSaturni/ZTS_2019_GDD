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
            this.label5 = new System.Windows.Forms.Label();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_saldo = new System.Windows.Forms.TextBox();
            this.cbo_usuarios = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // txt_monto
            // 
            this.txt_monto.Location = new System.Drawing.Point(228, 102);
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.Size = new System.Drawing.Size(178, 20);
            this.txt_monto.TabIndex = 1;
            this.txt_monto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Pago";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // combobox_tipopago
            // 
            this.combobox_tipopago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_tipopago.FormattingEnabled = true;
            this.combobox_tipopago.Location = new System.Drawing.Point(228, 64);
            this.combobox_tipopago.Name = "combobox_tipopago";
            this.combobox_tipopago.Size = new System.Drawing.Size(178, 21);
            this.combobox_tipopago.TabIndex = 11;
            // 
            // bt_cargar
            // 
            this.bt_cargar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bt_cargar.Location = new System.Drawing.Point(438, 155);
            this.bt_cargar.Name = "bt_cargar";
            this.bt_cargar.Size = new System.Drawing.Size(303, 35);
            this.bt_cargar.TabIndex = 12;
            this.bt_cargar.Text = "Cargar";
            this.bt_cargar.UseVisualStyleBackColor = true;
            this.bt_cargar.Click += new System.EventHandler(this.bt_cargar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Código de Seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "Número de la Tarjeta";
            // 
            // txt_num_tarjeta
            // 
            this.txt_num_tarjeta.Location = new System.Drawing.Point(228, 144);
            this.txt_num_tarjeta.Name = "txt_num_tarjeta";
            this.txt_num_tarjeta.Size = new System.Drawing.Size(178, 20);
            this.txt_num_tarjeta.TabIndex = 16;
            // 
            // txt_cod_segu
            // 
            this.txt_cod_segu.Location = new System.Drawing.Point(228, 188);
            this.txt_cod_segu.Name = "txt_cod_segu";
            this.txt_cod_segu.Size = new System.Drawing.Size(178, 20);
            this.txt_cod_segu.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_usuarios);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_cod_segu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_num_tarjeta);
            this.groupBox1.Controls.Add(this.txt_monto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.combobox_tipopago);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(422, 234);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Usuario";
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar.Location = new System.Drawing.Point(438, 203);
            this.bt_cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(303, 35);
            this.bt_cancelar.TabIndex = 18;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_saldo);
            this.groupBox2.Location = new System.Drawing.Point(438, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(303, 130);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldo Actual";
            // 
            // txt_saldo
            // 
            this.txt_saldo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldo.Location = new System.Drawing.Point(17, 29);
            this.txt_saldo.Margin = new System.Windows.Forms.Padding(2);
            this.txt_saldo.Multiline = true;
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.ReadOnly = true;
            this.txt_saldo.Size = new System.Drawing.Size(271, 70);
            this.txt_saldo.TabIndex = 20;
            this.txt_saldo.TextChanged += new System.EventHandler(this.txt_saldo_TextChanged);
            // 
            // cbo_usuarios
            // 
            this.cbo_usuarios.DisplayMember = "1";
            this.cbo_usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_usuarios.FormattingEnabled = true;
            this.cbo_usuarios.Items.AddRange(new object[] {
            "Elegir usuario..."});
            this.cbo_usuarios.Location = new System.Drawing.Point(228, 33);
            this.cbo_usuarios.Name = "cbo_usuarios";
            this.cbo_usuarios.Size = new System.Drawing.Size(178, 21);
            this.cbo_usuarios.TabIndex = 20;
            // 
            // CargaDeCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 255);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.bt_cargar);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_usuarios;
    }
}