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
using PalcoNet.UserData;
using PalcoNet.Validators;

namespace PalcoNet
{
    public partial class Form1 : Form
    {
        private string username;
        private string password;
        private bool usuarioValido = false;

        public Form1()
        {
            InitializeComponent();
            ErrorImage.Image = SystemIcons.Error.ToBitmap();
            ErrorImage.Visible = false;
        }


        private void InputUser_TextChanged(object sender, EventArgs e)
        {
            var userInput = sender as TextBox;
            ErrorImage.Visible = false;
            username = userInput.Text;
        }

        private void inputPass_TextChanged(object sender, EventArgs e)
        {
            var userPass = sender as TextBox;
            password = userPass.Text;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginDao loginDao = new LoginDao();
            bool usuarioHabilitado = loginDao.usuarioHabilitado(username);
            if (usuarioValido & usuarioHabilitado)
            {
                Usuario usuario = loginDao.loginAs(username, password);
                if (usuario == null)
                {
                    MessageBoxButtons alert = MessageBoxButtons.OK;
                    MessageBox.Show("Contraseña y/o usuario Incorrecto", "Error al ingresar", alert);
                    if (usuarioValido)
                    {
                        loginDao.incrementarContadorDeIntentos(username);
                    }
                }
                else
                {
                    UserData.UserData.setUsuario(usuario);
                    loginDao.resetearIntentos(usuario);
                    if (usuario.roles.Count > 1)
                    {
                        new PalcoNet.MainMenu.SeleccionDeRol().Show();
                    }
                    else
                    {
                        UserData.UserData.setRolActivo(usuario.getRol(0));
                        new PalcoNet.MainMenu.Form1().Show(); ;

                    }
                    this.Hide();

                }
            }
            else {
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("El usuario con el que esta intentando ingresar se encuentra inhabilitado\n\nContactese con algun administrador para revertirlo", "Error al ingresar", alert);
            }
            
        }

        private void afterCloseSignUp(object sender, FormClosedEventArgs e) {
            this.Show();
        }

        private void RegistrarseButton_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.RegistrarUsuario form = new Registro_de_Usuario.RegistrarUsuario("");
            form.FormClosed += this.afterCloseSignUp;
            form.Show();
            this.Hide();
        }

        private void AfterFocusUserTextBox(object sender, EventArgs e) { 
            LoginDao loginDao = new LoginDao();
            try
            {
                if (!String.IsNullOrWhiteSpace(username))
                {
                    
                    usuarioValido = loginDao.usuarioValido(username);
                    if (usuarioValido == false)
                    {
                        ErrorImage.Visible = true;
                    }
                    else { ErrorImage.Visible = false; }
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }
        }

    }
}
