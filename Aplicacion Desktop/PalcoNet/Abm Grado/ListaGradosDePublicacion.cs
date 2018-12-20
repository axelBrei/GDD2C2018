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
using System.Data;
using PalcoNet.Constants;

namespace PalcoNet.Abm_Grado
{
    public partial class ListaGradosDePublicacion : Form
    {
        private GradoPublicacion gradoSeleccionado;
        private int indexSeleccionado;
        private GradoDePublicacionDao dao = new GradoDePublicacionDao();

        public ListaGradosDePublicacion()
        {
            InitializeComponent();

            this.GradosListView.Columns.Insert(0, "Nombre", 10 * (int)GradosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.GradosListView.Columns.Insert(1, "Comision", 60 * (int)GradosListView.Font.SizeInPoints, HorizontalAlignment.Center);

            dao.getGradosDePublicacion().ForEach(elem => {
                GradosListView.Items.Add(getItemFromGrado(elem));
            }); 
        }

        private ListViewItem getItemFromGrado(GradoPublicacion grado) {
            ListViewItem item = new ListViewItem();
            item.Name = grado.nivel;
            item.Text = grado.nivel;
            item.SubItems.Add(grado.comision.ToString());

            item.ForeColor = grado.bajaLogica != null ? Color.Gray : Color.Black;

            item.Tag = grado;

            return item;

        }

        private void onAcceptNewGrade(GradoPublicacion grado, int index) {
            

            if (index != -1){
                GradosListView.BeginUpdate();
                    GradosListView.Items.RemoveAt(index);
                    this.GradosListView.Items.Insert(index, getItemFromGrado(grado));
                    this.GradosListView.Sort();
                GradosListView.EndUpdate();

                dao.actualizarGradoDePublicacion(grado);
            }
            else{
                // VERIFICAR Q NO ESTE YA EN LA LISTA
                if (GradosListView.Items.Find(grado.nivel, true).Length == 0)
                {
                    this.GradosListView.Items.Add(getItemFromGrado(grado));
                    dao.insertGradoDePublicacion(grado);
                }
                else {
                    MessageBox.Show("El grado de publicación que quiere agregar ya existe");
                }
                
            }
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarGradoButton_Click(object sender, EventArgs e)
        {
            AgregarGradoForm form = new AgregarGradoForm();
            form.onClickAcept += this.onAcceptNewGrade;
            form.Show(this);
        }

        private void ModificarGradoButton_Click(object sender, EventArgs e)
        {
            if (gradoSeleccionado != null)
            {
                AgregarGradoForm form = new AgregarGradoForm(gradoSeleccionado, indexSeleccionado);
                form.onClickAcept += this.onAcceptNewGrade;
                form.Show(this);
            }
            else
                MessageBox.Show("Debe seleccionar un grado de publicación para poder modificarlo");
            
        }

        private void GradosListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lista = sender as ListView;

            try
            {
                gradoSeleccionado = (GradoPublicacion)lista.SelectedItems[0].Tag;
                indexSeleccionado = lista.SelectedIndices[0];
                DeshabilitarGradoButton.Text = gradoSeleccionado.bajaLogica == null ? "Deshabilitar" : "Habilitar";
            }
            catch (Exception ex) { }
        }

        private void DeshabilitarGradoButton_Click(object sender, EventArgs e)
        {
            try
            {
                GradosListView.Items[indexSeleccionado].ForeColor = gradoSeleccionado.bajaLogica == null ? Color.Gray : Color.Black;
                if (gradoSeleccionado.bajaLogica == null)
                    gradoSeleccionado.bajaLogica = Generals.getFecha().Date;
                else
                    gradoSeleccionado.bajaLogica = null;
                dao.habilitarODeshabilitarGrado(gradoSeleccionado);

                GradosListView.BeginUpdate();
                GradosListView.Items.RemoveAt(indexSeleccionado);
                GradosListView.Items.Insert(indexSeleccionado, getItemFromGrado(gradoSeleccionado));
                GradosListView.EndUpdate();
            }
            catch (Exception ex) {
                MessageBox.Show("Debe seleccionar algún grado de publicación para poder habilitarlo o deshabilitarlo");
            }
        }
    }
}
