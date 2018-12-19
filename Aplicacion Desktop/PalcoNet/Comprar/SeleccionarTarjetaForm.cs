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
        private IngresarTarjetaForm form;
        public List<Tarjeta> tarjetas {
            set {
                this.TarjetasListView.Items.Clear();
                value.ForEach(tarj => {
                    this.TarjetasListView.Items.Add(creatItemDeTarjeta(tarj));
                });
            }
        }
        public Cliente cliente
        {
            get;
            set;
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

        private void button1_Click(object sender, EventArgs e)
        {
            form = new IngresarTarjetaForm();
            form.cli = cliente;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Button button = Utils.crearBoton("Aceptar");
            button.ForeColor = Color.Black;
            button.Location = new Point(428, 384);
            button.Size = new Size(75,30);
            button.Click += this.OnClickAceptarTarjeta;
            form.Controls.Add(button);
            form.Show(this);
        }

        private void OnClickAceptarTarjeta(object sender, EventArgs e) {
            if (esTarjetaValida(form.tarjeta).Length != 0)
            {
                MessageBox.Show("Debe completar los campos requeridos: \n\n:" + esTarjetaValida(form.tarjeta));
            }
            else {
                new TarjetasDao().insertarTarjetaDeCliente(form.tarjeta, cliente.id);
                TarjetasListView.Items.Clear();
                new TarjetasDao().getTardejtasDelCliente(cliente.id).ForEach(elem =>
                {
                    TarjetasListView.Items.Add(creatItemDeTarjeta(elem));
                });
                form.Close();
            }
        }

        private void EliminarTarjetaButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea eliminar la tarjeta", "Advertencia", MessageBoxButtons.YesNo))
            {
                tarjetasDao.elminarTarjetaDelCliente(cliente.id, tarjetaSeleccionada.id);
                tarjetaSeleccionada = null;
                TarjetasListView.Items.Clear();
                tarjetasDao.getTardejtasDelCliente(cliente.id).ForEach(elem => { 
                    TarjetasListView.Items.Add(creatItemDeTarjeta(elem));
                });

            }
        }


        private string esTarjetaValida(Tarjeta tar) {
            string res = "";
            if(tar.numero.Length == 0) res += "Numero de tarjeta \n";
            if (tar.titular.Length == 0) res += "Nombre del titular \n";
            if (tar.vencimiento.Length == 9) res += "Vencimiento \n";
            if (tar.vcc.Length == 0) res += "Codigo de seguridad \n";

            return res;
        }

        
    }
}
