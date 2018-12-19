namespace PalcoNet.Registro_de_Usuario
{
    partial class RegistrarUsuario
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
            this.ContraseñaLabel = new System.Windows.Forms.Label();
            this.UsuarioTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.TipoUsuarioLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TipoUsuariogroupBox = new System.Windows.Forms.GroupBox();
            this.EmpresaRadioButton = new System.Windows.Forms.RadioButton();
            this.ClienteRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.DatosPanel = new System.Windows.Forms.Panel();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.TipoUsuariogroupBox.SuspendLayout();
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
            // ContraseñaLabel
            // 
            this.ContraseñaLabel.AutoSize = true;
            this.ContraseñaLabel.Location = new System.Drawing.Point(20, 122);
            this.ContraseñaLabel.Name = "ContraseñaLabel";
            this.ContraseñaLabel.Size = new System.Drawing.Size(61, 13);
            this.ContraseñaLabel.TabIndex = 1;
            this.ContraseñaLabel.Text = "Contraseña";
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.Location = new System.Drawing.Point(69, 81);
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.Size = new System.Drawing.Size(187, 20);
            this.UsuarioTextBox.TabIndex = 3;
            this.UsuarioTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(87, 119);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(169, 20);
            this.PasswordTextBox.TabIndex = 4;
            // 
            // TipoUsuarioLabel
            // 
            this.TipoUsuarioLabel.AutoSize = true;
            this.TipoUsuarioLabel.Location = new System.Drawing.Point(20, 163);
            this.TipoUsuarioLabel.Name = "TipoUsuarioLabel";
            this.TipoUsuarioLabel.Size = new System.Drawing.Size(80, 13);
            this.TipoUsuarioLabel.TabIndex = 5;
            this.TipoUsuarioLabel.Text = "Tipo de usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.LimpiarButton);
            this.panel1.Controls.Add(this.TipoUsuariogroupBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.UsuarioTextBox);
            this.panel1.Controls.Add(this.TipoUsuarioLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PasswordTextBox);
            this.panel1.Controls.Add(this.ContraseñaLabel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 442);
            this.panel1.TabIndex = 6;
            // 
            // TipoUsuariogroupBox
            // 
            this.TipoUsuariogroupBox.Controls.Add(this.EmpresaRadioButton);
            this.TipoUsuariogroupBox.Controls.Add(this.ClienteRadioButton);
            this.TipoUsuariogroupBox.Location = new System.Drawing.Point(23, 180);
            this.TipoUsuariogroupBox.Name = "TipoUsuariogroupBox";
            this.TipoUsuariogroupBox.Size = new System.Drawing.Size(246, 46);
            this.TipoUsuariogroupBox.TabIndex = 9;
            this.TipoUsuariogroupBox.TabStop = false;
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
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.LightGray;
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
            this.AceptarButton.BackColor = System.Drawing.Color.LightGray;
            this.AceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AceptarButton.Location = new System.Drawing.Point(602, 405);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 33;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // DatosPanel
            // 
            this.DatosPanel.Location = new System.Drawing.Point(323, 0);
            this.DatosPanel.Name = "DatosPanel";
            this.DatosPanel.Size = new System.Drawing.Size(367, 399);
            this.DatosPanel.TabIndex = 34;
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.BackColor = System.Drawing.Color.LightGray;
            this.LimpiarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LimpiarButton.Location = new System.Drawing.Point(12, 406);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 35;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = false;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // RegistrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(689, 440);
            this.Controls.Add(this.DatosPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.panel1);
            this.Name = "RegistrarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TipoUsuariogroupBox.ResumeLayout(false);
            this.TipoUsuariogroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ContraseñaLabel;
        private System.Windows.Forms.TextBox UsuarioTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label TipoUsuarioLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox TipoUsuariogroupBox;
        private System.Windows.Forms.RadioButton EmpresaRadioButton;
        private System.Windows.Forms.RadioButton ClienteRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Panel DatosPanel;
        private System.Windows.Forms.Button LimpiarButton;
    }
}