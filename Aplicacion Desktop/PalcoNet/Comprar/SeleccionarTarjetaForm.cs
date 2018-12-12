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
    public partial class SeleccionarTarjetaForm : Form
    {
        public Tarjeta tarjetaSeleccionada { get; set; }
        public List<Tarjeta> tarjetas {
            set {
                value.ForEach(elem =>
                {
                    this.TarjetasListView.Items.Add(creatItemDeTarjeta(elem));
                });
            }
        }
        public Cliente cliente {
            set {
                tarjetasDao.getTardejtasDelCliente(value.id).ForEach(
                    elem => this.TarjetasListView.Items.Add(creatItemDeTarjeta(elem))
                    );
            }
        }
        private TarjetasDao tarjetasDao;

        public SeleccionarTarjetaForm()
        {
            InitializeComponent();
            tarjetasDao = new TarjetasDao();

            this.TarjetasListView.Columns.Insert(0, "Id", 6 * (int)TarjetasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.TarjetasListView.Columns.Insert(1, "Titular", 20 * (int)TarjetasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.TarjetasListView.Columns.Insert(2, "Numero", 15 * (int)TarjetasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.TarjetasListView.Columns.Insert(3, "Vencimiento", 15 * (int)TarjetasListView.Font.SizeInPoints, HorizontalAlignment.Center);

            
        }


        private ListViewItem creatItemDeTarjeta(Tarjeta tarj) {
            ListViewItem item = new ListViewItem();

            item.Text = tarj.id.ToString();
            item.SubItems.Add(tarj.titular);
            item.SubItems.Add(tarj.numero);
            item.SubItems.Add(tarj.vencimiento);

            item.Tag = tarj;

            return item;
        }

        private void TarjetasListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            try
            {
                tarjetaSeleccionada = (Tarjeta)((ListViewItem)list.SelectedItems[0]).Tag;
            }
            catch (Exception ex) { }
        }

        private void SeleccionarTarjetaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
