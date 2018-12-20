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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class AltaEmpresaForm : Form
    {
        private AñadirDireccion añadirDirForm;
        private Direccion dirEmpresa;
        private readonly ErrorProvider errorProveide = new ErrorProvider();

        public delegate void OnAcceptCompanyClick(int empId);
        public event OnAcceptCompanyClick onAccpetClientClick;

        public AltaEmpresaForm()
        {
            InitializeComponent();
            añadirDirForm = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA);
            añadirDirForm.getDireccion += this.getDireccion;
        }

        public AltaEmpresaForm(Empresa empre) {
            InitializeComponent();
            dirEmpresa = empre.direccion;

            RazonSocialEmpresa.Text = empre.razonSocial;
            MailEmpresa1.Text = empre.mailEmpresa;
            telefonoEmpresa1.Text = empre.telefonoEmpresa;
            CuitEmpresa.Text = empre.cuit;

            AñadirDirButton.Text = "Editar Dirección";

            añadirDirForm = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA, empre.direccion);
            añadirDirForm.getDireccion += this.getDireccion;

            AceptarButton.Visible = true;
            CancelarButton.Visible = true;
        }

        private void getDireccion(Direccion dir) {
            dirEmpresa = dir;
        }

        public Empresa getEmpresa() {
            Empresa empresa = new Empresa();
            if (getCamposRequeridos().Length == 0)
            {
                empresa.direccion = dirEmpresa;
                empresa.razonSocial = RazonSocialEmpresa.Text.Trim();
                empresa.mailEmpresa = MailEmpresa1.Text.Trim();
                empresa.telefonoEmpresa = telefonoEmpresa1.Text.Trim();
                empresa.cuit = CuitEmpresa.Text.Trim();
                
                return empresa;
            }
            else {
                //string mensaje = "Los siguientes campos son requeridos:\n\n" + getCamposRequeridos();
                //MessageBox.Show(mensaje);
                throw new Exception(getCamposRequeridos());
            }

            
        }

        private void AñadirDirButton_Click(object sender, EventArgs e)
        {
            añadirDirForm = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA,dirEmpresa);
            añadirDirForm.getDireccion += this.getDireccion;
            añadirDirForm.Show(this);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void LimpiarButton_Click(object sender, EventArgs e)
        {
            RazonSocialEmpresa.Text = "";
            MailEmpresa1.Text = "";
            telefonoEmpresa1.Text = "";
            CuitEmpresa.Text = "";
            dirEmpresa = null;

        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.onAccpetClientClick != null)
                    this.onAccpetClientClick((int)getEmpresa().id);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        // --------------------------- VALIDAR CAMPOS REQUERIDOS--------------------------------------------------
        public string getCamposRequeridos()
        {
            string requeridos = "";

            if (RazonSocialEmpresa.Text.Length == 0) requeridos += "Nombre \n";
            if (MailEmpresa1.Text.Length == 0) requeridos += "Mail \n";
            if (telefonoEmpresa1.Text.Length == 0) requeridos += "Telefono \n";
            if (dirEmpresa == null) requeridos += "Direccion \n";
            if (!CuilValidator.validarCuit(CuitEmpresa.Text.Trim())) requeridos += "Cuit \n";
            return requeridos;
        }
        // -------------------------------- VALIDACION DE FORMULARIO -----------------------------

        private void validarCuil(object sender, CancelEventArgs eve) {
            if (!CuilValidator.validarCuit(CuitEmpresa.Text.Trim())) {
                errorProveide.SetError(CuitEmpresa, "El cuit ingresado no es valido");
                eve.Cancel = true;
            }
        }

        private void telefonoEmpresa1_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.esTelefonoValido(telefonoEmpresa1.Text.Trim())) {
                errorProveide.SetError(telefonoEmpresa1, "El Telefono debe ser unicamente numerico");
                e.Cancel = true;
            }
        }

       

        
        
        




    }
}
