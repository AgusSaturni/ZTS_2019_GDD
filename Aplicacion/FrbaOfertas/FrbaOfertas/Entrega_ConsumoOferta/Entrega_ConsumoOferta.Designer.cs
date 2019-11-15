namespace FrbaOfertas.Entrega_ConsumoOferta
{
    partial class Entrega_ConsumoOferta
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
            this.detalles_gpb = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cliente_txt = new System.Windows.Forms.TextBox();
            this.codigo_cupon_txt = new System.Windows.Forms.TextBox();
            this.fecha_consumo_txt = new System.Windows.Forms.TextBox();
            this.eliminar_oferta_btn = new System.Windows.Forms.Button();
            this.detalles_gpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // detalles_gpb
            // 
            this.detalles_gpb.Controls.Add(this.label3);
            this.detalles_gpb.Controls.Add(this.label2);
            this.detalles_gpb.Controls.Add(this.label1);
            this.detalles_gpb.Controls.Add(this.cliente_txt);
            this.detalles_gpb.Controls.Add(this.codigo_cupon_txt);
            this.detalles_gpb.Controls.Add(this.fecha_consumo_txt);
            this.detalles_gpb.Location = new System.Drawing.Point(31, 36);
            this.detalles_gpb.Name = "detalles_gpb";
            this.detalles_gpb.Size = new System.Drawing.Size(396, 192);
            this.detalles_gpb.TabIndex = 6;
            this.detalles_gpb.TabStop = false;
            this.detalles_gpb.Text = "Detalles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha de consumo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código de cupón";
            // 
            // cliente_txt
            // 
            this.cliente_txt.Location = new System.Drawing.Point(242, 160);
            this.cliente_txt.Name = "cliente_txt";
            this.cliente_txt.Size = new System.Drawing.Size(100, 20);
            this.cliente_txt.TabIndex = 8;
            // 
            // codigo_cupon_txt
            // 
            this.codigo_cupon_txt.Location = new System.Drawing.Point(242, 10);
            this.codigo_cupon_txt.Name = "codigo_cupon_txt";
            this.codigo_cupon_txt.Size = new System.Drawing.Size(100, 20);
            this.codigo_cupon_txt.TabIndex = 6;
            // 
            // fecha_consumo_txt
            // 
            this.fecha_consumo_txt.Location = new System.Drawing.Point(242, 83);
            this.fecha_consumo_txt.Name = "fecha_consumo_txt";
            this.fecha_consumo_txt.Size = new System.Drawing.Size(100, 20);
            this.fecha_consumo_txt.TabIndex = 7;
            // 
            // eliminar_oferta_btn
            // 
            this.eliminar_oferta_btn.Location = new System.Drawing.Point(255, 256);
            this.eliminar_oferta_btn.Name = "eliminar_oferta_btn";
            this.eliminar_oferta_btn.Size = new System.Drawing.Size(136, 46);
            this.eliminar_oferta_btn.TabIndex = 7;
            this.eliminar_oferta_btn.Text = "Eliminar oferta";
            this.eliminar_oferta_btn.UseVisualStyleBackColor = true;
            // 
            // Entrega_ConsumoOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 340);
            this.Controls.Add(this.eliminar_oferta_btn);
            this.Controls.Add(this.detalles_gpb);
            this.Name = "Entrega_ConsumoOferta";
            this.Text = "Entrega_ConsumoOferta";
            this.Load += new System.EventHandler(this.Entrega_ConsumoOferta_Load);
            this.detalles_gpb.ResumeLayout(false);
            this.detalles_gpb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox detalles_gpb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cliente_txt;
        private System.Windows.Forms.TextBox codigo_cupon_txt;
        private System.Windows.Forms.TextBox fecha_consumo_txt;
        private System.Windows.Forms.Button eliminar_oferta_btn;

    }
}