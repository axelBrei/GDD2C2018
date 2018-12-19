namespace PalcoNet.Usuarios
{
    partial class UserDataForm
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
            this.RolesListView = new System.Windows.Forms.ListView();
            this.idRolHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NombreRolHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ContraseñaActualTextBox = new System.Windows.Forms.TextBox();
            this.NuevaContraseñaTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ModificarRolesButton = new System.Windows.Forms.Button();
            this.UsuarioLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RolesListView
            // 
            this.RolesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.RolesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RolesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RolesListView.CheckBoxes = true;
            this.RolesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idRolHeader,
            this.NombreRolHeader});
            this.RolesListView.FullRowSelect = true;
            this.RolesListView.GridLines = true;
            this.RolesListView.Location = new System.Drawing.Point(12, 234);
            this.RolesListView.MultiSelect = false;
            this.RolesListView.Name = "RolesListView";
            this.RolesListView.Size = new System.Drawing.Size(267, 179);
            this.RolesListView.TabIndex = 0;
            this.RolesListView.TabStop = false;
            this.RolesListView.UseCompatibleStateImageBehavior = false;
            this.RolesListView.View = System.Windows.Forms.View.Details;
            this.RolesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.RolesListView_ItemChecked);
            // 
            // idRolHeader
            // 
            this.idRolHeader.Text = "Id";
            // 
            // NombreRolHeader
            // 
            this.NombreRolHeader.Text = "Rol";
            this.NombreRolHeader.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contraseña actual";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.NuevaContraseñaTextBox);
            this.groupBox1.Controls.Add(this.ContraseñaActualTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 104);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cambiar contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nueva Contraseña";
            // 
            // ContraseñaActualTextBox
            // 
            this.ContraseñaActualTextBox.Location = new System.Drawing.Point(131, 21);
            this.ContraseñaActualTextBox.Name = "ContraseñaActualTextBox";
            this.ContraseñaActualTextBox.Size = new System.Drawing.Size(284, 20);
            this.ContraseñaActualTextBox.TabIndex = 3;
            this.ContraseñaActualTextBox.UseSystemPasswordChar = true;
            // 
            // NuevaContraseñaTextBox
            // 
            this.NuevaContraseñaTextBox.Location = new System.Drawing.Point(131, 63);
            this.NuevaContraseñaTextBox.Name = "NuevaContraseñaTextBox";
            this.NuevaContraseñaTextBox.Size = new System.Drawing.Size(284, 20);
            this.NuevaContraseñaTextBox.TabIndex = 4;
            this.NuevaContraseñaTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.IdLabel);
            this.groupBox2.Controls.Add(this.UsuarioLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 69);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Id";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(7, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(197, 25);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Datos del usuario";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(444, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cambiar Contraseña";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModificarRolesButton
            // 
            this.ModificarRolesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ModificarRolesButton.BackColor = System.Drawing.Color.LightGray;
            this.ModificarRolesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarRolesButton.Location = new System.Drawing.Point(285, 234);
            this.ModificarRolesButton.Name = "ModificarRolesButton";
            this.ModificarRolesButton.Size = new System.Drawing.Size(93, 50);
            this.ModificarRolesButton.TabIndex = 6;
            this.ModificarRolesButton.Text = "Modificar roles";
            this.ModificarRolesButton.UseVisualStyleBackColor = false;
            this.ModificarRolesButton.Click += new System.EventHandler(this.ModificarRolesButton_Click);
            // 
            // UsuarioLabel
            // 
            this.UsuarioLabel.AutoSize = true;
            this.UsuarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioLabel.Location = new System.Drawing.Point(87, 26);
            this.UsuarioLabel.Name = "UsuarioLabel";
            this.UsuarioLabel.Size = new System.Drawing.Size(0, 16);
            this.UsuarioLabel.TabIndex = 4;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.Location = new System.Drawing.Point(297, 26);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(0, 16);
            this.IdLabel.TabIndex = 5;
            // 
            // UserDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(625, 439);
            this.Controls.Add(this.ModificarRolesButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RolesListView);
            this.Name = "UserDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "UserDataForm";
            this.Load += new System.EventHandler(this.UserDataForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView RolesListView;
        private System.Windows.Forms.ColumnHeader idRolHeader;
        private System.Windows.Forms.ColumnHeader NombreRolHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NuevaContraseñaTextBox;
        private System.Windows.Forms.TextBox ContraseñaActualTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button ModificarRolesButton;
        private System.Windows.Forms.Label UsuarioLabel;
        private System.Windows.Forms.Label IdLabel;
    }
}