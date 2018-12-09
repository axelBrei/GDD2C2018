namespace PalcoNet.Editar_Publicacion
{
    partial class EditarEstadoForm
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
            this.EstadoComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HoraDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CodigoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EstadoComboBox
            // 
            this.EstadoComboBox.FormattingEnabled = true;
            this.EstadoComboBox.Location = new System.Drawing.Point(110, 124);
            this.EstadoComboBox.Name = "EstadoComboBox";
            this.EstadoComboBox.Size = new System.Drawing.Size(121, 21);
            this.EstadoComboBox.TabIndex = 0;
            this.EstadoComboBox.SelectedIndexChanged += new System.EventHandler(this.EstadoComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Editar Estado/Otros";
            // 
            // FechaDatePicker
            // 
            this.FechaDatePicker.Location = new System.Drawing.Point(182, 249);
            this.FechaDatePicker.Name = "FechaDatePicker";
            this.FechaDatePicker.Size = new System.Drawing.Size(227, 20);
            this.FechaDatePicker.TabIndex = 3;
            this.FechaDatePicker.ValueChanged += new System.EventHandler(this.FechaDatePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de la Publicacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora de la publicacion";
            // 
            // HoraDatePicker
            // 
            this.HoraDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.HoraDatePicker.Location = new System.Drawing.Point(182, 287);
            this.HoraDatePicker.Name = "HoraDatePicker";
            this.HoraDatePicker.Size = new System.Drawing.Size(227, 20);
            this.HoraDatePicker.TabIndex = 6;
            this.HoraDatePicker.ValueChanged += new System.EventHandler(this.HoraDatePicker_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Datos de la publicacion";
            // 
            // CodigoLabel
            // 
            this.CodigoLabel.AutoSize = true;
            this.CodigoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodigoLabel.Location = new System.Drawing.Point(55, 396);
            this.CodigoLabel.Name = "CodigoLabel";
            this.CodigoLabel.Size = new System.Drawing.Size(204, 20);
            this.CodigoLabel.TabIndex = 9;
            this.CodigoLabel.Text = "Codigo de la publicacion";
            // 
            // EditarEstadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 510);
            this.Controls.Add(this.CodigoLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HoraDatePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FechaDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EstadoComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarEstadoForm";
            this.Text = "EditarEstadoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EstadoComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker HoraDatePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CodigoLabel;
    }
}