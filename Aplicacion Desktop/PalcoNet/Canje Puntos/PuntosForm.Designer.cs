namespace PalcoNet.Canje_Puntos
{
    partial class PuntosForm
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
            this.PuntosPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PuntosTextLabel = new System.Windows.Forms.Label();
            this.PuntosLabel = new System.Windows.Forms.Label();
            this.VencimientoLabel = new System.Windows.Forms.Label();
            this.VencimientoTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PuntosPanel
            // 
            this.PuntosPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PuntosPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PuntosPanel.Location = new System.Drawing.Point(0, 145);
            this.PuntosPanel.Name = "PuntosPanel";
            this.PuntosPanel.Size = new System.Drawing.Size(701, 498);
            this.PuntosPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Canje de puntos";
            // 
            // PuntosTextLabel
            // 
            this.PuntosTextLabel.AutoSize = true;
            this.PuntosTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PuntosTextLabel.Location = new System.Drawing.Point(14, 68);
            this.PuntosTextLabel.Name = "PuntosTextLabel";
            this.PuntosTextLabel.Size = new System.Drawing.Size(118, 16);
            this.PuntosTextLabel.TabIndex = 2;
            this.PuntosTextLabel.Text = "Puntos actuales";
            // 
            // PuntosLabel
            // 
            this.PuntosLabel.AutoSize = true;
            this.PuntosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PuntosLabel.Location = new System.Drawing.Point(138, 70);
            this.PuntosLabel.Name = "PuntosLabel";
            this.PuntosLabel.Size = new System.Drawing.Size(13, 13);
            this.PuntosLabel.TabIndex = 3;
            this.PuntosLabel.Text = "0";
            // 
            // VencimientoLabel
            // 
            this.VencimientoLabel.AutoSize = true;
            this.VencimientoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.VencimientoLabel.Location = new System.Drawing.Point(113, 101);
            this.VencimientoLabel.Name = "VencimientoLabel";
            this.VencimientoLabel.Size = new System.Drawing.Size(13, 13);
            this.VencimientoLabel.TabIndex = 5;
            this.VencimientoLabel.Text = "0";
            // 
            // VencimientoTextLabel
            // 
            this.VencimientoTextLabel.AutoSize = true;
            this.VencimientoTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VencimientoTextLabel.Location = new System.Drawing.Point(14, 99);
            this.VencimientoTextLabel.Name = "VencimientoTextLabel";
            this.VencimientoTextLabel.Size = new System.Drawing.Size(93, 16);
            this.VencimientoTextLabel.TabIndex = 4;
            this.VencimientoTextLabel.Text = "Vencimiento";
            // 
            // PuntosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(701, 643);
            this.Controls.Add(this.VencimientoLabel);
            this.Controls.Add(this.VencimientoTextLabel);
            this.Controls.Add(this.PuntosLabel);
            this.Controls.Add(this.PuntosTextLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PuntosPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PuntosForm";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PuntosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PuntosPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PuntosTextLabel;
        private System.Windows.Forms.Label PuntosLabel;
        private System.Windows.Forms.Label VencimientoLabel;
        private System.Windows.Forms.Label VencimientoTextLabel;

    }
}