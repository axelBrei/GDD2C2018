namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class GenerarComisionesForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CantidadARedimirNumericDD = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.FormaPagoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CantidadComboBox = new System.Windows.Forms.ComboBox();
            this.ListaComprasButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SeleccionarButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DetalleButton = new System.Windows.Forms.Button();
            this.ComprasListView = new System.Windows.Forms.ListView();
            this.Empresa = new System.Windows.Forms.GroupBox();
            this.RazonSocialTextBox = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadARedimirNumericDD)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.Empresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generar Comisiones";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CantidadARedimirNumericDD);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.FormaPagoComboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CantidadComboBox);
            this.groupBox2.Controls.Add(this.ListaComprasButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(24, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 87);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compras";
            // 
            // CantidadARedimirNumericDD
            // 
            this.CantidadARedimirNumericDD.Location = new System.Drawing.Point(445, 56);
            this.CantidadARedimirNumericDD.Name = "CantidadARedimirNumericDD";
            this.CantidadARedimirNumericDD.Size = new System.Drawing.Size(102, 20);
            this.CantidadARedimirNumericDD.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cantidad a redimir";
            // 
            // FormaPagoComboBox
            // 
            this.FormaPagoComboBox.FormattingEnabled = true;
            this.FormaPagoComboBox.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia",
            "Tarjeta de crédito"});
            this.FormaPagoComboBox.Location = new System.Drawing.Point(432, 19);
            this.FormaPagoComboBox.Name = "FormaPagoComboBox";
            this.FormaPagoComboBox.Size = new System.Drawing.Size(115, 21);
            this.FormaPagoComboBox.TabIndex = 10;
            this.FormaPagoComboBox.SelectedIndexChanged += new System.EventHandler(this.FormaPagoComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Forma de pago";
            // 
            // CantidadComboBox
            // 
            this.CantidadComboBox.FormattingEnabled = true;
            this.CantidadComboBox.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "200",
            "500"});
            this.CantidadComboBox.Location = new System.Drawing.Point(63, 20);
            this.CantidadComboBox.Name = "CantidadComboBox";
            this.CantidadComboBox.Size = new System.Drawing.Size(78, 21);
            this.CantidadComboBox.TabIndex = 8;
            this.CantidadComboBox.SelectedIndexChanged += new System.EventHandler(this.CantidadComboBox_SelectedIndexChanged);
            this.CantidadComboBox.TextUpdate += new System.EventHandler(this.updateCantidadText);
            // 
            // ListaComprasButton
            // 
            this.ListaComprasButton.BackColor = System.Drawing.Color.LightGray;
            this.ListaComprasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaComprasButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ListaComprasButton.Location = new System.Drawing.Point(10, 58);
            this.ListaComprasButton.Name = "ListaComprasButton";
            this.ListaComprasButton.Size = new System.Drawing.Size(131, 23);
            this.ListaComprasButton.TabIndex = 7;
            this.ListaComprasButton.Text = "Listar Compras";
            this.ListaComprasButton.UseVisualStyleBackColor = false;
            this.ListaComprasButton.Click += new System.EventHandler(this.ListaComprasButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cantidad";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(568, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 47);
            this.button2.TabIndex = 0;
            this.button2.Text = "Rendir Comisiones";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SeleccionarButton
            // 
            this.SeleccionarButton.BackColor = System.Drawing.Color.LightGray;
            this.SeleccionarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeleccionarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SeleccionarButton.Location = new System.Drawing.Point(6, 18);
            this.SeleccionarButton.Name = "SeleccionarButton";
            this.SeleccionarButton.Size = new System.Drawing.Size(136, 20);
            this.SeleccionarButton.TabIndex = 7;
            this.SeleccionarButton.Text = "Seleccionar empresa";
            this.SeleccionarButton.UseVisualStyleBackColor = false;
            this.SeleccionarButton.Click += new System.EventHandler(this.SeleccionarButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DetalleButton);
            this.groupBox3.Controls.Add(this.ComprasListView);
            this.groupBox3.Location = new System.Drawing.Point(24, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(653, 416);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compras";
            // 
            // DetalleButton
            // 
            this.DetalleButton.BackColor = System.Drawing.Color.LightGray;
            this.DetalleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetalleButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DetalleButton.Location = new System.Drawing.Point(11, 19);
            this.DetalleButton.Name = "DetalleButton";
            this.DetalleButton.Size = new System.Drawing.Size(133, 23);
            this.DetalleButton.TabIndex = 1;
            this.DetalleButton.Text = "Detalle compra";
            this.DetalleButton.UseVisualStyleBackColor = false;
            this.DetalleButton.Click += new System.EventHandler(this.DetalleButton_Click);
            // 
            // ComprasListView
            // 
            this.ComprasListView.FullRowSelect = true;
            this.ComprasListView.GridLines = true;
            this.ComprasListView.Location = new System.Drawing.Point(6, 64);
            this.ComprasListView.MultiSelect = false;
            this.ComprasListView.Name = "ComprasListView";
            this.ComprasListView.Size = new System.Drawing.Size(641, 346);
            this.ComprasListView.TabIndex = 0;
            this.ComprasListView.UseCompatibleStateImageBehavior = false;
            this.ComprasListView.View = System.Windows.Forms.View.Details;
            this.ComprasListView.SelectedIndexChanged += new System.EventHandler(this.ComprasListView_SelectedIndexChanged);
            // 
            // Empresa
            // 
            this.Empresa.Controls.Add(this.RazonSocialTextBox);
            this.Empresa.Controls.Add(this.label11);
            this.Empresa.Controls.Add(this.SeleccionarButton);
            this.Empresa.Location = new System.Drawing.Point(24, 60);
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(653, 56);
            this.Empresa.TabIndex = 9;
            this.Empresa.TabStop = false;
            this.Empresa.Text = "Seleccion de empresa";
            // 
            // RazonSocialTextBox
            // 
            this.RazonSocialTextBox.AutoSize = true;
            this.RazonSocialTextBox.Location = new System.Drawing.Point(270, 22);
            this.RazonSocialTextBox.Name = "RazonSocialTextBox";
            this.RazonSocialTextBox.Size = new System.Drawing.Size(10, 13);
            this.RazonSocialTextBox.TabIndex = 9;
            this.RazonSocialTextBox.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(194, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Razon Social";
            // 
            // GenerarComisionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(701, 643);
            this.Controls.Add(this.Empresa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenerarComisionesForm";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadARedimirNumericDD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.Empresa.ResumeLayout(false);
            this.Empresa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ListaComprasButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SeleccionarButton;
        private System.Windows.Forms.NumericUpDown CantidadARedimirNumericDD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox FormaPagoComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CantidadComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DetalleButton;
        private System.Windows.Forms.ListView ComprasListView;
        private System.Windows.Forms.GroupBox Empresa;
        private System.Windows.Forms.Label RazonSocialTextBox;
        private System.Windows.Forms.Label label11;
    }
}