namespace PalcoNet.Abm_Rol
{
    partial class NuevRol
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
            this.nombreRol = new System.Windows.Forms.TextBox();
            this.funcionalidadesCheckboxList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del nuevo rol";
            // 
            // nombreRol
            // 
            this.nombreRol.Location = new System.Drawing.Point(26, 46);
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.Size = new System.Drawing.Size(310, 20);
            this.nombreRol.TabIndex = 1;
            this.nombreRol.TextChanged += new System.EventHandler(this.nombreRol_TextChanged);
            // 
            // funcionalidadesCheckboxList
            // 
            this.funcionalidadesCheckboxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionalidadesCheckboxList.CheckOnClick = true;
            this.funcionalidadesCheckboxList.FormattingEnabled = true;
            this.funcionalidadesCheckboxList.Location = new System.Drawing.Point(26, 103);
            this.funcionalidadesCheckboxList.Name = "funcionalidadesCheckboxList";
            this.funcionalidadesCheckboxList.Size = new System.Drawing.Size(333, 244);
            this.funcionalidadesCheckboxList.TabIndex = 2;
            this.funcionalidadesCheckboxList.SelectedIndexChanged += new System.EventHandler(this.funcionalidadesCheckboxList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarButton.BackColor = System.Drawing.Color.RosyBrown;
            this.CancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelarButton.Location = new System.Drawing.Point(204, 408);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 4;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = false;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarButton.BackColor = System.Drawing.Color.RosyBrown;
            this.AceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AceptarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AceptarButton.Location = new System.Drawing.Point(302, 408);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 5;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // NuevRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(389, 443);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.funcionalidadesCheckboxList);
            this.Controls.Add(this.nombreRol);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevRol";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "NuevRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreRol;
        private System.Windows.Forms.CheckedListBox funcionalidadesCheckboxList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button AceptarButton;

    }
}