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
using System.Data;
using System.Data.SqlClient;
using PalcoNet.Dao;
using PalcoNet.Constants;
using System.Threading;

namespace PalcoNet.Editar_Publicacion
{
    public partial class ListaPublicacionesForm : Form
    {
        /*
         * ESTRATEGIA: 
         *  - UNA PUBLICACION NO PUEDE SER DESHABILITADA, SI SE LA PUEDE MARCAR COMO FINALIZADA ANTES DE QUE SUCEDA.
         *  - EL CAMBIO DE ESTADO DE UNA LOCALIDAD SE HACE A TRAVEZ DE SU MODIFICACION, YA QUE TODAS LAS PUBLICACIONES QUE SE CREAN SE PONEN CON
         *      EL ESTADO DE "BORRADOR"
         *  - CUANDO CARGA LA PANTALLA SOLO SE TRAE LA INFORMACION BASICA DE UNA PUBLICACION, AL HACER CLICK EN MODIFICAR SE 
         *      PUEDE ACCEDER A LA TOTALIDAD DE LA INFORMACION
         *     
        */

        private Publicacion publicacionSeleccionada;
        private int indexSeleccionado;

        private List<Publicacion> publicaiones = new List<Publicacion>();

        private PublicacionesController publicacionesController;
        private PublicacionesDao publicacionesDao;

        public ListaPublicacionesForm()
        {
            InitializeComponent();
            publicacionesController = new PublicacionesController();
            publicacionesDao = new PublicacionesDao();

            this.PublicacionesListView.Columns.Insert(0, "Id", 5 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(1, "Descripcion", 30 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(2, "Estado", 10 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(3, "Fecha Publicada", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(4, "Fecha del evento", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(5, "Direccion/Teatro", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(6, "Grado", 10 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);

            PublicacionesListView.BeginUpdate();
            publicacionesDao.getPublicacionesConInfoBasica().ForEach(elem => { 
                PublicacionesListView.Items.Add(getItemFromPublicacion(elem));
            });

        }

        private ListViewItem getItemFromPublicacion(Publicacion publi) {
            ListViewItem item = new ListViewItem();
            item.Text = publi.id.ToString();
            item.SubItems.Add(publi.espectaculo.descripcion);
            item.SubItems.Add(publi.estado);
            item.SubItems.Add( ((DateTime)publi.fechaPublicacion).Date.ToString() );
            item.SubItems.Add( ((DateTime) publi.fechaEvento).Date.ToString() );
            item.SubItems.Add(publi.espectaculo.direccion);
            item.SubItems.Add(publi.gradoPublicacion.nivel);

            item.Tag = publi;

            return item;
        }

        private void PublicacionesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lista = (ListView)sender;
            try
            {
                publicacionSeleccionada = (Publicacion)lista.SelectedItems[0].Tag;
                indexSeleccionado = lista.SelectedIndices[0];
            }
            catch (Exception ex) { }
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            
            Publicacion publicacion = publicacionesController.getPublicacionPorId(publicacionSeleccionada.id);
            EditarPublicacionForm form = new EditarPublicacionForm(publicacion);
            form.publicacionEditadaHandler += this.publicacionEditadaHandler;
            form.Show(this);
        }

        private void publicacionEditadaHandler(Publicacion publi) { 

            this.PublicacionesListView.BeginUpdate();
                this.PublicacionesListView.Items.RemoveAt(indexSeleccionado);
                this.PublicacionesListView.Items.Insert(indexSeleccionado, getItemFromPublicacion(publi));
            this.PublicacionesListView.EndUpdate();
        }
    }
}
