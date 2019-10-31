namespace FrbaOfertas.CargaDireccion
{
    partial class CargarDireccion
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Direccion = new System.Windows.Forms.TextBox();
            this.CodigoPostal = new System.Windows.Forms.TextBox();
            this.Localidad = new System.Windows.Forms.TextBox();
            this.Ciudad = new System.Windows.Forms.TextBox();
            this.NroPiso = new System.Windows.Forms.TextBox();
            this.Departamento = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Direccion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo Postal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ciudad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = " Nro Piso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = " Departamento";
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(106, 37);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(198, 20);
            this.Direccion.TabIndex = 6;
            this.Direccion.TextChanged += new System.EventHandler(this.Direccion_TextChanged);
            // 
            // CodigoPostal
            // 
            this.CodigoPostal.Location = new System.Drawing.Point(155, 81);
            this.CodigoPostal.Name = "CodigoPostal";
            this.CodigoPostal.Size = new System.Drawing.Size(92, 20);
            this.CodigoPostal.TabIndex = 7;
            // 
            // Localidad
            // 
            this.Localidad.Location = new System.Drawing.Point(106, 119);
            this.Localidad.Name = "Localidad";
            this.Localidad.Size = new System.Drawing.Size(198, 20);
            this.Localidad.TabIndex = 8;
            // 
            // Ciudad
            // 
            this.Ciudad.Location = new System.Drawing.Point(106, 155);
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Size = new System.Drawing.Size(198, 20);
            this.Ciudad.TabIndex = 9;
            // 
            // NroPiso
            // 
            this.NroPiso.Location = new System.Drawing.Point(155, 188);
            this.NroPiso.Name = "NroPiso";
            this.NroPiso.Size = new System.Drawing.Size(88, 20);
            this.NroPiso.TabIndex = 10;
            // 
            // Departamento
            // 
            this.Departamento.Location = new System.Drawing.Point(111, 220);
            this.Departamento.Name = "Departamento";
            this.Departamento.Size = new System.Drawing.Size(193, 20);
            this.Departamento.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Hecho";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CargarDireccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 330);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Departamento);
            this.Controls.Add(this.NroPiso);
            this.Controls.Add(this.Ciudad);
            this.Controls.Add(this.Localidad);
            this.Controls.Add(this.CodigoPostal);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CargarDireccion";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CargarDireccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Direccion;
        private System.Windows.Forms.TextBox CodigoPostal;
        private System.Windows.Forms.TextBox Localidad;
        private System.Windows.Forms.TextBox Ciudad;
        private System.Windows.Forms.TextBox NroPiso;
        private System.Windows.Forms.TextBox Departamento;
        private System.Windows.Forms.Button button1;
    }
}