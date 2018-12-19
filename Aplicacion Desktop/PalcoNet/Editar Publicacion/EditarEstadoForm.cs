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
using PalcoNet.Constants;

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarEstadoForm : Form
    {
        public Publicacion publicacionActual { get; set; }
        private int preSelectedIndex;

        public EditarEstadoForm(Publicacion publicacion)
        {
            InitializeComponent();
            publicacionActual = publicacion;

            mostrarEstados();

            this.FechaDatePicker.Value = ((DateTime)publicacion.fechaPublicacion).Date;
            this.HoraDatePicker.Value = ((DateTime)publicacion.fechaPublicacion);

            this.CodigoLabel.Text = this.CodigoLabel.Text + ": " + publicacion.id;

            if (publicacion.estado == "Publicada" || publicacion.estado == "Finaliada")
            {
                FechaDatePicker.Enabled = false;
                HoraDatePicker.Enabled = false;
            }
        }

        private void EstadoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = (Item)((ComboBox)sender).SelectedItem;

            string estado = permisosEstado( item.texto );
            if (!String.IsNullOrWhiteSpace(estado))
            {
                preSelectedIndex = ((ComboBox)sender).SelectedIndex;
                publicacionActual.estado = estado;
            }
            else
                this.EstadoComboBox.SelectedIndex = preSelectedIndex;
        }

        private void FechaDatePicker_ValueChanged(object sender, EventArgs e)
        {
            publicacionActual.fechaPublicacion = ((DateTimePicker)sender).Value;
        }

        private void HoraDatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            DateTime fecha = ((DateTime)publicacionActual.fechaPublicacion).Date;
            fecha = fecha.AddHours(picker.Value.Hour);
            fecha = fecha.AddMinutes(picker.Value.Minute);

            publicacionActual.fechaPublicacion = fecha;
        }

        private string permisosEstado(string nuevoEstado) {
            string estado = nuevoEstado.ToLower();
            if(publicacionActual.estado.ToLower().Equals(Strings.ESTADO_FINALIZADA.ToLower()) 
                    && estado.ToLower().Equals(Strings.ESTADO_FINALIZADA.ToLower())){
                accionNuevoEstado();
                return null;
            }else if(publicacionActual.estado.ToLower().Equals(Strings.ESTADO_ACTIVA.ToLower()) 
                    && estado.ToLower().Equals(Strings.ESTADO_BORRADOR.ToLower())){
                accionNuevoEstado();
                return null;
            }else{
                return nuevoEstado;
            }
        }

        private void accionNuevoEstado() {
            MessageBox.Show("No se pude pasar la publicacion a un estado anterior");
        }

        private void mostrarEstados() {

            this.EstadoComboBox.Items.Add(new Item(Strings.ESTADO_ACTIVA));
            this.EstadoComboBox.Items.Add(new Item(Strings.ESTADO_BORRADOR));
            this.EstadoComboBox.Items.Add(new Item(Strings.ESTADO_FINALIZADA));

            if (Strings.ESTADO_ACTIVA.ToLower().Equals(publicacionActual.estado.ToLower()))
            {
                this.EstadoComboBox.SelectedIndex = 0;
            }
            else if (Strings.ESTADO_BORRADOR.ToLower().Equals(publicacionActual.estado.ToLower()))
            {
                this.EstadoComboBox.SelectedIndex = 1;
            }
            else
            {
                this.EstadoComboBox.SelectedIndex = 2;
            }
        }

        private class Item {
            public string texto { get; set; }

            public Item(string text) {
                texto = text;
            }

            public override string ToString()
            {
                return this.texto;
            }
        }
    }
}
