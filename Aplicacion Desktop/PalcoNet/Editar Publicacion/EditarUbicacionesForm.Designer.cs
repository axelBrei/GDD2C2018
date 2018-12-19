namespace PalcoNet.Editar_Publicacion
{
    partial class EditarUbicacionesForm
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
            this.UbicacionesListView = new System.Windows.Forms.ListView();
            this.AgregarUbicacionButton = new System.Windows.Forms.Button();
            this.ModificarButtton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UbicacionesListView
            // 
            this.UbicacionesListView.FullRowSelect = true;
            this.UbicacionesListView.GridLines = true;
            this.UbicacionesListView.Location = new System.Drawing.Point(12, 79);
            this.UbicacionesListView.Name = "UbicacionesListView";
            this.UbicacionesListView.Size = new System.Drawing.Size(539, 415);
            this.UbicacionesListView.TabIndex = 0;
            this.UbicacionesListView.UseCompatibleStateImageBehavior = false;
            this.UbicacionesListView.View = System.Windows.Forms.View.Details;
            this.UbicacionesListView.SelectedIndexChanged += new System.EventHandler(this.UbicacionesListView_SelectedIndexChanged);
            // 
            // AgregarUbicacionButton
            // 
            this.AgregarUbicacionButton.BackColor = System.Drawing.Color.LightGray;
            this.AgregarUbicacionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarUbicacionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AgregarUbicacionButton.Location = new System.Drawing.Point(579, 95);
            this.AgregarUbicacionButton.Name = "AgregarUbicacionButton";
            this.AgregarUbicacionButton.Size = new System.Drawing.Size(118, 23);
            this.AgregarUbicacionButton.TabIndex = 1;
            this.AgregarUbicacionButton.Text = "Añadir";
            this.AgregarUbicacionButton.UseVisualStyleBackColor = false;
            this.AgregarUbicacionButton.Click += new System.EventHandler(this.AgregarUbicacionButton_Click);
            // 
            // ModificarButtton
            // 
            this.ModificarButtton.BackColor = System.Drawing.Color.LightGray;
            this.ModificarButtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarButtton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ModificarButtton.Location = new System.Drawing.Point(579, 133);
            this.ModificarButtton.Name = "ModificarButtton";
            this.ModificarButtton.Size = new System.Drawing.Size(118, 23);
            this.ModificarButtton.TabIndex = 2;
            this.ModificarButtton.Text = "Modificar";
            this.ModificarButtton.UseVisualStyleBackColor = false;
            this.ModificarButtton.Click += new System.EventHandler(this.ModificarButtton_Click);
            // 
            // EliminarButton
            // 
            this.EliminarButton.BackColor = System.Drawing.Color.LightGray;
            this.EliminarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EliminarButton.Location = new System.Drawing.Point(579, 172);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(118, 23);
            this.EliminarButton.TabIndex = 3;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = false;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // EditarUbicacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(709, 509);
            this.ControlBox = false;
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.ModificarButtton);
            this.Controls.Add(this.AgregarUbicacionButton);
            this.Controls.Add(this.UbicacionesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarUbicacionesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditarUbicacionesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView UbicacionesListView;
        private System.Windows.Forms.Button AgregarUbicacionButton;
        private System.Windows.Forms.Button ModificarButtton;
        private System.Windows.Forms.Button EliminarButton;
    }
}