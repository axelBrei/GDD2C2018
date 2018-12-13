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
using PalcoNet.Exceptions;
using PalcoNet.Dao;
using PalcoNet.ConectionUtils;


namespace PalcoNet.Comprar
{
    public partial class ConfirmacionCompraForm : Form
    {
        private Compra compraA;
        private Publicacion publicA;

        public ConfirmacionCompraForm(Compra compra, Publicacion publicacion)
        {
            InitializeComponent();
            compraA = compra;
            publicA = publicacion;

            this.PublicacionTextBox.Text += publicacion.id.ToString() + "/" + publicacion.espectaculo.descripcion;
            this.FechaTextBox.Text += publicacion.fechaEvento;
            this.MedioPagoTextBox.Text += compra.medioPago.ToString();
            this.CantUbicacionesTextBox.Text += compra.ubicaciones.Count.ToString();
            this.MontoTextView.Text = compra.total.ToString();
            compra.ubicaciones.ForEach(elem => {
                this.UbicacionesListTextBox.Text += "● " + elem.ToString() + '\n';
            });
        }
    }
}
