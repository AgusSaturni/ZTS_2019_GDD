namespace FrbaOfertas.AbmCliente
{
    partial class bajasClientes
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
            this.bt_habilitar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.bt_eliminar = new System.Windows.Forms.Button();
            this.bt_deshabilitar = new System.Windows.Forms.Button();
            this.contenedor_estado = new System.Windows.Forms.GroupBox();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.contenedor_info_cliente = new System.Windows.Forms.GroupBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.lbl_DNI = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_nacimiento = new System.Windows.Forms.Label();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_telefono = new System.Windows.Forms.Label();
            this.contenedor_estado.SuspendLayout();
            this.contenedor_info_cliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_habilitar
            // 
            this.bt_habilitar.Location = new System.Drawing.Point(320, 116);
            this.bt_habilitar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_habilitar.Name = "bt_habilitar";
            this.bt_habilitar.Size = new System.Drawing.Size(177, 28);
            this.bt_habilitar.TabIndex = 19;
            this.bt_habilitar.Text = "Habilitar";
            this.bt_habilitar.UseVisualStyleBackColor = true;
            this.bt_habilitar.Click += new System.EventHandler(this.bt_habilitar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.Location = new System.Drawing.Point(320, 234);
            this.bt_cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(177, 27);
            this.bt_cancelar.TabIndex = 18;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = true;
            // 
            // bt_eliminar
            // 
            this.bt_eliminar.Location = new System.Drawing.Point(320, 196);
            this.bt_eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_eliminar.Name = "bt_eliminar";
            this.bt_eliminar.Size = new System.Drawing.Size(177, 27);
            this.bt_eliminar.TabIndex = 17;
            this.bt_eliminar.Text = "Eliminar";
            this.bt_eliminar.UseVisualStyleBackColor = true;
            // 
            // bt_deshabilitar
            // 
            this.bt_deshabilitar.Location = new System.Drawing.Point(320, 155);
            this.bt_deshabilitar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_deshabilitar.Name = "bt_deshabilitar";
            this.bt_deshabilitar.Size = new System.Drawing.Size(177, 27);
            this.bt_deshabilitar.TabIndex = 16;
            this.bt_deshabilitar.Text = "Deshabilitar";
            this.bt_deshabilitar.UseVisualStyleBackColor = true;
            this.bt_deshabilitar.Click += new System.EventHandler(this.bt_deshabilitar_Click);
            // 
            // contenedor_estado
            // 
            this.contenedor_estado.Controls.Add(this.txt_estado);
            this.contenedor_estado.Location = new System.Drawing.Point(320, 11);
            this.contenedor_estado.Margin = new System.Windows.Forms.Padding(2);
            this.contenedor_estado.Name = "contenedor_estado";
            this.contenedor_estado.Padding = new System.Windows.Forms.Padding(2);
            this.contenedor_estado.Size = new System.Drawing.Size(177, 101);
            this.contenedor_estado.TabIndex = 15;
            this.contenedor_estado.TabStop = false;
            this.contenedor_estado.Text = "Estado";
            // 
            // txt_estado
            // 
            this.txt_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estado.Location = new System.Drawing.Point(21, 21);
            this.txt_estado.Margin = new System.Windows.Forms.Padding(2);
            this.txt_estado.Multiline = true;
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.ReadOnly = true;
            this.txt_estado.Size = new System.Drawing.Size(134, 66);
            this.txt_estado.TabIndex = 14;
            this.txt_estado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contenedor_info_cliente
            // 
            this.contenedor_info_cliente.Controls.Add(this.txt_email);
            this.contenedor_info_cliente.Controls.Add(this.txt_direccion);
            this.contenedor_info_cliente.Controls.Add(this.txt_telefono);
            this.contenedor_info_cliente.Controls.Add(this.txt_id);
            this.contenedor_info_cliente.Controls.Add(this.txt_nombre);
            this.contenedor_info_cliente.Controls.Add(this.txt_apellido);
            this.contenedor_info_cliente.Controls.Add(this.txt_dni);
            this.contenedor_info_cliente.Controls.Add(this.txt_fecha);
            this.contenedor_info_cliente.Controls.Add(this.lbl_direccion);
            this.contenedor_info_cliente.Controls.Add(this.lbl_DNI);
            this.contenedor_info_cliente.Controls.Add(this.lbl_id);
            this.contenedor_info_cliente.Controls.Add(this.lbl_nacimiento);
            this.contenedor_info_cliente.Controls.Add(this.lbl_mail);
            this.contenedor_info_cliente.Controls.Add(this.lbl_apellido);
            this.contenedor_info_cliente.Controls.Add(this.lbl_nombre);
            this.contenedor_info_cliente.Controls.Add(this.lbl_telefono);
            this.contenedor_info_cliente.Location = new System.Drawing.Point(11, 11);
            this.contenedor_info_cliente.Margin = new System.Windows.Forms.Padding(2);
            this.contenedor_info_cliente.Name = "contenedor_info_cliente";
            this.contenedor_info_cliente.Padding = new System.Windows.Forms.Padding(2);
            this.contenedor_info_cliente.Size = new System.Drawing.Size(304, 258);
            this.contenedor_info_cliente.TabIndex = 14;
            this.contenedor_info_cliente.TabStop = false;
            this.contenedor_info_cliente.Text = "Informacion del Cliente";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(162, 227);
            this.txt_email.Margin = new System.Windows.Forms.Padding(2);
            this.txt_email.Name = "txt_email";
            this.txt_email.ReadOnly = true;
            this.txt_email.Size = new System.Drawing.Size(131, 20);
            this.txt_email.TabIndex = 21;
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(162, 196);
            this.txt_direccion.Margin = new System.Windows.Forms.Padding(2);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.ReadOnly = true;
            this.txt_direccion.Size = new System.Drawing.Size(131, 20);
            this.txt_direccion.TabIndex = 20;
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(162, 165);
            this.txt_telefono.Margin = new System.Windows.Forms.Padding(2);
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.ReadOnly = true;
            this.txt_telefono.Size = new System.Drawing.Size(131, 20);
            this.txt_telefono.TabIndex = 19;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(162, 21);
            this.txt_id.Margin = new System.Windows.Forms.Padding(2);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(131, 20);
            this.txt_id.TabIndex = 18;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(162, 49);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.ReadOnly = true;
            this.txt_nombre.Size = new System.Drawing.Size(131, 20);
            this.txt_nombre.TabIndex = 17;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(162, 77);
            this.txt_apellido.Margin = new System.Windows.Forms.Padding(2);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.ReadOnly = true;
            this.txt_apellido.Size = new System.Drawing.Size(131, 20);
            this.txt_apellido.TabIndex = 16;
            // 
            // txt_dni
            // 
            this.txt_dni.Location = new System.Drawing.Point(162, 105);
            this.txt_dni.Margin = new System.Windows.Forms.Padding(2);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.ReadOnly = true;
            this.txt_dni.Size = new System.Drawing.Size(131, 20);
            this.txt_dni.TabIndex = 15;
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(162, 133);
            this.txt_fecha.Margin = new System.Windows.Forms.Padding(2);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.ReadOnly = true;
            this.txt_fecha.Size = new System.Drawing.Size(131, 20);
            this.txt_fecha.TabIndex = 14;
            // 
            // lbl_direccion
            // 
            this.lbl_direccion.AutoSize = true;
            this.lbl_direccion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_direccion.Location = new System.Drawing.Point(14, 196);
            this.lbl_direccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_direccion.Name = "lbl_direccion";
            this.lbl_direccion.Size = new System.Drawing.Size(70, 17);
            this.lbl_direccion.TabIndex = 4;
            this.lbl_direccion.Text = "Direccion";
            // 
            // lbl_DNI
            // 
            this.lbl_DNI.AutoSize = true;
            this.lbl_DNI.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DNI.Location = new System.Drawing.Point(14, 105);
            this.lbl_DNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DNI.Name = "lbl_DNI";
            this.lbl_DNI.Size = new System.Drawing.Size(32, 17);
            this.lbl_DNI.TabIndex = 3;
            this.lbl_DNI.Text = "DNI";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.Location = new System.Drawing.Point(14, 21);
            this.lbl_id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(22, 17);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "ID";
            // 
            // lbl_nacimiento
            // 
            this.lbl_nacimiento.AutoSize = true;
            this.lbl_nacimiento.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nacimiento.Location = new System.Drawing.Point(14, 133);
            this.lbl_nacimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nacimiento.Name = "lbl_nacimiento";
            this.lbl_nacimiento.Size = new System.Drawing.Size(146, 17);
            this.lbl_nacimiento.TabIndex = 7;
            this.lbl_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mail.Location = new System.Drawing.Point(14, 228);
            this.lbl_mail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(45, 17);
            this.lbl_mail.TabIndex = 6;
            this.lbl_mail.Text = "Email";
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_apellido.Location = new System.Drawing.Point(14, 77);
            this.lbl_apellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(58, 17);
            this.lbl_apellido.TabIndex = 2;
            this.lbl_apellido.Text = "Apellido";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre.Location = new System.Drawing.Point(14, 49);
            this.lbl_nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(60, 17);
            this.lbl_nombre.TabIndex = 1;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_telefono
            // 
            this.lbl_telefono.AutoSize = true;
            this.lbl_telefono.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefono.Location = new System.Drawing.Point(14, 164);
            this.lbl_telefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_telefono.Name = "lbl_telefono";
            this.lbl_telefono.Size = new System.Drawing.Size(62, 17);
            this.lbl_telefono.TabIndex = 5;
            this.lbl_telefono.Text = "Telefono";
            // 
            // bajasClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 276);
            this.Controls.Add(this.bt_habilitar);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.bt_eliminar);
            this.Controls.Add(this.bt_deshabilitar);
            this.Controls.Add(this.contenedor_estado);
            this.Controls.Add(this.contenedor_info_cliente);
            this.Name = "bajasClientes";
            this.Text = " ";
            this.contenedor_estado.ResumeLayout(false);
            this.contenedor_estado.PerformLayout();
            this.contenedor_info_cliente.ResumeLayout(false);
            this.contenedor_info_cliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_habilitar;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button bt_eliminar;
        private System.Windows.Forms.Button bt_deshabilitar;
        private System.Windows.Forms.GroupBox contenedor_estado;
        public System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.GroupBox contenedor_info_cliente;
        public System.Windows.Forms.TextBox txt_email;
        public System.Windows.Forms.TextBox txt_direccion;
        public System.Windows.Forms.TextBox txt_telefono;
        public System.Windows.Forms.TextBox txt_id;
        public System.Windows.Forms.TextBox txt_nombre;
        public System.Windows.Forms.TextBox txt_apellido;
        public System.Windows.Forms.TextBox txt_dni;
        public System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.Label lbl_direccion;
        private System.Windows.Forms.Label lbl_DNI;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_nacimiento;
        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_telefono;
    }
}