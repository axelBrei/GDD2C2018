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
    public partial class SeleccionarClienteForm : Form
    {
        public Cliente clienteSeleccionado { get; set; }

        private List<Cliente> clientes = new List<Cliente>();

        public SeleccionarClienteForm()
        {
            InitializeComponent();

            this.ClientesListView.Columns.Insert(0, "Id", 10 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(1, "Nombre", 20 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(2, "Apellido", 20 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(3, "Documento", 10 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(4, "TipoDocumento", 5 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(5, "Mail", 30 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(6, "Telefono", 12 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(7, "Calle", 20 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(8, "Piso", 5 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(9, "Nacimiento", 10 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ClientesListView.Columns.Insert(10, "Puntos", 10 * (int)ClientesListView.Font.SizeInPoints, HorizontalAlignment.Center);

            ClientesDao dao = new ClientesDao();
            clientes.AddRange(dao.getClientes());
            actualizarLista("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            actualizarLista(((TextBox)sender).Text);
        }

        private void actualizarLista(string filtro) {
            List<Cliente> clieList = this.clientes.FindAll(elem =>
                        elem.nombre.ToLower().Contains(filtro.ToLower()) ||
                        elem.apellido.ToLower().Contains(filtro.ToLower()) ||
                        elem.documento.ToLower().Equals(filtro.ToLower()) ||
                        elem.mail.ToLower().Contains(filtro.ToLower())
                    );

            this.ClientesListView.BeginUpdate();
            this.ClientesListView.Items.Clear();
            clieList.ForEach(elem => this.ClientesListView.Items.Add(getItemFromClient(elem)));
            this.ClientesListView.EndUpdate();
        }

        private ListViewItem getItemFromClient(Cliente elem)
        {
            ListViewItem item = new ListViewItem();
            item.Text = elem.id.ToString();
            item.SubItems.Add(elem.nombre);
            item.SubItems.Add(elem.apellido);
            item.SubItems.Add(elem.documento);
            item.SubItems.Add(elem.TipoDocumento);
            item.SubItems.Add(elem.mail);
            item.SubItems.Add(elem.telefono);
            item.SubItems.Add(elem.direccion.calle + " " + elem.direccion.numero);
            item.SubItems.Add(elem.direccion.piso + " / " + elem.direccion.depto);
            item.SubItems.Add(elem.fechaNacimiento != null ? ((DateTime)elem.fechaNacimiento).ToString() : "");
            item.SubItems.Add(elem.puntos.ToString());

            item.ForeColor = elem.bajaLogica == null ? Color.Black : Color.Gray;

            item.Tag = elem;
            return item;
        }

        private void ClientesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clienteSeleccionado = (Cliente)((ListView)sender).SelectedItems[0].Tag;
            }
            catch (Exception ex) { }
        }
    }
}
