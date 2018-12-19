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
using PalcoNet.Generar_Publicacion;
using PalcoNet;
namespace PalcoNet.Comprar
{
    public partial class ListadoPublicacionesComprasForm : Form
    {
        private PublicacionesDao publiDao;
        private FiltrosForm filtrosForm;
        private Filtro filtroActual;
        private int indexActual;
        private int paginaActual;

        private ListaPublicacionesPaginadaForm publicacionesForm;

        public ListadoPublicacionesComprasForm()
        {
            InitializeComponent();

            filtroActual = new Filtro();
            filtroActual.tipo = -1;

            publiDao = new PublicacionesDao();

            filtrosForm = new FiltrosForm();
            filtrosForm.onFilterSelected += this.onSelectFilter;

            publicacionesForm = new ListaPublicacionesPaginadaForm();


            Utils.añadirVistaAPanel(publicacionesForm, ListaPanel);
            
        }

        private void onSelectFilter(int tipo, string desc, List<Rubro> rubros, Nullable<DateTime> fechaI, Nullable<DateTime> fechaF){
            Filtro filtro = new Filtro();
            filtro.tipo = tipo;
            filtro.desc = desc;
            filtro.rubros = rubros;
            filtro.fechaI = fechaI;
            filtro.fechaF = fechaF;

            filtroActual = filtro;
            publicacionesForm.filtroActual = filtro;
            publicacionesForm.actualizarPagina(1);



        }

        private ListViewItem getItemFromPublicacion(Publicacion publi)
        {
            ListViewItem item = new ListViewItem();
            item.Text = publi.id.ToString();
            item.SubItems.Add(publi.espectaculo.descripcion);
            item.SubItems.Add(publi.estado);
            item.SubItems.Add(((DateTime)publi.fechaPublicacion).ToString());
            item.SubItems.Add(((DateTime)publi.fechaEvento).ToString());
            item.SubItems.Add(publi.espectaculo.direccion);
            item.SubItems.Add(publi.gradoPublicacion.nivel);

            item.Tag = publi;

            return item;
        }

        private void FiltrosButton_Click(object sender, EventArgs e)
        {
            try
            {
                filtrosForm.Show(this);
            }
            catch (Exception ex) { }
        }

        private void PaginaTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo se pueden introducir numeros para la pagina");
                e.Handled = true;
            }
            else if (e.KeyChar.Equals('0')) {
                MessageBox.Show("EL numero de pagina debe ser mayor a 0");
                e.Handled = true;
            }
        }

        private void LimpiarFiltrosButton_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            filtro.tipo = -1;
            filtroActual = filtro;
            publicacionesForm.filtroActual = filtroActual;
            publicacionesForm.actualizarPagina(1);
        }

        private void DetallesButton_Click(object sender, EventArgs e)
        {
            Publicacion publiacion = publicacionesForm.publicacionSeleccionada;
            if (publiacion == null)
            {
                MessageBox.Show("Debe seleccionar una publicacion para poder continuar");
            }
            else {
                ComprarForm form = new ComprarForm(publiacion);
                paginaActual = publicacionesForm.paginaActual;
                form.FormClosed += this.onCompraConfirmada;
                form.Show(this);
                publicacionesForm.publicacionSeleccionada = null;
            }
            
        }

        private void onCompraConfirmada(object sender, FormClosedEventArgs e){
            publicacionesForm.actualizarPagina(paginaActual);
        }
    }
}
