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

namespace PalcoNet.Registro_de_Usuario
{
    public partial class Form1 : Form
    {


        private Direccion direccion;
        // CLIENTE
        private string nombre;
        private string apellido;
        private string TipoDocumento;
        private string dni;
        private string cuil;
        private string mail;
        private string telefono;
        private DateTime fechaNacimiento;
        private string numeroTarjeta;

        // EMPRESA
        private string razonSocial;
        private string mailEmpresa;
        private string telefonoEmpresa;
        private string cuit;

        public Form1()
        {
            InitializeComponent();

            TipoDocumentoDao tipoDocdao = new TipoDocumentoDao();
            tipoDocdao.getTiposDeDocumento().ForEach(elem =>
            {
                ListaTiposDocumento.Items.Add(elem);
            });

            ClienteRadioButton.Checked = true;
            EmpresaRadioButton.Checked = false;
        }

        private void getDireccionDelCliente(Direccion dir) {
            direccion = dir;
        }

        private void numeroTarjetaCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClienteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) { 
            this.SuspendLayout();
            panelCliente.Visible = true;
            PanelEmpresa.Visible = false;
            this.ResumeLayout();
            }
            
        }

        private void EmpresaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.SuspendLayout();
                PanelEmpresa.Visible = true;
                panelCliente.Visible = false;
                this.ResumeLayout();
            }

        }

        private void RazonSocialEmpresa_TextChanged(object sender, EventArgs e)
        {
            razonSocial = ((TextBox)sender).Text;
        }

        private void MailEmpresa1_TextChanged(object sender, EventArgs e)
        {
            mailEmpresa = ((TextBox)sender).Text;
        }

        private void telefonoEmpresa1_TextChanged(object sender, EventArgs e)
        {
            telefonoEmpresa = ((TextBox)sender).Text;
        }

        private void CuitEmpresa_TextChanged(object sender, EventArgs e)
        {
            cuit = ((TextBox)sender).Text;
        }

        private void NombreCliente_TextChanged(object sender, EventArgs e)
        {
            nombre = ((TextBox)sender).Text;
        }

        private void ApellidoCliente_TextChanged(object sender, EventArgs e)
        {
            apellido = ((TextBox)sender).Text;
        }

        private void ListaTiposDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDocumento = ((ComboBox)sender).SelectedItem.ToString();
        }

        private void DniCliente_TextChanged(object sender, EventArgs e)
        {
            dni = ((TextBox)sender).Text;
        }

        private void MailCliente_TextChanged(object sender, EventArgs e)
        {
            mail = ((TextBox)sender).Text;
        }

        private void TelefonoCliente_TextChanged(object sender, EventArgs e)
        {
            telefono = ((TextBox)sender).Text;
        }

        private void FechaNacimientoCli_TextChanged(object sender, EventArgs e)
        {
            fechaNacimiento = DateTime.Parse(((TextBox)sender).Text);
        }

        private void numeroTarjetaCliente_TextChanged_1(object sender, EventArgs e)
        {
            numeroTarjeta = ((TextBox)sender).Text;
        }

        private void AñadirDireccionButton_Click_1(object sender, EventArgs e)
        {
            AñadirDireccion form = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE);
            form.getDireccion += getDireccionDelCliente;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AñadirDireccion form = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA);
            form.getDireccion += getDireccionDelCliente;
            form.ShowDialog();
        }

        private void CuilCliente_TextChanged(object sender, EventArgs e)
        {
            cuil = ((TextBox)sender).Text;
        }
    }
}
