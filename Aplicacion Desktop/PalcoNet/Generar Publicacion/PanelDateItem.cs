using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class PanelDateItem : Form
    {
        public delegate void OnDateChange(DateTime date, int index);
        public event OnDateChange onDateChange;

        public delegate void OnCheckedChange(bool newState, int index);
        public event OnCheckedChange onCheckedChange;

        private DateTime fecha;
        private DateTime fechaAnterior;
        private int index;

        public PanelDateItem(DateTime lastDate, int index)
        {
            InitializeComponent();
            this.fechaAnterior = lastDate;
            this.index = index;
            this.CheckboxHabilitado.Checked = true;
            this.PickerFecha.MinDate = fechaAnterior;
            this.PickerFecha.Value = fechaAnterior;

            this.PickerHora.MinDate = fechaAnterior;
            this.PickerHora.Value = fechaAnterior;

            this.ItemId.Text = "item " + index.ToString();
        }

        public DateTime getFecha() {
            return fecha;
        }
        public bool getChecked() {
            return CheckboxHabilitado.Checked;
        }
        public void setFecha(DateTime date) {
            this.fechaAnterior = date;
            this.PickerHora.Value = date;
            this.PickerFecha.Value = date;
        }
        private void CheckboxHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (this.onCheckedChange != null)
                this.onCheckedChange(checkbox.Checked, index);
            if (checkbox.Checked)
            {
                this.PickerFecha.Enabled = true;
                this.PickerHora.Enabled = true;
            }
            else {
                this.PickerFecha.Enabled = false;
                this.PickerHora.Enabled = false;
            }
        }

        private void PickerFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            try
            {
                if (picker.Value.Date.CompareTo(fechaAnterior.Date) < 0)
                {
                    MessageBox.Show("La fecha introducida es anterior a la fecha ya establecida anteriormente");
                }
                else { 
                    fecha = picker.Value.Date;
                    if (this.onDateChange != null)
                        this.onDateChange(fecha, index);
                }
                


            }
            catch (Exception ex) { }
        }

        private void PickerHora_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            try
            {
                if (picker.Value.TimeOfDay.CompareTo(fechaAnterior.TimeOfDay) < 0)
                {
                    MessageBox.Show("La fecha introducida es anterior a la fecha ya establecida anteriormente");
                }
                else {
                    fecha = fecha.AddHours(picker.Value.Hour);
                    fecha = fecha.AddMinutes(picker.Value.Minute);
                    if (this.onDateChange != null)
                        this.onDateChange(fecha, index);
                }
                
            }
            catch (Exception ex) { }
        }


    }
}
