﻿using System;
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

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegistrarUsuario : Form
    {

        private string usuario;
        private string contraseña;

        private Direccion direccion;
        // CLIENTE
        private int id;
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

        // TIPOS
        public static string TIPO_CLIENTE = "CLIENTE";
        public static string TIPO_EMPRESA = "EMPRESA";
        public static string TIPO_EDITAR_CLIENTE = "EDITAR_CLIENTE";
        public static string TIPO_EDITAR_EMPRESA = "EDITAR_EMPRESA";

        private string tipoUsuario;

        public delegate void OnFinishregistration();
        public event OnFinishregistration onFinishregistration;

        public delegate void OnFinishUpdate(int clieId);
        public event OnFinishUpdate onFinisUpdate;

        AñadirDireccion direccionForm;


        public RegistrarUsuario(Cliente cliente) {
            InitializeComponent();

            TipoDocumentoDao tipoDocdao = new TipoDocumentoDao();
            tipoDocdao.getTiposDeDocumento().ForEach(elem =>
            {
                ListaTiposDocumento.Items.Add(elem);
            });
            id = cliente.id;
            direccion = cliente.direccion;
            NombreCliente.Text = cliente.nombre;
            ApellidoCliente.Text = cliente.apellido;
            ListaTiposDocumento.SelectedIndex = 0;
            DniCliente.Text = cliente.documento;
            CuilCliente.Text = cliente.cuil;
            MailCliente.Text = cliente.mail;
            TelefonoCliente.Text = cliente.telefono;
            FechaNacimientoCli.Text = ((DateTime)cliente.fechaNacimiento).ToString("yyyy/MM/dd");
            numeroTarjetaCliente.Text = cliente.numeroTarjeta;

            direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE, cliente.direccion);

            tipoUsuario = TIPO_EDITAR_CLIENTE;

            mostrarControlesCliente();

        }

        public RegistrarUsuario(Empresa empresa) {
            InitializeComponent();
            direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA, empresa.direccion);
            direccion = empresa.direccion;
            tipoUsuario = TIPO_EDITAR_EMPRESA;
            mostrarControlesEmpresa();
        }


        public RegistrarUsuario(string tipo)
        {
            InitializeComponent();

            if(tipo == TIPO_CLIENTE){
                mostrarControlesCliente();
                tipoUsuario = TIPO_CLIENTE;
                direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE);
            }else if(tipo == TIPO_EMPRESA){
                mostrarControlesEmpresa();
                tipoUsuario = TIPO_EMPRESA;
                direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA);
            }else{
                ClienteRadioButton.Checked = true;
                EmpresaRadioButton.Checked = false;

                TipoDocumentoDao tipoDocdao = new TipoDocumentoDao();
                tipoDocdao.getTiposDeDocumento().ForEach(elem =>
                {
                    ListaTiposDocumento.Items.Add(elem);
                });
            }
        }

        private void mostrarControlesCliente() {
            TipoUsuarioLabel.Visible = false;
            TipoUsuariogroupBox.Visible = false;
            panelCliente.Visible = true;
        }

        private void mostrarControlesEmpresa() {
            TipoUsuarioLabel.Visible = false;
            PanelEmpresa.Visible = true;
            TipoUsuariogroupBox.Visible = false;
        }

        private void getDireccionDelCliente(Direccion dir) {
            direccion = dir;
        }

        private void numeroTarjetaCliente_TextChanged(object sender, EventArgs e)
        {
            numeroTarjeta = ((TextBox)sender).Text;
        }

        private void ClienteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) { 
            this.SuspendLayout();
            panelCliente.Visible = true;
            PanelEmpresa.Visible = false;
            this.ResumeLayout();
            tipoUsuario = TIPO_CLIENTE;
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
                tipoUsuario = TIPO_EMPRESA;
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
            try { fechaNacimiento = DateTime.Parse(((TextBox)sender).Text); }
            catch (Exception ex) { }
        }

        private void numeroTarjetaCliente_TextChanged_1(object sender, EventArgs e)
        {
            numeroTarjeta = ((TextBox)sender).Text;
        }

        private void AñadirDireccionButton_Click_1(object sender, EventArgs e)
        {
            if (direccionForm == null)
            {
                direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE);
            }
            direccionForm.getDireccion += getDireccionDelCliente;
            direccionForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ANÑADIR DIRECCION DE EMPRESA
            if (direccionForm == null) {
                direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_EMPRESA);
            }
            direccionForm.getDireccion += getDireccionDelCliente;
            direccionForm.ShowDialog(this);
        }

        private void CuilCliente_TextChanged(object sender, EventArgs e)
        {
            cuil = ((TextBox)sender).Text;
        }

        private void AñadirDireccionButton_Click(object sender, EventArgs e)
        {
            if (direccionForm == null)
            {
                direccionForm = new AñadirDireccion(AñadirDireccion.TIPO_CLIENTE);
            }
            direccionForm.getDireccion += getDireccionDelCliente;
            direccionForm.ShowDialog(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            new PalcoNet.Form1().Show(this);
            this.Close();
        }

        private Cliente getCliente(){
            Cliente cliente = new Cliente();
            if (id != null || id != 0)
                cliente.id = id;
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            cliente.TipoDocumento = TipoDocumento;
            cliente.documento = dni;
            cliente.cuil = cuil;
            cliente.mail = mail;
            cliente.telefono = telefono;
            cliente.direccion = direccion;
            cliente.fechaNacimiento = fechaNacimiento;
            cliente.fechaCreacion = DateTime.Now;
            cliente.numeroTarjeta = numeroTarjeta;
            cliente.usuario = usuario;

            return cliente;
        }


        private void AceptarButton_Click(object sender, EventArgs e)
        {
            ClientesDao clientesDao = new ClientesDao();
            if (nombre != null & apellido != null & TipoDocumento != null &
                    dni != null & cuil != null & mail != null & telefono != null & direccion != null & 
                    fechaNacimiento != null & numeroTarjeta != null)
            {
                 if (CuilValidator.validarCuit(cuil))
                {

                    
                    if (tipoUsuario.Equals(TIPO_EDITAR_CLIENTE))
                    {
                        // TODO: update del cliente
                        clientesDao.actualizarCliente(getCliente());
                        this.onFinisUpdate(id);
                    }
                    else if (ClienteRadioButton.Checked)
                    {
                        clientesDao.insertarCliente(getCliente(), contraseña);
                    }
                    
                    if (this.onFinishregistration != null)
                    {
                        this.onFinishregistration();
                    }
                    
                    this.Close();
                }
                else {
                    MessageBoxButtons alert = MessageBoxButtons.OK;
                    MessageBox.Show("Debe introducir un cuil valido", "Cuil invalido", alert);
                }
            }
            else if (razonSocial != null & mailEmpresa != null &
                    telefonoEmpresa != null & cuit != null)
            {
                if (CuilValidator.validarCuit(cuit))
                {
                    if (tipoUsuario.Equals(TIPO_EDITAR_EMPRESA)) { 
                        // TODO: HACER ABM DE EMPRESAS
                    }
                    else if (EmpresaRadioButton.Checked){
                        Empresa empresa = new Empresa();
                        empresa.razonSocial = razonSocial;
                        empresa.direccion = direccion;
                        empresa.cuit = cuit;
                        empresa.mailEmpresa = mailEmpresa;
                        empresa.telefonoEmpresa = telefonoEmpresa;

                        EmpresasDao empresasDao = new EmpresasDao();
                        empresasDao.insertarEmpresaConUsuario(empresa, usuario, contraseña);
                        if (this.onFinishregistration != null)
                        {
                            this.onFinishregistration();
                        }
                    }
                    this.Close();
                }
                else {
                    MessageBoxButtons alert = MessageBoxButtons.OK;
                    MessageBox.Show("Debe introducir un cuit valido", "Cuit invalido", alert);
                }
            }
            else if(direccion == null){
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("Debe agregar una direccion para continuar", "Direccion invalido", alert);
            } else{
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("Debe completar todos los campos para continuar", "Formulario invalido", alert);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            usuario = ((TextBox)sender).Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            contraseña = ((TextBox)sender).Text;
        }

        
    }
}