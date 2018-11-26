namespace PalcoNet.MainMenu
{
    partial class SeleccionDeRol
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
            this.RolesList = new System.Windows.Forms.ListBox();
            this.AceptarRol = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RolesList
            // 
            this.RolesList.FormattingEnabled = true;
            this.RolesList.IntegralHeight = false;
            this.RolesList.Location = new System.Drawing.Point(12, 12);
            this.RolesList.Name = "RolesList";
            this.RolesList.Size = new System.Drawing.Size(189, 212);
            this.RolesList.TabIndex = 0;
            this.RolesList.SelectedIndexChanged += new System.EventHandler(this.RolesList_SelectedIndexChanged);
            // 
            // AceptarRol
            // 
            this.AceptarRol.Location = new System.Drawing.Point(207, 24);
            this.AceptarRol.Name = "AceptarRol";
            this.AceptarRol.Size = new System.Drawing.Size(75, 23);
            this.AceptarRol.TabIndex = 1;
            this.AceptarRol.Text = "Aceptar";
            this.AceptarRol.UseVisualStyleBackColor = true;
            this.AceptarRol.Click += new System.EventHandler(this.AceptarRol_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(207, 62);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 2;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // SeleccionDeRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarRol);
            this.Controls.Add(this.RolesList);
            this.Name = "SeleccionDeRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionDeRol";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AceptarRol;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.ListBox RolesList;
    }
}