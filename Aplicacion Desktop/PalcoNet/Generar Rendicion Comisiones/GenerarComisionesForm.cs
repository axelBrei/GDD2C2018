using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Model;
using PalcoNet.Dao;
using PalcoNet.Exceptions;
using PalcoNet.Validators;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class GenerarComisionesForm : Form
    {
        private SeleccionarEmpresa seleccionarEmpresaForm;
        private Empresa empresaSelec;
        private Compra compraSelec;
        private List<Compra> comprasList;
        private int cantidad;

        public GenerarComisionesForm()
        {
            InitializeComponent();

            

            this.ComprasListView.Columns.Insert(0, "Id", 5 * (int)ComprasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ComprasListView.Columns.Insert(1, "Fecha", 30 * (int)ComprasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ComprasListView.Columns.Insert(2, "Medio de pago", 10 * (int)ComprasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ComprasListView.Columns.Insert(3, "Cantidad", 15 * (int)ComprasListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.ComprasListView.Columns.Insert(4, "Total", 15 * (int)ComprasListView.Font.SizeInPoints, HorizontalAlignment.Center);

            FormaPagoComboBox.Items.Clear();
            new FormasDePagoDao().getFormasDePago().ForEach(elem => {
                FormaPagoComboBox.Items.Add(elem);
            });
            FormaPagoComboBox.SelectedIndex = 0;
            

            this.CantidadComboBox.SelectedItem = "50";
        }

        private void onEmpresaSeleccionada(Empresa empresa) { 
            // BUSCAR COMPRAS DE LA EMPRESA
            empresaSelec = empresa;
            this.RazonSocialTextBox.Text = empresa.razonSocial;
            actualizarlista();
        }

        private void actualizarlista() {
            if (empresaSelec != null)
            {
                this.ComprasListView.Items.Clear();
                new ComprasDao().getComprasPorEmpresa(
                (int)empresaSelec.id,
                cantidad,
                list =>
                {
                    comprasList = list;
                    this.ComprasListView.BeginUpdate();
                    list.ForEach(elem =>
                    {
                        this.ComprasListView.Items.Add(getItemDeCompra(elem));
                    });
                    this.ComprasListView.EndUpdate();
                });
            }
            
        }

        private void limpiarFiltros() {
            this.RazonSocialTextBox.Text = "";
            this.empresaSelec = null;
        }

        private ListViewItem getItemDeCompra(Compra c)
        {
            ListViewItem item = new ListViewItem();
            item.Text = c.id.ToString();
            item.SubItems.Add(c.fechaCompra.ToString());
            item.SubItems.Add(c.medioPago.numero);
            item.SubItems.Add(c.cantidad.ToString());
            item.SubItems.Add(c.total.ToString());

            item.Tag = c;

            return item;
        }

        private void SeleccionarButton_Click(object sender, EventArgs e)
        {
            seleccionarEmpresaForm = new SeleccionarEmpresa();
            seleccionarEmpresaForm.onFinisCompanySelection += this.onEmpresaSeleccionada;
            seleccionarEmpresaForm.Show(this);
        }

        private void CantidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cantidad = int.Parse(this.CantidadComboBox.SelectedItem.ToString());
                actualizarlista();
            }
            catch (Exception ex) { }
        }

        private void updateCantidadText(object sender, EventArgs e) {
            try
            {
                cantidad = int.Parse(this.CantidadComboBox.Text);
                actualizarlista();
            }
            catch (Exception ex) { }
        }

        private void ComprasListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                compraSelec = (Compra)((ListView)sender).SelectedItems[0].Tag;
            }
            catch (Exception ex) { }
        }

        private void DetalleButton_Click(object sender, EventArgs e)
        {
            if (compraSelec != null)
            {
                Historial_Cliente.DetalleCompraForm form = new Historial_Cliente.DetalleCompraForm(new ComprasDao().getDetalleCompraPorId(compraSelec.id));
                form.Show(this);
            }
            else
                MessageBox.Show("Debe seleccinar una compra para poder ver su detalle");
        }

        private void ListaComprasButton_Click(object sender, EventArgs e)
        {
            
            actualizarlista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // REDIMIR BUTTON
            FacturasDao factDao = new FacturasDao();
            PublicacionesDao publisDao = new PublicacionesDao();
            GradoDePublicacionDao gradosDao = new GradoDePublicacionDao();
            EspectaculosDao espeDao = new EspectaculosDao();
            SqlTransaction trans = DatabaseConection.getInstance().BeginTransaction();
            try
            {

                if (empresaSelec != null)
                {
                    if (CantidadARedimirNumericDD.Value < int.Parse(CantidadComboBox.SelectedItem.ToString()))
                    {
                        for (int i = 0; i < this.CantidadARedimirNumericDD.Value; i++)
                        {
                            Compra compra = (Compra)this.ComprasListView.Items[i].Tag;
                            compra.publicacion = publisDao.getPublicacionPorId(compra.publicacion.id, trans);
                            compra.publicacion.gradoPublicacion =
                                    gradosDao.getGradoPorId(compra.publicacion.gradoPublicacion.id, trans);
                            compra.publicacion.espectaculo = espeDao.getEspectaculoPorId((int)compra.publicacion.espectaculo.id, trans);
                            new UbicacionesCompraDao().getUbicacionesDeLaCompra(compra,
                                (comprasList) => compra.ubicaciones = comprasList,
                                trans);
                            insertarFactura(trans, factDao, compra);
                        }
                        trans.Commit();
                        MessageBox.Show("Generación de comisiones exitosa!");
                    }
                    else
                    {
                        throw new Exception("La cantidad de compras a rendir debe ser menor que la cantidad seleccionadas para mostrar en la pagina");
                    }
                }
                else
                    throw new Exception("Debe seleccionar una empresa a la cual rendirle las compras realizadas");
                
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                trans.Rollback();
            }
        }

        private void insertarFactura(SqlTransaction trans,FacturasDao factDao, Compra compra){
            ItemFacturaDao itemDao = new ItemFacturaDao();
            factDao.insertarFactura(
                trans,
                this.FormaPagoComboBox.SelectedItem.ToString(),
                compra,
                (nuevoNumeroFactura) =>
                {
                    // INSERTO LOS ITEMS, UN ITEM POR CADA UBICACION
                    compra.ubicaciones.ForEach(ubic =>
                    {
                        ItemFactura item = new ItemFactura();
                        item.cantidad = 1;
                        item.descripcion = "Comision por compra";
                        item.numFactura = nuevoNumeroFactura;
                        item.monto = float.Parse(ubic.precio.ToString()) / (float)compra.publicacion.gradoPublicacion.comision;
                        item.publicacion = compra.publicacion;
                        item.ubicacion = ubic;

                        itemDao.insertarItem(item, trans);
                    });
                });
        }

        private void FormaPagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VerFacturasButton_Click(object sender, EventArgs e)
        {
            // MOSTRAR FACTURAS DEL LA EMPRESA
            if (empresaSelec != null)
            {
                VerFactuasForm form = new VerFactuasForm(empresaSelec);
                form.Show(this);
            }
            else
                MessageBox.Show("Debe seleccionar alguna empresa para poder ver sus facturas");
        }

    }
}
