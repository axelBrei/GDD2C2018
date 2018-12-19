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
using PalcoNet.Comprar;

namespace PalcoNet.Generar_Publicacion
{
    public partial class ListaPublicacionesPaginadaForm : Form
    {
        public static int TIPO_NOMRAL = -1;
        public static int TIPO_EDITAR = 5;

        private PublicacionesDao publiDao;
        public int paginaActual { get; set; }
        public Filtro filtroActual { get; set; }

        public Publicacion publicacionSeleccionada { get; set; }

        public ListaPublicacionesPaginadaForm(int tipo = -1, Nullable<int> empresaId = null)
        {
            InitializeComponent();

            this.PublicacionesListView.Columns.Insert(0, "Id", 5 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(1, "Descripcion", 30 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(2, "Estado", 10 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(3, "Fecha Publicada", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(4, "Fecha del evento", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(5, "Direccion/Teatro", 15 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PublicacionesListView.Columns.Insert(6, "Grado", 10 * (int)PublicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);

            filtroActual = new Filtro();
            filtroActual.tipo = tipo;

            publiDao = new PublicacionesDao();
            paginaActual = 1;
            actualizarPagina(paginaActual);
        }


        public void actualizarPagina(int pagina)
        {

            List<Publicacion> publicaciones = new List<Publicacion>();
            try
            {
                this.PublicacionesListView.Items.Clear();
                switch (filtroActual.tipo)
                {
                    case 0:
                        {
                            publicaciones = publiDao.filtrarPaginasPorDescripcion(pagina, filtroActual.desc);
                            break;
                        }
                    case 1:
                        {
                            publicaciones = publiDao.filtrarPaginasPorRubro(pagina, filtroActual.rubros);
                            break;
                        }
                    case 2:
                        {
                            publicaciones = publiDao.filtrarPaginasPorFechas(pagina, (DateTime)filtroActual.fechaI, (DateTime)filtroActual.fechaF);
                            break;
                        }
                    case 5: {
                        Usuario user = UserData.UserData.getUsuario();
                        if (filtroActual.tipo == 5 & user.usuarioRegistrable.getTipo() == UserData.UserData.TIPO_EMPRESA) {
                            publicaciones = publiDao.getPublicacionesPorPagina(pagina, user.usuarioRegistrable.getId());
                        }else
                            publicaciones = publiDao.getPublicacionesPorPagina(pagina);
                        break;
                    }
                    default:
                        {
                            publicaciones = publiDao.filtrarPaginasPorDescripcion(pagina, "");
                            break;
                        }
                }
                this.PublicacionesListView.BeginUpdate();
                publicaciones.ForEach(elem =>
                {
                    this.PublicacionesListView.Items.Add(getItemFromPublicacion(elem));
                });
            }
            catch (Exception e)
            {
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

        private void lastPageButton_Click(object sender, EventArgs e)
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
                case 5: {
                    i = publiDao.getUlitimaPaginaNoFiltro();
                    break;
                }
                default:
                    {
                        i = publiDao.getUltimaPaginaDesc("");
                        break;
                    }
            }
            this.PaginaTextBox.Text = i.ToString();
            paginaActual = i;
            actualizarPagina(i);
        }

        private void PaginaTextBox_TextChanged(object sender, EventArgs e)
        {
            int num = int.Parse(((TextBox)sender).Text.ToString());
            if (num != paginaActual)
                actualizarPagina(num);
            paginaActual = num;
        }

        private void FirstPageButton_Click(object sender, EventArgs e)
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

        private void PublicacionesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                publicacionSeleccionada = (Publicacion)((ListView)sender).SelectedItems[0].Tag;
            }
            catch (Exception ex) { }
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
    }
}
