namespace PalcoNet.Usuarios
{
    partial class ListaUsuariosForm
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
            this.UsuariosListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.DeshabilitarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsuariosListView
            // 
            this.UsuariosListView.FullRowSelect = true;
            this.UsuariosListView.GridLines = true;
            this.UsuariosListView.Location = new System.Drawing.Point(19, 75);
            this.UsuariosListView.MultiSelect = false;
            this.UsuariosListView.Name = "UsuariosListView";
            this.UsuariosListView.Size = new System.Drawing.Size(576, 450);
            this.UsuariosListView.TabIndex = 0;
            this.UsuariosListView.UseCompatibleStateImageBehavior = false;
            this.UsuariosListView.View = System.Windows.Forms.View.Details;
            this.UsuariosListView.SelectedIndexChanged += new System.EventHandler(this.UsuariosListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuarios";
            // 
            // ModificarButton
            // 
            this.ModificarButton.BackColor = System.Drawing.Color.LightGray;
            this.ModificarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarButton.Location = new System.Drawing.Point(609, 75);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(88, 23);
            this.ModificarButton.TabIndex = 3;
            this.ModificarButton.Text = "Modificar";
            this.ModificarButton.UseVisualStyleBackColor = false;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // DeshabilitarButton
            // 
            this.DeshabilitarButton.BackColor = System.Drawing.Color.LightGray;
            this.DeshabilitarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeshabilitarButton.Location = new System.Drawing.Point(609, 115);
            this.DeshabilitarButton.Name = "DeshabilitarButton";
            this.DeshabilitarButton.Size = new System.Drawing.Size(88, 23);
            this.DeshabilitarButton.TabIndex = 4;
            this.DeshabilitarButton.Text = "Deshabilitar";
            this.DeshabilitarButton.UseVisualStyleBackColor = false;
            this.DeshabilitarButton.Click += new System.EventHandler(this.DeshabilitarButton_Click);
            // 
            // ListaUsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 612);
            this.Controls.Add(this.DeshabilitarButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsuariosListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaUsuariosForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ListaUsuariosForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView UsuariosListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.Button DeshabilitarButton;
    }
}