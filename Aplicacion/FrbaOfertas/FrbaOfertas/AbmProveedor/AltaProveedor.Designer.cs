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
            this.Siguiente = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Contacto = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Rubro = new System.Windows.Forms.TextBox();
            this.RS = new System.Windows.Forms.TextBox();
            this.Mail = new System.Windows.Forms.TextBox();
            this.CUIT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Siguiente
            // 
            this.Siguiente.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Siguiente.Location = new System.Drawing.Point(304, 503);
            this.Siguiente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Siguiente.Name = "Siguiente";
            this.Siguiente.Size = new System.Drawing.Size(269, 52);
            this.Siguiente.TabIndex = 21;
            this.Siguiente.Text = "Siguiente";
            this.Siguiente.UseVisualStyleBackColor = true;
            this.Siguiente.Click += new System.EventHandler(this.Siguiente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(25, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 24);
            this.label7.TabIndex = 32;
            this.label7.Text = "Nombre de Contacto(*)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Contacto
            // 
            this.Contacto.Location = new System.Drawing.Point(288, 36);
            this.Contacto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Contacto.Name = "Contacto";
            this.Contacto.Size = new System.Drawing.Size(232, 30);
            this.Contacto.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Rubro);
            this.groupBox1.Controls.Add(this.RS);
            this.groupBox1.Controls.Add(this.Mail);
            this.groupBox1.Controls.Add(this.CUIT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Telefono);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 377);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Empresa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(24, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 24);
            this.label6.TabIndex = 44;
            this.label6.Text = "Rubro(*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "Razon Social(*)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(343, 335);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 21);
            this.label8.TabIndex = 35;
            this.label8.Text = "(*) son Obligatorios";
            // 
            // Rubro
            // 
            this.Rubro.Location = new System.Drawing.Point(205, 222);
            this.Rubro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Rubro.Name = "Rubro";
            this.Rubro.Size = new System.Drawing.Size(336, 30);
            this.Rubro.TabIndex = 43;
            // 
            // RS
            // 
            this.RS.Location = new System.Drawing.Point(205, 45);
            this.RS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RS.Name = "RS";
            this.RS.Size = new System.Drawing.Size(336, 30);
            this.RS.TabIndex = 35;
            // 
            // Mail
            // 
            this.Mail.Location = new System.Drawing.Point(205, 279);
            this.Mail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(336, 30);
            this.Mail.TabIndex = 42;
            // 
            // CUIT
            // 
            this.CUIT.Location = new System.Drawing.Point(205, 165);
            this.CUIT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CUIT.Name = "CUIT";
            this.CUIT.Size = new System.Drawing.Size(336, 30);
            this.CUIT.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(24, 279);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "Mail(*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(24, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "CUIT(*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(24, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 40;
            this.label4.Text = "Teléfono(*)";
            // 
            // Telefono
            // 
            this.Telefono.Location = new System.Drawing.Point(205, 105);
            this.Telefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(336, 30);
            this.Telefono.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Contacto);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 95);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Personales";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(13, 503);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 52);
            this.button1.TabIndex = 37;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AltaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 570);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Siguiente);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AltaProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Proveedor";
            this.Load += new System.EventHandler(this.AltaProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Siguiente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Contacto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Rubro;
        private System.Windows.Forms.TextBox RS;
        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.TextBox CUIT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Telefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}