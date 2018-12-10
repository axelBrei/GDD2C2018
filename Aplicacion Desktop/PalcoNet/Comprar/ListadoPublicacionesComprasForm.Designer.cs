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
            this.SuspendLayout();
            // 
            // PublicacionesListView
            // 
            this.PublicacionesListView.FullRowSelect = true;
            this.PublicacionesListView.GridLines = true;
            this.PublicacionesListView.Location = new System.Drawing.Point(12, 41);
            this.PublicacionesListView.Name = "PublicacionesListView";
            this.PublicacionesListView.Size = new System.Drawing.Size(564, 543);
            this.PublicacionesListView.TabIndex = 0;
            this.PublicacionesListView.UseCompatibleStateImageBehavior = false;
            this.PublicacionesListView.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compras";
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
            this.DetallesButton.Size = new System.Drawing.Size(75, 23);
            this.DetallesButton.TabIndex = 3;
            this.DetallesButton.Text = "Detalles";
            this.DetallesButton.UseVisualStyleBackColor = false;
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
            // 
            // ListadoPublicacionesComprasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 670);
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
    }
}