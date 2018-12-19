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
using System.Data.SqlClient;
using System.Data;
using PalcoNet.Dao;
using PalcoNet.Generar_Publicacion;
using PalcoNet.ConectionUtils;


namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarPublicacionForm : Form
    {
        private Publicacion publicacionActual;
        private Button botonAceptar;

        GenerarPublicacionForm publicacionForm;
        EditarUbicacionesForm ubicacionesForm;
        EditarEstadoForm estadoForm;

        public delegate void PublicacionEditadaHandler(Publicacion publicacion);
        public event PublicacionEditadaHandler publicacionEditadaHandler;

        public EditarPublicacionForm(Publicacion publi)
        {
            InitializeComponent();
            this.publicacionActual = publi;
            ubicacionesForm = new EditarUbicacionesForm(publicacionActual.ubicaciones);
            publicacionForm = new GenerarPublicacionForm(publi);
            publicacionForm.Size = new Size(this.ContentPanel.Size.Width, this.ContentPanel.Size.Height - 40);
            estadoForm = new EditarEstadoForm(publi);

            publicacionForm.Size = new Size(this.ContentPanel.Size.Width, this.ContentPanel.Size.Height - 40);

            if (publi.estado == "Publicada" || publi.estado == "Finaliada") {
                ubicacionesForm.Enabled = false;

                publicacionForm.Enabled = false;
            }

            botonAceptar = new Button();
            botonAceptar.Text = "Aceptar";
            botonAceptar.Click += AceptarButton_Click;
            botonAceptar.Size = new Size(131,23);
            botonAceptar.Location = new Point(573,665);
            botonAceptar.BackColor = this.MenuPanel.BackColor;
            botonAceptar.ForeColor = Color.White;

            showHideForm(publicacionForm);
        }

        private void showHideForm(Form form) {
            form.TopLevel = false;
            form.AutoScroll = true;
            this.ContentPanel.Controls.Add(form);
            form.Show();
            this.ContentPanel.Controls.Add(botonAceptar);
            
        }

        private void PublicacionesMenuButton_Click(object sender, EventArgs e)
        {
            this.ContentPanel.Controls.Clear();
            //publicacionForm = new GenerarPublicacionForm(publicacionActual);
            //publicacionForm.Size = new Size(this.ContentPanel.Size.Width, this.ContentPanel.Size.Height - 40);
            showHideForm(publicacionForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ContentPanel.Controls.Clear();
            //ubicacionesForm = new EditarUbicacionesForm(publicacionActual.ubicaciones);
            showHideForm(ubicacionesForm);
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            List<Ubicacion> agregadas = ubicacionesForm.getAgregadas();
            List<Ubicacion> eliminadas = ubicacionesForm.getElminadas();

            publicacionActual = publicacionForm.publicacionAModificar;
            publicacionActual.estado = estadoForm.publicacionActual.estado;
            publicacionActual.fechaPublicacion = estadoForm.publicacionActual.fechaPublicacion;
            if (eliminadas != null) {
                publicacionActual.ubicaciones.RemoveAll(item => eliminadas.Contains(item));
            }
            if (agregadas != null) { 
                publicacionActual.ubicaciones.AddRange(agregadas);
            }
            
            PublicacionesController controller = new PublicacionesController();
            SqlTransaction transaction = DatabaseConection.getInstance().BeginTransaction();
            try
            {
                controller.actualizarPublicacion(publicacionActual, transaction, agregadas, eliminadas, publicacionForm.fechaModificada);
                transaction.Commit();
                if (this.publicacionEditadaHandler != null)
                    this.publicacionEditadaHandler(publicacionActual);
                this.Close();
            }
            catch (SqlInsertException ex)
            {
                MessageBox.Show(ex.msgDescription);
                transaction.Rollback();
            }
            catch (SqlDeleteException ex)
            {
                MessageBox.Show(ex.msgDescription);
                transaction.Rollback();
            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado al intentar actualizar la publicacion");
                transaction.Rollback();
            }
        }

        private void EstadoButton_Click(object sender, EventArgs e)
        {
            this.ContentPanel.Controls.Clear();
            //estadoForm = new EditarEstadoForm(publicacionActual);
            showHideForm(estadoForm);
        }
    }
}
