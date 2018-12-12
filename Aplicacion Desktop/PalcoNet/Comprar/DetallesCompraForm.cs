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
using PalcoNet.Editar_Publicacion;
using System.Threading;

namespace PalcoNet.Comprar
{
    public partial class DetallesCompraForm : Form
    {
        private Publicacion publiActual;
        private PublicacionesDao publiDao;
        private PublicacionesController controller;

        public DetallesCompraForm(Publicacion publi)
        {
            InitializeComponent();
            controller = new PublicacionesController();
            publiActual = publi;
            completarDatosDePublicacion(publi);

        }

        private void completarDatosDePublicacion(Publicacion publi)
        {
            Task.Factory.StartNew(() =>
            {
                Publicacion p = Task.Run<Publicacion>(() => controller.getPublicacionesPorIdAsync(publi.id)).Result;
                PublicacionSelecLabel.Text = PublicacionSelecLabel.Text + " " + p.id;
                DescripcionLabel.Text = p.espectaculo.descripcion;
                DireccionLabel.Text = p.espectaculo.direccion;
                EmpresaLabel.Text = p.espectaculo.empresa.razonSocial;
                FechaLabel.Text = ((DateTime)p.fechaEvento).Date.ToShortDateString();
                CategoriaLabel.Text = p.espectaculo.rubro.descripcion;
                publiActual = p;
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetallesUbicacionesCompraForm form = new DetallesUbicacionesCompraForm(publiActual);

            form.Show(this);
        }
    }
}
