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
            this.fecha_consumo_dtp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cliente_txt = new System.Windows.Forms.TextBox();
            this.codigo_cupon_txt = new System.Windows.Forms.TextBox();
            this.eliminar_oferta_btn = new System.Windows.Forms.Button();
            this.atras_btn = new System.Windows.Forms.Button();
            this.lbl_detalles = new System.Windows.Forms.Label();
            this.detalles_gpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // detalles_gpb
            // 
            this.detalles_gpb.Controls.Add(this.lbl_detalles);
            this.detalles_gpb.Controls.Add(this.fecha_consumo_dtp);
            this.detalles_gpb.Controls.Add(this.label3);
            this.detalles_gpb.Controls.Add(this.label2);
            this.detalles_gpb.Controls.Add(this.label1);
            this.detalles_gpb.Controls.Add(this.cliente_txt);
            this.detalles_gpb.Controls.Add(this.codigo_cupon_txt);
            this.detalles_gpb.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalles_gpb.Location = new System.Drawing.Point(12, 10);
            this.detalles_gpb.Name = "detalles_gpb";
            this.detalles_gpb.Size = new System.Drawing.Size(492, 264);
            this.detalles_gpb.TabIndex = 6;
            this.detalles_gpb.TabStop = false;
            this.detalles_gpb.Text = "Detalles";
            // 
            // fecha_consumo_dtp
            // 
            this.fecha_consumo_dtp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.fecha_consumo_dtp.Location = new System.Drawing.Point(211, 144);
            this.fecha_consumo_dtp.Name = "fecha_consumo_dtp";
            this.fecha_consumo_dtp.Size = new System.Drawing.Size(275, 22);
            this.fecha_consumo_dtp.TabIndex = 13;
            this.fecha_consumo_dtp.Value = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha de consumo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código de cupón";
            // 
            // cliente_txt
            // 
            this.cliente_txt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.cliente_txt.Location = new System.Drawing.Point(211, 217);
            this.cliente_txt.Name = "cliente_txt";
            this.cliente_txt.Size = new System.Drawing.Size(275, 22);
            this.cliente_txt.TabIndex = 8;
            // 
            // codigo_cupon_txt
            // 
            this.codigo_cupon_txt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.codigo_cupon_txt.Location = new System.Drawing.Point(211, 71);
            this.codigo_cupon_txt.Name = "codigo_cupon_txt";
            this.codigo_cupon_txt.Size = new System.Drawing.Size(275, 22);
            this.codigo_cupon_txt.TabIndex = 6;
            // 
            // eliminar_oferta_btn
            // 
            this.eliminar_oferta_btn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminar_oferta_btn.Location = new System.Drawing.Point(331, 280);
            this.eliminar_oferta_btn.Name = "eliminar_oferta_btn";
            this.eliminar_oferta_btn.Size = new System.Drawing.Size(136, 46);
            this.eliminar_oferta_btn.TabIndex = 7;
            this.eliminar_oferta_btn.Text = "Entregar Oferta";
            this.eliminar_oferta_btn.UseVisualStyleBackColor = true;
            this.eliminar_oferta_btn.Click += new System.EventHandler(this.eliminar_oferta_btn_Click);
            // 
            // atras_btn
            // 
            this.atras_btn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atras_btn.Location = new System.Drawing.Point(23, 280);
            this.atras_btn.Name = "atras_btn";
            this.atras_btn.Size = new System.Drawing.Size(99, 46);
            this.atras_btn.TabIndex = 8;
            this.atras_btn.Text = "Volver";
            this.atras_btn.UseVisualStyleBackColor = true;
            this.atras_btn.Click += new System.EventHandler(this.atras_btn_Click);
            // 
            // lbl_detalles
            // 
            this.lbl_detalles.AutoSize = true;
            this.lbl_detalles.BackColor = System.Drawing.Color.Transparent;
            this.lbl_detalles.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_detalles.Location = new System.Drawing.Point(7, 3);
            this.lbl_detalles.Name = "lbl_detalles";
            this.lbl_detalles.Size = new System.Drawing.Size(163, 44);
            this.lbl_detalles.TabIndex = 14;
            this.lbl_detalles.Text = "Detalles";
            // 
            // Entrega_ConsumoOferta
            // 
            this.AcceptButton = this.eliminar_oferta_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 338);
            this.ControlBox = false;
            this.Controls.Add(this.atras_btn);
            this.Controls.Add(this.eliminar_oferta_btn);
            this.Controls.Add(this.detalles_gpb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Entrega_ConsumoOferta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrega de Ofertas";
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
        private System.Windows.Forms.Button eliminar_oferta_btn;
        private System.Windows.Forms.DateTimePicker fecha_consumo_dtp;
        private System.Windows.Forms.Button atras_btn;
        private System.Windows.Forms.Label lbl_detalles;

    }
}