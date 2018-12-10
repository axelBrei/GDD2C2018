namespace PalcoNet.Generar_Publicacion
{
    partial class GenerarPublicacionForm
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
            this.FechaEventoTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.RubroComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GradoPublicacionComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.UbicacionesPanel = new System.Windows.Forms.Panel();
            this.UbicacionesListView = new System.Windows.Forms.ListView();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.EliminarUbicacionButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.HoraEventoTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ClearFormButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UbicacionesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FechaEventoTimePicker
            // 
            this.FechaEventoTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FechaEventoTimePicker.Location = new System.Drawing.Point(104, 69);
            this.FechaEventoTimePicker.Name = "FechaEventoTimePicker";
            this.FechaEventoTimePicker.Size = new System.Drawing.Size(257, 20);
            this.FechaEventoTimePicker.TabIndex = 2;
            this.FechaEventoTimePicker.ValueChanged += new System.EventHandler(this.FechaEventoTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Evento";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Direccion/Nombre del teatro";
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DireccionTextBox.Location = new System.Drawing.Point(162, 106);
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.Size = new System.Drawing.Size(403, 20);
            this.DireccionTextBox.TabIndex = 5;
            this.DireccionTextBox.TextChanged += new System.EventHandler(this.DireccionTextBox_TextChanged);
            // 
            // RubroComboBox
            // 
            this.RubroComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RubroComboBox.FormattingEnabled = true;
            this.RubroComboBox.Location = new System.Drawing.Point(117, 139);
            this.RubroComboBox.Name = "RubroComboBox";
            this.RubroComboBox.Size = new System.Drawing.Size(448, 21);
            this.RubroComboBox.TabIndex = 6;
            this.RubroComboBox.SelectedIndexChanged += new System.EventHandler(this.RubroComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Categoria";
            // 
            // GradoPublicacionComboBox
            // 
            this.GradoPublicacionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradoPublicacionComboBox.FormattingEnabled = true;
            this.GradoPublicacionComboBox.Location = new System.Drawing.Point(127, 181);
            this.GradoPublicacionComboBox.Name = "GradoPublicacionComboBox";
            this.GradoPublicacionComboBox.Size = new System.Drawing.Size(438, 21);
            this.GradoPublicacionComboBox.TabIndex = 8;
            this.GradoPublicacionComboBox.SelectedIndexChanged += new System.EventHandler(this.GradoPublicacionComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Grado de Publicacion";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Descripcion";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 236);
            this.textBox1.MaxLength = 255;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(550, 112);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Desktop;
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(15, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Añadir Ubicaciones";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UbicacionesPanel
            // 
            this.UbicacionesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UbicacionesPanel.Controls.Add(this.UbicacionesListView);
            this.UbicacionesPanel.Location = new System.Drawing.Point(142, 375);
            this.UbicacionesPanel.Name = "UbicacionesPanel";
            this.UbicacionesPanel.Size = new System.Drawing.Size(458, 265);
            this.UbicacionesPanel.TabIndex = 13;
            // 
            // UbicacionesListView
            // 
            this.UbicacionesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.UbicacionesListView.FullRowSelect = true;
            this.UbicacionesListView.GridLines = true;
            this.UbicacionesListView.Location = new System.Drawing.Point(4, 4);
            this.UbicacionesListView.MultiSelect = false;
            this.UbicacionesListView.Name = "UbicacionesListView";
            this.UbicacionesListView.Size = new System.Drawing.Size(416, 238);
            this.UbicacionesListView.TabIndex = 0;
            this.UbicacionesListView.UseCompatibleStateImageBehavior = false;
            this.UbicacionesListView.View = System.Windows.Forms.View.Details;
            // 
            // AceptarButton
            // 
            this.AceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.AceptarButton.ForeColor = System.Drawing.Color.Snow;
            this.AceptarButton.Location = new System.Drawing.Point(630, 617);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 15;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // EliminarUbicacionButton
            // 
            this.EliminarUbicacionButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.EliminarUbicacionButton.ForeColor = System.Drawing.Color.Snow;
            this.EliminarUbicacionButton.Location = new System.Drawing.Point(15, 420);
            this.EliminarUbicacionButton.Name = "EliminarUbicacionButton";
            this.EliminarUbicacionButton.Size = new System.Drawing.Size(115, 23);
            this.EliminarUbicacionButton.TabIndex = 16;
            this.EliminarUbicacionButton.Text = "Eliminar Ubicacion";
            this.EliminarUbicacionButton.UseVisualStyleBackColor = false;
            this.EliminarUbicacionButton.Click += new System.EventHandler(this.EliminarUbicacionButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.ForeColor = System.Drawing.Color.Snow;
            this.button2.Location = new System.Drawing.Point(590, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Mas fechas";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HoraEventoTimePicker
            // 
            this.HoraEventoTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HoraEventoTimePicker.CustomFormat = "HH:mm";
            this.HoraEventoTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HoraEventoTimePicker.Location = new System.Drawing.Point(402, 69);
            this.HoraEventoTimePicker.Name = "HoraEventoTimePicker";
            this.HoraEventoTimePicker.ShowUpDown = true;
            this.HoraEventoTimePicker.Size = new System.Drawing.Size(160, 20);
            this.HoraEventoTimePicker.TabIndex = 18;
            this.HoraEventoTimePicker.Value = new System.DateTime(2018, 12, 4, 0, 0, 0, 0);
            this.HoraEventoTimePicker.ValueChanged += new System.EventHandler(this.HoraEventoTimePicker_ValueChanged);
            // 
            // ClearFormButton
            // 
            this.ClearFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearFormButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClearFormButton.ForeColor = System.Drawing.Color.Snow;
            this.ClearFormButton.Location = new System.Drawing.Point(630, 577);
            this.ClearFormButton.Name = "ClearFormButton";
            this.ClearFormButton.Size = new System.Drawing.Size(75, 23);
            this.ClearFormButton.TabIndex = 19;
            this.ClearFormButton.Text = "Limpiar";
            this.ClearFormButton.UseVisualStyleBackColor = false;
            this.ClearFormButton.Click += new System.EventHandler(this.ClearFormButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Generar Publicación";
            // 
            // GenerarPublicacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(717, 697);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearFormButton);
            this.Controls.Add(this.HoraEventoTimePicker);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EliminarUbicacionButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.UbicacionesPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GradoPublicacionComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RubroComboBox);
            this.Controls.Add(this.DireccionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FechaEventoTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerarPublicacionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerarPublicacion";
            this.UbicacionesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FechaEventoTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.ComboBox RubroComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GradoPublicacionComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel UbicacionesPanel;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.ListView UbicacionesListView;
        private System.Windows.Forms.Button EliminarUbicacionButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker HoraEventoTimePicker;
        private System.Windows.Forms.Button ClearFormButton;
        private System.Windows.Forms.Label label1;
    }
}