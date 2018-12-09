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
            this.PublicacionesListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.EditarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PublicacionesListView
            // 
            this.PublicacionesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PublicacionesListView.FullRowSelect = true;
            this.PublicacionesListView.GridLines = true;
            this.PublicacionesListView.Location = new System.Drawing.Point(12, 69);
            this.PublicacionesListView.MultiSelect = false;
            this.PublicacionesListView.Name = "PublicacionesListView";
            this.PublicacionesListView.Size = new System.Drawing.Size(586, 516);
            this.PublicacionesListView.TabIndex = 0;
            this.PublicacionesListView.UseCompatibleStateImageBehavior = false;
            this.PublicacionesListView.View = System.Windows.Forms.View.Details;
            this.PublicacionesListView.SelectedIndexChanged += new System.EventHandler(this.PublicacionesListView_SelectedIndexChanged);
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
            this.EditarButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.EditarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EditarButton.Location = new System.Drawing.Point(612, 69);
            this.EditarButton.Name = "EditarButton";
            this.EditarButton.Size = new System.Drawing.Size(75, 23);
            this.EditarButton.TabIndex = 2;
            this.EditarButton.Text = "Editar";
            this.EditarButton.UseVisualStyleBackColor = false;
            this.EditarButton.Click += new System.EventHandler(this.EditarButton_Click);
            // 
            // ListaPublicacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(717, 593);
            this.ControlBox = false;
            this.Controls.Add(this.EditarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PublicacionesListView);
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

        private System.Windows.Forms.ListView PublicacionesListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditarButton;
    }
}