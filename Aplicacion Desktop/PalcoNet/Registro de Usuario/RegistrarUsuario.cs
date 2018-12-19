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
                    if (tipoUsuario == TIPO_CLIENTE)
                    {
                        Cliente cli = altaClieForm.getCliente();
                        cli.usuario = UsuarioTextBox.Text.Trim();
                        ClientesDao clientesDao = new ClientesDao();
                        clientesDao.insertarCliente(cli, PasswordTextBox.Text.Trim());
                    }
                    else if (tipoUsuario == TIPO_EMPRESA)
                    {
                        Empresa empre = altaEmpresaForm.getEmpresa();
                        empre.usuario = UsuarioTextBox.Text.Trim();
                        EmpresasDao empresasDao = new EmpresasDao();
                        empresasDao.insertarEmpresaConUsuario(empre,
                            UsuarioTextBox.Text.Trim(),
                            PasswordTextBox.Text.Trim());
                    }
                    MessageBox.Show("Usuario registrado con exito");
                    new PalcoNet.Form1().Show(this);
                    this.Close();
                }
                else
                {
                    string mensaje = "Los siguientes campos son requeridos:\n\n" + validarCamposRequeridos();
                    MessageBox.Show(mensaje);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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

            return resp;
        }

        

        
        
    }
}
