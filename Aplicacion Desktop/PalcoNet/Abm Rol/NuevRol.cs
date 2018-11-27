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
    public partial class NuevRol : Form
    {

        private string nombreNuevoRol;
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
        private List<Funcionalidad> funcionalidadesDelRol = new List<Funcionalidad>();

        public delegate void NuevoRolHandler(Rol rol);
        public event NuevoRolHandler nuevoRol;

        public NuevRol()
        {
            InitializeComponent();

            // AGREGO ELEMENTOS A LA LISTA DE CHECKBOX
            FuncionalidadesDao funcionalidadesDao = new FuncionalidadesDao();
            funcionalidades = funcionalidadesDao.getFuncionalidades();
            funcionalidades.ForEach(elem => {
                funcionalidadesCheckboxList.Items.Add(elem.descripcion, false);
            });
        }

        private void nombreRol_TextChanged(object sender, EventArgs e)
        {
            nombreNuevoRol = ((TextBox)sender).Text;
        }

        private void funcionalidadesCheckboxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox listBox = (CheckedListBox)sender;

            Funcionalidad funcionalidad = funcionalidades.Find(elem => elem.descripcion == listBox.SelectedItem.ToString());
            if (funcionalidadesDelRol.Contains(funcionalidad) & listBox.GetSelected(listBox.SelectedIndex))
            {
                funcionalidadesDelRol.Remove(funcionalidad);
            }
            else {
                funcionalidadesDelRol.Add(funcionalidad);
            }
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            rol.nombre = nombreNuevoRol;
            rol.funcionalidades = funcionalidadesDelRol;

            RolesDao rolesDao = new RolesDao();
            rolesDao.insertarNuevoRol(rol);

            this.nuevoRol(rol);

            this.Close();
        }


    }
}
