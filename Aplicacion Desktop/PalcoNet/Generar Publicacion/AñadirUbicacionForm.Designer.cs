namespace PalcoNet.Generar_Publicacion
{
    partial class AñadirUbicacionForm
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
            this.TipoUbicacionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilasDesdeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FilasHastaTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.AsientosHastaTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AsientosDesdeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.EnumeracionCheckbox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de ubicacion";
            // 
            // TipoUbicacionComboBox
            // 
            this.TipoUbicacionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipoUbicacionComboBox.FormattingEnabled = true;
            this.TipoUbicacionComboBox.Location = new System.Drawing.Point(121, 72);
            this.TipoUbicacionComboBox.Name = "TipoUbicacionComboBox";
            this.TipoUbicacionComboBox.Size = new System.Drawing.Size(177, 21);
            this.TipoUbicacionComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filas";
            // 
            // FilasDesdeTextBox
            // 
            this.FilasDesdeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FilasDesdeTextBox.Location = new System.Drawing.Point(56, 32);
            this.FilasDesdeTextBox.MaxLength = 1;
            this.FilasDesdeTextBox.Name = "FilasDesdeTextBox";
            this.FilasDesdeTextBox.Size = new System.Drawing.Size(56, 20);
            this.FilasDesdeTextBox.TabIndex = 3;
            this.FilasDesdeTextBox.TextChanged += new System.EventHandler(this.FilasDesdeTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hasta";
            // 
            // FilasHastaTextBox
            // 
            this.FilasHastaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FilasHastaTextBox.Location = new System.Drawing.Point(167, 32);
            this.FilasHastaTextBox.MaxLength = 1;
            this.FilasHastaTextBox.Name = "FilasHastaTextBox";
            this.FilasHastaTextBox.Size = new System.Drawing.Size(56, 20);
            this.FilasHastaTextBox.TabIndex = 5;
            this.FilasHastaTextBox.TextChanged += new System.EventHandler(this.FilasHastaTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.FilasDesdeTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.FilasHastaTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 67);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.AsientosHastaTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.AsientosDesdeTextBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(14, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 65);
            this.panel2.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Hasta";
            // 
            // AsientosHastaTextBox
            // 
            this.AsientosHastaTextBox.Location = new System.Drawing.Point(172, 33);
            this.AsientosHastaTextBox.MaxLength = 2;
            this.AsientosHastaTextBox.Name = "AsientosHastaTextBox";
            this.AsientosHastaTextBox.Size = new System.Drawing.Size(56, 20);
            this.AsientosHastaTextBox.TabIndex = 15;
            this.AsientosHastaTextBox.TextChanged += new System.EventHandler(this.AsientosHastaTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Desde";
            // 
            // AsientosDesdeTextBox
            // 
            this.AsientosDesdeTextBox.Location = new System.Drawing.Point(55, 33);
            this.AsientosDesdeTextBox.MaxLength = 2;
            this.AsientosDesdeTextBox.Name = "AsientosDesdeTextBox";
            this.AsientosDesdeTextBox.Size = new System.Drawing.Size(56, 20);
            this.AsientosDesdeTextBox.TabIndex = 13;
            this.AsientosDesdeTextBox.TextChanged += new System.EventHandler(this.AsientosDesdeTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Asientos";
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrecioTextBox.Location = new System.Drawing.Point(66, 115);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(85, 20);
            this.PrecioTextBox.TabIndex = 7;
            this.PrecioTextBox.TextChanged += new System.EventHandler(this.onPriceChanged);
            this.PrecioTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PrecioTextBox_Validating);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Precio";
            // 
            // AceptarButton
            // 
            this.AceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarButton.Location = new System.Drawing.Point(286, 406);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 14;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // SalirButton
            // 
            this.SalirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SalirButton.Location = new System.Drawing.Point(205, 406);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(75, 23);
            this.SalirButton.TabIndex = 15;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Añadir ubicaciones";
            // 
            // EnumeracionCheckbox
            // 
            this.EnumeracionCheckbox.AutoSize = true;
            this.EnumeracionCheckbox.Location = new System.Drawing.Point(26, 342);
            this.EnumeracionCheckbox.Name = "EnumeracionCheckbox";
            this.EnumeracionCheckbox.Size = new System.Drawing.Size(88, 17);
            this.EnumeracionCheckbox.TabIndex = 17;
            this.EnumeracionCheckbox.Text = "Sin enumerar";
            this.EnumeracionCheckbox.UseVisualStyleBackColor = true;
            // 
            // AñadirUbicacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(373, 441);
            this.ControlBox = false;
            this.Controls.Add(this.EnumeracionCheckbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PrecioTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TipoUbicacionComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AñadirUbicacionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AñadirUbicacionForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoUbicacionComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FilasDesdeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FilasHastaTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AsientosHastaTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AsientosDesdeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox EnumeracionCheckbox;
    }
}