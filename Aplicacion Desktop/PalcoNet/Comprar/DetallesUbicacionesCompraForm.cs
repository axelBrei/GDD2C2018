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
using PalcoNet.Editar_Publicacion;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;
using PalcoNet.Constants;
using PalcoNet.UserData;

namespace PalcoNet.Comprar
{
    public partial class DetallesUbicacionesCompraForm : Form
    {
        private Publicacion publicacionActual;
        public List<Ubicacion> ubicacionesSeleccionadas { get; set; }

        public DetallesUbicacionesCompraForm(Publicacion publi)
        {
            InitializeComponent();
            publicacionActual = publi;
            this.UbicacionesListView.Columns.Insert(0, "Fila", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(1, "Asiento", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(2, "Tipo de Ubicacion", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(3, "Precio", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            ubicacionesSeleccionadas = new List<Ubicacion>();

            publi.ubicaciones.ForEach(elem => {
                UbicacionesListView.Items.Add(getItemDeUbicacion(elem));
            });
        }

        private ListViewItem getItemDeUbicacion(Ubicacion elem)
        {
            ListViewItem item = new ListViewItem();
            item.Text = elem.fila.ToUpper();
            item.SubItems.Add(elem.asiento.ToString());
            item.SubItems.Add(elem.tipoUbicaciones.descripcion);
            item.SubItems.Add("$" + elem.precio.ToString());

            item.Tag = elem;

            return item;
        }

        private void ItemCheckedEvent(object sender, ItemCheckedEventArgs e) {
            try
            {
                if (e.Item.Checked && !ubicacionesSeleccionadas.Contains(e.Item.Tag))
                    ubicacionesSeleccionadas.Add((Ubicacion)(e.Item.Tag));
                else if (ubicacionesSeleccionadas.Contains((Ubicacion)e.Item.Tag))
                    ubicacionesSeleccionadas.RemoveAt(e.Item.Index);

            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            foreach (var u in UbicacionesListView.CheckedItems) {
                Ubicacion ubi = (Ubicacion) ((ListViewItem)u).Tag;
                compra.total += ubi.precio;
                ubicaciones.Add(ubi);
            }
            ComprasDao comprasDao = new ComprasDao();
            SqlTransaction trans  = DatabaseConection.getInstance().BeginTransaction();

            
            compra.ubicaciones = ubicaciones;
            compra.fechaCompra = Utils.getFecha();
            compra.cantidad = ubicaciones.Count;
            Cliente clie = new Cliente();
            compra.cli = clie;
            
            
            ubicacionesSeleccionadas = ubicaciones;
            try
            {
                comprasDao.insertarCompra(compra, publicacionActual, trans);
                trans.Commit();
                MessageBox.Show("Compra realizada con exito");
            }
            catch (Exception ex) {
                trans.Rollback();
                MessageBox.Show("Ha ocurrido un error al procesar la compra");
            }
        }
    } 
}
