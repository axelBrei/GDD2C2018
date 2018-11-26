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



namespace PalcoNet.Abm_Rol
{
    public partial class EditarRol : Form
    {

        private string nuevoNombreRol;
        private Rol rolActual;
        private Funcionalidad funcionalidadSeleccionada;
        private List<Funcionalidad> funcionalidadesBorradas = new List<Funcionalidad>();

        public EditarRol(Rol rol)
        {
            
            InitializeComponent();
            rolActual = rol;

            this.RolNombre.Text = rol.nombre;;
            funcionalidadesRol.View = View.Details;
            funcionalidadesRol.HeaderStyle = ColumnHeaderStyle.None;

            foreach (Funcionalidad fun in rol.funcionalidades)
            {
                ListViewItem item = new ListViewItem(fun.descripcion);
                this.funcionalidadesRol.Items.Add(item);
            }


        }

        private void RolNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            nuevoNombreRol = textBox.Text;
        }

        private void EliminarRol_Click(object sender, EventArgs e)
        {
            
            Funcionalidad funci = rolActual.funcionalidades.Find(x => x.descripcion == funcionalidadesRol.SelectedItems[0].Text);
            if (funci != null)
            {
                funcionalidadesBorradas.Add(funci);
                this.funcionalidadesRol.Items.Remove(funcionalidadesRol.SelectedItems[0]);
            }

            
        }

        private void funcionalidadesRol_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListView listBox = (ListView)sender;
            if (listBox.SelectedItems.Count > 0) { 
              Funcionalidad fun = rolActual.funcionalidades.Find(x => x.descripcion.Equals(listBox.SelectedItems[0].Text));
              funcionalidadSeleccionada = fun;
            }
           
                            
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            new MainMenu.Form1().Show(); 
            this.Hide();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            // APPLICAR CAMBIOS
            RolesDao rolesDao = new RolesDao();
            rolActual.nombre = nuevoNombreRol;
            if (!rolActual.nombre.Equals(nuevoNombreRol)) {
                rolesDao.actualizarRol(rolActual);
            }
            if (funcionalidadesBorradas.Count > 0){
                rolesDao.actualizarRol(rolActual, funcionalidadesBorradas);
            }

            
        }
    }
}
