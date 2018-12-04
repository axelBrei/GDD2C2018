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

namespace PalcoNet.Abm_Rubro
{
    public partial class ListadoRubros : Form
    {
        public ListadoRubros()
        {
            InitializeComponent();

            this.RubrosListView.Columns.Insert(0, "Id", 10 * (int)RubrosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.RubrosListView.Columns.Insert(1, "Descripcion", 50 * (int)RubrosListView.Font.SizeInPoints, HorizontalAlignment.Center);

            RubrosDao rubrosDao = new RubrosDao();
            rubrosDao.getRubros().ForEach(elem => {
                RubrosListView.Items.Add(getItemFromRubro(elem));
            });
        }

        private ListViewItem getItemFromRubro(Rubro rub) {
            ListViewItem item = new ListViewItem();
            item.Text = rub.id.ToString();
            item.SubItems.Add(rub.descripcion);

            item.Tag = rub;

            return item;
        }
    }
}
