namespace PalcoNet.Generar_Publicacion
{
    partial class PanelDateItem
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
            this.PickerFecha = new System.Windows.Forms.DateTimePicker();
            this.PickerHora = new System.Windows.Forms.DateTimePicker();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.ItemId = new System.Windows.Forms.Label();
            this.CheckboxHabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // PickerFecha
            // 
            this.PickerFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PickerFecha.Location = new System.Drawing.Point(70, 8);
            this.PickerFecha.MinDate = new System.DateTime(2018, 12, 5, 0, 0, 0, 0);
            this.PickerFecha.Name = "PickerFecha";
            this.PickerFecha.Size = new System.Drawing.Size(200, 20);
            this.PickerFecha.TabIndex = 0;
            this.PickerFecha.Value = new System.DateTime(2018, 12, 5, 0, 0, 0, 0);
            this.PickerFecha.ValueChanged += new System.EventHandler(this.PickerFecha_ValueChanged);
            // 
            // PickerHora
            // 
            this.PickerHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PickerHora.CustomFormat = "HH:mm";
            this.PickerHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.PickerHora.Location = new System.Drawing.Point(276, 8);
            this.PickerHora.Name = "PickerHora";
            this.PickerHora.ShowUpDown = true;
            this.PickerHora.Size = new System.Drawing.Size(69, 20);
            this.PickerHora.TabIndex = 1;
            this.PickerHora.ValueChanged += new System.EventHandler(this.PickerHora_ValueChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(414, 37);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 414;
            this.lineShape1.Y1 = 36;
            this.lineShape1.Y2 = 36;
            // 
            // ItemId
            // 
            this.ItemId.AutoSize = true;
            this.ItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemId.Location = new System.Drawing.Point(12, 12);
            this.ItemId.Name = "ItemId";
            this.ItemId.Size = new System.Drawing.Size(41, 13);
            this.ItemId.TabIndex = 4;
            this.ItemId.Text = "item 0";
            // 
            // CheckboxHabilitado
            // 
            this.CheckboxHabilitado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxHabilitado.AutoSize = true;
            this.CheckboxHabilitado.Location = new System.Drawing.Point(385, 12);
            this.CheckboxHabilitado.Name = "CheckboxHabilitado";
            this.CheckboxHabilitado.Size = new System.Drawing.Size(15, 14);
            this.CheckboxHabilitado.TabIndex = 5;
            this.CheckboxHabilitado.UseVisualStyleBackColor = true;
            // 
            // PanelDateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(414, 37);
            this.ControlBox = false;
            this.Controls.Add(this.CheckboxHabilitado);
            this.Controls.Add(this.ItemId);
            this.Controls.Add(this.PickerHora);
            this.Controls.Add(this.PickerFecha);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PanelDateItem";
            this.Text = "PanelDateItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker PickerFecha;
        private System.Windows.Forms.DateTimePicker PickerHora;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label ItemId;
        private System.Windows.Forms.CheckBox CheckboxHabilitado;
    }
}