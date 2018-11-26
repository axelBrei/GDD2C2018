namespace PalcoNet
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InputUser = new System.Windows.Forms.TextBox();
            this.inputPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(112, 142);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Ingresar";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // InputUser
            // 
            this.InputUser.Location = new System.Drawing.Point(79, 59);
            this.InputUser.Name = "InputUser";
            this.InputUser.Size = new System.Drawing.Size(201, 20);
            this.InputUser.TabIndex = 3;
            this.InputUser.TextChanged += new System.EventHandler(this.InputUser_TextChanged);
            // 
            // inputPass
            // 
            this.inputPass.Location = new System.Drawing.Point(79, 93);
            this.inputPass.Name = "inputPass";
            this.inputPass.Size = new System.Drawing.Size(201, 20);
            this.inputPass.TabIndex = 4;
            this.inputPass.UseSystemPasswordChar = true;
            this.inputPass.TextChanged += new System.EventHandler(this.inputPass_TextChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.inputPass);
            this.Controls.Add(this.InputUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputUser;
        private System.Windows.Forms.TextBox inputPass;

    }
}

