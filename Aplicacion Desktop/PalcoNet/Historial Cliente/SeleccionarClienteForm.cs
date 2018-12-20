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

namespace PalcoNet.Historial_Cliente
{
    public partial class SeleccionarClienteForm : Form
    {
        private ClientesDao clientesDao;
        private List<Cliente> clientes;
        private Cliente cliSeleccionado;


        public delegate void OnSelectClient(int clieId);
        public event OnSelectClient onSelectClient;

        public SeleccionarClienteForm()
        {
            InitializeComponent();
            clientesDao = new ClientesDao();

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

            clientesDao.getClientesHabilitados((listaCli) => {
                clientes = listaCli;
                listaCli.ForEach(elem => {
                    ClientesListView.Items.Add(getItemFromClient(elem));
                });
            });
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

        private void BuscadorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox filterInput = (TextBox)sender;
                List<Cliente> clientes = this.clientes.FindAll(elem =>
                        elem.nombre.Contains(filterInput.Text) |
                        elem.apellido.Contains(filterInput.Text) |
                        elem.documento.Equals(filterInput.Text) |
                        elem.mail.Contains(filterInput.Text)
                    );

                this.ClientesListView.BeginUpdate();
                this.ClientesListView.Items.Clear();
                clientes.ForEach(elem => this.ClientesListView.Items.Add(getItemFromClient(elem)));
                this.ClientesListView.EndUpdate();
            }
            catch (Exception ex) { }
        }

        private void SeleccionarButton_Click(object sender, EventArgs e)
        {
            if (cliSeleccionado != null)
            {
                HistorialCliente form = new HistorialCliente(cliSeleccionado.id, 2);
                form.onBackPress += this.onBackPressComprasDelCliente;
                if (this.onSelectClient != null)
                {
                    this.Hide();
                    this.onSelectClient(cliSeleccionado.id);
                }
            }
            else
                MessageBox.Show("Debe seleccionar un cliente para poder ver su historial");
        }

        private void ClientesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cliSeleccionado = (Cliente)((ListView)sender).SelectedItems[0].Tag;
            }
            catch (Exception ex) { }
        }

        private void onBackPressComprasDelCliente(){
            this.Show();
        }

    }
}
