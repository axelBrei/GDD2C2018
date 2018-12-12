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

namespace PalcoNet.Comprar
{
    public partial class IngresarTarjetaForm : Form
    {
        public Tarjeta tarjeta { get; set; }
        public Cliente cli { set; get; }

        public IngresarTarjetaForm()
        {
            tarjeta = new Tarjeta();
            InitializeComponent();
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
                tarjeta.vencimiento = this.VencimientoTextBox.Text.ToString();
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
    }

    
}
