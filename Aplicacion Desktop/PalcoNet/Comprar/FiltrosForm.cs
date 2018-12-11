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

namespace PalcoNet.Comprar
{
    public partial class FiltrosForm : Form
    {
        public const int DESCRIPCION = 0;
        public const int RUBROS = 1;
        public const int FECHAS = 2;
       

        public delegate void OnFilterSelected(int tipo, string desc = null, 
                                                List<Rubro> rubros = null, 
                                                Nullable<DateTime> fechaInicio = null, 
                                                Nullable<DateTime> fechaFin = null);
        public event OnFilterSelected onFilterSelected;

        private RubrosDao rubrosDao;



        public FiltrosForm()
        {
            InitializeComponent();

            rubrosDao = new RubrosDao();

            rubrosDao.getRubros().ForEach(elem => {
                this.RubrosListView.Items.Add(elem, false);
            });

            this.DescripcionFilterTextBox.Enabled = true;
            this.FechaIDatePicker.Enabled = false;
            this.FechaFDatePicker.Enabled = false;
            this.RubrosListView.Enabled = false;
        }

        private void DescRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.DescripcionFilterTextBox.Enabled = ((RadioButton)sender).Checked;
        }

        private void FechasRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ((RadioButton)sender).Checked;
            this.FechaIDatePicker.Enabled = check;
            this.FechaFDatePicker.Enabled = check;
        }

        private void RubrosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.RubrosListView.Enabled = ((RadioButton)sender).Checked;
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if(this.onFilterSelected != null){
                if (this.DescRadioButton.Checked) {
                    this.onFilterSelected(DESCRIPCION, this.DescripcionFilterTextBox.Text.ToString());
                }
                else if (this.FechasRadioButton.Checked) {
                    this.onFilterSelected(FECHAS,fechaInicio: this.FechaIDatePicker.Value, fechaFin: this.FechaFDatePicker.Value);
                }
                else if (this.RubrosRadioButton.Checked) {

                    List<Rubro> rubros = new List<Rubro>();

                    foreach (Object o in this.RubrosListView.CheckedItems) {
                        Rubro rub = o as Rubro;
                        rubros.Add(rub);
                    }
                    this.onFilterSelected(RUBROS,rubros:rubros);
                }
                this.Hide();
            }
        }
    }
}
