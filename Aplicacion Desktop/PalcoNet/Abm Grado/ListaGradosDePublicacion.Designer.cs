﻿namespace PalcoNet.Abm_Grado
{
    partial class ListaGradosDePublicacion
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
            this.GradosListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.AgregarGradoButton = new System.Windows.Forms.Button();
            this.ModificarGradoButton = new System.Windows.Forms.Button();
            this.DeshabilitarGradoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GradosListView
            // 
            this.GradosListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.GradosListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.GradosListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradosListView.FullRowSelect = true;
            this.GradosListView.GridLines = true;
            this.GradosListView.Location = new System.Drawing.Point(12, 75);
            this.GradosListView.MultiSelect = false;
            this.GradosListView.Name = "GradosListView";
            this.GradosListView.Size = new System.Drawing.Size(576, 518);
            this.GradosListView.TabIndex = 0;
            this.GradosListView.UseCompatibleStateImageBehavior = false;
            this.GradosListView.View = System.Windows.Forms.View.Details;
            this.GradosListView.SelectedIndexChanged += new System.EventHandler(this.GradosListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grados de publicacion";
            // 
            // AgregarGradoButton
            // 
            this.AgregarGradoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AgregarGradoButton.BackColor = System.Drawing.Color.LightGray;
            this.AgregarGradoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarGradoButton.ForeColor = System.Drawing.Color.Black;
            this.AgregarGradoButton.Location = new System.Drawing.Point(604, 75);
            this.AgregarGradoButton.Name = "AgregarGradoButton";
            this.AgregarGradoButton.Size = new System.Drawing.Size(93, 23);
            this.AgregarGradoButton.TabIndex = 2;
            this.AgregarGradoButton.Text = "Agregar";
            this.AgregarGradoButton.UseVisualStyleBackColor = false;
            this.AgregarGradoButton.Click += new System.EventHandler(this.AgregarGradoButton_Click);
            // 
            // ModificarGradoButton
            // 
            this.ModificarGradoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ModificarGradoButton.BackColor = System.Drawing.Color.LightGray;
            this.ModificarGradoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarGradoButton.ForeColor = System.Drawing.Color.Black;
            this.ModificarGradoButton.Location = new System.Drawing.Point(604, 113);
            this.ModificarGradoButton.Name = "ModificarGradoButton";
            this.ModificarGradoButton.Size = new System.Drawing.Size(93, 23);
            this.ModificarGradoButton.TabIndex = 3;
            this.ModificarGradoButton.Text = "Modificar";
            this.ModificarGradoButton.UseVisualStyleBackColor = false;
            this.ModificarGradoButton.Click += new System.EventHandler(this.ModificarGradoButton_Click);
            // 
            // DeshabilitarGradoButton
            // 
            this.DeshabilitarGradoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeshabilitarGradoButton.BackColor = System.Drawing.Color.LightGray;
            this.DeshabilitarGradoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeshabilitarGradoButton.ForeColor = System.Drawing.Color.Black;
            this.DeshabilitarGradoButton.Location = new System.Drawing.Point(604, 151);
            this.DeshabilitarGradoButton.Name = "DeshabilitarGradoButton";
            this.DeshabilitarGradoButton.Size = new System.Drawing.Size(93, 23);
            this.DeshabilitarGradoButton.TabIndex = 4;
            this.DeshabilitarGradoButton.Text = "Deshabilitar";
            this.DeshabilitarGradoButton.UseVisualStyleBackColor = false;
            this.DeshabilitarGradoButton.Click += new System.EventHandler(this.DeshabilitarGradoButton_Click);
            // 
            // ListaGradosDePublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 670);
            this.ControlBox = false;
            this.Controls.Add(this.DeshabilitarGradoButton);
            this.Controls.Add(this.ModificarGradoButton);
            this.Controls.Add(this.AgregarGradoButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GradosListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaGradosDePublicacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView GradosListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AgregarGradoButton;
        private System.Windows.Forms.Button ModificarGradoButton;
        private System.Windows.Forms.Button DeshabilitarGradoButton;
    }
}