namespace PalcoNet.Canje_Puntos
{
    partial class PremiosListForm
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
            this.PremiosListView = new System.Windows.Forms.ListView();
            this.CanjearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PremiosListView
            // 
            this.PremiosListView.FullRowSelect = true;
            this.PremiosListView.GridLines = true;
            this.PremiosListView.Location = new System.Drawing.Point(12, 34);
            this.PremiosListView.MultiSelect = false;
            this.PremiosListView.Name = "PremiosListView";
            this.PremiosListView.Size = new System.Drawing.Size(550, 291);
            this.PremiosListView.TabIndex = 0;
            this.PremiosListView.UseCompatibleStateImageBehavior = false;
            this.PremiosListView.View = System.Windows.Forms.View.Details;
            this.PremiosListView.SelectedIndexChanged += new System.EventHandler(this.PremiosListView_SelectedIndexChanged);
            // 
            // CanjearButton
            // 
            this.CanjearButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.CanjearButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CanjearButton.Location = new System.Drawing.Point(568, 34);
            this.CanjearButton.Name = "CanjearButton";
            this.CanjearButton.Size = new System.Drawing.Size(113, 23);
            this.CanjearButton.TabIndex = 2;
            this.CanjearButton.Text = "Canjear";
            this.CanjearButton.UseVisualStyleBackColor = false;
            this.CanjearButton.Click += new System.EventHandler(this.CanjearButton_Click);
            // 
            // PremiosListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(693, 353);
            this.ControlBox = false;
            this.Controls.Add(this.CanjearButton);
            this.Controls.Add(this.PremiosListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PremiosListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PremiosListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PremiosListView;
        public System.Windows.Forms.Button CanjearButton;
    }
}