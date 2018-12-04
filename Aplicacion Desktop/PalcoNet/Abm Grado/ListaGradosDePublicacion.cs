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

namespace PalcoNet.Abm_Grado
{
    public partial class ListaGradosDePublicacion : Form
    {

        public ListaGradosDePublicacion()
        {
            InitializeComponent();

            this.GradosListView.Columns.Insert(0, "Nombre", 10 * (int)GradosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.GradosListView.Columns.Insert(1, "Comision", 60 * (int)GradosListView.Font.SizeInPoints, HorizontalAlignment.Center);

            GradoDePublicacionDao dao = new GradoDePublicacionDao();
            dao.getGradosDePublicacion().ForEach(elem => {
                GradosListView.Items.Add(getItemFromGrado(elem));
            }); 
        }

        private ListViewItem getItemFromGrado(GradoPublicacion grado) {
            ListViewItem item = new ListViewItem();
            item.Text = grado.nivel;
            item.SubItems.Add(grado.comision.ToString());

            item.Tag = grado;

            return item;

        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
