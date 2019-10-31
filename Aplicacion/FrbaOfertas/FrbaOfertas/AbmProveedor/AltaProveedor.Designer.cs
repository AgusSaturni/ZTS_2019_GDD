namespace FrbaOfertas.AbmProveedor
{
    partial class AltaProveedor
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
            this.Mail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CUIT = new System.Windows.Forms.TextBox();
            this.Siguiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RS = new System.Windows.Forms.TextBox();
            this.Rubro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Contacto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Mail
            // 
            this.Mail.Location = new System.Drawing.Point(107, 200);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(228, 20);
            this.Mail.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Telefono";
            // 
            // Telefono
            // 
            this.Telefono.Location = new System.Drawing.Point(107, 69);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(228, 20);
            this.Telefono.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "CUIT";
            // 
            // CUIT
            // 
            this.CUIT.Location = new System.Drawing.Point(107, 110);
            this.CUIT.Name = "CUIT";
            this.CUIT.Size = new System.Drawing.Size(228, 20);
            this.CUIT.TabIndex = 22;
            // 
            // Siguiente
            // 
            this.Siguiente.Location = new System.Drawing.Point(262, 341);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(103, 26);
            this.Siguiente.TabIndex = 21;
            this.Siguiente.Text = "Siguiente";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "RazonSocial";
            // 
            // RS
            // 
            this.RS.Location = new System.Drawing.Point(107, 28);
            this.RS.Name = "RS";
            this.RS.Size = new System.Drawing.Size(228, 20);
            this.RS.TabIndex = 17;
            // 
            // Rubro
            // 
            this.Rubro.Location = new System.Drawing.Point(107, 153);
            this.Rubro.Name = "Rubro";
            this.Rubro.Size = new System.Drawing.Size(228, 20);
            this.Rubro.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Rubro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Nombre de Contacto";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Contacto
            // 
            this.Contacto.Location = new System.Drawing.Point(107, 274);
            this.Contacto.Name = "Contacto";
            this.Contacto.Size = new System.Drawing.Size(228, 20);
            this.Contacto.TabIndex = 33;
            // 
            // AltaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 379);
            this.Controls.Add(this.Contacto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Rubro);
            this.Controls.Add(this.Mail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CUIT);
            this.Controls.Add(this.Siguiente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RS);
            this.Name = "AltaProveedor";
            this.Text = "Alta Proveedor";
            this.Load += new System.EventHandler(this.AltaProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Telefono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CUIT;
        private System.Windows.Forms.Button Siguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RS;
        private System.Windows.Forms.TextBox Rubro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Contacto;
    }
}