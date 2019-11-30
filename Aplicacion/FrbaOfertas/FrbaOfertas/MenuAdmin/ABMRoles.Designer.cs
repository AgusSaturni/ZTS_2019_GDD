namespace FrbaOfertas.MenuAdmin
{
    partial class ABMRoles
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
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.bt_modificar_rol = new System.Windows.Forms.Button();
            this.bt_alta_rol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_cancelar);
            this.groupBox1.Controls.Add(this.bt_modificar_rol);
            this.groupBox1.Controls.Add(this.bt_alta_rol);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Roles";
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(32, 186);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(483, 44);
            this.bt_cancelar.TabIndex = 2;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // bt_modificar_rol
            // 
            this.bt_modificar_rol.Location = new System.Drawing.Point(32, 123);
            this.bt_modificar_rol.Name = "bt_modificar_rol";
            this.bt_modificar_rol.Size = new System.Drawing.Size(483, 44);
            this.bt_modificar_rol.TabIndex = 1;
            this.bt_modificar_rol.Text = "Modificacion Rol";
            this.bt_modificar_rol.UseVisualStyleBackColor = true;
            this.bt_modificar_rol.Click += new System.EventHandler(this.bt_modificar_rol_Click);
            // 
            // bt_alta_rol
            // 
            this.bt_alta_rol.Location = new System.Drawing.Point(32, 59);
            this.bt_alta_rol.Name = "bt_alta_rol";
            this.bt_alta_rol.Size = new System.Drawing.Size(483, 44);
            this.bt_alta_rol.TabIndex = 0;
            this.bt_alta_rol.Text = "Alta Rol";
            this.bt_alta_rol.UseVisualStyleBackColor = true;
            this.bt_alta_rol.Click += new System.EventHandler(this.bt_alta_rol_Click);
            // 
            // ABMRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 281);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMRoles";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button bt_modificar_rol;
        private System.Windows.Forms.Button bt_alta_rol;
    }
}