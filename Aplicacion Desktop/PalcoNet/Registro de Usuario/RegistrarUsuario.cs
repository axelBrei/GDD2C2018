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
using PalcoNet.Exceptions;
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegistrarUsuario : Form
    {

        private string usuario;
        private string contraseña;

        private Direccion direccion;

        // TIPOS
        public static string TIPO_CLIENTE = "CLIENTE";
        public static string TIPO_EMPRESA = "EMPRESA";
        public static string TIPO_EDITAR_CLIENTE = "EDITAR_CLIENTE";
        public static string TIPO_EDITAR_EMPRESA = "EDITAR_EMPRESA";

        private string tipoUsuario;

        public delegate void OnFinishregistration();
        public event OnFinishregistration onFinishregistration;

        public delegate void OnFinishUpdate(int id);
        public event OnFinishUpdate onFinisUpdate;

        private AltaClienteForm altaClieForm;
        private AltaEmpresaForm altaEmpresaForm;

        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public RegistrarUsuario(string tipo)
        {
            InitializeComponent();

            if(tipo == TIPO_CLIENTE){
                tipoUsuario = TIPO_CLIENTE;
                TipoUsuarioLabel.Visible = false;
                TipoUsuariogroupBox.Visible = false;
                ClienteRadioButton.Checked = true;
                EmpresaRadioButton.Checked = false;
            }else if(tipo == TIPO_EMPRESA){
                tipoUsuario = TIPO_EMPRESA;
                TipoUsuarioLabel.Visible = false;
                TipoUsuariogroupBox.Visible = false;
                ClienteRadioButton.Checked = false;
                EmpresaRadioButton.Checked = true;
            }else{
                ClienteRadioButton.Checked = true;
                EmpresaRadioButton.Checked = false;
            }
            
        }

        private void mostrarEnPanel(Form form)
        {
            form.TopLevel = false;
            form.AutoScroll = true;
            form.Parent = this.Parent;
            this.DatosPanel.Controls.Add(form);
            form.Show();
        }

        private void ClienteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) {
                this.DatosPanel.Controls.Clear();
            this.SuspendLayout();
                altaClieForm = new AltaClienteForm();
                mostrarEnPanel(altaClieForm);
                tipoUsuario = TIPO_CLIENTE;
            this.ResumeLayout();
            }
            
        }

        private void EmpresaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.DatosPanel.Controls.Clear();
                this.SuspendLayout();
                    altaEmpresaForm = new AltaEmpresaForm();
                    mostrarEnPanel(altaEmpresaForm);
                    tipoUsuario = TIPO_EMPRESA;
                this.ResumeLayout();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            new PalcoNet.Form1().Show(this);
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            UsuarioTextBox.Text = "";
            PasswordTextBox.Text = "";
            if (tipoUsuario == TIPO_CLIENTE) {
                altaClieForm.LimpiarButton_Click(null, null);
            }
            else if (tipoUsuario == TIPO_EMPRESA) {
                altaEmpresaForm.LimpiarButton_Click(null, null);
            }
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCamposRequeridos().Length == 0)
                {
                    registrarUsuario(UsuarioTextBox.Text.Trim(), PasswordTextBox.Text.Trim());
                }
                else if (UserData.UserData.getUsuario() != null &&
                                UserData.UserData.getUsuario().usuarioRegistrable.getTipo() == UserData.UserData.TIPO_ADMIN &&
                                UsuarioTextBox.Text.Length == 0 && PasswordTextBox.Text.Length == 0)
                {
                    var res = MessageBox.Show("Dese autogenerar el usuario y la contraseña", "Advertencia", MessageBoxButtons.YesNo);
                    if( res == DialogResult.Yes){
                        string usuario = null;
                    if (tipoUsuario == TIPO_CLIENTE)
                    {
                        Cliente cli = altaClieForm.getCliente();
                        if (cli != null)
                            usuario = cli.nombre + "." + cli.apellido;
                    }
                    else if (tipoUsuario == TIPO_EMPRESA)
                    {
                        Empresa emp = altaEmpresaForm.getEmpresa();
                        if (emp != null)
                            usuario = emp.razonSocial.Substring(0, 2) + emp.cuit.Substring(emp.cuit.Length - 2);
                    }
                    if (usuario != null && usuario.Length != 0)
                        registrarUsuario(usuario, "1234");
                    else
                        throw new GenericException("");
                    }else
                        throw new GenericException("");
                    

                }
                else
                {
                    string mensaje = "Los siguientes campos son requeridos:\n\n" + validarCamposRequeridos();
                    MessageBox.Show(mensaje);
                }
            }
            catch (GenericException ex) { 
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registrarUsuario(string usuario, string password) {
            if (tipoUsuario == TIPO_CLIENTE)
            {
                Cliente cli = altaClieForm.getCliente();
                cli.usuario = usuario.Trim();
                ClientesDao clientesDao = new ClientesDao();
                clientesDao.insertarCliente(cli, password.Trim());
            }
            else if (tipoUsuario == TIPO_EMPRESA)
            {
                Empresa empre = altaEmpresaForm.getEmpresa();
                empre.usuario = usuario.Trim();
                EmpresasDao empresasDao = new EmpresasDao();
                empresasDao.insertarEmpresaConUsuario(empre,
                    usuario.Trim(), password.Trim());
            }
            if (this.onFinishregistration != null)
                this.onFinishregistration();
            MessageBox.Show("Usuario registrado con exito");
            new PalcoNet.Form1().Show(this);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            usuario = ((TextBox)sender).Text;
        }

        // ------------------------ VALIDACIONES FORMULARIO-----------------------------

        private string validarCamposRequeridos() { 
            string resp = "";
            if (UsuarioTextBox.Text.Length == 0) resp += " Usuario \n";
            if (PasswordTextBox.Text.Length == 0) resp += "Contraseña \n";
            if (tipoUsuario == TIPO_CLIENTE && altaClieForm.getCamposRequeridos().Length != 0) resp += altaClieForm.getCamposRequeridos();
            if(tipoUsuario == TIPO_EMPRESA && altaEmpresaForm.getCamposRequeridos().Length != 0) resp += altaEmpresaForm.getCamposRequeridos();
            return resp;
        }

        

        
        
    }
}
