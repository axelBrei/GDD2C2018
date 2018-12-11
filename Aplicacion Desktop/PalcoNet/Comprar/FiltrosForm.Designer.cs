namespace PalcoNet.Comprar
{
    partial class FiltrosForm
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
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RubrosRadioButton = new System.Windows.Forms.RadioButton();
            this.RubrosListView = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FechasRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FechaIDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaFDatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DescRadioButton = new System.Windows.Forms.RadioButton();
            this.DescripcionFilterTextBox = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.MainGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGroupBox.Controls.Add(this.RubrosRadioButton);
            this.MainGroupBox.Controls.Add(this.FechasRadioButton);
            this.MainGroupBox.Controls.Add(this.DescRadioButton);
            this.MainGroupBox.Controls.Add(this.AceptarButton);
            this.MainGroupBox.Controls.Add(this.groupBox3);
            this.MainGroupBox.Controls.Add(this.groupBox2);
            this.MainGroupBox.Controls.Add(this.groupBox4);
            this.MainGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainGroupBox.Location = new System.Drawing.Point(0, -6);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(392, 507);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RubrosListView);
            this.groupBox3.Location = new System.Drawing.Point(45, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 217);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Categoria";
            // 
            // RubrosRadioButton
            // 
            this.RubrosRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RubrosRadioButton.AutoSize = true;
            this.RubrosRadioButton.Location = new System.Drawing.Point(12, 324);
            this.RubrosRadioButton.Name = "RubrosRadioButton";
            this.RubrosRadioButton.Size = new System.Drawing.Size(14, 13);
            this.RubrosRadioButton.TabIndex = 4;
            this.RubrosRadioButton.TabStop = true;
            this.RubrosRadioButton.UseVisualStyleBackColor = true;
            this.RubrosRadioButton.CheckedChanged += new System.EventHandler(this.RubrosRadioButton_CheckedChanged);
            // 
            // RubrosListView
            // 
            this.RubrosListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RubrosListView.CheckOnClick = true;
            this.RubrosListView.FormattingEnabled = true;
            this.RubrosListView.Location = new System.Drawing.Point(13, 27);
            this.RubrosListView.Name = "RubrosListView";
            this.RubrosListView.Size = new System.Drawing.Size(306, 169);
            this.RubrosListView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.FechaIDatePicker);
            this.groupBox2.Controls.Add(this.FechaFDatePicker);
            this.groupBox2.Location = new System.Drawing.Point(45, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 69);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha";
            // 
            // FechasRadioButton
            // 
            this.FechasRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FechasRadioButton.AutoSize = true;
            this.FechasRadioButton.Location = new System.Drawing.Point(12, 157);
            this.FechasRadioButton.Name = "FechasRadioButton";
            this.FechasRadioButton.Size = new System.Drawing.Size(14, 13);
            this.FechasRadioButton.TabIndex = 2;
            this.FechasRadioButton.TabStop = true;
            this.FechasRadioButton.UseVisualStyleBackColor = true;
            this.FechasRadioButton.CheckedChanged += new System.EventHandler(this.FechasRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // FechaIDatePicker
            // 
            this.FechaIDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaIDatePicker.Location = new System.Drawing.Point(57, 24);
            this.FechaIDatePicker.Name = "FechaIDatePicker";
            this.FechaIDatePicker.Size = new System.Drawing.Size(87, 20);
            this.FechaIDatePicker.TabIndex = 1;
            // 
            // FechaFDatePicker
            // 
            this.FechaFDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaFDatePicker.Location = new System.Drawing.Point(230, 24);
            this.FechaFDatePicker.Name = "FechaFDatePicker";
            this.FechaFDatePicker.Size = new System.Drawing.Size(87, 20);
            this.FechaFDatePicker.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DescripcionFilterTextBox);
            this.groupBox4.Location = new System.Drawing.Point(45, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(332, 66);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Descripcion";
            // 
            // DescRadioButton
            // 
            this.DescRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescRadioButton.AutoSize = true;
            this.DescRadioButton.Location = new System.Drawing.Point(12, 60);
            this.DescRadioButton.Name = "DescRadioButton";
            this.DescRadioButton.Size = new System.Drawing.Size(14, 13);
            this.DescRadioButton.TabIndex = 1;
            this.DescRadioButton.TabStop = true;
            this.DescRadioButton.UseVisualStyleBackColor = true;
            this.DescRadioButton.CheckedChanged += new System.EventHandler(this.DescRadioButton_CheckedChanged);
            // 
            // DescripcionFilterTextBox
            // 
            this.DescripcionFilterTextBox.Location = new System.Drawing.Point(10, 23);
            this.DescripcionFilterTextBox.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.DescripcionFilterTextBox.Name = "DescripcionFilterTextBox";
            this.DescripcionFilterTextBox.Size = new System.Drawing.Size(312, 20);
            this.DescripcionFilterTextBox.TabIndex = 0;
            // 
            // AceptarButton
            // 
            this.AceptarButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.AceptarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AceptarButton.Location = new System.Drawing.Point(302, 462);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 5;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // FiltrosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(389, 490);
            this.Controls.Add(this.MainGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltrosForm";
            this.Text = "FiltrosForm";
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RubrosRadioButton;
        private System.Windows.Forms.CheckedListBox RubrosListView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton FechasRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaIDatePicker;
        private System.Windows.Forms.DateTimePicker FechaFDatePicker;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton DescRadioButton;
        private System.Windows.Forms.TextBox DescripcionFilterTextBox;
        private System.Windows.Forms.Button AceptarButton;


    }
}