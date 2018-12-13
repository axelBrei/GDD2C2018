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

namespace PalcoNet.Historial_Cliente
{
    public partial class DetalleCompraForm : Form
    {
        public DetalleCompraForm(Compra compra)
        {
            InitializeComponent();

            try
            {
                FechaCompraTextBox.Text = compra.fechaCompra.ToString();
                FechaEventoTextBox.Text = compra.publicacion.fechaEvento.ToString();
                DescripcionTextBox.Text = compra.publicacion.espectaculo.descripcion;
                EstadoTextBox.Text = compra.publicacion.estado;
                EmpresaTextBox.Text = compra.publicacion.espectaculo.empresa.razonSocial;
                TotalTextBox.Text = "$ " + compra.total.ToString();
            }
            catch (Exception e) { }
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
