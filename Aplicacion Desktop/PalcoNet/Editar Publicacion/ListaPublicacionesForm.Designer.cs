namespace PalcoNet.Editar_Publicacion
{
    partial class ListaPublicacionesForm
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
            this.EditarButton = new System.Windows.Forms.Button();
            this.PublicacionesPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Editar publicaciones";
            // 
            // EditarButton
            // 
            this.EditarButton.BackColor = System.Drawing.Color.LightGray;
            this.EditarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EditarButton.Location = new System.Drawing.Point(612, 69);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(75, 23);
            this.EditarButton.TabIndex = 2;
            this.EditarButton.Text = "Editar";
            this.EditarButton.UseVisualStyleBackColor = false;
            this.EditarButton.Click += new System.EventHandler(this.EditarButton_Click);
            // 
            // PublicacionesPanel
            // 
            this.PublicacionesPanel.Location = new System.Drawing.Point(17, 49);
            this.PublicacionesPanel.Name = "PublicacionesPanel";
            this.PublicacionesPanel.Size = new System.Drawing.Size(589, 578);
            this.PublicacionesPanel.TabIndex = 3;
            // 
            // ListaPublicacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(717, 639);
            this.ControlBox = false;
            this.Controls.Add(this.PublicacionesPanel);
            this.Controls.Add(this.EditarButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaPublicacionesForm";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditarButton;
        private System.Windows.Forms.Panel PublicacionesPanel;
    }
}