namespace PalcoNet.Historial_Cliente
{
    partial class HistorialCliente
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
            this.HistorialListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.PaginaTextBox = new System.Windows.Forms.TextBox();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.LastPageButton = new System.Windows.Forms.Button();
            this.BackPageButton = new System.Windows.Forms.Button();
            this.FirstPageButton = new System.Windows.Forms.Button();
            this.DetallesButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HistorialListView
            // 
            this.HistorialListView.FullRowSelect = true;
            this.HistorialListView.GridLines = true;
            this.HistorialListView.Location = new System.Drawing.Point(28, 59);
            this.HistorialListView.Name = "HistorialListView";
            this.HistorialListView.Size = new System.Drawing.Size(657, 423);
            this.HistorialListView.TabIndex = 0;
            this.HistorialListView.UseCompatibleStateImageBehavior = false;
            this.HistorialListView.View = System.Windows.Forms.View.Details;
            this.HistorialListView.SelectedIndexChanged += new System.EventHandler(this.HistorialListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historial";
            // 
            // PaginaTextBox
            // 
            this.PaginaTextBox.Location = new System.Drawing.Point(579, 491);
            this.PaginaTextBox.Name = "PaginaTextBox";
            this.PaginaTextBox.Size = new System.Drawing.Size(23, 20);
            this.PaginaTextBox.TabIndex = 2;
            this.PaginaTextBox.Text = "1";
            this.PaginaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PaginaTextBox.TextChanged += new System.EventHandler(this.PaginaTextBox_TextChanged);
            this.PaginaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaginaTextBox_KeyPress);
            // 
            // NextPageButton
            // 
            this.NextPageButton.FlatAppearance.BorderSize = 0;
            this.NextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPageButton.Location = new System.Drawing.Point(605, 489);
            this.NextPageButton.Margin = new System.Windows.Forms.Padding(0);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(25, 23);
            this.NextPageButton.TabIndex = 3;
            this.NextPageButton.Text = ">";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // LastPageButton
            // 
            this.LastPageButton.FlatAppearance.BorderSize = 0;
            this.LastPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastPageButton.Location = new System.Drawing.Point(630, 489);
            this.LastPageButton.Margin = new System.Windows.Forms.Padding(0);
            this.LastPageButton.Name = "LastPageButton";
            this.LastPageButton.Size = new System.Drawing.Size(33, 23);
            this.LastPageButton.TabIndex = 4;
            this.LastPageButton.Text = ">>";
            this.LastPageButton.UseVisualStyleBackColor = true;
            this.LastPageButton.Click += new System.EventHandler(this.LastPageButton_Click);
            // 
            // BackPageButton
            // 
            this.BackPageButton.FlatAppearance.BorderSize = 0;
            this.BackPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackPageButton.Location = new System.Drawing.Point(548, 489);
            this.BackPageButton.Margin = new System.Windows.Forms.Padding(0);
            this.BackPageButton.Name = "BackPageButton";
            this.BackPageButton.Size = new System.Drawing.Size(28, 23);
            this.BackPageButton.TabIndex = 6;
            this.BackPageButton.Text = "<";
            this.BackPageButton.UseVisualStyleBackColor = true;
            this.BackPageButton.Click += new System.EventHandler(this.BackPageButton_Click);
            // 
            // FirstPageButton
            // 
            this.FirstPageButton.FlatAppearance.BorderSize = 0;
            this.FirstPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FirstPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstPageButton.Location = new System.Drawing.Point(517, 489);
            this.FirstPageButton.Margin = new System.Windows.Forms.Padding(0);
            this.FirstPageButton.Name = "FirstPageButton";
            this.FirstPageButton.Size = new System.Drawing.Size(31, 23);
            this.FirstPageButton.TabIndex = 5;
            this.FirstPageButton.Text = "<<";
            this.FirstPageButton.UseVisualStyleBackColor = true;
            this.FirstPageButton.Click += new System.EventHandler(this.FirstPageButton_Click);
            // 
            // DetallesButton
            // 
            this.DetallesButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.DetallesButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DetallesButton.Location = new System.Drawing.Point(28, 489);
            this.DetallesButton.Name = "DetallesButton";
            this.DetallesButton.Size = new System.Drawing.Size(75, 23);
            this.DetallesButton.TabIndex = 7;
            this.DetallesButton.Text = "Detalles";
            this.DetallesButton.UseVisualStyleBackColor = false;
            this.DetallesButton.Click += new System.EventHandler(this.DetallesButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(109, 489);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 9;
            this.BackButton.Text = "Volver";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // HistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 566);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.DetallesButton);
            this.Controls.Add(this.BackPageButton);
            this.Controls.Add(this.FirstPageButton);
            this.Controls.Add(this.LastPageButton);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.PaginaTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HistorialListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistorialCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView HistorialListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PaginaTextBox;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Button LastPageButton;
        private System.Windows.Forms.Button BackPageButton;
        private System.Windows.Forms.Button FirstPageButton;
        private System.Windows.Forms.Button DetallesButton;
        private System.Windows.Forms.Button BackButton;
    }
}