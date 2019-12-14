namespace FrbaOfertas.Interfaces
{
    partial class menu_principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu_principal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_funciones = new System.Windows.Forms.ComboBox();
            this.lbl_bienvenida = new System.Windows.Forms.Label();
            this.bt_ejecutar = new System.Windows.Forms.Button();
            this.bt_cerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_funciones);
            this.groupBox1.Location = new System.Drawing.Point(8, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(355, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones Disponibles";
            // 
            // comboBox_funciones
            // 
            this.comboBox_funciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_funciones.FormattingEnabled = true;
            this.comboBox_funciones.Location = new System.Drawing.Point(11, 16);
            this.comboBox_funciones.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_funciones.Name = "comboBox_funciones";
            this.comboBox_funciones.Size = new System.Drawing.Size(331, 21);
            this.comboBox_funciones.TabIndex = 0;
            this.comboBox_funciones.SelectedIndexChanged += new System.EventHandler(this.comboBox_funciones_SelectedIndexChanged);
            // 
            // lbl_bienvenida
            // 
            this.lbl_bienvenida.AutoSize = true;
            this.lbl_bienvenida.Font = new System.Drawing.Font("Arial Narrow", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bienvenida.Location = new System.Drawing.Point(8, 6);
            this.lbl_bienvenida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_bienvenida.Name = "lbl_bienvenida";
            this.lbl_bienvenida.Size = new System.Drawing.Size(72, 31);
            this.lbl_bienvenida.TabIndex = 0;
            this.lbl_bienvenida.Text = "Menu";
            this.lbl_bienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_ejecutar
            // 
            this.bt_ejecutar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ejecutar.Location = new System.Drawing.Point(189, 236);
            this.bt_ejecutar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_ejecutar.Name = "bt_ejecutar";
            this.bt_ejecutar.Size = new System.Drawing.Size(174, 29);
            this.bt_ejecutar.TabIndex = 1;
            this.bt_ejecutar.Text = "Ejecutar";
            this.bt_ejecutar.UseVisualStyleBackColor = true;
            this.bt_ejecutar.Click += new System.EventHandler(this.bt_ejecutar_Click);
            // 
            // bt_cerrar
            // 
            this.bt_cerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_cerrar.Location = new System.Drawing.Point(8, 236);
            this.bt_cerrar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_cerrar.Name = "bt_cerrar";
            this.bt_cerrar.Size = new System.Drawing.Size(174, 29);
            this.bt_cerrar.TabIndex = 2;
            this.bt_cerrar.Text = "Cerrar Sesion";
            this.bt_cerrar.UseVisualStyleBackColor = true;
            this.bt_cerrar.Click += new System.EventHandler(this.bt_cerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 96);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menu_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 273);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_cerrar);
            this.Controls.Add(this.bt_ejecutar);
            this.Controls.Add(this.lbl_bienvenida);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "menu_principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frba Ofertas";
            this.Load += new System.EventHandler(this.menu_principal_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_funciones;
        public System.Windows.Forms.Label lbl_bienvenida;
        private System.Windows.Forms.Button bt_ejecutar;
        private System.Windows.Forms.Button bt_cerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}