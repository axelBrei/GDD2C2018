﻿namespace PalcoNet.Historial_Cliente
{
    partial class SeleccionarClienteForm
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
            this.ClientesListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SeleccionarButton = new System.Windows.Forms.Button();
            this.BuscadorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClientesListView
            // 
            this.ClientesListView.FullRowSelect = true;
            this.ClientesListView.GridLines = true;
            this.ClientesListView.Location = new System.Drawing.Point(17, 82);
            this.ClientesListView.MultiSelect = false;
            this.ClientesListView.Name = "ClientesListView";
            this.ClientesListView.Size = new System.Drawing.Size(661, 402);
            this.ClientesListView.TabIndex = 0;
            this.ClientesListView.UseCompatibleStateImageBehavior = false;
            this.ClientesListView.View = System.Windows.Forms.View.Details;
            this.ClientesListView.SelectedIndexChanged += new System.EventHandler(this.ClientesListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccion de cliente";
            // 
            // SeleccionarButton
            // 
            this.SeleccionarButton.Location = new System.Drawing.Point(603, 504);
            this.SeleccionarButton.Name = "SeleccionarButton";
            this.SeleccionarButton.Size = new System.Drawing.Size(75, 23);
            this.SeleccionarButton.TabIndex = 2;
            this.SeleccionarButton.Text = "Seleccionar";
            this.SeleccionarButton.UseVisualStyleBackColor = true;
            this.SeleccionarButton.Click += new System.EventHandler(this.SeleccionarButton_Click);
            // 
            // BuscadorTextBox
            // 
            this.BuscadorTextBox.Location = new System.Drawing.Point(116, 52);
            this.BuscadorTextBox.Name = "BuscadorTextBox";
            this.BuscadorTextBox.Size = new System.Drawing.Size(307, 20);
            this.BuscadorTextBox.TabIndex = 3;
            this.BuscadorTextBox.TextChanged += new System.EventHandler(this.BuscadorTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar por nombre";
            // 
            // SeleccionarClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(701, 539);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BuscadorTextBox);
            this.Controls.Add(this.SeleccionarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClientesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionarClienteForm";
            this.Text = "SeleccionarClienteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ClientesListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SeleccionarButton;
        private System.Windows.Forms.TextBox BuscadorTextBox;
        private System.Windows.Forms.Label label2;
    }
}