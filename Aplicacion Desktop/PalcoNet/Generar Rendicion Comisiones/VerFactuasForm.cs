using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Dao;
using PalcoNet.Model;
using PalcoNet.Constants;
using PalcoNet.Exceptions;
using PalcoNet.Validators;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class VerFactuasForm : Form
    {
        private int pagina = 1;
        private Empresa empresa;
        private FacturasDao facturasDao;

        public VerFactuasForm(Empresa emp)
        {
            InitializeComponent();
            this.empresa = emp;
            this.FacturaListView.Columns.Insert(0, "Numero", 10 * (int)FacturaListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.FacturaListView.Columns.Insert(1, "Fecha", 30 * (int)FacturaListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.FacturaListView.Columns.Insert(2, "Total", 10 * (int)FacturaListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.FacturaListView.Columns.Insert(3, "Forma de pago", 15 * (int)FacturaListView.Font.SizeInPoints, HorizontalAlignment.Center);
            facturasDao = new FacturasDao();
            actualizarPagina();
        }

        private void actualizarPagina() {
            FacturaListView.Items.Clear();
            facturasDao.getFacturasDeEmpresaPorpagina( (int)empresa.id, pagina).ForEach(elem => {
                FacturaListView.Items.Add(getitemFactura(elem));
            });
        }


        private ListViewItem getitemFactura(Factura fact) {
            ListViewItem item = new ListViewItem();
            item.Text = fact.numero.ToString();
            item.SubItems.Add(fact.fecha.ToString());
            item.SubItems.Add(fact.total.ToString());
            item.SubItems.Add(fact.formaDePago.ToString());

            item.Tag = fact;

            return item;
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaginaTextBox_TextChanged(object sender, EventArgs e)
        {
            pagina = int.Parse(PaginaTextBox.Text);
            actualizarPagina();
        }

        private void PaginaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Validator.esNumerico(e.KeyChar.ToString())) {
                e.Handled = true;
                MessageBox.Show("Solo se pueden ingresar valores numericos como numero de pagina");
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            pagina++;
            PaginaTextBox.Text = pagina.ToString();
            actualizarPagina();
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            pagina--;
            PaginaTextBox.Text = pagina.ToString();
            actualizarPagina();
        }

        private void FirstPageButton_Click(object sender, EventArgs e)
        {
            pagina = 1;
            PaginaTextBox.Text = pagina.ToString();
            actualizarPagina();
        }

        private void lastPageButton_Click(object sender, EventArgs e)
        {
            pagina = facturasDao.getUltimaPaginaFacturasPorEmpresa( (int) empresa.id);
            PaginaTextBox.Text = pagina.ToString();
            actualizarPagina();
        }
    }
}
