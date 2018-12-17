namespace PalcoNet.Listado_Estadistico
{
    partial class ListadoForm
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
            this.toplistView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AñoComboBox = new System.Windows.Forms.ComboBox();
            this.TrimestreComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EstadisticaComboBox = new System.Windows.Forms.ComboBox();
            this.gradoLabel = new System.Windows.Forms.Label();
            this.gradoComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toplistView
            // 
            this.toplistView.FullRowSelect = true;
            this.toplistView.GridLines = true;
            this.toplistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.toplistView.HideSelection = false;
            this.toplistView.Location = new System.Drawing.Point(12, 244);
            this.toplistView.Name = "toplistView";
            this.toplistView.Size = new System.Drawing.Size(653, 165);
            this.toplistView.TabIndex = 0;
            this.toplistView.UseCompatibleStateImageBehavior = false;
            this.toplistView.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradoLabel);
            this.groupBox1.Controls.Add(this.gradoComboBox);
            this.groupBox1.Controls.Add(this.EstadisticaComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TrimestreComboBox);
            this.groupBox1.Controls.Add(this.AñoComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busquedas";
            // 
            // AñoComboBox
            // 
            this.AñoComboBox.FormattingEnabled = true;
            this.AñoComboBox.Location = new System.Drawing.Point(50, 39);
            this.AñoComboBox.Name = "AñoComboBox";
            this.AñoComboBox.Size = new System.Drawing.Size(121, 21);
            this.AñoComboBox.TabIndex = 0;
            this.AñoComboBox.SelectedIndexChanged += new System.EventHandler(this.EstadisticaComboBox_SelectedIndexChanged);
            // 
            // TrimestreComboBox
            // 
            this.TrimestreComboBox.FormattingEnabled = true;
            this.TrimestreComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.TrimestreComboBox.Location = new System.Drawing.Point(74, 83);
            this.TrimestreComboBox.Name = "TrimestreComboBox";
            this.TrimestreComboBox.Size = new System.Drawing.Size(97, 21);
            this.TrimestreComboBox.TabIndex = 2;
            this.TrimestreComboBox.SelectedIndexChanged += new System.EventHandler(this.EstadisticaComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estadistica";
            // 
            // EstadisticaComboBox
            // 
            this.EstadisticaComboBox.FormattingEnabled = true;
            this.EstadisticaComboBox.Items.AddRange(new object[] {
            "Empresas con mayor cantidad de localidades no vendidas",
            "Clientes con mayores puntos vencidos",
            "Clientes con mayor cantidad de compras"});
            this.EstadisticaComboBox.Location = new System.Drawing.Point(309, 39);
            this.EstadisticaComboBox.Name = "EstadisticaComboBox";
            this.EstadisticaComboBox.Size = new System.Drawing.Size(322, 21);
            this.EstadisticaComboBox.TabIndex = 1;
            this.EstadisticaComboBox.SelectedIndexChanged += new System.EventHandler(this.EstadisticaComboBox_SelectedIndexChanged);
            // 
            // gradoLabel
            // 
            this.gradoLabel.AutoSize = true;
            this.gradoLabel.Location = new System.Drawing.Point(245, 86);
            this.gradoLabel.Name = "gradoLabel";
            this.gradoLabel.Size = new System.Drawing.Size(99, 13);
            this.gradoLabel.TabIndex = 6;
            this.gradoLabel.Text = "Grado de visibilidad";
            // 
            // gradoComboBox
            // 
            this.gradoComboBox.FormattingEnabled = true;
            this.gradoComboBox.Location = new System.Drawing.Point(350, 83);
            this.gradoComboBox.Name = "gradoComboBox";
            this.gradoComboBox.Size = new System.Drawing.Size(121, 21);
            this.gradoComboBox.TabIndex = 5;
            this.gradoComboBox.SelectedIndexChanged += new System.EventHandler(this.EstadisticaComboBox_SelectedIndexChanged);
            // 
            // ListadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(701, 643);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toplistView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListadoForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView toplistView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox EstadisticaComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TrimestreComboBox;
        private System.Windows.Forms.ComboBox AñoComboBox;
        private System.Windows.Forms.Label gradoLabel;
        private System.Windows.Forms.ComboBox gradoComboBox;
    }
}