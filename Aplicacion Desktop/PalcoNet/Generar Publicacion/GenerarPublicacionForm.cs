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

namespace PalcoNet.Generar_Publicacion
{
    public partial class GenerarPublicacionForm : Form
    {
        private RubrosDao rubrosDao;

        private string direccionPublicacion;
        private string descripcionPublicacion;
        private Rubro rubro;
        private List<DateTime> fechasDeLaPublicacion = new List<DateTime>();
        private List<Ubicacion> ubicacionesList = new List<Ubicacion>();

        public GenerarPublicacionForm()
        {
            InitializeComponent();
            rubrosDao = new RubrosDao();

            rubrosDao.getRubros().ForEach(
                elem => RubroComboBox.Items.Add(elem)
            );

            this.FechaEventoTimePicker.ShowUpDown = false;
            this.FechaEventoTimePicker.CustomFormat = "yyyy.MM.dd";
            // Dia Minimo: ayer
            DateTime fechaMinima = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Date;
            this.FechaEventoTimePicker.MinDate = fechaMinima;
            this.FechaEventoTimePicker.Value = fechaMinima;


            
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
                fechasDeLaPublicacion.Insert(0, time);
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
            form.onFinishDateInsertion += this.onFinishDateInsertion;
            form.Show(this);
        }

        private void onFinishDateInsertion(List<DateTime> lista) {
            fechasDeLaPublicacion.AddRange(lista);
        }
    }
}
