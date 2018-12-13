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
using PalcoNet.Dao;
using PalcoNet.Exceptions;

namespace PalcoNet.Historial_Cliente
{
    public partial class HistorialCliente : Form
    {

        /*
         * ESTRATEGIA:
         *  - LAS COMPRAS SE MUESTRAN CON INFORMACION REDUCIDA PORQUE LUEGO SE PUEDE VER EL DETALLE DE LA MISMA
        */

        private ComprasDao comprasDao;
        private int paginaActual = 1;
        private int idCliete;
        private Compra compraSeleccionada;

        public delegate void OnBackPress();
        public event OnBackPress onBackPress;

        public HistorialCliente(int clieID, int tipo = 0)
        {
            InitializeComponent();

            comprasDao = new ComprasDao();
            
            this.HistorialListView.Columns.Insert(0, "Id", 5 * (int)HistorialListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.HistorialListView.Columns.Insert(1, "Fecha", 30 * (int)HistorialListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.HistorialListView.Columns.Insert(2, "Medio de pago", 10 * (int)HistorialListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.HistorialListView.Columns.Insert(3, "Cantidad", 15 * (int)HistorialListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.HistorialListView.Columns.Insert(4, "Total", 15 * (int)HistorialListView.Font.SizeInPoints, HorizontalAlignment.Center);

            idCliete = clieID;

            if (tipo != 0)
            {
                this.BackButton.Visible = true;
            }
            else
                this.BackButton.Visible = false;

            actualizarListaSgunpagina();
        }

        private ListViewItem getItemDeCompra(Compra c) {
            ListViewItem item = new ListViewItem();
            item.Text = c.id.ToString();
            item.SubItems.Add(c.fechaCompra.ToString());
            item.SubItems.Add(c.medioPago.numero);
            item.SubItems.Add(c.cantidad.ToString());
            item.SubItems.Add(c.total.ToString());

            item.Tag = c;

            return item;
        }

        private void actualizarListaSgunpagina() {
            
            List<Compra> compras = comprasDao.getPaginaComprasCliente(idCliete, paginaActual);
            if (compras.Count == 0)
            {
                paginaActual--;
                MessageBox.Show("No hay mas paginas con historial de compras para mostrar");
            }
            else {
                this.HistorialListView.Items.Clear();
                this.HistorialListView.BeginUpdate();
                    compras.ForEach(elem => {
                        this.HistorialListView.Items.Add(getItemDeCompra(elem));
                    });
                this.HistorialListView.EndUpdate();
            }
            
            this.PaginaTextBox.Text = paginaActual.ToString();

        }

        private void LastPageButton_Click(object sender, EventArgs e)
        {
            paginaActual = comprasDao.getLastPaginaComprasCliente(idCliete);
            actualizarListaSgunpagina();

        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            paginaActual++;
            actualizarListaSgunpagina();
        }

        private void BackPageButton_Click(object sender, EventArgs e)
        {
            paginaActual--;
            actualizarListaSgunpagina();
        }

        private void FirstPageButton_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            actualizarListaSgunpagina();
        }

        private void PaginaTextBox_TextChanged(object sender, EventArgs e)
        {
            int num = int.Parse(((TextBox)sender).Text.ToString());
            if (num != paginaActual) {
                paginaActual = num;
                actualizarListaSgunpagina();
            }
                
        }

        private void PaginaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se pueden introducir numeros para la pagina");
                e.Handled = true;
            }
            else if (e.KeyChar.Equals('0'))
            {
                MessageBox.Show("EL numero de pagina debe ser mayor a 0");
                e.Handled = true;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (this.onBackPress != null) {
                this.Close();
                this.onBackPress();
            }
        }

        private void DetallesButton_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleCompraForm form = new DetalleCompraForm(comprasDao.getDetalleCompraPorId(compraSeleccionada.id));
                form.Show(this);
            }
            catch (Exception ex) {
                if (e.GetType() == typeof(DataNotFoundException)) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void HistorialListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                compraSeleccionada = (Compra)((ListView)sender).SelectedItems[0].Tag;
            }
            catch (Exception ec) { }
        }

    }
}
