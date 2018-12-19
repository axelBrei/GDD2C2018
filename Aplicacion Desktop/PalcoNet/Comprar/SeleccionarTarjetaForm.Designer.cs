namespace PalcoNet.Comprar
{
    partial class SeleccionarTarjetaForm
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
            this.TarjetasListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.EliminarTarjetaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TarjetasListView
            // 
            this.TarjetasListView.FullRowSelect = true;
            this.TarjetasListView.GridLines = true;
            this.TarjetasListView.Location = new System.Drawing.Point(17, 58);
            this.TarjetasListView.Name = "TarjetasListView";
            this.TarjetasListView.Size = new System.Drawing.Size(446, 310);
            this.TarjetasListView.TabIndex = 0;
            this.TarjetasListView.UseCompatibleStateImageBehavior = false;
            this.TarjetasListView.View = System.Windows.Forms.View.Details;
            this.TarjetasListView.SelectedIndexChanged += new System.EventHandler(this.TarjetasListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione su medio de pago";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(310, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Añadir Medio de pago";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EliminarTarjetaButton
            // 
            this.EliminarTarjetaButton.BackColor = System.Drawing.Color.LightGray;
            this.EliminarTarjetaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarTarjetaButton.Location = new System.Drawing.Point(17, 374);
            this.EliminarTarjetaButton.Name = "EliminarTarjetaButton";
            this.EliminarTarjetaButton.Size = new System.Drawing.Size(153, 23);
            this.EliminarTarjetaButton.TabIndex = 3;
            this.EliminarTarjetaButton.Text = "Eliminar Tarjeta";
            this.EliminarTarjetaButton.UseVisualStyleBackColor = false;
            this.EliminarTarjetaButton.Click += new System.EventHandler(this.EliminarTarjetaButton_Click);
            // 
            // SeleccionarTarjetaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(507, 405);
            this.Controls.Add(this.EliminarTarjetaButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TarjetasListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionarTarjetaForm";
            this.Text = "SeleccionarTarjetaForm";
            this.Load += new System.EventHandler(this.SeleccionarTarjetaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TarjetasListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EliminarTarjetaButton;
    }
}