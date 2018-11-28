namespace PalcoNet.Registro_de_Usuario
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EmpresaRadioButton = new System.Windows.Forms.RadioButton();
            this.ClienteRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelEmpresa = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.CuitEmpresa = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.telefonoEmpresa1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.MailEmpresa1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.RazonSocialEmpresa = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NombreCliente = new System.Windows.Forms.TextBox();
            this.ApellidoCliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DniCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.MailCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TelefonoCliente = new System.Windows.Forms.TextBox();
            this.ListaTiposDocumento = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FechaNacimientoCli = new System.Windows.Forms.TextBox();
            this.AñadirDireccionButton = new System.Windows.Forms.Button();
            this.numeroTarjetaCliente = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CuilCliente = new System.Windows.Forms.TextBox();
            this.nada = new System.Windows.Forms.Label();
            this.panelCliente = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PanelEmpresa.SuspendLayout();
            this.panelCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(169, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 442);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EmpresaRadioButton);
            this.groupBox1.Controls.Add(this.ClienteRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(23, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 46);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // EmpresaRadioButton
            // 
            this.EmpresaRadioButton.AutoSize = true;
            this.EmpresaRadioButton.Location = new System.Drawing.Point(129, 15);
            this.EmpresaRadioButton.Name = "EmpresaRadioButton";
            this.EmpresaRadioButton.Size = new System.Drawing.Size(66, 17);
            this.EmpresaRadioButton.TabIndex = 1;
            this.EmpresaRadioButton.TabStop = true;
            this.EmpresaRadioButton.Text = "Empresa";
            this.EmpresaRadioButton.UseVisualStyleBackColor = true;
            this.EmpresaRadioButton.CheckedChanged += new System.EventHandler(this.EmpresaRadioButton_CheckedChanged);
            // 
            // ClienteRadioButton
            // 
            this.ClienteRadioButton.AutoSize = true;
            this.ClienteRadioButton.Location = new System.Drawing.Point(6, 15);
            this.ClienteRadioButton.Name = "ClienteRadioButton";
            this.ClienteRadioButton.Size = new System.Drawing.Size(57, 17);
            this.ClienteRadioButton.TabIndex = 0;
            this.ClienteRadioButton.TabStop = true;
            this.ClienteRadioButton.Text = "Cliente";
            this.ClienteRadioButton.UseVisualStyleBackColor = true;
            this.ClienteRadioButton.CheckedChanged += new System.EventHandler(this.ClienteRadioButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Registro de usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(333, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Apellido";
            // 
            // PanelEmpresa
            // 
            this.PanelEmpresa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelEmpresa.Controls.Add(this.button3);
            this.PanelEmpresa.Controls.Add(this.CuitEmpresa);
            this.PanelEmpresa.Controls.Add(this.label15);
            this.PanelEmpresa.Controls.Add(this.telefonoEmpresa1);
            this.PanelEmpresa.Controls.Add(this.label16);
            this.PanelEmpresa.Controls.Add(this.MailEmpresa1);
            this.PanelEmpresa.Controls.Add(this.label18);
            this.PanelEmpresa.Controls.Add(this.RazonSocialEmpresa);
            this.PanelEmpresa.Controls.Add(this.label19);
            this.PanelEmpresa.Location = new System.Drawing.Point(383, 34);
            this.PanelEmpresa.Name = "PanelEmpresa";
            this.PanelEmpresa.Size = new System.Drawing.Size(265, 347);
            this.PanelEmpresa.TabIndex = 29;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(81, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "Añadir Direccion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CuitEmpresa
            // 
            this.CuitEmpresa.Location = new System.Drawing.Point(64, 108);
            this.CuitEmpresa.Name = "CuitEmpresa";
            this.CuitEmpresa.Size = new System.Drawing.Size(198, 20);
            this.CuitEmpresa.TabIndex = 18;
            this.CuitEmpresa.TextChanged += new System.EventHandler(this.CuitEmpresa_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(26, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "CUIT";
            // 
            // telefonoEmpresa1
            // 
            this.telefonoEmpresa1.Location = new System.Drawing.Point(81, 76);
            this.telefonoEmpresa1.Name = "telefonoEmpresa1";
            this.telefonoEmpresa1.Size = new System.Drawing.Size(181, 20);
            this.telefonoEmpresa1.TabIndex = 16;
            this.telefonoEmpresa1.TextChanged += new System.EventHandler(this.telefonoEmpresa1_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(26, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Telefono";
            // 
            // MailEmpresa1
            // 
            this.MailEmpresa1.Location = new System.Drawing.Point(58, 43);
            this.MailEmpresa1.Name = "MailEmpresa1";
            this.MailEmpresa1.Size = new System.Drawing.Size(204, 20);
            this.MailEmpresa1.TabIndex = 12;
            this.MailEmpresa1.TextChanged += new System.EventHandler(this.MailEmpresa1_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(26, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Mail";
            // 
            // RazonSocialEmpresa
            // 
            this.RazonSocialEmpresa.Location = new System.Drawing.Point(102, 8);
            this.RazonSocialEmpresa.Name = "RazonSocialEmpresa";
            this.RazonSocialEmpresa.Size = new System.Drawing.Size(160, 20);
            this.RazonSocialEmpresa.TabIndex = 10;
            this.RazonSocialEmpresa.TextChanged += new System.EventHandler(this.RazonSocialEmpresa_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(26, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "Razon Social";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(516, 405);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AceptarButton.Location = new System.Drawing.Point(602, 405);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 33;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(26, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nombre";
            // 
            // NombreCliente
            // 
            this.NombreCliente.Location = new System.Drawing.Point(75, 8);
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Size = new System.Drawing.Size(187, 20);
            this.NombreCliente.TabIndex = 10;
            this.NombreCliente.TextChanged += new System.EventHandler(this.NombreCliente_TextChanged);
            // 
            // ApellidoCliente
            // 
            this.ApellidoCliente.Location = new System.Drawing.Point(75, 43);
            this.ApellidoCliente.Name = "ApellidoCliente";
            this.ApellidoCliente.Size = new System.Drawing.Size(187, 20);
            this.ApellidoCliente.TabIndex = 12;
            this.ApellidoCliente.TextChanged += new System.EventHandler(this.ApellidoCliente_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(26, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tipo de Documento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(26, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "DNI";
            // 
            // DniCliente
            // 
            this.DniCliente.Location = new System.Drawing.Point(58, 116);
            this.DniCliente.Name = "DniCliente";
            this.DniCliente.Size = new System.Drawing.Size(204, 20);
            this.DniCliente.TabIndex = 16;
            this.DniCliente.TextChanged += new System.EventHandler(this.DniCliente_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(26, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Mail";
            // 
            // MailCliente
            // 
            this.MailCliente.Location = new System.Drawing.Point(58, 150);
            this.MailCliente.Name = "MailCliente";
            this.MailCliente.Size = new System.Drawing.Size(204, 20);
            this.MailCliente.TabIndex = 18;
            this.MailCliente.TextChanged += new System.EventHandler(this.MailCliente_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(26, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Telefono";
            // 
            // TelefonoCliente
            // 
            this.TelefonoCliente.Location = new System.Drawing.Point(81, 185);
            this.TelefonoCliente.Name = "TelefonoCliente";
            this.TelefonoCliente.Size = new System.Drawing.Size(181, 20);
            this.TelefonoCliente.TabIndex = 20;
            this.TelefonoCliente.TextChanged += new System.EventHandler(this.TelefonoCliente_TextChanged);
            // 
            // ListaTiposDocumento
            // 
            this.ListaTiposDocumento.FormattingEnabled = true;
            this.ListaTiposDocumento.Location = new System.Drawing.Point(133, 80);
            this.ListaTiposDocumento.Name = "ListaTiposDocumento";
            this.ListaTiposDocumento.Size = new System.Drawing.Size(121, 21);
            this.ListaTiposDocumento.TabIndex = 22;
            this.ListaTiposDocumento.SelectedIndexChanged += new System.EventHandler(this.ListaTiposDocumento_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(26, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Fecha De Nacimiento";
            // 
            // FechaNacimientoCli
            // 
            this.FechaNacimientoCli.Location = new System.Drawing.Point(142, 220);
            this.FechaNacimientoCli.Name = "FechaNacimientoCli";
            this.FechaNacimientoCli.Size = new System.Drawing.Size(120, 20);
            this.FechaNacimientoCli.TabIndex = 24;
            this.FechaNacimientoCli.Text = "AAAA/MM/DD";
            this.FechaNacimientoCli.TextChanged += new System.EventHandler(this.FechaNacimientoCli_TextChanged);
            // 
            // AñadirDireccionButton
            // 
            this.AñadirDireccionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AñadirDireccionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AñadirDireccionButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AñadirDireccionButton.Location = new System.Drawing.Point(81, 322);
            this.AñadirDireccionButton.Name = "AñadirDireccionButton";
            this.AñadirDireccionButton.Size = new System.Drawing.Size(112, 23);
            this.AñadirDireccionButton.TabIndex = 28;
            this.AñadirDireccionButton.Text = "Añadir Direccion";
            this.AñadirDireccionButton.UseVisualStyleBackColor = true;
            this.AñadirDireccionButton.Click += new System.EventHandler(this.AñadirDireccionButton_Click);
            // 
            // numeroTarjetaCliente
            // 
            this.numeroTarjetaCliente.Location = new System.Drawing.Point(112, 256);
            this.numeroTarjetaCliente.Name = "numeroTarjetaCliente";
            this.numeroTarjetaCliente.Size = new System.Drawing.Size(150, 20);
            this.numeroTarjetaCliente.TabIndex = 29;
            this.numeroTarjetaCliente.TextChanged += new System.EventHandler(this.numeroTarjetaCliente_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(26, 259);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "Numero Tarjeta";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(25, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Apellido";
            // 
            // CuilCliente
            // 
            this.CuilCliente.Location = new System.Drawing.Point(63, 289);
            this.CuilCliente.Name = "CuilCliente";
            this.CuilCliente.Size = new System.Drawing.Size(199, 20);
            this.CuilCliente.TabIndex = 32;
            this.CuilCliente.TextChanged += new System.EventHandler(this.CuilCliente_TextChanged);
            // 
            // nada
            // 
            this.nada.AutoSize = true;
            this.nada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nada.Location = new System.Drawing.Point(26, 292);
            this.nada.Name = "nada";
            this.nada.Size = new System.Drawing.Size(31, 13);
            this.nada.TabIndex = 33;
            this.nada.Text = "CUIL";
            // 
            // panelCliente
            // 
            this.panelCliente.AutoSize = true;
            this.panelCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCliente.Controls.Add(this.nada);
            this.panelCliente.Controls.Add(this.CuilCliente);
            this.panelCliente.Controls.Add(this.label13);
            this.panelCliente.Controls.Add(this.label20);
            this.panelCliente.Controls.Add(this.numeroTarjetaCliente);
            this.panelCliente.Controls.Add(this.AñadirDireccionButton);
            this.panelCliente.Controls.Add(this.FechaNacimientoCli);
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
            this.panelCliente.Location = new System.Drawing.Point(383, 36);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(265, 348);
            this.panelCliente.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(689, 440);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.panelCliente);
            this.Controls.Add(this.PanelEmpresa);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelEmpresa.ResumeLayout(false);
            this.PanelEmpresa.PerformLayout();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PanelEmpresa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox CuitEmpresa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox telefonoEmpresa1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox MailEmpresa1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox RazonSocialEmpresa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton EmpresaRadioButton;
        private System.Windows.Forms.RadioButton ClienteRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NombreCliente;
        private System.Windows.Forms.TextBox ApellidoCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DniCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox MailCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TelefonoCliente;
        private System.Windows.Forms.ComboBox ListaTiposDocumento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox FechaNacimientoCli;
        private System.Windows.Forms.Button AñadirDireccionButton;
        private System.Windows.Forms.TextBox numeroTarjetaCliente;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox CuilCliente;
        private System.Windows.Forms.Label nada;
        private System.Windows.Forms.Panel panelCliente;
    }
}