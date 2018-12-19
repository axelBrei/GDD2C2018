namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class AltaEmpresaForm
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
            this.PanelEmpresa = new System.Windows.Forms.Panel();
            this.AñadirDirButton = new System.Windows.Forms.Button();
            this.CuitEmpresa = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.telefonoEmpresa1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.MailEmpresa1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.RazonSocialEmpresa = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.PanelEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelEmpresa
            // 
            this.PanelEmpresa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelEmpresa.Controls.Add(this.AñadirDirButton);
            this.PanelEmpresa.Controls.Add(this.CuitEmpresa);
            this.PanelEmpresa.Controls.Add(this.label15);
            this.PanelEmpresa.Controls.Add(this.telefonoEmpresa1);
            this.PanelEmpresa.Controls.Add(this.label16);
            this.PanelEmpresa.Controls.Add(this.MailEmpresa1);
            this.PanelEmpresa.Controls.Add(this.label18);
            this.PanelEmpresa.Controls.Add(this.RazonSocialEmpresa);
            this.PanelEmpresa.Controls.Add(this.label19);
            this.PanelEmpresa.Location = new System.Drawing.Point(0, 0);
            this.PanelEmpresa.Name = "PanelEmpresa";
            this.PanelEmpresa.Size = new System.Drawing.Size(357, 338);
            this.PanelEmpresa.TabIndex = 30;
            // 
            // AñadirDirButton
            // 
            this.AñadirDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AñadirDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AñadirDirButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AñadirDirButton.Location = new System.Drawing.Point(76, 315);
            this.AñadirDirButton.Name = "AñadirDirButton";
            this.AñadirDirButton.Size = new System.Drawing.Size(204, 23);
            this.AñadirDirButton.TabIndex = 28;
            this.AñadirDirButton.Text = "Añadir Direccion";
            this.AñadirDirButton.UseVisualStyleBackColor = true;
            this.AñadirDirButton.Click += new System.EventHandler(this.AñadirDirButton_Click);
            // 
            // CuitEmpresa
            // 
            this.CuitEmpresa.Location = new System.Drawing.Point(98, 123);
            this.CuitEmpresa.Name = "CuitEmpresa";
            this.CuitEmpresa.Size = new System.Drawing.Size(198, 20);
            this.CuitEmpresa.TabIndex = 18;
            this.CuitEmpresa.Validating += new System.ComponentModel.CancelEventHandler(this.validarCuil);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(60, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "CUIT";
            // 
            // telefonoEmpresa1
            // 
            this.telefonoEmpresa1.Location = new System.Drawing.Point(115, 91);
            this.telefonoEmpresa1.Name = "telefonoEmpresa1";
            this.telefonoEmpresa1.Size = new System.Drawing.Size(181, 20);
            this.telefonoEmpresa1.TabIndex = 16;
            this.telefonoEmpresa1.Validating += new System.ComponentModel.CancelEventHandler(this.telefonoEmpresa1_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(60, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Telefono";
            // 
            // MailEmpresa1
            // 
            this.MailEmpresa1.Location = new System.Drawing.Point(92, 58);
            this.MailEmpresa1.Name = "MailEmpresa1";
            this.MailEmpresa1.Size = new System.Drawing.Size(204, 20);
            this.MailEmpresa1.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(60, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Mail";
            // 
            // RazonSocialEmpresa
            // 
            this.RazonSocialEmpresa.Location = new System.Drawing.Point(136, 23);
            this.RazonSocialEmpresa.Name = "RazonSocialEmpresa";
            this.RazonSocialEmpresa.Size = new System.Drawing.Size(160, 20);
            this.RazonSocialEmpresa.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(60, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "Razon Social";
            // 
            // CancelarButton
            // 
            this.CancelarButton.BackColor = System.Drawing.Color.LightGray;
            this.CancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(189, 355);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 38;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = false;
            this.CancelarButton.Visible = false;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.BackColor = System.Drawing.Color.LightGray;
            this.AceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AceptarButton.Location = new System.Drawing.Point(270, 355);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 37;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Visible = false;
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.BackColor = System.Drawing.Color.LightGray;
            this.LimpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarButton.Location = new System.Drawing.Point(0, 355);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 39;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = false;
            this.LimpiarButton.Visible = false;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // AltaEmpresaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(357, 381);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.PanelEmpresa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AltaEmpresaForm";
            this.Text = "AltaEmpresaForm";
            this.PanelEmpresa.ResumeLayout(false);
            this.PanelEmpresa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelEmpresa;
        private System.Windows.Forms.Button AñadirDirButton;
        private System.Windows.Forms.TextBox CuitEmpresa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox telefonoEmpresa1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox MailEmpresa1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox RazonSocialEmpresa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button LimpiarButton;
    }
}