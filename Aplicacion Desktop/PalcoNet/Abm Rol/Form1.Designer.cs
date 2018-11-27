namespace PalcoNet.Abm_Rol
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.EditarButton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.listaRoles = new System.Windows.Forms.ListView();
            this.Rol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 150);
            this.panel1.TabIndex = 0;
            // 
            // AgregarButton
            // 
            this.AgregarButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AgregarButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AgregarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AgregarButton.Location = new System.Drawing.Point(811, 180);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(75, 23);
            this.AgregarButton.TabIndex = 1;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // EditarButton
            // 
            this.EditarButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EditarButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditarButton.Location = new System.Drawing.Point(811, 227);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(75, 23);
            this.EditarButton.TabIndex = 5;
            this.EditarButton.Text = "Editar";
            this.EditarButton.UseVisualStyleBackColor = false;
            this.EditarButton.Click += new System.EventHandler(this.EditarButton_Click);
            // 
            // EliminarButton
            // 
            this.EliminarButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EliminarButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EliminarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EliminarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EliminarButton.Location = new System.Drawing.Point(811, 273);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(75, 23);
            this.EliminarButton.TabIndex = 6;
            this.EliminarButton.Text = "Deshabilitar";
            this.EliminarButton.UseVisualStyleBackColor = false;
            // 
            // SalirButton
            // 
            this.SalirButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SalirButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SalirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SalirButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SalirButton.Location = new System.Drawing.Point(12, 638);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(75, 23);
            this.SalirButton.TabIndex = 7;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = false;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // listaRoles
            // 
            this.listaRoles.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listaRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rol});
            this.listaRoles.Location = new System.Drawing.Point(12, 180);
            this.listaRoles.Name = "listaRoles";
            this.listaRoles.Size = new System.Drawing.Size(753, 423);
            this.listaRoles.TabIndex = 8;
            this.listaRoles.UseCompatibleStateImageBehavior = false;
            this.listaRoles.SelectedIndexChanged += new System.EventHandler(this.listaRoles_SelectedIndexChanged);
            // 
            // Rol
            // 
            this.Rol.Width = 150;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(912, 692);
            this.ControlBox = false;
            this.Controls.Add(this.listaRoles);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.EditarButton);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.Button EditarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.ListView listaRoles;
        private System.Windows.Forms.ColumnHeader Rol;
    }
}