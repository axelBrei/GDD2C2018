namespace PalcoNet.MainMenu
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CerrarSesionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 591);
            this.panel1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(203, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 697);
            this.panel2.TabIndex = 2;
            // 
            // CerrarSesionButton
            // 
            this.CerrarSesionButton.BackColor = System.Drawing.Color.RosyBrown;
            this.CerrarSesionButton.FlatAppearance.BorderSize = 0;
            this.CerrarSesionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CerrarSesionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CerrarSesionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CerrarSesionButton.Location = new System.Drawing.Point(0, 665);
            this.CerrarSesionButton.Name = "CerrarSesionButton";
            this.CerrarSesionButton.Size = new System.Drawing.Size(200, 35);
            this.CerrarSesionButton.TabIndex = 3;
            this.CerrarSesionButton.Text = "Cerrar Sesion";
            this.CerrarSesionButton.UseVisualStyleBackColor = false;
            this.CerrarSesionButton.Click += new System.EventHandler(this.CerrarSesionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "PalcoNet";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 71);
            this.panel3.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.CerrarSesionButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.TopMost = true;
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CerrarSesionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;

    }
}