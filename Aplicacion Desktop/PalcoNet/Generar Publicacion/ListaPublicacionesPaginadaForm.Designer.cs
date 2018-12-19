namespace PalcoNet.Generar_Publicacion
{
    partial class ListaPublicacionesPaginadaForm
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
            this.FirstPageButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.PaginaTextBox = new System.Windows.Forms.TextBox();
            this.PublicacionesListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // FirstPageButton
            // 
            this.FirstPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstPageButton.FlatAppearance.BorderSize = 0;
            this.FirstPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FirstPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstPageButton.Location = new System.Drawing.Point(190, 532);
            this.FirstPageButton.Name = "FirstPageButton";
            this.FirstPageButton.Size = new System.Drawing.Size(40, 23);
            this.FirstPageButton.TabIndex = 15;
            this.FirstPageButton.Text = "<<";
            this.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FirstPageButton.UseVisualStyleBackColor = true;
            this.FirstPageButton.Click += new System.EventHandler(this.FirstPageButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastPageButton.FlatAppearance.BorderSize = 0;
            this.lastPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastPageButton.Location = new System.Drawing.Point(330, 532);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(38, 23);
            this.lastPageButton.TabIndex = 14;
            this.lastPageButton.Text = ">>";
            this.lastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(301, 532);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(23, 23);
            this.NextButton.TabIndex = 13;
            this.NextButton.Text = ">";
            this.NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // LastButton
            // 
            this.LastButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastButton.FlatAppearance.BorderSize = 0;
            this.LastButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastButton.Location = new System.Drawing.Point(236, 532);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(23, 23);
            this.LastButton.TabIndex = 12;
            this.LastButton.Text = "<";
            this.LastButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // PaginaTextBox
            // 
            this.PaginaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaginaTextBox.Location = new System.Drawing.Point(265, 534);
            this.PaginaTextBox.Name = "PaginaTextBox";
            this.PaginaTextBox.Size = new System.Drawing.Size(30, 20);
            this.PaginaTextBox.TabIndex = 11;
            this.PaginaTextBox.Text = "1";
            this.PaginaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PaginaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaginaTextBox_KeyPress);
            // 
            // PublicacionesListView
            // 
            this.PublicacionesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PublicacionesListView.FullRowSelect = true;
            this.PublicacionesListView.GridLines = true;
            this.PublicacionesListView.Location = new System.Drawing.Point(7, 1);
            this.PublicacionesListView.MultiSelect = false;
            this.PublicacionesListView.Name = "PublicacionesListView";
            this.PublicacionesListView.Size = new System.Drawing.Size(547, 515);
            this.PublicacionesListView.TabIndex = 10;
            this.PublicacionesListView.UseCompatibleStateImageBehavior = false;
            this.PublicacionesListView.View = System.Windows.Forms.View.Details;
            this.PublicacionesListView.SelectedIndexChanged += new System.EventHandler(this.PublicacionesListView_SelectedIndexChanged);
            // 
            // ListaPublicacionesPaginadaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(560, 560);
            this.Controls.Add(this.FirstPageButton);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LastButton);
            this.Controls.Add(this.PaginaTextBox);
            this.Controls.Add(this.PublicacionesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaPublicacionesPaginadaForm";
            this.Text = "ListaPublicacionesPaginadaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FirstPageButton;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.TextBox PaginaTextBox;
        private System.Windows.Forms.ListView PublicacionesListView;
    }
}