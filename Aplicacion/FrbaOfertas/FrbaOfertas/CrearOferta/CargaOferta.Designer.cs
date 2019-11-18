namespace FrbaOfertas.CrearOferta
{
    partial class CargaOferta
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
            this.Descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FechaPublicacion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.PrecioOferta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PrecioLista = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cantidad = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.CantMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantMax)).BeginInit();
            this.SuspendLayout();
            // 
            // Descripcion
            // 
            this.Descripcion.Location = new System.Drawing.Point(147, 21);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(206, 20);
            this.Descripcion.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripcion(*)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Fecha de Publicacion(*)";
            // 
            // FechaPublicacion
            // 
            this.FechaPublicacion.Location = new System.Drawing.Point(25, 89);
            this.FechaPublicacion.Name = "FechaPublicacion";
            this.FechaPublicacion.Size = new System.Drawing.Size(196, 20);
            this.FechaPublicacion.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Fecha de Vencimiento(*)";
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.Location = new System.Drawing.Point(25, 150);
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.Size = new System.Drawing.Size(196, 20);
            this.FechaVencimiento.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Precio Oferta";
            // 
            // PrecioOferta
            // 
            this.PrecioOferta.Location = new System.Drawing.Point(191, 185);
            this.PrecioOferta.Name = "PrecioOferta";
            this.PrecioOferta.Size = new System.Drawing.Size(137, 20);
            this.PrecioOferta.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Precio Lista";
            // 
            // PrecioLista
            // 
            this.PrecioLista.Location = new System.Drawing.Point(191, 226);
            this.PrecioLista.Name = "PrecioLista";
            this.PrecioLista.Size = new System.Drawing.Size(137, 20);
            this.PrecioLista.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Cantidad Disponible";
            // 
            // Cantidad
            // 
            this.Cantidad.Location = new System.Drawing.Point(191, 258);
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Size = new System.Drawing.Size(120, 20);
            this.Cantidad.TabIndex = 35;
            this.Cantidad.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(286, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 37);
            this.button1.TabIndex = 36;
            this.button1.Text = "Publicar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CantMax
            // 
            this.CantMax.Location = new System.Drawing.Point(51, 339);
            this.CantMax.Name = "CantMax";
            this.CantMax.Size = new System.Drawing.Size(120, 20);
            this.CantMax.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Cantidad máxima por Usuario";
            // 
            // CargaOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 378);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CantMax);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Cantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PrecioLista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PrecioOferta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FechaVencimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FechaPublicacion);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.label1);
            this.Name = "CargaOferta";
            this.Text = "Carga de Oferta";
            ((System.ComponentModel.ISupportInitialize)(this.Cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker FechaPublicacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaVencimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PrecioOferta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PrecioLista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Cantidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown CantMax;
        private System.Windows.Forms.Label label5;
    }
}