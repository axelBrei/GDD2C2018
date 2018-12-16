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

namespace PalcoNet.Historial_Cliente
{
    public partial class DetalleCompraForm : Form
    {
        public DetalleCompraForm(Compra compra)
        {
            InitializeComponent();

            try
            {
                FechaCompraTextBox.Text = compra.fechaCompra == null ? "" : compra.fechaCompra.ToString(); 
                FechaEventoTextBox.Text = compra.publicacion.fechaEvento == null ? "" : compra.publicacion.fechaEvento.ToString();
                DescripcionTextBox.Text = compra.publicacion.espectaculo.descripcion;
                EstadoTextBox.Text = compra.publicacion.estado == null ? "": compra.publicacion.estado;
                EmpresaTextBox.Text = compra.publicacion.espectaculo.empresa.razonSocial == null ? "" : compra.publicacion.espectaculo.empresa.razonSocial;
                TotalTextBox.Text = "$ " + compra.total.ToString();

                this.UbicacionesListView.Columns.Insert(0, "Fila", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
                this.UbicacionesListView.Columns.Insert(1, "Asiento", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
                this.UbicacionesListView.Columns.Insert(2, "Tipo de Ubicacion", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
                this.UbicacionesListView.Columns.Insert(3, "Precio", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);

                new UbicacionesCompraDao().getUbicacionesDeLaCompra(compra,
                        ubi => ubi.ForEach(elem => this.UbicacionesListView.Items.Add(getItemDeUbicacion(elem)))
                    );
            }
            catch (Exception e) { }
        }

        private ListViewItem getItemDeUbicacion(Ubicacion elem)
        {
            ListViewItem item = new ListViewItem();
            item.Text = elem.fila.ToUpper();
            item.SubItems.Add(elem.asiento.ToString());
            item.SubItems.Add(elem.tipoUbicaciones.descripcion);
            item.SubItems.Add("$" + elem.precio.ToString());

            item.Tag = elem;

            return item;
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
