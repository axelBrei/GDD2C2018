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
using System.Data;
using PalcoNet.Constants;
using PalcoNet.UserData;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;

namespace PalcoNet.Generar_Publicacion
{
    public partial class GenerarPublicacionForm : Form
    {

        /*
         *  ESTRAGTEGIA:
         *  - TODAS LAS PUBLICACIONES QUE SE AGREGAN ENTRAN EN UN ESTADO DE BORRADOR, LUEGO SE PUEDE MODIFICAR DICHO ESTADO
         *      A FINALIZADA O ACTIVA
         */ 

        private RubrosDao rubrosDao;
        private GradoDePublicacionDao gradosDao;
        private PublicacionesDao publicacionesDao;
        private EspectaculosDao espectaculosDao;
        private PublicacionesController controller;

        private string direccionPublicacion;
        private string descripcionPublicacion;
        private Rubro rubro;
        private GradoPublicacion gradoPublicacion;
        private List<DateTime> fechasDeLaPublicacion = new List<DateTime>();
        private List<Ubicacion> ubicacionesList = new List<Ubicacion>();
        private DateTime fechaMinima;

        public GenerarPublicacionForm()
        {
            InitializeComponent();
            rubrosDao = new RubrosDao();
            gradosDao = new GradoDePublicacionDao();
            publicacionesDao = new PublicacionesDao();
            espectaculosDao = new EspectaculosDao();
            controller = new PublicacionesController();

            rubrosDao.getRubros().ForEach(
                elem => RubroComboBox.Items.Add(elem)
            );

            this.FechaEventoTimePicker.ShowUpDown = false;
            this.FechaEventoTimePicker.CustomFormat = "yyyy.MM.dd";
            // Dia Minimo: ayer
            fechaMinima = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Date;
            fechasDeLaPublicacion.Add(fechaMinima);
            this.FechaEventoTimePicker.MinDate = fechaMinima;
            this.FechaEventoTimePicker.Value = fechaMinima;

            
            gradosDao.getGradosDePublicacion().ForEach(elem => {
                GradoPublicacionComboBox.Items.Add(elem);
            });
            
            
            this.UbicacionesListView.Columns.Insert(0, "Fila", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(1, "Asiento", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(2, "Tipo de Ubicacion", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(3, "Precio", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
        }
 

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DireccionTextBox_TextChanged(object sender, EventArgs e)
        {
            direccionPublicacion = ((TextBox)sender).Text; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            descripcionPublicacion = ((TextBox)sender).Text;
        }

        private void FechaEventoTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var timePicker = sender as DateTimePicker;
            try
            {
                DateTime time = this.FechaEventoTimePicker.Value;
                fechasDeLaPublicacion.RemoveAt(0);
                fechasDeLaPublicacion.Insert(0, time);
                fechaMinima = time;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void HoraEventoTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker horas = sender as DateTimePicker;
                DateTime fecha = fechasDeLaPublicacion[0].Date; 

                fecha = fecha.AddHours(horas.Value.Hour);
                fecha = fecha.AddMinutes(horas.Value.Minute);

                fechasDeLaPublicacion.RemoveAt(0);
                fechasDeLaPublicacion.Insert(0, fecha);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void RubroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox lista = sender as ComboBox;
            try
            {
                rubro = (Rubro)lista.SelectedItem;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AñadirUbicacionForm form = new AñadirUbicacionForm();
            form.onFinishregistration += this.onFinishLocationInsertions;
            form.Show(this);
        }


        private void onFinishLocationInsertions(List<Ubicacion> ubicaciones) {
            string filasDuplicadas = "";
            foreach (Ubicacion elem in ubicaciones) {
                if (ubicacionesList.Contains(elem))
                {
                    if (!filasDuplicadas.Contains(elem.fila))
                        filasDuplicadas += elem.fila + "-";
                    continue;
                }
                ListViewItem item = new ListViewItem();
                item.Text = elem.fila.ToUpper();
                item.SubItems.Add(elem.asiento.ToString());
                item.SubItems.Add(elem.tipoUbicaciones.descripcion);
                item.SubItems.Add("$" + elem.precio.ToString());

                item.Tag = elem;

                UbicacionesListView.Items.Add(item);
            }
            if (!string.IsNullOrEmpty(filasDuplicadas)) {
                if (filasDuplicadas.Length % 2 == 0)
                    filasDuplicadas = filasDuplicadas.Remove(filasDuplicadas.Length - 1);
                MessageBox.Show("No se pudieron insertar las filas y asientos porque ya estan asignados\n Filas: " + filasDuplicadas.ToUpper());
            }
            ubicaciones.ForEach(elem => {
                if (!ubicacionesList.Contains(elem)) {
                    ubicacionesList.Add(elem);
                }
            });
        }

        private void EliminarUbicacionButton_Click(object sender, EventArgs e)
        {
            UbicacionesListView.Items.Remove(UbicacionesListView.SelectedItems[0]);
            ubicacionesList.Remove((Ubicacion)UbicacionesListView.Items[0].Tag);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AñadirFechasForm form = new AñadirFechasForm(fechasDeLaPublicacion[0]);
            if (fechasDeLaPublicacion.Count > 1)
                form = new AñadirFechasForm(fechasDeLaPublicacion[0], fechasDeLaPublicacion.Skip(1).OrderBy( elem => elem).ToList());
            form.onFinishDateInsertion += this.onFinishDateInsertion;
            form.Show(this);
        }

        private void onFinishDateInsertion(List<DateTime> lista, bool modificando) {
            if (!modificando)
            {
                lista.ForEach(elem =>
                {
                    fechasDeLaPublicacion.Add(elem);
                });
            }
            else {
                for (int i = 1; i < lista.Count; i++) {
                    fechasDeLaPublicacion.RemoveAt(i);
                    fechasDeLaPublicacion.Insert(i, lista[i]);
                }
            }
            
        }

        private void GradoPublicacionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gradoPublicacion = (GradoPublicacion)GradoPublicacionComboBox.SelectedItem;
            }
            catch (Exception ex) { } 
        }
        private bool espectGenerado = false;
        private Espectaculo espec;

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (espectGenerado == false) { 
                espec = new Espectaculo();
                espec.descripcion = descripcionPublicacion;
                espec.direccion = direccionPublicacion;
                espec.rubro = rubro;
                espec.id = espectaculosDao.insertarEspectaculo(espec);
                espectGenerado = true;
            }

            SqlTransaction transaction = DatabaseConection.getInstance().BeginTransaction();   
            try
            {
                fechasDeLaPublicacion.ForEach(elem =>
                {
                    Publicacion publicacion = new Publicacion();
                    publicacion.gradoPublicacion = gradoPublicacion;
                    publicacion.fechaEvento = elem;
                    publicacion.fechaPublicacion = DateTime.Now.Date;
                    publicacion.estado = Strings.ESTADO_BORRADOR;

                    publicacion.espectaculo = espec;
                    publicacion.ubicaciones = ubicacionesList;

                    controller.insertarPublicacionEnDB(publicacion, transaction);
                });
                transaction.Commit();
                MessageBox.Show("Se ha cargado la publicación");
                borrarFormulario();
            }
            catch (SqlInsertException ex) {
                transaction.Rollback();
                MessageBox.Show("Ha ocurrido un error al intentar cargar la/s publicacion/es.");
            }
        }

        private void borrarFormulario() {
            this.FechaEventoTimePicker.Value = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Date;
            this.DireccionTextBox.Text = "";
            this.RubroComboBox.SelectedItem = null;
            this.GradoPublicacionComboBox.SelectedItem = null;
            this.UbicacionesListView.Items.Clear();
            this.textBox1.Text = "";

            this.ubicacionesList.Clear();
            this.fechasDeLaPublicacion.Clear();
            this.fechasDeLaPublicacion.Add(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Date);
            direccionPublicacion = "";
            rubro = null;
            gradoPublicacion = null;
            descripcionPublicacion = "";
        }

        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha limpiado el formulario");
            borrarFormulario();
        }
    }
}
