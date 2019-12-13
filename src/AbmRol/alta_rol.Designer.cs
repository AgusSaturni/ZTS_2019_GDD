namespace FrbaOfertas.AbmRol
{
    partial class alta_rol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_finalizar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre_rol = new System.Windows.Forms.TextBox();
            this.bt_izq_a_der = new System.Windows.Forms.Button();
            this.bt_der_a_izq = new System.Windows.Forms.Button();
            this.contenedor_funciones_totales = new System.Windows.Forms.GroupBox();
            this.list_totales = new System.Windows.Forms.ListBox();
            this.contenedor_funciones_del_rol = new System.Windows.Forms.GroupBox();
            this.list_rol = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.contenedor_funciones_totales.SuspendLayout();
            this.contenedor_funciones_del_rol.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_finalizar);
            this.groupBox1.Controls.Add(this.bt_cancelar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_nombre_rol);
            this.groupBox1.Controls.Add(this.bt_izq_a_der);
            this.groupBox1.Controls.Add(this.bt_der_a_izq);
            this.groupBox1.Controls.Add(this.contenedor_funciones_totales);
            this.groupBox1.Controls.Add(this.contenedor_funciones_del_rol);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_finalizar
            // 
            this.bt_finalizar.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_finalizar.Location = new System.Drawing.Point(529, 476);
            this.bt_finalizar.Name = "bt_finalizar";
            this.bt_finalizar.Size = new System.Drawing.Size(378, 44);
            this.bt_finalizar.TabIndex = 17;
            this.bt_finalizar.Text = "Finalizar";
            this.bt_finalizar.UseVisualStyleBackColor = true;
            this.bt_finalizar.Click += new System.EventHandler(this.bt_finalizar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cancelar.Location = new System.Drawing.Point(21, 476);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(378, 44);
            this.bt_cancelar.TabIndex = 16;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Seleccione las Funciones Deseadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Introduzca el nombre del nuevo ROL";
            // 
            // txt_nombre_rol
            // 
            this.txt_nombre_rol.Location = new System.Drawing.Point(20, 68);
            this.txt_nombre_rol.Name = "txt_nombre_rol";
            this.txt_nombre_rol.Size = new System.Drawing.Size(339, 26);
            this.txt_nombre_rol.TabIndex = 13;
            // 
            // bt_izq_a_der
            // 
            this.bt_izq_a_der.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_izq_a_der.Location = new System.Drawing.Point(415, 212);
            this.bt_izq_a_der.Name = "bt_izq_a_der";
            this.bt_izq_a_der.Size = new System.Drawing.Size(100, 79);
            this.bt_izq_a_der.TabIndex = 11;
            this.bt_izq_a_der.Text = ">";
            this.bt_izq_a_der.UseVisualStyleBackColor = true;
            this.bt_izq_a_der.Click += new System.EventHandler(this.bt_izq_a_der_Click);
            // 
            // bt_der_a_izq
            // 
            this.bt_der_a_izq.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_der_a_izq.Location = new System.Drawing.Point(415, 316);
            this.bt_der_a_izq.Name = "bt_der_a_izq";
            this.bt_der_a_izq.Size = new System.Drawing.Size(100, 79);
            this.bt_der_a_izq.TabIndex = 12;
            this.bt_der_a_izq.Text = "<";
            this.bt_der_a_izq.UseVisualStyleBackColor = true;
            this.bt_der_a_izq.Click += new System.EventHandler(this.bt_der_a_izq_Click);
            // 
            // contenedor_funciones_totales
            // 
            this.contenedor_funciones_totales.Controls.Add(this.list_totales);
            this.contenedor_funciones_totales.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_funciones_totales.Location = new System.Drawing.Point(19, 157);
            this.contenedor_funciones_totales.Name = "contenedor_funciones_totales";
            this.contenedor_funciones_totales.Size = new System.Drawing.Size(380, 304);
            this.contenedor_funciones_totales.TabIndex = 9;
            this.contenedor_funciones_totales.TabStop = false;
            this.contenedor_funciones_totales.Text = "Funciones Disponibles del Sistema";
            // 
            // list_totales
            // 
            this.list_totales.FormattingEnabled = true;
            this.list_totales.ItemHeight = 19;
            this.list_totales.Location = new System.Drawing.Point(17, 25);
            this.list_totales.Name = "list_totales";
            this.list_totales.Size = new System.Drawing.Size(339, 270);
            this.list_totales.TabIndex = 9;
            // 
            // contenedor_funciones_del_rol
            // 
            this.contenedor_funciones_del_rol.Controls.Add(this.list_rol);
            this.contenedor_funciones_del_rol.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_funciones_del_rol.Location = new System.Drawing.Point(532, 157);
            this.contenedor_funciones_del_rol.Name = "contenedor_funciones_del_rol";
            this.contenedor_funciones_del_rol.Size = new System.Drawing.Size(375, 304);
            this.contenedor_funciones_del_rol.TabIndex = 10;
            this.contenedor_funciones_del_rol.TabStop = false;
            this.contenedor_funciones_del_rol.Text = "Funciones a Asignar";
            // 
            // list_rol
            // 
            this.list_rol.FormattingEnabled = true;
            this.list_rol.ItemHeight = 19;
            this.list_rol.Location = new System.Drawing.Point(15, 25);
            this.list_rol.Name = "list_rol";
            this.list_rol.Size = new System.Drawing.Size(339, 270);
            this.list_rol.TabIndex = 0;
            // 
            // alta_rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 557);
            this.Controls.Add(this.groupBox1);
            this.Name = "alta_rol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Roles";
            this.Load += new System.EventHandler(this.alta_rol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contenedor_funciones_totales.ResumeLayout(false);
            this.contenedor_funciones_del_rol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_izq_a_der;
        private System.Windows.Forms.Button bt_der_a_izq;
        private System.Windows.Forms.GroupBox contenedor_funciones_totales;
        private System.Windows.Forms.ListBox list_totales;
        private System.Windows.Forms.GroupBox contenedor_funciones_del_rol;
        private System.Windows.Forms.ListBox list_rol;
        private System.Windows.Forms.Button bt_finalizar;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre_rol;
    }
}