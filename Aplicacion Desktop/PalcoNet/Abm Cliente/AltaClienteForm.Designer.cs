namespace PalcoNet.Abm_Cliente
{
    partial class AltaClienteForm
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
            this.panelCliente = new System.Windows.Forms.Panel();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.FechaNacimientoCliente = new System.Windows.Forms.DateTimePicker();
            this.nada = new System.Windows.Forms.Label();
            this.CuilCliente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AñadirDireccionButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ListaTiposDocumento = new System.Windows.Forms.ComboBox();
            this.TelefonoCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.MailCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DniCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ApellidoCliente = new System.Windows.Forms.TextBox();
            this.NombreCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.panelCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCliente
            // 
            this.panelCliente.AutoSize = true;
            this.panelCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCliente.Controls.Add(this.LimpiarButton);
            this.panelCliente.Controls.Add(this.CancelarButton);
            this.panelCliente.Controls.Add(this.AceptarButton);
            this.panelCliente.Controls.Add(this.FechaNacimientoCliente);
            this.panelCliente.Controls.Add(this.nada);
            this.panelCliente.Controls.Add(this.CuilCliente);
            this.panelCliente.Controls.Add(this.label13);
            this.panelCliente.Controls.Add(this.AñadirDireccionButton);
            this.panelCliente.Controls.Add(this.label12);
            this.panelCliente.Controls.Add(this.ListaTiposDocumento);
            this.panelCliente.Controls.Add(this.TelefonoCliente);
            this.panelCliente.Controls.Add(this.label11);
            this.panelCliente.Controls.Add(this.MailCliente);
            this.panelCliente.Controls.Add(this.label10);
            this.panelCliente.Controls.Add(this.DniCliente);
            this.panelCliente.Controls.Add(this.label9);
            this.panelCliente.Controls.Add(this.label8);
            this.panelCliente.Controls.Add(this.ApellidoCliente);
            this.panelCliente.Controls.Add(this.NombreCliente);
            this.panelCliente.Controls.Add(this.label6);
            this.panelCliente.Location = new System.Drawing.Point(-10, 0);
            this.panelCliente.Margin = new System.Windows.Forms.Padding(0);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(377, 381);
            this.panelCliente.TabIndex = 32;
            // 
            // CancelarButton
            // 
            this.CancelarButton.BackColor = System.Drawing.Color.LightGray;
            this.CancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(208, 355);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 36;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = false;
            this.CancelarButton.Visible = false;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.BackColor = System.Drawing.Color.LightGray;
            this.AceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AceptarButton.Location = new System.Drawing.Point(289, 355);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 35;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Visible = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // FechaNacimientoCliente
            // 
            this.FechaNacimientoCliente.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaNacimientoCliente.Location = new System.Drawing.Point(173, 225);
            this.FechaNacimientoCliente.Name = "FechaNacimientoCliente";
            this.FechaNacimientoCliente.Size = new System.Drawing.Size(120, 20);
            this.FechaNacimientoCliente.TabIndex = 34;
            // 
            // nada
            // 
            this.nada.AutoSize = true;
            this.nada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nada.Location = new System.Drawing.Point(57, 258);
            this.nada.Name = "nada";
            this.nada.Size = new System.Drawing.Size(31, 13);
            this.nada.TabIndex = 33;
            this.nada.Text = "CUIL";
            // 
            // CuilCliente
            // 
            this.CuilCliente.Location = new System.Drawing.Point(94, 255);
            this.CuilCliente.Name = "CuilCliente";
            this.CuilCliente.Size = new System.Drawing.Size(199, 20);
            this.CuilCliente.TabIndex = 32;
            this.CuilCliente.Validating += new System.ComponentModel.CancelEventHandler(this.cuilValidator);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(56, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Apellido";
            // 
            // AñadirDireccionButton
            // 
            this.AñadirDireccionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AñadirDireccionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AñadirDireccionButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AñadirDireccionButton.Location = new System.Drawing.Point(86, 315);
            this.AñadirDireccionButton.Name = "AñadirDireccionButton";
            this.AñadirDireccionButton.Size = new System.Drawing.Size(204, 23);
            this.AñadirDireccionButton.TabIndex = 28;
            this.AñadirDireccionButton.Text = "Añadir Direccion";
            this.AñadirDireccionButton.UseVisualStyleBackColor = true;
            this.AñadirDireccionButton.Click += new System.EventHandler(this.AñadirDireccionButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(57, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Fecha De Nacimiento";
            // 
            // ListaTiposDocumento
            // 
            this.ListaTiposDocumento.FormattingEnabled = true;
            this.ListaTiposDocumento.Location = new System.Drawing.Point(164, 78);
            this.ListaTiposDocumento.Name = "ListaTiposDocumento";
            this.ListaTiposDocumento.Size = new System.Drawing.Size(121, 21);
            this.ListaTiposDocumento.TabIndex = 22;
            // 
            // TelefonoCliente
            // 
            this.TelefonoCliente.Location = new System.Drawing.Point(112, 183);
            this.TelefonoCliente.Name = "TelefonoCliente";
            this.TelefonoCliente.Size = new System.Drawing.Size(181, 20);
            this.TelefonoCliente.TabIndex = 20;
            this.TelefonoCliente.Validating += new System.ComponentModel.CancelEventHandler(this.validarTelefono);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(57, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Telefono";
            // 
            // MailCliente
            // 
            this.MailCliente.Location = new System.Drawing.Point(89, 148);
            this.MailCliente.Name = "MailCliente";
            this.MailCliente.Size = new System.Drawing.Size(204, 20);
            this.MailCliente.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(57, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mail";
            // 
            // DniCliente
            // 
            this.DniCliente.Location = new System.Drawing.Point(89, 114);
            this.DniCliente.Name = "DniCliente";
            this.DniCliente.Size = new System.Drawing.Size(204, 20);
            this.DniCliente.TabIndex = 16;
            this.DniCliente.Validating += new System.ComponentModel.CancelEventHandler(this.validarDni);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(57, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "DNI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(57, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tipo de Documento";
            // 
            // ApellidoCliente
            // 
            this.ApellidoCliente.Location = new System.Drawing.Point(106, 41);
            this.ApellidoCliente.Name = "ApellidoCliente";
            this.ApellidoCliente.Size = new System.Drawing.Size(187, 20);
            this.ApellidoCliente.TabIndex = 12;
            // 
            // NombreCliente
            // 
            this.NombreCliente.Location = new System.Drawing.Point(106, 6);
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Size = new System.Drawing.Size(187, 20);
            this.NombreCliente.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(57, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nombre";
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.BackColor = System.Drawing.Color.LightGray;
            this.LimpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarButton.Location = new System.Drawing.Point(13, 355);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 37;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = false;
            this.LimpiarButton.Visible = false;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // AltaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(357, 381);
            this.Controls.Add(this.panelCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AltaClienteForm";
            this.Text = "AltaClienteForm";
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.DateTimePicker FechaNacimientoCliente;
        private System.Windows.Forms.Label nada;
        private System.Windows.Forms.TextBox CuilCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button AñadirDireccionButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ListaTiposDocumento;
        private System.Windows.Forms.TextBox TelefonoCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox MailCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox DniCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ApellidoCliente;
        private System.Windows.Forms.TextBox NombreCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button LimpiarButton;
    }
}