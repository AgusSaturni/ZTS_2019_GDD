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
            this.Monto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TipoPago = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NroTarjeta = new System.Windows.Forms.TextBox();
            this.CodSegu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // Monto
            // 
            this.Monto.Location = new System.Drawing.Point(141, 88);
            this.Monto.Name = "Monto";
            this.Monto.Size = new System.Drawing.Size(178, 20);
            this.Monto.TabIndex = 1;
            this.Monto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Pago";
            // 
            // TipoPago
            // 
            this.TipoPago.FormattingEnabled = true;
            this.TipoPago.Items.AddRange(new object[] {
            "Crédito",
            "Débito"});
            this.TipoPago.Location = new System.Drawing.Point(141, 33);
            this.TipoPago.Name = "TipoPago";
            this.TipoPago.Size = new System.Drawing.Size(178, 21);
            this.TipoPago.TabIndex = 11;
            this.TipoPago.Text = "Seleccione";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Volver al Menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Codigo de Seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Numero de la Tarjeta";
            // 
            // NroTarjeta
            // 
            this.NroTarjeta.Location = new System.Drawing.Point(141, 134);
            this.NroTarjeta.Name = "NroTarjeta";
            this.NroTarjeta.Size = new System.Drawing.Size(178, 20);
            this.NroTarjeta.TabIndex = 16;
            // 
            // CodSegu
            // 
            this.CodSegu.Location = new System.Drawing.Point(141, 178);
            this.CodSegu.Name = "CodSegu";
            this.CodSegu.Size = new System.Drawing.Size(178, 20);
            this.CodSegu.TabIndex = 17;
            // 
            // CargaDeCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 308);
            this.Controls.Add(this.CodSegu);
            this.Controls.Add(this.NroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TipoPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Monto);
            this.Controls.Add(this.label1);
            this.Name = "CargaDeCredito";
            this.Text = "Carga de Credito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Monto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TipoPago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NroTarjeta;
        private System.Windows.Forms.TextBox CodSegu;
    }
}