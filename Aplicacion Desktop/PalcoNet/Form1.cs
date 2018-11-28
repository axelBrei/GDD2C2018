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

namespace PalcoNet
{
    public partial class Form1 : Form
    {
        private string username;
        private string password;

        public Form1()
        {
            InitializeComponent();
        }


        private void InputUser_TextChanged(object sender, EventArgs e)
        {
            var userInput = sender as TextBox;
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
            Usuario usuario = loginDao.loginAs(username, password);
            if (usuario == null)
            {
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("Contraseña y/o usuario Incorrecto", "Error al ingresar", alert);
            }
            else {
                UserData.UserData.setUsuario(usuario);
                if (usuario.roles.Count > 1)
                {
                    new PalcoNet.MainMenu.SeleccionDeRol().Show();
                }
                else {
                    UserData.UserData.setRolActivo(usuario.getRol(0));
                    new PalcoNet.MainMenu.Form1().Show();
                }
                this.Hide();
                
            }
        }

        private void RegistrarseButton_Click(object sender, EventArgs e)
        {
            new Registro_de_Usuario.Form1().Show();
            this.Hide();
        }

    }
}
