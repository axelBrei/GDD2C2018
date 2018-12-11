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
        private int paginaActual;
        private Filtros filtroActual;

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

            filtroActual = new Filtros();
            filtroActual.tipo = -1;

            publiDao = new PublicacionesDao();
            paginaActual = 1;
            actualizarPagina(paginaActual);

            filtrosForm = new FiltrosForm();
            filtrosForm.onFilterSelected += this.onSelectFilter;

            
            
        }

        private class Filtros {
            public int tipo { get; set; }
            public string desc { get; set; }
            public List<Rubro> rubros{get;set;}
            public Nullable<DateTime> fechaI{get;set;}
            public Nullable<DateTime> fechaF {get;set;}

            public Filtros() {
                rubros = new List<Rubro>();
            }
        }

        private void onSelectFilter(int tipo, string desc, List<Rubro> rubros, Nullable<DateTime> fechaI, Nullable<DateTime> fechaF){
            Filtros filtro = new Filtros();
            filtro.tipo = tipo;
            filtro.desc = desc;
            filtro.rubros = rubros;
            filtro.fechaI = fechaI;
            filtro.fechaF = fechaF;

            filtroActual = filtro;
            actualizarPagina(1);



        }

        private void actualizarPagina(int pagina) {
            
            List<Publicacion> publicaciones = new List<Publicacion>();
            try
            {
                this.PublicacionesListView.Items.Clear();
                switch (filtroActual.tipo) {
                    case 0: {
                        publicaciones = publiDao.filtrarPaginasPorDescripcion(pagina, filtroActual.desc);
                        break;
                    }
                    case 1: {
                        publicaciones = publiDao.filtrarPaginasPorRubro(pagina, filtroActual.rubros);
                        break;
                    }
                    case 2: {
                        publicaciones = publiDao.filtrarPaginasPorFechas(pagina, (DateTime)filtroActual.fechaI, (DateTime)filtroActual.fechaF);
                        break;
                    }
                    default: {
                        publicaciones = publiDao.filtrarPaginasPorDescripcion(pagina, "");
                        break;
                    }
                }
                this.PublicacionesListView.BeginUpdate();
                publicaciones.ForEach(elem => {
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
            try
            {
                filtrosForm.Show(this);
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            switch (filtroActual.tipo)
            {
                case 0:
                    {
                        i = publiDao.getUltimaPaginaDesc(filtroActual.desc);
                        break;
                    }
                case 1:
                    {
                        i = publiDao.getUltimaPaginaRubros(filtroActual.rubros);
                        break;
                    }
                case 2:
                    {
                        i = publiDao.getUltimaPaginaFecha((DateTime)filtroActual.fechaI, (DateTime)filtroActual.fechaF);
                        break;
                    }
                default:
                    {
                        i = publiDao.getUltimaPaginaDesc("");
                        break;
                    }
            }
            this.PaginaTextBox.Text = i.ToString();
            actualizarPagina(i);
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

        private void PaginaTextBox_TextChanged(object sender, EventArgs e)
        {
            int num = int.Parse(((TextBox)sender).Text.ToString());
            if(num != paginaActual)
                actualizarPagina(num);
            paginaActual = num;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            this.PaginaTextBox.Text = paginaActual.ToString();
            actualizarPagina(1);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            paginaActual += 1;
            this.PaginaTextBox.Text = paginaActual.ToString();
            actualizarPagina(paginaActual);
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            paginaActual -= 1;
            this.PaginaTextBox.Text = paginaActual.ToString();
            actualizarPagina(paginaActual);
        }

        private void LimpiarFiltrosButton_Click(object sender, EventArgs e)
        {
            Filtros filtro = new Filtros();
            filtro.tipo = -1;
            filtroActual = filtro;
            actualizarPagina(1);
        }
    }
}
