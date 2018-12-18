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
            this.RolNombre = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.funcionalidadesRol = new System.Windows.Forms.CheckedListBox();
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
            this.AceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarButton.BackColor = System.Drawing.Color.Gainsboro;
            this.AceptarButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AceptarButton.Location = new System.Drawing.Point(630, 662);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 6;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarButton.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelarButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CancelarButton.Location = new System.Drawing.Point(530, 662);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 7;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = false;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
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
            // funcionalidadesRol
            // 
            this.funcionalidadesRol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionalidadesRol.CheckOnClick = true;
            this.funcionalidadesRol.FormattingEnabled = true;
            this.funcionalidadesRol.Location = new System.Drawing.Point(12, 113);
            this.funcionalidadesRol.Name = "funcionalidadesRol";
            this.funcionalidadesRol.Size = new System.Drawing.Size(573, 454);
            this.funcionalidadesRol.TabIndex = 10;
            this.funcionalidadesRol.SelectedIndexChanged += new System.EventHandler(this.funcionalidadesRol_SelectedIndexChanged);
            // 
            // EditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(717, 697);
            this.Controls.Add(this.funcionalidadesRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.RolNombre);
            this.Controls.Add(this.label1);
            this.Name = "EditarRol";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EditarRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RolNombre;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox funcionalidadesRol;
    }
}