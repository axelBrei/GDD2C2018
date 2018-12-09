namespace PalcoNet.Editar_Publicacion
{
    partial class EditarPublicacionForm
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
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.PublicacionesMenuButton = new System.Windows.Forms.Button();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.MenuPanel.Controls.Add(this.button2);
            this.MenuPanel.Controls.Add(this.PublicacionesMenuButton);
            this.MenuPanel.Location = new System.Drawing.Point(1, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(200, 700);
            this.MenuPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(3, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Ubicaciones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PublicacionesMenuButton
            // 
            this.PublicacionesMenuButton.FlatAppearance.BorderSize = 0;
            this.PublicacionesMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PublicacionesMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublicacionesMenuButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PublicacionesMenuButton.Location = new System.Drawing.Point(3, 58);
            this.PublicacionesMenuButton.Name = "PublicacionesMenuButton";
            this.PublicacionesMenuButton.Size = new System.Drawing.Size(194, 45);
            this.PublicacionesMenuButton.TabIndex = 0;
            this.PublicacionesMenuButton.Text = "Publicacion";
            this.PublicacionesMenuButton.UseVisualStyleBackColor = true;
            this.PublicacionesMenuButton.Click += new System.EventHandler(this.PublicacionesMenuButton_Click);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ContentPanel.Location = new System.Drawing.Point(204, 0);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(717, 700);
            this.ContentPanel.TabIndex = 1;
            // 
            // EditarPublicacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.MenuPanel);
            this.Name = "EditarPublicacionForm";
            this.Text = "EditarPublicacionForm";
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Button PublicacionesMenuButton;
        private System.Windows.Forms.Button button2;
    }
}