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
using PalcoNet.UserData;

namespace PalcoNet.MainMenu
{
    public partial class SeleccionDeRol : Form
    {
        private List<Rol> roles;
        private Rol rolSeleccionado = new Rol();
        public SeleccionDeRol()
        {
            InitializeComponent();

            roles = UserData.UserData.getUsuario().roles;
            this.RolesList.Items.Clear();
            foreach (Rol rol in roles) {
                // ListViewItem item = new ListViewItem(rol.nombre, (Int32)rol.id);
                this.RolesList.Items.Add(rol.nombre);
            }
        }

        private void RolesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreRol = this.RolesList.SelectedItem.ToString();
            rolSeleccionado = UserData.UserData.getUsuario().roles.Find(x => x.nombre.Equals(nombreRol));

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            new PalcoNet.Form1().Show();
            this.Hide();
        }

        private void AceptarRol_Click(object sender, EventArgs e)
        {
            if (rolSeleccionado != null) {
                if (UserData.UserData.setRolActivo(rolSeleccionado))
                {
                    new MainMenu.Form1().Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("El usuario con el que se quiere acceder se encuentra deshabilitado");
                    new PalcoNet.Form1().Show();
                }
            }
        }
    }
}
