namespace PalcoNet.Abm_Empresa_Espectaculo
{
    partial class ListaEmpresas
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
            this.FiltrosTextBox = new System.Windows.Forms.TextBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.EmpresasListView = new System.Windows.Forms.ListView();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.DeshabilitarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar";
            // 
            // FiltrosTextBox
            // 
            this.FiltrosTextBox.Location = new System.Drawing.Point(77, 76);
            this.FiltrosTextBox.Name = "FiltrosTextBox";
            this.FiltrosTextBox.Size = new System.Drawing.Size(523, 20);
            this.FiltrosTextBox.TabIndex = 2;
            this.FiltrosTextBox.TextChanged += new System.EventHandler(this.FiltrosTextBox_TextChanged);
            // 
            // AgregarButton
            // 
            this.AgregarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AgregarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(114)))), ((int)(((byte)(155)))));
            this.AgregarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AgregarButton.Location = new System.Drawing.Point(622, 111);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(75, 23);
            this.AgregarButton.TabIndex = 3;
            this.AgregarButton.Text = "Agregar";
            this.AgregarButton.UseVisualStyleBackColor = false;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // EmpresasListView
            // 
            this.EmpresasListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.EmpresasListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.EmpresasListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmpresasListView.FullRowSelect = true;
            this.EmpresasListView.GridLines = true;
            this.EmpresasListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.EmpresasListView.HoverSelection = true;
            this.EmpresasListView.Location = new System.Drawing.Point(16, 111);
            this.EmpresasListView.MultiSelect = false;
            this.EmpresasListView.Name = "EmpresasListView";
            this.EmpresasListView.Size = new System.Drawing.Size(584, 487);
            this.EmpresasListView.TabIndex = 4;
            this.EmpresasListView.UseCompatibleStateImageBehavior = false;
            this.EmpresasListView.View = System.Windows.Forms.View.Details;
            this.EmpresasListView.SelectedIndexChanged += new System.EventHandler(this.EmpresasListView_SelectedIndexChanged);
            // 
            // ModificarButton
            // 
            this.ModificarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ModificarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(114)))), ((int)(((byte)(155)))));
            this.ModificarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ModificarButton.Location = new System.Drawing.Point(622, 151);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(75, 23);
            this.ModificarButton.TabIndex = 5;
            this.ModificarButton.Text = "Modificar";
            this.ModificarButton.UseVisualStyleBackColor = false;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // DeshabilitarButton
            // 
            this.DeshabilitarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeshabilitarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(114)))), ((int)(((byte)(155)))));
            this.DeshabilitarButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeshabilitarButton.Location = new System.Drawing.Point(622, 193);
            this.DeshabilitarButton.Name = "DeshabilitarButton";
            this.DeshabilitarButton.Size = new System.Drawing.Size(75, 23);
            this.DeshabilitarButton.TabIndex = 6;
            this.DeshabilitarButton.Text = "Deshabilitar";
            this.DeshabilitarButton.UseVisualStyleBackColor = false;
            this.DeshabilitarButton.Click += new System.EventHandler(this.DeshabilitarButton_Click);
            // 
            // ListaEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 670);
            this.Controls.Add(this.DeshabilitarButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.EmpresasListView);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.FiltrosTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FiltrosTextBox;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.ListView EmpresasListView;
        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.Button DeshabilitarButton;
    }
}