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
using PalcoNet.Constants;
using PalcoNet.Validators;

namespace PalcoNet.Comprar
{
    public partial class IngresarTarjetaForm : Form
    {
        public Tarjeta tarjeta { get; set; }
        public Cliente cli { set; get; }

        private readonly ErrorProvider eProvideer = new ErrorProvider();

        public IngresarTarjetaForm()
        {
            tarjeta = new Tarjeta();
            InitializeComponent();

            VencimientoDatePicker.Value = Generals.getFecha();
        }
        private void TitularTextBox_TextChanged(object sender, EventArgs e)
        {
            try {
                tarjeta.titular = TitularTextBox.Text.ToString();
            }
            catch (Exception ex) { }
        }

        private void NumeroTextBox_TextChanged(object sender, EventArgs e)
        {
            try {
                tarjeta.numero = this.NumeroTextBox.Text.ToString();
            }
            catch (Exception ex) { }
        }

        private void VencimientoTextBox_TextChanged(object sender, EventArgs e)
        {
            try {
                DateTime fecha = VencimientoDatePicker.Value;
                if (fecha.CompareTo(Generals.getFecha()) < 0)
                {
                    // FECHA ANTERIOR A HOY
                    tarjeta.vencimiento = null;
                }
                else
                    tarjeta.vencimiento = fecha.ToString("yyyy/MM");
            }
            catch (Exception ex) { }
        }

        private void CVVTextBox_TextChanged(object sender, EventArgs e)
        {
            try {
                tarjeta.vcc = this.CVVTextBox.Text.ToString();
            }
            catch (Exception ex) { }
        }

        private void TitularTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        // VALIDACIONES

        private void NumeroTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.esNumerico(NumeroTextBox.Text)) { 
                eProvideer.SetError(NumeroTextBox, "El campo debe ser numerico unicamente");
                e.Cancel = true;
            }
        }

        private void CVVTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.esNumerico(CVVTextBox.Text))
            {
                eProvideer.SetError(CVVTextBox, "El campo debe ser numerico unicamente");
                e.Cancel = true;
            }
            else if (CVVTextBox.Text.Length > 4)
            {
                eProvideer.SetError(CVVTextBox, "El código de seguridad no puede poseer mas de 3 digitos");
                e.Cancel = true;
            }

        }

        public string esTarjetaValida(Tarjeta tar)
        {
            string res = "";
            if (tar.numero.Length == 0) res += "Numero de tarjeta \n";
            if (tar.titular.Length == 0) res += "Nombre del titular \n";
            if (tar.vencimiento == null) res += "Vencimiento \n";
            if (tar.vcc.Length == 0) res += "Codigo de seguridad \n";

            return res;
        }





    }
}
