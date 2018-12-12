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
using System.Threading;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Dao;

namespace PalcoNet.Comprar
{
    public partial class ComprarForm : Form
    {

        private DetallesCompraForm detallesForm;
        private DetallesUbicacionesCompraForm ubicacionesForm;
        private SeleccionarTarjetaForm tarjetaForm;
        private SeleccionarClienteForm clienteForm;
        private IngresarTarjetaForm ingresarTarjetaFrom;

        private List<Form> forms = new List<Form>();
        private int currentForm = 0;

        private List<Tarjeta> tarjetasDelCliente;
        private List<Ubicacion> ubicacionesAComprar;
        private Cliente clienteActual;
        private Tarjeta tarjetaParaPagar;

        private Publicacion publicacionActual;
        private Compra compraA;

        TarjetasDao tarjetasDao;


        public ComprarForm(Publicacion publi)
        {
            InitializeComponent();
            publicacionActual = publi;
            completarDatosDePublicacion(publicacionActual);

            tarjetaParaPagar = new Tarjeta();
            tarjetasDao = new TarjetasDao();

            this.BackButton.Text = "Salir";

            
            
        }

        private void completarDatosDePublicacion(Publicacion publi)
        {
            PublicacionesController controller = new PublicacionesController();
            Task.Factory.StartNew(() =>
            {
                Publicacion p = Task.Run<Publicacion>(() => controller.getPublicacionesPorIdAsync(publi.id)).Result;
                publicacionActual = p;
                detallesForm = new DetallesCompraForm(p);
                ubicacionesForm = new DetallesUbicacionesCompraForm(p);
                clienteForm = new SeleccionarClienteForm();
                ingresarTarjetaFrom = new IngresarTarjetaForm();
                tarjetaForm = new SeleccionarTarjetaForm();
                

                forms.Add(detallesForm);
                forms.Add(ubicacionesForm);
                forms.Add(clienteForm);
                forms.Add(ingresarTarjetaFrom);
                forms.Add(tarjetaForm);
                showHideForm(forms[currentForm]);
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void showHideForm(Form form)
        {
            this.ContentPanel.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            this.ContentPanel.Controls.Add(form);
            form.Show();

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currentForm <= 4) {
                if (actualizarDatosDelForm(ref currentForm)) {
                    showHideForm(forms[currentForm]);
                }
                this.NextButton.Text = "Siguiente";
                this.BackButton.Text = "Anterior";

            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (currentForm > 0) {
                currentForm--;
                if (currentForm == 0)
                    this.BackButton.Text = "Salir";
                    
                else {
                    this.BackButton.Text = "Anterior";
                    this.NextButton.Text = "Siguiente";
                }
                    
                showHideForm(forms[currentForm]);
            }else{
                this.Close();
            }
        }

        private bool actualizarDatosDelForm(ref int currentForm){
            switch(currentForm){
                case 0: {
                    currentForm = 1;
                    return true;
                }
                case 1: {
                    Usuario user = UserData.UserData.getUsuario();
                    
                   ubicacionesAComprar = ubicacionesForm.ubicacionesSeleccionadas;
                   if (ubicacionesAComprar.Count == 0) {
                       MessageBox.Show("Debe seleccionar una ubicacion para poder continuar");
                       return false;
                   }
                    if (user.usuarioRegistrable.getTipo() == UserData.UserData.TIPO_CLIENTE)
                    {
                        ClientesDao cliDao = new ClientesDao();
                        clienteActual = cliDao.getClientePorId(user.usuarioRegistrable.getId());
                        tarjetasDelCliente = tarjetasDao.getTardejtasDelCliente(clienteActual.id);
                        if (tarjetasDelCliente.Count > 0)
                        {
                            tarjetaForm.tarjetas = tarjetasDelCliente;
                            currentForm = 4;
                        }
                        else
                            currentForm = 3;
                        return true;
                    }
                    else {
                        currentForm = 2;
                        return true;
                    }
                }
                case 2: {
                    
                    clienteActual = clienteForm.clienteSeleccionado;
                    if (clienteActual == null) {
                        MessageBox.Show("Debe seleccionar un cliente para el cual realizar la compra");
                        return false;
                    }
                    tarjetasDelCliente = tarjetasDao.getTardejtasDelCliente(clienteActual.id);
                    if (tarjetasDelCliente.Count > 0){
                        tarjetaForm.tarjetas = tarjetasDelCliente;
                        currentForm = 4;
                    }
                    else
                        currentForm = 3;
                    
                    return true;
                }
                case 3: {
                    Tarjeta tarj = ingresarTarjetaFrom.tarjeta;
                    if (string.IsNullOrWhiteSpace(tarj.titular)
                    || string.IsNullOrWhiteSpace(tarj.numero)
                    || string.IsNullOrWhiteSpace(tarj.vencimiento)
                    || string.IsNullOrWhiteSpace(tarj.vcc))
                    {

                        MessageBox.Show("Debe tener todos los campos completos para poder continuar");
                        return false;
                    }
                    tarjetasDelCliente.Add(ingresarTarjetaFrom.tarjeta);
                    tarjetaForm.tarjetas = tarjetasDelCliente;
                    tarjetasDao.insertarTarjetaDeCliente(ingresarTarjetaFrom.tarjeta, clienteActual.id);
                    currentForm = 4;
                    return true;
                }
                case 4: {


                    Tarjeta tarj = tarjetaParaPagar;
                    if (!Application.OpenForms.OfType<IngresarTarjetaForm>().Any())
                    {
                        
                        tarj = tarjetaForm.tarjetaSeleccionada;
                        if (tarj == null) {
                            MessageBox.Show("Debe seleccionar un metodo de pago valido");
                            return false;
                        }
                    }
                    // CONFIRMAR COMPRA
                    Compra compra = new Compra();
                    compra.cli = clienteActual;
                    compra.ubicaciones = ubicacionesAComprar;
                    compra.fechaCompra = Constants.Utils.getFecha();
                    compra.cantidad = ubicacionesForm.ubicacionesSeleccionadas.Count;
                    ubicacionesForm.ubicacionesSeleccionadas.ForEach(elem => compra.total += elem.precio);
                    compraA = compra;
                    compra.medioPago = tarj;
                    ConfirmacionCompraForm form = new ConfirmacionCompraForm(compra, publicacionActual);
                    showHideForm(form);
                    this.BackButton.Text = "salir";
                    this.BackButton.Click += this.onPressSalir;
                    this.NextButton.Click += this.onPressConfirmar;
                    this.NextButton.Text = "Confirmar";
                    return false;
                }
                default: { return true; }
            }
            return false;
        }

        private void onPressSalir(object sender, EventArgs e) {
            this.Close();
            this.ContentPanel.Controls.Clear();
        }

        private void onPressConfirmar(object sender, EventArgs e) {
            ComprasController controller = new ComprasController();
            try
            {
                controller.insertarCompraConItems(compraA, publicacionActual);
                MessageBox.Show("Compra realizada con exito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al procesar la compra");
            }
            this.Close();
            this.ContentPanel.Controls.Clear();
        }
    }
}
