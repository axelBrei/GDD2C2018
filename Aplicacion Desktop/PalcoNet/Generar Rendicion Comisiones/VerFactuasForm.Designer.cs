namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class VerFactuasForm
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
            this.FacturaListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.DetallesButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.FirstPageButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.PaginaTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FacturaListView
            // 
            this.FacturaListView.FullRowSelect = true;
            this.FacturaListView.GridLines = true;
            this.FacturaListView.Location = new System.Drawing.Point(12, 37);
            this.FacturaListView.MultiSelect = false;
            this.FacturaListView.Name = "FacturaListView";
            this.FacturaListView.Size = new System.Drawing.Size(513, 414);
            this.FacturaListView.TabIndex = 0;
            this.FacturaListView.UseCompatibleStateImageBehavior = false;
            this.FacturaListView.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturas";
            // 
            // DetallesButton
            // 
            this.DetallesButton.BackColor = System.Drawing.Color.LightGray;
            this.DetallesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetallesButton.Location = new System.Drawing.Point(12, 457);
            this.DetallesButton.Name = "DetallesButton";
            this.DetallesButton.Size = new System.Drawing.Size(75, 23);
            this.DetallesButton.TabIndex = 2;
            this.DetallesButton.Text = "Detalle";
            this.DetallesButton.UseVisualStyleBackColor = false;
            // 
            // SalirButton
            // 
            this.SalirButton.BackColor = System.Drawing.Color.LightGray;
            this.SalirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalirButton.Location = new System.Drawing.Point(459, 499);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(75, 23);
            this.SalirButton.TabIndex = 3;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = false;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // FirstPageButton
            // 
            this.FirstPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstPageButton.FlatAppearance.BorderSize = 0;
            this.FirstPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FirstPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstPageButton.Location = new System.Drawing.Point(184, 458);
            this.FirstPageButton.Name = "FirstPageButton";
            this.FirstPageButton.Size = new System.Drawing.Size(40, 23);
            this.FirstPageButton.TabIndex = 20;
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
            this.lastPageButton.Location = new System.Drawing.Point(324, 458);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(38, 23);
            this.lastPageButton.TabIndex = 19;
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
            this.NextButton.Location = new System.Drawing.Point(295, 458);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(23, 23);
            this.NextButton.TabIndex = 18;
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
            this.LastButton.Location = new System.Drawing.Point(230, 458);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(23, 23);
            this.LastButton.TabIndex = 17;
            this.LastButton.Text = "<";
            this.LastButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // PaginaTextBox
            // 
            this.PaginaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaginaTextBox.Location = new System.Drawing.Point(259, 460);
            this.PaginaTextBox.Name = "PaginaTextBox";
            this.PaginaTextBox.Size = new System.Drawing.Size(30, 20);
            this.PaginaTextBox.TabIndex = 16;
            this.PaginaTextBox.TabStop = false;
            this.PaginaTextBox.Text = "1";
            this.PaginaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PaginaTextBox.TextChanged += new System.EventHandler(this.PaginaTextBox_TextChanged);
            this.PaginaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaginaTextBox_KeyPress);
            // 
            // VerFactuasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(546, 534);
            this.Controls.Add(this.FirstPageButton);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LastButton);
            this.Controls.Add(this.PaginaTextBox);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.DetallesButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FacturaListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerFactuasForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView FacturaListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DetallesButton;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.Button FirstPageButton;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.TextBox PaginaTextBox;
    }
}