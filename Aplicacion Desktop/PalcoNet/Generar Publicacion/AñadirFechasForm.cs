using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Dao;
using PalcoNet.Model;


namespace PalcoNet.Generar_Publicacion
{

    public partial class AñadirFechasForm : Form
    {
        /*
         * 
         * ESTRATEGIA:
         *  - SE PUEDEN AGREGAR ELEMENTOS PERO NO QUITARLOS, PARA Q NO SEAN CONSIDERADOS SE PUEDEN DESHABILITAR
         *  - 
         * 
         */

        public delegate void OnFinishNewDates(List<DateTime> fechas, bool modificando);
        public event OnFinishNewDates onFinishDateInsertion;

        private List<PanelItem> items = new List<PanelItem>();
        private DateTime fechaAnterior;
        private bool modificando = false;

        public AñadirFechasForm(DateTime fechaAnterior)
        {
            InitializeComponent();
            this.fechaAnterior = fechaAnterior;

        }

        public AñadirFechasForm(DateTime fechaAnterior , List<DateTime> items){

            InitializeComponent();
            this.fechaAnterior = fechaAnterior;
            modificando = true;
            for (int i = 0; i < items.Count; i++) {
                DateTime item = items[i];
                addDateItem(item);
            }
        }

        private void AñadirButton_Click(object sender, EventArgs e)
        {
            addDateItem(fechaAnterior);
        }

        private void addDateItem(DateTime fecha) {
            int panelItemsCount = FechasPanel.Controls.Count;

            PanelDateItem item = new PanelDateItem(fecha, panelItemsCount);
            item.TopLevel = false;
            item.AutoScroll = true;
            item.Size = new Size(this.FechasPanel.Size.Width,37);
            item.Location = new Point(0, item.Size.Height * panelItemsCount + 1);
            item.onCheckedChange += this.onItemCheckChange;
            item.onDateChange += this.onDateChange;
            FechasPanel.Controls.Add(item);
            item.Show();
            PanelItem panelItem = new PanelItem(FechasPanel.Controls.IndexOf(item), item);
            panelItem.fecha = fecha;
            items.Add(panelItem);
            
        }

        private void onItemCheckChange(bool itemChecked, int index) {
            items[index].isChecked = itemChecked;
        }

        private void onDateChange(DateTime fecha, int index) {
            items[index].fecha = fecha;
        }

        private class PanelItem
        {
            public int index { get; set; }
            public PanelDateItem item { get; set; }
            public bool isChecked { get; set; }
            public DateTime fecha { get; set; }

            public PanelItem(int index, PanelDateItem item) {
                this.index = index;
                this.item = item;
                this.isChecked = true;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            List<DateTime> respuesta = new List<DateTime>();
            DateTime minDate = fechaAnterior;
            string elementosACorregirFecha = "";
            List<DateTime> remover = new List<DateTime>();
            items.ForEach(elem => {
                if (elem.isChecked) { 
                    if (minDate.CompareTo(elem.fecha) < 0)
                    {
                        minDate = elem.fecha;
                        respuesta.Add(elem.fecha);
                    }
                    else {
                        elementosACorregirFecha += elem.index + "-";
                        remover.Add(elem.fecha);
                    }
                }
                
                
            });
            respuesta.RemoveAll(el => remover.Contains(el));
            if (string.IsNullOrEmpty(elementosACorregirFecha))
            {
                if (this.onFinishDateInsertion != null)
                    this.onFinishDateInsertion(respuesta, modificando);
                    this.Close();
            }
            else {
                MessageBox.Show("Corrija las fechas de los items: " + elementosACorregirFecha.Remove(elementosACorregirFecha.Length -1));
            }
            
        }


        
    }
}
