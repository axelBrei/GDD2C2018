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


namespace PalcoNet.Generar_Publicacion
{
    public partial class SeleccionarEmpresa : Form
    {
        private List<Empresa> empresas;
        private Empresa empresaSeleccionada;
        private EmpresasDao empresasDao;

        public delegate void OnFinishCompanySelection(Empresa empresa);
        public event OnFinishCompanySelection onFinisCompanySelection;

        public SeleccionarEmpresa()
        {
            InitializeComponent();

            empresasDao = new EmpresasDao();

            this.EmpresasListView.Columns.Insert(0, "Id", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(1, "Razon Social", 20 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(2, "CUIT", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(3, "Mail", 30 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(4, "Telefono", 30 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(5, "Calle", 12 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(6, "Altura", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(7, "Piso", 5 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(8, "Ciudad", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);

            empresas = new List<Empresa>();
            empresasDao.getEmpresas().ForEach(elem => {
                empresas.Add(elem);
                this.EmpresasListView.Items.Add(getItemEmpresa(elem));
            });

        }

        public SeleccionarEmpresa(List<Empresa> empresasList) {
            this.EmpresasListView.Columns.Insert(0, "Id", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(1, "Razon Social", 20 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(2, "CUIT", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(3, "Mail", 30 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(4, "Telefono", 30 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(5, "Calle", 12 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(6, "Altura", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(7, "Piso", 5 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.EmpresasListView.Columns.Insert(8, "Ciudad", 10 * (int)EmpresasListView.Font.SizeInPoints, HorizontalAlignment.Center);

            empresas.AddRange(empresasList);
            empresasList.ForEach(elem => {
                this.EmpresasListView.Items.Add(getItemEmpresa(elem));
            });
        }

        private ListViewItem getItemEmpresa(Empresa empresa)
        {
            ListViewItem item = new ListViewItem();
            item.Text = empresa.usuario;
            item.SubItems.Add(empresa.razonSocial);
            item.SubItems.Add(empresa.cuit);
            item.SubItems.Add(empresa.mailEmpresa);
            item.SubItems.Add(empresa.telefonoEmpresa);
            item.SubItems.Add(empresa.direccion.calle);
            item.SubItems.Add(empresa.direccion.numero);
            item.SubItems.Add(empresa.direccion.piso);
            item.SubItems.Add(empresa.direccion.ciudad);


            item.Tag = empresa;


            return item;
        }

        private void EmpresasListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            try
            {
                empresaSeleccionada = ((Empresa)list.SelectedItems[0].Tag);
            }
            catch (Exception ex) { }
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (this.onFinisCompanySelection != null)
            {
                this.onFinisCompanySelection(empresaSeleccionada);
                this.Close();
            }
            else {
                MessageBox.Show("Debe seleccionar una empresa para continuar");
            }
                

        }
    }
}
