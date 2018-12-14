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

namespace PalcoNet.Canje_Puntos
{
    public partial class PremiosListForm : Form
    {
        private PuntosDao puntosDao;
        private Premio premioActual;
        private Cliente cliente;

        public delegate void OnCanjePress(int puntosCanjeados);
        public event OnCanjePress onCanjePress;

        public PremiosListForm(Cliente clie)
        {
            InitializeComponent();
            puntosDao = new PuntosDao();
            cliente = clie;

            this.PremiosListView.Columns.Insert(0, "Id", 5 * (int)PremiosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PremiosListView.Columns.Insert(1, "Nombre", 30 * (int)PremiosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PremiosListView.Columns.Insert(2, "Puntos necesarios", 10 * (int)PremiosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.PremiosListView.Columns.Insert(3, "Dispoible hasta", 15 * (int)PremiosListView.Font.SizeInPoints, HorizontalAlignment.Center);

            puntosDao.getPremiosPorPuntos().ForEach(elem => {
                this.PremiosListView.Items.Add(getItemFromPremio(elem));
            });
        }

        private ListViewItem getItemFromPremio(Premio pre) {
            ListViewItem item = new ListViewItem();
            item.Text = pre.id.ToString();
            item.SubItems.Add(pre.nombre);
            item.SubItems.Add(pre.puntosNecesarios.ToString());
            item.SubItems.Add(pre.fechaVencimiento.ToShortDateString());

            item.Tag = pre;

            return item;
        }

        private void CanjearButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                    "Desea realiar el canje de " + premioActual.nombre + "?",
                    "Confirmacion del canje",
                    MessageBoxButtons.YesNo
                );
            if (result == DialogResult.Yes) { 
                // CANJEO LOS PUNTOS (SE LOS RESTO AL USUARIO)
                try
                {
                    puntosDao.canjearPuntos(cliente.id, premioActual.puntosNecesarios);
                    MessageBox.Show("Puntos canjeados con exito!");
                    if (this.onCanjePress != null)
                        this.onCanjePress((int)cliente.puntos - premioActual.puntosNecesarios);
                }
                catch (Exception ex) {
                    MessageBox.Show("Error al canjear los puntos intente de nuevo mas tarde.");
                }
            }
        }

        private void PremiosListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                premioActual = (Premio)((ListView)sender).SelectedItems[0].Tag;
                if (premioActual.puntosNecesarios > cliente.puntos)
                    this.CanjearButton.Enabled = false;
                else
                    this.CanjearButton.Enabled = true;
            }
            catch (Exception ex) { }
        }
    }
}
