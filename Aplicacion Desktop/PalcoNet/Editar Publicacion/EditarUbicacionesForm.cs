using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using PalcoNet.Constants;
using PalcoNet.UserData;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Model;

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarUbicacionesForm : Form
    {

        public List<Ubicacion> agregadas { set; get; }
        public List<Ubicacion> eliminadas { set; get; }

        private Ubicacion ubiSeleccionada { get; set; }
        private int indexSeleccionado;

        public EditarUbicacionesForm(List<Ubicacion> ubicaciones)
        {
            InitializeComponent();

            agregadas = new List<Ubicacion>();
            eliminadas = new List<Ubicacion>();

            this.UbicacionesListView.Columns.Insert(0, "Fila", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(1, "Asiento", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(2, "Tipo de Ubicacion", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(3, "Precio", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(3, "Enumerada", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);

            ubicaciones.ForEach(elem => {
                this.UbicacionesListView.Items.Add(getItemDeUbicacion(elem));
            });

        }

        private ListViewItem getItemDeUbicacion(Ubicacion elem)
        {
            ListViewItem item = new ListViewItem();
            item.Text = elem.fila.ToUpper();
            item.SubItems.Add(elem.asiento.ToString());
            item.SubItems.Add(elem.tipoUbicaciones.descripcion);
            item.SubItems.Add("$" + elem.precio.ToString());
            item.SubItems.Add(elem.sinEnumerar == 1 ? "Si" : "No");
            item.Tag = elem;

            return item;
        }

        private void AgregarUbicacionButton_Click(object sender, EventArgs e)
        {
            AñadirUbicacionForm form = new AñadirUbicacionForm();
            form.onFinishregistration += this.añadirUbicacionesALista;
            form.ShowDialog(this);
        }

        public void añadirUbicacionesALista(List<Ubicacion> ubis){
            agregadas.AddRange(ubis);
            ubis.ForEach(elem =>
            {
                this.UbicacionesListView.Items.Add(getItemDeUbicacion(elem));
            });
        }

        private void UbicacionesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ubiSeleccionada = ((Ubicacion)((ListView)sender).SelectedItems[0].Tag);
                indexSeleccionado = ((ListView)sender).SelectedIndices[0];
            }
            catch (Exception ex) { }
        }

        private void ModificarButtton_Click(object sender, EventArgs e)
        {
            if (ubiSeleccionada != null)
            {
                AñadirUbicacionForm form = new AñadirUbicacionForm(ubiSeleccionada);
                form.onFinishregistration += this.onFinishModification;
                form.ShowDialog(this);
            }
            else
                MessageBox.Show("Debe seleccionar una ubicación");
        }
        private void onFinishModification(List<Ubicacion> ubis) {
            eliminadas.Add(ubis[0]);

            this.UbicacionesListView.BeginUpdate();

                this.UbicacionesListView.Items.RemoveAt(indexSeleccionado);
                this.UbicacionesListView.Items.Insert(indexSeleccionado, getItemDeUbicacion(ubis[0]));

            this.UbicacionesListView.EndUpdate();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            this.UbicacionesListView.BeginUpdate();
                for (int i = 0; i < UbicacionesListView.SelectedItems.Count; i++) {
                    Ubicacion elem = (Ubicacion)UbicacionesListView.SelectedItems[i].Tag;

                    eliminadas.Add(elem);

                    UbicacionesListView.Items.RemoveAt(UbicacionesListView.SelectedIndices[i]);
                }
            this.UbicacionesListView.EndUpdate();
        }

        // METODOS PARA OBTENER DATOS

        public List<Ubicacion> getAgregadas() {
            return agregadas.Count == 0 ? null : agregadas;
        }

        public List<Ubicacion> getElminadas() {
            return eliminadas.Count == 0 ? null : eliminadas;
        }
    }
}
