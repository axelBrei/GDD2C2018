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
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Constants;

namespace PalcoNet.Abm_Cliente
{
    public partial class ListadoClientesForm : Form
    {
        private Cliente clienteSeleccionado;
        private List<Cliente> listaClientes = new List<Cliente>();
        private int indexClienteSeleccionado;

        public ListadoClientesForm()
        {
            InitializeComponent();

            this.ListaCliente.Columns.Insert(0, "Id", 10 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(1, "Nombre", 20 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(2, "Apellido", 20 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(3, "Documento", 10 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(4, "TipoDocumento", 5 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(5, "Mail", 30 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(6, "Telefono", 12 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(7, "Calle", 20 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(8, "Piso", 5 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(9, "Nacimiento", 10 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ListaCliente.Columns.Insert(10, "Puntos", 10 * (int)ListaCliente.Font.SizeInPoints, HorizontalAlignment.Center);
            

            ClientesDao clientesDao = new ClientesDao();
            listaClientes = clientesDao.getClientes();
            listaClientes.ForEach(elem => {
                
                ListaCliente.Items.Add(getItemFromClient(elem));
            });


        }

        private void FiltroClientesTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox filterInput = (TextBox)sender;
                List<Cliente> clientes = this.listaClientes.FindAll(elem =>
                        elem.nombre.ToLower().Contains(filterInput.Text.ToLower()) |
                        elem.apellido.ToLower().Contains(filterInput.Text.ToLower()) |
                        elem.documento.ToLower().Equals(filterInput.Text.ToLower()) |
                        elem.mail.ToLower().Contains(filterInput.Text.ToLower())
                    );

                this.ListaCliente.BeginUpdate();
                this.ListaCliente.Items.Clear();
                clientes.ForEach(elem => this.ListaCliente.Items.Add(getItemFromClient(elem)));
                this.ListaCliente.EndUpdate();
            }
            catch (Exception ex) { }
        }

        private ListViewItem getItemFromClient(Cliente elem) {
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

            item.ForeColor = elem.bajaLogica == null ? Color.Black :  Color.Gray;

            item.Tag = elem;
            return item;
        }

        private void updateClientesAfterInsert() {
            ClientesDao clientesDao = new ClientesDao();
            clientesDao.getClientesMayoresAId(listaClientes.Count - 1).ForEach(elem => {
                listaClientes.Add(elem);
                ListaCliente.Items.Add(getItemFromClient(elem));
            });
        }

        private void onFinishUpdateClient(int clieID) { 
            ClientesDao clientesDao = new ClientesDao();
            Cliente cli = clientesDao.getClientePorId(clieID);
            listaClientes.Insert(indexClienteSeleccionado, cli);
            ListaCliente.BeginUpdate();
                ListaCliente.Items.RemoveAt(indexClienteSeleccionado);
                ListaCliente.Items.Insert(indexClienteSeleccionado, getItemFromClient(cli));
            ListaCliente.EndUpdate();
        }

        private void agregarClienteButton_Click(object sender, EventArgs e)
        {
            RegistrarUsuario form = new RegistrarUsuario(RegistrarUsuario.TIPO_CLIENTE);
            form.onFinishregistration += this.updateClientesAfterInsert;
            form.Show(this);
        }

        private void ModificarClienteButton_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado != null)
            {
                AltaClienteForm form = new AltaClienteForm(clienteSeleccionado);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                form.onAccpetClientClick += this.onFinishUpdateClient;
                form.Show(this);
                clienteSeleccionado = null;
            }
            else {
                MessageBox.Show("Debe seleccionar un cliente para poder modificarlo.");
            }
        }

        private void onFormCloseNewClient(object sender, FormClosedEventArgs eve) {
            ListaCliente.BeginUpdate();
                ClientesDao clieDao = new ClientesDao();
                clieDao.getClientesMayoresAId(((Cliente)ListaCliente.Items[ListaCliente.Items.Count].Tag).id).ForEach(elem =>
                {
                    ListaCliente.Items.Add(getItemFromClient(elem));
                });
            ListaCliente.EndUpdate();
        }

        private void ListaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lista = sender as ListView;
            try { 
                clienteSeleccionado = (Cliente)lista.SelectedItems[0].Tag;
                indexClienteSeleccionado = lista.SelectedItems[0].Index;

                bool isHabilitado = clienteSeleccionado.bajaLogica == null;
                DeshabilitarClienteButton.Text = isHabilitado ? "Deshabilitar" : "Habilitar";

            }
            catch (Exception ex) { }
        }

        private void DeshabilitarClienteButton_Click(object sender, EventArgs e)
        {
            ClientesDao clientesDao = new ClientesDao();
            try
            {
                bool isHabilitado = clienteSeleccionado.bajaLogica == null;
                if (!isHabilitado) clienteSeleccionado.bajaLogica = Generals.getFecha();
                clientesDao.habilitarODesabilitarCliente(clienteSeleccionado);
                ((ListViewItem)ListaCliente.SelectedItems[0]).ForeColor = isHabilitado ? Color.Gray : Color.Black;
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
