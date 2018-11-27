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
using System.Drawing;

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
                ListViewItem item = new ListViewItem(rol.nombre);
                if (rol.bajaLogica == DateTime.Parse("01/01/1900 0:00:00"))
                {
                    item.ForeColor = Color.Black;
                }
                else { 
                    item.ForeColor = Color.Gray; 
                }
                this.listaRoles.Items.Add(item);
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
                ListViewItem selectedItem = listBox.SelectedItems[0];
                if (selectedItem.ForeColor == Color.Gray)
                {
                    EliminarButton.Text = "Habilitar";
                }
                else {
                    EliminarButton.Text = "Deshabilitar";
                }
                Rol rol = roles.Find(x => x.nombre.Equals(selectedItem.Text));
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

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            
            ListViewItem item = listaRoles.SelectedItems[0];
            
            Rol rol = roles.Find(elem => elem.nombre.Equals(item.Text));
            if (item.ForeColor == Color.Gray)
            {
                // Le quito la baja logica al ROl
                rol.bajaLogica = DateTime.MinValue;
            }
            else { 
                // Le agrego la baja logica con la fecha de hoy
                rol.bajaLogica = DateTime.Now;
            }
            item.ForeColor = item.ForeColor == Color.Gray ? Color.Black : Color.Gray;
            RolesDao rolesDao = new RolesDao();
            rolesDao.actualizarRol(rol);
        }
    }
}
