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
using PalcoNet.Constants;

namespace PalcoNet.Comprar
{
    public partial class ListadoPublicacionesComprasForm : Form
    {
        private PublicacionesDao publiDao;
        FiltrosForm filtrosForm;

        public ListadoPublicacionesComprasForm()
        {
            InitializeComponent();

            this.PublicacionesListView.Columns.Insert(0, "Id", 5 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(1, "Descripcion", 30 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(2, "Estado", 10 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(3, "Fecha Publicada", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(4, "Fecha del evento", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(5, "Direccion/Teatro", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(6, "Grado", 10 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);

            publiDao = new PublicacionesDao();
            actualizarPagina(1);

            filtrosForm = new FiltrosForm();
            
        }

        private void actualizarPagina(int pagina) {
            this.PublicacionesListView.BeginUpdate();
            try
            {
                publiDao.filtrarPaginasPorDescripcion(pagina,"").ForEach(elem =>
                {
                    this.PublicacionesListView.Items.Add(getItemFromPublicacion(elem));
                });
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            this.PublicacionesListView.EndUpdate();
        }

        private ListViewItem getItemFromPublicacion(Publicacion publi)
        {
            ListViewItem item = new ListViewItem();
            item.Text = publi.id.ToString();
            item.SubItems.Add(publi.espectaculo.descripcion);
            item.SubItems.Add(publi.estado);
            item.SubItems.Add(((DateTime)publi.fechaPublicacion).Date.ToString());
            item.SubItems.Add(((DateTime)publi.fechaEvento).Date.ToString());
            item.SubItems.Add(publi.espectaculo.direccion);
            item.SubItems.Add(publi.gradoPublicacion.nivel);

            item.Tag = publi;

            return item;
        }

        private void FiltrosButton_Click(object sender, EventArgs e)
        {
            filtrosForm.Show(this);
        }
    }
}
