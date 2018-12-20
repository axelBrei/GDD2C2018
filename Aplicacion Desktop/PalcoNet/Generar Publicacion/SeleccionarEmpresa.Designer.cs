namespace PalcoNet.Generar_Publicacion
{
    partial class SeleccionarEmpresa
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
            this.EmpresasListView = new System.Windows.Forms.ListView();
            this.BuscadoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmpresasListView
            // 
            this.EmpresasListView.FullRowSelect = true;
            this.EmpresasListView.GridLines = true;
            this.EmpresasListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.EmpresasListView.Location = new System.Drawing.Point(12, 86);
            this.EmpresasListView.MultiSelect = false;
            this.EmpresasListView.Name = "EmpresasListView";
            this.EmpresasListView.Size = new System.Drawing.Size(502, 346);
            this.EmpresasListView.TabIndex = 0;
            this.EmpresasListView.UseCompatibleStateImageBehavior = false;
            this.EmpresasListView.View = System.Windows.Forms.View.Details;
            this.EmpresasListView.SelectedIndexChanged += new System.EventHandler(this.EmpresasListView_SelectedIndexChanged);
            // 
            // BuscadoTextBox
            // 
            this.BuscadoTextBox.Location = new System.Drawing.Point(135, 60);
            this.BuscadoTextBox.Name = "BuscadoTextBox";
            this.BuscadoTextBox.Size = new System.Drawing.Size(346, 20);
            this.BuscadoTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar empresa publicante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Buscar por razon social";
            // 
            // AceptarButton
            // 
            this.AceptarButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.AceptarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AceptarButton.Location = new System.Drawing.Point(439, 455);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 4;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = false;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.CancelarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelarButton.Location = new System.Drawing.Point(358, 455);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 5;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = false;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // SeleccionarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(526, 490);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuscadoTextBox);
            this.Controls.Add(this.EmpresasListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionarEmpresa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView EmpresasListView;
        private System.Windows.Forms.TextBox BuscadoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
    }
}