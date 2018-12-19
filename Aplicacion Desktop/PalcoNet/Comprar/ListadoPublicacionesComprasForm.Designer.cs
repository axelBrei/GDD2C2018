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
            this.label1 = new System.Windows.Forms.Label();
            this.FiltrosButton = new System.Windows.Forms.Button();
            this.DetallesButton = new System.Windows.Forms.Button();
            this.LimpiarFiltrosButton = new System.Windows.Forms.Button();
            this.ListaPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
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
            this.FiltrosButton.BackColor = System.Drawing.Color.LightGray;
            this.FiltrosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltrosButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FiltrosButton.Location = new System.Drawing.Point(608, 46);
            this.FiltrosButton.Name = "FiltrosButton";
            this.FiltrosButton.Size = new System.Drawing.Size(89, 23);
            this.FiltrosButton.TabIndex = 2;
            this.FiltrosButton.Text = "Filtros";
            this.FiltrosButton.UseVisualStyleBackColor = false;
            this.FiltrosButton.Click += new System.EventHandler(this.FiltrosButton_Click);
            // 
            // DetallesButton
            // 
            this.DetallesButton.BackColor = System.Drawing.Color.LightGray;
            this.DetallesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetallesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DetallesButton.Location = new System.Drawing.Point(608, 112);
            this.DetallesButton.Name = "DetallesButton";
            this.DetallesButton.Size = new System.Drawing.Size(89, 41);
            this.DetallesButton.TabIndex = 3;
            this.DetallesButton.Text = "Seleccionar Publicacion";
            this.DetallesButton.UseVisualStyleBackColor = false;
            this.DetallesButton.Click += new System.EventHandler(this.DetallesButton_Click);
            // 
            // LimpiarFiltrosButton
            // 
            this.LimpiarFiltrosButton.BackColor = System.Drawing.Color.LightGray;
            this.LimpiarFiltrosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarFiltrosButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LimpiarFiltrosButton.Location = new System.Drawing.Point(608, 79);
            this.LimpiarFiltrosButton.Margin = new System.Windows.Forms.Padding(7);
            this.LimpiarFiltrosButton.Name = "LimpiarFiltrosButton";
            this.LimpiarFiltrosButton.Size = new System.Drawing.Size(89, 23);
            this.LimpiarFiltrosButton.TabIndex = 4;
            this.LimpiarFiltrosButton.Text = "LimpiarFiltros";
            this.LimpiarFiltrosButton.UseVisualStyleBackColor = false;
            this.LimpiarFiltrosButton.Click += new System.EventHandler(this.LimpiarFiltrosButton_Click);
            // 
            // ListaPanel
            // 
            this.ListaPanel.Location = new System.Drawing.Point(12, 46);
            this.ListaPanel.Name = "ListaPanel";
            this.ListaPanel.Size = new System.Drawing.Size(586, 612);
            this.ListaPanel.TabIndex = 5;
            // 
            // ListadoPublicacionesComprasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 670);
            this.Controls.Add(this.ListaPanel);
            this.Controls.Add(this.LimpiarFiltrosButton);
            this.Controls.Add(this.DetallesButton);
            this.Controls.Add(this.FiltrosButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListadoPublicacionesComprasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FiltrosButton;
        private System.Windows.Forms.Button DetallesButton;
        private System.Windows.Forms.Button LimpiarFiltrosButton;
        private System.Windows.Forms.Panel ListaPanel;
    }
}