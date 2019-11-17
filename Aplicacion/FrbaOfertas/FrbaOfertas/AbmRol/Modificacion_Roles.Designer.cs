namespace FrbaOfertas.AbmRol
{
    partial class Modificacion_Roles
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
            this.bt_seleccionar = new System.Windows.Forms.Button();
            this.comboBox_roles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.bt_deshabilitar_rol = new System.Windows.Forms.Button();
            this.bt_habilitar_rol = new System.Windows.Forms.Button();
            this.contenedor_funciones_totales = new System.Windows.Forms.GroupBox();
            this.list_totales = new System.Windows.Forms.ListBox();
            this.contenedor_funciones_del_rol = new System.Windows.Forms.GroupBox();
            this.list_rol = new System.Windows.Forms.ListBox();
            this.bt_izq_a_der = new System.Windows.Forms.Button();
            this.bt_der_a_izq = new System.Windows.Forms.Button();
            this.bt_volver = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contenedor_funciones_totales.SuspendLayout();
            this.contenedor_funciones_del_rol.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_finalizar);
            this.groupBox1.Controls.Add(this.bt_seleccionar);
            this.groupBox1.Controls.Add(this.comboBox_roles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificacion de Funcionalidades";
            // 
            // bt_finalizar
            // 
            this.bt_finalizar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_finalizar.Location = new System.Drawing.Point(29, 138);
            this.bt_finalizar.Name = "bt_finalizar";
            this.bt_finalizar.Size = new System.Drawing.Size(355, 33);
            this.bt_finalizar.TabIndex = 9;
            this.bt_finalizar.Text = "Finalizar";
            this.bt_finalizar.UseVisualStyleBackColor = true;
            this.bt_finalizar.Click += new System.EventHandler(this.bt_finalizar_Click);
            // 
            // bt_seleccionar
            // 
            this.bt_seleccionar.Location = new System.Drawing.Point(29, 99);
            this.bt_seleccionar.Name = "bt_seleccionar";
            this.bt_seleccionar.Size = new System.Drawing.Size(355, 33);
            this.bt_seleccionar.TabIndex = 2;
            this.bt_seleccionar.Text = "Seleccionar";
            this.bt_seleccionar.UseVisualStyleBackColor = true;
            this.bt_seleccionar.Click += new System.EventHandler(this.bt_seleccionar_Click);
            // 
            // comboBox_roles
            // 
            this.comboBox_roles.FormattingEnabled = true;
            this.comboBox_roles.Location = new System.Drawing.Point(105, 46);
            this.comboBox_roles.Name = "comboBox_roles";
            this.comboBox_roles.Size = new System.Drawing.Size(279, 32);
            this.comboBox_roles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rol";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_estado);
            this.groupBox2.Controls.Add(this.bt_deshabilitar_rol);
            this.groupBox2.Controls.Add(this.bt_habilitar_rol);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(457, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 187);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Habilitacion y Deshabilitacion de Roles";
            // 
            // txt_estado
            // 
            this.txt_estado.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estado.Location = new System.Drawing.Point(28, 40);
            this.txt_estado.Multiline = true;
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.ReadOnly = true;
            this.txt_estado.Size = new System.Drawing.Size(409, 92);
            this.txt_estado.TabIndex = 4;
            // 
            // bt_deshabilitar_rol
            // 
            this.bt_deshabilitar_rol.Location = new System.Drawing.Point(262, 138);
            this.bt_deshabilitar_rol.Name = "bt_deshabilitar_rol";
            this.bt_deshabilitar_rol.Size = new System.Drawing.Size(175, 33);
            this.bt_deshabilitar_rol.TabIndex = 3;
            this.bt_deshabilitar_rol.Text = "Deshabilitar";
            this.bt_deshabilitar_rol.UseVisualStyleBackColor = true;
            this.bt_deshabilitar_rol.Click += new System.EventHandler(this.bt_deshabilitar_rol_Click);
            // 
            // bt_habilitar_rol
            // 
            this.bt_habilitar_rol.Location = new System.Drawing.Point(28, 138);
            this.bt_habilitar_rol.Name = "bt_habilitar_rol";
            this.bt_habilitar_rol.Size = new System.Drawing.Size(179, 33);
            this.bt_habilitar_rol.TabIndex = 2;
            this.bt_habilitar_rol.Text = "Habilitar";
            this.bt_habilitar_rol.UseVisualStyleBackColor = true;
            this.bt_habilitar_rol.Click += new System.EventHandler(this.bt_habilitar_rol_Click);
            // 
            // contenedor_funciones_totales
            // 
            this.contenedor_funciones_totales.Controls.Add(this.list_totales);
            this.contenedor_funciones_totales.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_funciones_totales.Location = new System.Drawing.Point(12, 219);
            this.contenedor_funciones_totales.Name = "contenedor_funciones_totales";
            this.contenedor_funciones_totales.Size = new System.Drawing.Size(385, 304);
            this.contenedor_funciones_totales.TabIndex = 5;
            this.contenedor_funciones_totales.TabStop = false;
            this.contenedor_funciones_totales.Text = "Funciones Disponibles del Sistema";
            // 
            // list_totales
            // 
            this.list_totales.FormattingEnabled = true;
            this.list_totales.ItemHeight = 19;
            this.list_totales.Location = new System.Drawing.Point(20, 25);
            this.list_totales.Name = "list_totales";
            this.list_totales.Size = new System.Drawing.Size(339, 270);
            this.list_totales.TabIndex = 9;
            // 
            // contenedor_funciones_del_rol
            // 
            this.contenedor_funciones_del_rol.Controls.Add(this.list_rol);
            this.contenedor_funciones_del_rol.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_funciones_del_rol.Location = new System.Drawing.Point(542, 219);
            this.contenedor_funciones_del_rol.Name = "contenedor_funciones_del_rol";
            this.contenedor_funciones_del_rol.Size = new System.Drawing.Size(375, 304);
            this.contenedor_funciones_del_rol.TabIndex = 6;
            this.contenedor_funciones_del_rol.TabStop = false;
            this.contenedor_funciones_del_rol.Text = "Funciones del Rol Seleccionado";
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
            // bt_izq_a_der
            // 
            this.bt_izq_a_der.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_izq_a_der.Location = new System.Drawing.Point(420, 271);
            this.bt_izq_a_der.Name = "bt_izq_a_der";
            this.bt_izq_a_der.Size = new System.Drawing.Size(100, 79);
            this.bt_izq_a_der.TabIndex = 7;
            this.bt_izq_a_der.Text = ">";
            this.bt_izq_a_der.UseVisualStyleBackColor = true;
            this.bt_izq_a_der.Click += new System.EventHandler(this.bt_izq_a_der_Click);
            // 
            // bt_der_a_izq
            // 
            this.bt_der_a_izq.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_der_a_izq.Location = new System.Drawing.Point(420, 380);
            this.bt_der_a_izq.Name = "bt_der_a_izq";
            this.bt_der_a_izq.Size = new System.Drawing.Size(100, 79);
            this.bt_der_a_izq.TabIndex = 8;
            this.bt_der_a_izq.Text = "<";
            this.bt_der_a_izq.UseVisualStyleBackColor = true;
            this.bt_der_a_izq.Click += new System.EventHandler(this.bt_der_a_izq_Click);
            // 
            // bt_volver
            // 
            this.bt_volver.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_volver.Location = new System.Drawing.Point(12, 534);
            this.bt_volver.Name = "bt_volver";
            this.bt_volver.Size = new System.Drawing.Size(120, 33);
            this.bt_volver.TabIndex = 9;
            this.bt_volver.Text = "Volver";
            this.bt_volver.UseVisualStyleBackColor = true;
            this.bt_volver.Click += new System.EventHandler(this.bt_volver_Click);
            // 
            // Modificacion_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 579);
            this.Controls.Add(this.bt_volver);
            this.Controls.Add(this.bt_der_a_izq);
            this.Controls.Add(this.bt_izq_a_der);
            this.Controls.Add(this.contenedor_funciones_del_rol);
            this.Controls.Add(this.contenedor_funciones_totales);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Modificacion_Roles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificacion_Roles";
            this.Load += new System.EventHandler(this.Modificacion_Roles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contenedor_funciones_totales.ResumeLayout(false);
            this.contenedor_funciones_del_rol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_seleccionar;
        private System.Windows.Forms.ComboBox comboBox_roles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_deshabilitar_rol;
        private System.Windows.Forms.Button bt_habilitar_rol;
        private System.Windows.Forms.GroupBox contenedor_funciones_totales;
        private System.Windows.Forms.GroupBox contenedor_funciones_del_rol;
        private System.Windows.Forms.Button bt_izq_a_der;
        private System.Windows.Forms.Button bt_der_a_izq;
        private System.Windows.Forms.ListBox list_totales;
        private System.Windows.Forms.ListBox list_rol;
        private System.Windows.Forms.Button bt_finalizar;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.Button bt_volver;
    }
}