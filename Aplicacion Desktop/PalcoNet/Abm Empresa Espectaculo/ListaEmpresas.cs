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
using PalcoNet.Exceptions;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ListaEmpresas : Form
    {
        private Empresa empresaSeleccionada;
        private int indexEmpresaSeleccionada;

        public ListaEmpresas()
        {
            InitializeComponent();
            EmpresasDao empresasDa = new EmpresasDao();

            this.EmpresasListView.Columns.Insert(0, "Id", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(1, "Usuario", 20 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(2, "Razon Social", 20 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(3, "CUIT", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(4, "Mail", 30 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(5, "Telefono", 30 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(6, "Calle", 12 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(7, "Altura", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(8, "Piso", 5 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(9, "Ciudad", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);

            empresasDa.getEmpresas().ForEach(elem => {
                EmpresasListView.Items.Add(getItemEmpresa(elem));
            });
        }

        private ListViewItem getItemEmpresa(Empresa empresa){
            ListViewItem item = new ListViewItem();
            item.Text = empresa.id.ToString();
            item.SubItems.Add(empresa.usuario);
            item.SubItems.Add(empresa.razonSocial);
            item.SubItems.Add(empresa.cuit);
            item.SubItems.Add(empresa.mailEmpresa);
            item.SubItems.Add(empresa.telefonoEmpresa);
            item.SubItems.Add(empresa.direccion.calle);
            item.SubItems.Add(empresa.direccion.numero);
            item.SubItems.Add(empresa.direccion.piso);
            item.SubItems.Add(empresa.direccion.ciudad);

            item.ForeColor = empresa.bajaLogica == null ? Color.Black : Color.Gray;

            item.Tag = empresa;


            return item;
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            RegistrarUsuario form = new RegistrarUsuario(RegistrarUsuario.TIPO_EMPRESA);
            form.onFinishregistration += this.updateEmpresasAfterInsert;
            form.Show(this);

        }

        private void updateEmpresasAfterInsert() {
            try {
                EmpresasDao empresasDao = new EmpresasDao();
                empresasDao.getEmpresasMayoresAId(EmpresasListView.Items.Count - 1).ForEach(elem =>
                {
                    EmpresasListView.Items.Add(getItemEmpresa(elem));
                }); 
            }catch(DataNotFoundException ex){
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("No se ha podido actualizar la lista", "ERROR!", alert);
            }
        }

        

        private void EmpresasListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lista = sender as ListView;
            try {
                empresaSeleccionada = (Empresa) lista.SelectedItems[0].Tag;
                indexEmpresaSeleccionada = lista.SelectedIndices[0];

                if (empresaSeleccionada.bajaLogica == null)
                {
                    DeshabilitarButton.Text = "Deshabilitar";
                }
                else {
                    DeshabilitarButton.Text = "Habilitar";
                }
            }catch(Exception ex){
            
            }
         }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            RegistrarUsuario form = new RegistrarUsuario(empresaSeleccionada);
            form.onFinisUpdate += this.onFinishUpdateEmpresa;
            form.Show(this);
        }
        
        private void onFinishUpdateEmpresa(int id) {
            EmpresasDao empresasDao = new EmpresasDao();
            Empresa empresa = new Empresa();
            empresa = empresasDao.getEmpresaPorId(id);
            reemplazarEnLista(empresa);
        }

        private void DeshabilitarButton_Click(object sender, EventArgs e)
        {
            EmpresasDao empresasDao = new EmpresasDao();
            bool habilitado = empresaSeleccionada.bajaLogica == null;
            try
            {
                if (habilitado)
                {
                    empresaSeleccionada.bajaLogica = DateTime.Now;
                }
                else
                {
                    empresaSeleccionada.bajaLogica = null;
                }
                empresasDao.habilitarODesahabilitarEmpresa(empresaSeleccionada);
                reemplazarEnLista(empresaSeleccionada);
            }
            catch (SqlException ex)
            {
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("No se ha podido deshabilitar la empresa seleccionada", "ERROR!", alert);
            }
            finally {
                ((ListViewItem)EmpresasListView.Items[indexEmpresaSeleccionada]).ForeColor = !habilitado ? Color.Black : Color.Gray;
            }
        }

        private void reemplazarEnLista(Empresa empresa) {
            EmpresasListView.BeginUpdate();
                EmpresasListView.Items.RemoveAt(indexEmpresaSeleccionada);
                EmpresasListView.Items.Insert(indexEmpresaSeleccionada, getItemEmpresa(empresa));
            EmpresasListView.EndUpdate();
        }
    }
}
