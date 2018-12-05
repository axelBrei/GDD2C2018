namespace PalcoNet.Abm_Cliente
{
    partial class ListadoClientesForm
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
            this.FiltroClientesTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.agregarClienteButton = new System.Windows.Forms.Button();
            this.ModificarClienteButton = new System.Windows.Forms.Button();
            this.DeshabilitarClienteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaCliente = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // FiltroClientesTextBox
            // 
            this.FiltroClientesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltroClientesTextBox.Location = new System.Drawing.Point(77, 80);
            this.FiltroClientesTextBox.Name = "FiltroClientesTextBox";
            this.FiltroClientesTextBox.Size = new System.Drawing.Size(527, 20);
            this.FiltroClientesTextBox.TabIndex = 1;
            this.FiltroClientesTextBox.TextChanged += new System.EventHandler(this.FiltroClientesTextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(622, 635);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // agregarClienteButton
            // 
            this.agregarClienteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.agregarClienteButton.Location = new System.Drawing.Point(622, 113);
            this.agregarClienteButton.Name = "agregarClienteButton";
            this.agregarClienteButton.Size = new System.Drawing.Size(75, 23);
            this.agregarClienteButton.TabIndex = 3;
            this.agregarClienteButton.Text = "Agregar";
            this.agregarClienteButton.UseVisualStyleBackColor = true;
            this.agregarClienteButton.Click += new System.EventHandler(this.agregarClienteButton_Click);
            // 
            // ModificarClienteButton
            // 
            this.ModificarClienteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ModificarClienteButton.Location = new System.Drawing.Point(622, 151);
            this.ModificarClienteButton.Name = "ModificarClienteButton";
            this.ModificarClienteButton.Size = new System.Drawing.Size(75, 23);
            this.ModificarClienteButton.TabIndex = 4;
            this.ModificarClienteButton.Text = "Modificar";
            this.ModificarClienteButton.UseVisualStyleBackColor = true;
            this.ModificarClienteButton.Click += new System.EventHandler(this.ModificarClienteButton_Click);
            // 
            // DeshabilitarClienteButton
            // 
            this.DeshabilitarClienteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeshabilitarClienteButton.Location = new System.Drawing.Point(622, 191);
            this.DeshabilitarClienteButton.Name = "DeshabilitarClienteButton";
            this.DeshabilitarClienteButton.Size = new System.Drawing.Size(75, 23);
            this.DeshabilitarClienteButton.TabIndex = 5;
            this.DeshabilitarClienteButton.Text = "Deshabilitar";
            this.DeshabilitarClienteButton.UseVisualStyleBackColor = true;
            this.DeshabilitarClienteButton.Click += new System.EventHandler(this.DeshabilitarClienteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar";
            // 
            // ListaCliente
            // 
            this.ListaCliente.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListaCliente.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.ListaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaCliente.AutoArrange = false;
            this.ListaCliente.FullRowSelect = true;
            this.ListaCliente.GridLines = true;
            this.ListaCliente.Location = new System.Drawing.Point(16, 113);
            this.ListaCliente.Name = "ListaCliente";
            this.ListaCliente.Size = new System.Drawing.Size(588, 498);
            this.ListaCliente.TabIndex = 7;
            this.ListaCliente.UseCompatibleStateImageBehavior = false;
            this.ListaCliente.View = System.Windows.Forms.View.Details;
            this.ListaCliente.SelectedIndexChanged += new System.EventHandler(this.ListaCliente_SelectedIndexChanged);
            // 
            // ListadoClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 670);
            this.Controls.Add(this.ListaCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeshabilitarClienteButton);
            this.Controls.Add(this.ModificarClienteButton);
            this.Controls.Add(this.agregarClienteButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FiltroClientesTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListadoClientesForm";
            this.Text = "Listado de clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FiltroClientesTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button agregarClienteButton;
        private System.Windows.Forms.Button ModificarClienteButton;
        private System.Windows.Forms.Button DeshabilitarClienteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ListaCliente;
    }
}