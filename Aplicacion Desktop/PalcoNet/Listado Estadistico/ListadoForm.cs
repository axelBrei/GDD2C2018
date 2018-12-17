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
using PalcoNet.Dao;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoForm : Form
    {
        private string añoSeleccionado;
        private string TrimestreSeleccionado;

        public ListadoForm()
        {
            InitializeComponent();

            for (int i = Utils.getFecha().Year; i >= 2000; i--)
            {
                this.AñoComboBox.Items.Add(i.ToString());
            }

            this.AñoComboBox.SelectedIndex = 0;
            this.TrimestreComboBox.SelectedIndex = 0;
            this.EstadisticaComboBox.SelectedIndex = 0;
        }

        private void EstadisticaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int año;
                try
                {
                    año = int.Parse(this.AñoComboBox.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    año = int.Parse("2018");
                }
                int trimestre;
                try
                {
                    trimestre = int.Parse(this.TrimestreComboBox.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    trimestre = int.Parse("1");
                }
                DateTime firstDayOfQuarter = new DateTime(año, (trimestre - 1) * 3 + 1, 1);
                DateTime lastDayOfQuarter = firstDayOfQuarter.AddMonths(3).AddDays(-1);

            }
            catch (Exception ex) { 
                
            }

        }

        private void AñoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
