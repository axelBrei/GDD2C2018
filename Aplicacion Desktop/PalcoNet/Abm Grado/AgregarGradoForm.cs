using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Model;
using PalcoNet.Model;
using PalcoNet.Exceptions;

namespace PalcoNet.Abm_Grado
{
    public partial class AgregarGradoForm : Form
    {

        private GradoPublicacion gradoPublicacion;
        private int index;

        public delegate void OnClickAceptHandler(GradoPublicacion grado, int index);
        public event OnClickAceptHandler onClickAcept;

        public AgregarGradoForm()
        {
            InitializeComponent();
            this.index = -1;
        }

        public AgregarGradoForm(GradoPublicacion grado, int index)
        {
            InitializeComponent();
            gradoPublicacion = grado;
            this.index = index;
            this.Title.Text = "Modificar grado de publicación";

            this.DescripcionTextBox.Text = gradoPublicacion.nivel;
            this.ComisionNumericDropDown.Value = (decimal) gradoPublicacion.comision;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            string desc = this.DescripcionTextBox.Text;
            float comision = float.Parse(this.ComisionNumericDropDown.Value.ToString());
            if (string.IsNullOrEmpty(desc))
                MessageBox.Show("Debe completar el campo de descripcion.");
            else if(comision.Equals(0))
                MessageBox.Show("El campo Comision debe ser mayor a 0.");
            else {
                GradoPublicacion grado = new GradoPublicacion();
                if(gradoPublicacion != null)
                    grado.id = gradoPublicacion.id;
                grado.comision = comision;
                grado.nivel = desc.ToUpper();
                if (this.onClickAcept != null)
                    this.onClickAcept(grado, index);
                this.Close();
            }
            
        }
    }
}
