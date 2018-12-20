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
using PalcoNet.Validators;
using PalcoNet.Exceptions;
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Constants;
using PalcoNet.Validators;

namespace PalcoNet.Abm_Cliente
{
    public partial class AltaClienteForm : Form
    {

        private AñadirDireccion direccionForm;
        private readonly ErrorProvider errorProveide = new ErrorProvider();
        private Direccion dirDelCliente;
        private Cliente cli;

        public delegate void OnAcceptClientClick(int clieId);
        public event OnAcceptClientClick onAccpetClientClick;

        public AltaClienteForm(Cliente cliente)
        {
            InitializeComponent();
            TipoDocumentoDao tipoDocdao = new TipoDocumentoDao();
            tipoDocdao.getTiposDeDocumento().ForEach(elem =>
            {
                ListaTiposDocumento.Items.Add(elem);
            });
            cli = cliente;

            AñadirDireccionButton.Text = "Editar Dirección";
            direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE, cliente.direccion);
            direccionForm.getDireccion += this.getDireccionEvent;
            NombreCliente.Text = cliente.nombre;
            ApellidoCliente.Text = cliente.apellido;
            DniCliente.Text = cliente.documento;
            MailCliente.Text = cliente.mail;
            TelefonoCliente.Text = cliente.telefono;
            CuilCliente.Text = cliente.cuil;
            cli.direccion = cliente.direccion;
            ListaTiposDocumento.SelectedItem = ListaTiposDocumento.Items[ListaTiposDocumento.Items.IndexOf(cliente.TipoDocumento)];
            ListaTiposDocumento.SelectedIndex = 0;
            FechaNacimientoCliente.Value = (DateTime)cliente.fechaNacimiento;

            AceptarButton.Visible = true;
            CancelarButton.Visible = true;

        }

        public AltaClienteForm() {
            InitializeComponent();
            cli = new Cliente();
            TipoDocumentoDao tipoDocDao = new TipoDocumentoDao();
            tipoDocDao.getTiposDeDocumento().ForEach(elem =>
            {
                ListaTiposDocumento.Items.Add(elem);
            });

            direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE);
            direccionForm.getDireccion += this.getDireccionEvent;
            ListaTiposDocumento.SelectedIndex = 0;
        }

        private void getDireccionEvent(Direccion dir) {
            dirDelCliente = dir;
        }

        public Cliente getCliente() {
            if (getCamposRequeridos().Length == 0)
            {
                cli.nombre = NombreCliente.Text;
                cli.apellido = ApellidoCliente.Text;
                cli.mail = MailCliente.Text;
                cli.documento = DniCliente.Text.Trim();
                cli.telefono = TelefonoCliente.Text;
                cli.cuil = CuilCliente.Text.Trim();
                cli.direccion = dirDelCliente;
                cli.fechaCreacion = Generals.getFecha();
                cli.fechaNacimiento = FechaNacimientoCliente.Value;
                cli.TipoDocumento = ListaTiposDocumento.SelectedItem.ToString();
                return cli;
            }
            else {
                string mensaje = "Los siguientes campos son requeridos:\n\n" + getCamposRequeridos();
                MessageBox.Show(mensaje);
                return null;
            }
            
        }

        private void AñadirDireccionButton_Click(object sender, EventArgs e)
        {
            direccionForm.Show(this);
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            Cliente cliente = getCliente();
            if (this.onAccpetClientClick != null && cliente != null) {
                new ClientesDao().actualizarCliente(cliente);
                this.onAccpetClientClick(cliente.id);
                this.Close();
            }
                
                
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LimpiarButton_Click(object sender, EventArgs e)
        {
            NombreCliente.Text = "";
            ApellidoCliente.Text = "";
            MailCliente.Text = "";
            TelefonoCliente.Text = "";
            CuilCliente.Text = "";
            dirDelCliente = null;
            FechaNacimientoCliente.Value = Generals.getFecha();
            DniCliente.Text = "";
            ListaTiposDocumento.SelectedIndex = 0;
        }

        // ----------------------------- VALIDAR CAMPOS REQUERIDOS ---------------------------
        public string getCamposRequeridos() {
            string requeridos = "";

            if (NombreCliente.Text.Length == 0) requeridos += "Nombre \n";
            if (ApellidoCliente.Text.Length == 0) requeridos += "Apellido \n";
            if (DniCliente.Text.Length == 0) requeridos += "Dni \n";
            if (MailCliente.Text.Length == 0) requeridos += "Mail \n";
            if (TelefonoCliente.Text.Length == 0) requeridos += "Telefono \n";
            if (CuilCliente.Text.Length == 0) requeridos += "CUIL \n";
            if (dirDelCliente == null) requeridos += "Direccion \n";

            return requeridos;
        }

        // ---------------------- VALIDACION DE CAMPOS ---------------------------

        private void validarDni(object sender, CancelEventArgs e) { 
            if(!Validator.esNumerico(DniCliente.Text)){
                errorProveide.SetError(DniCliente, "El campo dni debe ser numerico");
                e.Cancel = true;
            }
        }

        private void validarTelefono(object sender, CancelEventArgs e) {
            if (!Validator.esTelefonoValido(TelefonoCliente.Text)) {
                errorProveide.SetError(TelefonoCliente, "El campo dni debe ser numerico");
                e.Cancel = true;
            }
        }

        private void cuilValidator(object sender, CancelEventArgs e) {
            if (!CuilValidator.validarCuit(CuilCliente.Text)) {
                errorProveide.SetError(CuilCliente, "Cuil Inválido, por favor reingreselo correctamente");
                e.Cancel = true;
            }
        }

        

       





    }
}
