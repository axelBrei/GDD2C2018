namespace PalcoNet.Abm_Rol
{
    partial class EditarRol
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
            this.AgregarRol = new System.Windows.Forms.Button();
            this.EliminarRol = new System.Windows.Forms.Button();
            this.RolNombre = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.funcionalidadesRol = new System.Windows.Forms.ListView();
            this.Funcionalidades = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rol:";
            // 
            // AgregarRol
            // 
            this.AgregarRol.Location = new System.Drawing.Point(436, 100);
            this.AgregarRol.Name = "AgregarRol";
            this.AgregarRol.Size = new System.Drawing.Size(75, 23);
            this.AgregarRol.TabIndex = 3;
            this.AgregarRol.Text = "Agregar";
            this.AgregarRol.UseVisualStyleBackColor = true;
            // 
            // EliminarRol
            // 
            this.EliminarRol.Location = new System.Drawing.Point(436, 139);
            this.EliminarRol.Name = "EliminarRol";
            this.EliminarRol.Size = new System.Drawing.Size(75, 23);
            this.EliminarRol.TabIndex = 4;
            this.EliminarRol.Text = "Eliminar";
            this.EliminarRol.UseVisualStyleBackColor = true;
            this.EliminarRol.Click += new System.EventHandler(this.EliminarRol_Click);
            // 
            // RolNombre
            // 
            this.RolNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RolNombre.Location = new System.Drawing.Point(57, 21);
            this.RolNombre.Name = "RolNombre";
            this.RolNombre.Size = new System.Drawing.Size(350, 31);
            this.RolNombre.TabIndex = 5;
            this.RolNombre.TextChanged += new System.EventHandler(this.RolNombre_TextChanged);
            // 
            // AceptarButton
            // 
            this.AceptarButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AceptarButton.Location = new System.Drawing.Point(452, 522);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 6;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CancelarButton.Location = new System.Drawing.Point(352, 522);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 7;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // funcionalidadesRol
            // 
            this.funcionalidadesRol.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.funcionalidadesRol.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Funcionalidades});
            this.funcionalidadesRol.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.funcionalidadesRol.Location = new System.Drawing.Point(12, 112);
            this.funcionalidadesRol.MultiSelect = false;
            this.funcionalidadesRol.Name = "funcionalidadesRol";
            this.funcionalidadesRol.Size = new System.Drawing.Size(395, 357);
            this.funcionalidadesRol.TabIndex = 8;
            this.funcionalidadesRol.UseCompatibleStateImageBehavior = false;
            this.funcionalidadesRol.SelectedIndexChanged += new System.EventHandler(this.funcionalidadesRol_SelectedIndexChanged_1);
            // 
            // Funcionalidades
            // 
            this.Funcionalidades.Width = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Funcionalidades:";
            // 
            // EditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(539, 557);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.funcionalidadesRol);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.RolNombre);
            this.Controls.Add(this.EliminarRol);
            this.Controls.Add(this.AgregarRol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditarRol";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EditarRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AgregarRol;
        private System.Windows.Forms.Button EliminarRol;
        private System.Windows.Forms.TextBox RolNombre;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.ListView funcionalidadesRol;
        private System.Windows.Forms.ColumnHeader Funcionalidades;
        private System.Windows.Forms.Label label2;
    }
}