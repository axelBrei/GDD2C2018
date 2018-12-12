namespace PalcoNet.Comprar
{
    partial class ListadoPublicacionesComprasForm
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
            this.FiltrosButton = new System.Windows.Forms.Button();
            this.DetallesButton = new System.Windows.Forms.Button();
            this.LimpiarFiltrosButton = new System.Windows.Forms.Button();
            this.PaginaTextBox = new System.Windows.Forms.TextBox();
            this.LastButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PublicacionesListView
            // 
            this.PublicacionesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.PublicacionesListView.FullRowSelect = true;
            this.PublicacionesListView.GridLines = true;
            this.PublicacionesListView.Location = new System.Drawing.Point(12, 41);
            this.PublicacionesListView.MultiSelect = false;
            this.PublicacionesListView.Name = "PublicacionesListView";
            this.PublicacionesListView.Size = new System.Drawing.Size(564, 543);
            this.PublicacionesListView.TabIndex = 0;
            this.PublicacionesListView.UseCompatibleStateImageBehavior = false;
            this.PublicacionesListView.View = System.Windows.Forms.View.Details;
            this.PublicacionesListView.SelectedIndexChanged += new System.EventHandler(this.PublicacionesListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comprar";
            // 
            // FiltrosButton
            // 
            this.FiltrosButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.FiltrosButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FiltrosButton.Location = new System.Drawing.Point(604, 62);
            this.FiltrosButton.Name = "FiltrosButton";
            this.FiltrosButton.Size = new System.Drawing.Size(75, 23);
            this.FiltrosButton.TabIndex = 2;
            this.FiltrosButton.Text = "Filtros";
            this.FiltrosButton.UseVisualStyleBackColor = false;
            this.FiltrosButton.Click += new System.EventHandler(this.FiltrosButton_Click);
            // 
            // DetallesButton
            // 
            this.DetallesButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.DetallesButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DetallesButton.Location = new System.Drawing.Point(604, 128);
            this.DetallesButton.Name = "DetallesButton";
            this.DetallesButton.Size = new System.Drawing.Size(75, 41);
            this.DetallesButton.TabIndex = 3;
            this.DetallesButton.Text = "Seleccionar Publicacion";
            this.DetallesButton.UseVisualStyleBackColor = false;
            this.DetallesButton.Click += new System.EventHandler(this.DetallesButton_Click);
            // 
            // LimpiarFiltrosButton
            // 
            this.LimpiarFiltrosButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.LimpiarFiltrosButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LimpiarFiltrosButton.Location = new System.Drawing.Point(604, 95);
            this.LimpiarFiltrosButton.Margin = new System.Windows.Forms.Padding(7);
            this.LimpiarFiltrosButton.Name = "LimpiarFiltrosButton";
            this.LimpiarFiltrosButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarFiltrosButton.TabIndex = 4;
            this.LimpiarFiltrosButton.Text = "LimpiarFiltros";
            this.LimpiarFiltrosButton.UseVisualStyleBackColor = false;
            this.LimpiarFiltrosButton.Click += new System.EventHandler(this.LimpiarFiltrosButton_Click);
            // 
            // PaginaTextBox
            // 
            this.PaginaTextBox.Location = new System.Drawing.Point(279, 617);
            this.PaginaTextBox.Name = "PaginaTextBox";
            this.PaginaTextBox.Size = new System.Drawing.Size(30, 20);
            this.PaginaTextBox.TabIndex = 5;
            this.PaginaTextBox.Text = "1";
            this.PaginaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PaginaTextBox.TextChanged += new System.EventHandler(this.PaginaTextBox_TextChanged);
            this.PaginaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaginaTextBox_KeyPress);
            // 
            // LastButton
            // 
            this.LastButton.FlatAppearance.BorderSize = 0;
            this.LastButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastButton.Location = new System.Drawing.Point(250, 615);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(23, 23);
            this.LastButton.TabIndex = 6;
            this.LastButton.Text = "<";
            this.LastButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(315, 615);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(23, 23);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = ">";
            this.NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(344, 615);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = ">>";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(204, 615);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "<<";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListadoPublicacionesComprasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 670);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LastButton);
            this.Controls.Add(this.PaginaTextBox);
            this.Controls.Add(this.LimpiarFiltrosButton);
            this.Controls.Add(this.DetallesButton);
            this.Controls.Add(this.FiltrosButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PublicacionesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListadoPublicacionesComprasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView PublicacionesListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FiltrosButton;
        private System.Windows.Forms.Button DetallesButton;
        private System.Windows.Forms.Button LimpiarFiltrosButton;
        private System.Windows.Forms.TextBox PaginaTextBox;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}