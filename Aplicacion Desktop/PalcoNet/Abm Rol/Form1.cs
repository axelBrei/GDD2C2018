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
using PalcoNet.Dao;

namespace PalcoNet.Abm_Rol
{
    public partial class Form1 : Form
    {
        private List<Rol> roles = new List<Rol>();
        private Rol rolSeleccionado = null;

        public Form1()
        {
            InitializeComponent();

            RolesDao rolesDao = new RolesDao();
            roles = rolesDao.getRoles();

            listaRoles.View = View.Details;
            listaRoles.HeaderStyle = ColumnHeaderStyle.None;

            foreach (Rol rol in roles) {
                
                this.listaRoles.Items.Add(new ListViewItem(rol.nombre));
            }
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            EditarRol form = new EditarRol(rolSeleccionado);
            form.updateRol += this.updateRol;
            form.ShowDialog();
        }

        private void listaRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listBox = (ListView)sender;
            try {
                string selectedItem = listBox.SelectedItems[0].Text;
                Rol rol = roles.Find(x => x.nombre.Equals(selectedItem));
                if (rol.bajaLogica != null)
                {
                    rolSeleccionado = rol;
                }
                else
                {

                }
            }
            catch (ArgumentOutOfRangeException ex) { 

            }
        }


        public void updateRol(Rol rol)
        {
            RolesDao rolesDao = new RolesDao();
            roles.Insert(roles.IndexOf(rol), rolesDao.getRolPorId(rol.id));
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            NuevRol nuevoRolForm = new NuevRol();
            nuevoRolForm.nuevoRol += this.añadirNuevoRol;
            nuevoRolForm.ShowDialog();
        }

        private void añadirNuevoRol(Rol rol){
            RolesDao rolesDao = new RolesDao();
            Rol rolActualizado = rolesDao.getRolPorId(rol.id);
            listaRoles.Items.Add(new ListViewItem(rolActualizado.nombre));
            roles.Add(rolActualizado);
            
        }
    }
}
