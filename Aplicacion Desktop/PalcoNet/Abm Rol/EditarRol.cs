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


namespace PalcoNet.Abm_Rol
{
    public partial class EditarRol : Form
    {


        private string nuevoNombreRol;
        private Rol rolActual;
        private Funcionalidad funcionalidadSeleccionada;
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
        private Dictionary<string, List<Funcionalidad>> diccionarioActualizacion = new Dictionary<string, List<Funcionalidad>>();

        public delegate void UpdateRolHandler(Rol rol);
        public event UpdateRolHandler updateRol;

        public EditarRol(Rol rol)
        {
            
            InitializeComponent();
            rolActual = rol;
            this.RolNombre.Text = rol.nombre;;

            FuncionalidadesDao funcionalidadesDao = new FuncionalidadesDao();
            funcionalidades = funcionalidadesDao.getFuncionalidades();

            diccionarioActualizacion.Add(RolesDao.AGREGAR , new List<Funcionalidad>());
            diccionarioActualizacion.Add(RolesDao.BORRAR , new List<Funcionalidad>());

            foreach (Funcionalidad fun in funcionalidades)
            {
                funcionalidadesRol.Items.Add(fun.descripcion, rol.funcionalidades.Contains(fun));
            }


        }

        private void RolNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            nuevoNombreRol = textBox.Text;
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
            new Abm_Rol.Form1().Show();
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
            rolesDao.actualizarRol(rolActual, diccionarioActualizacion[RolesDao.BORRAR], diccionarioActualizacion[RolesDao.AGREGAR]);

            diccionarioActualizacion[RolesDao.AGREGAR].Clear();
            diccionarioActualizacion[RolesDao.BORRAR].Clear();

            if (this.updateRol != null)
                this.updateRol(rolActual);

            this.Close();
        }

        private void funcionalidadesRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox list = (CheckedListBox)sender;
            Funcionalidad funcio = funcionalidades.Find(x => x.descripcion == list.SelectedItem.ToString());
            bool hola = list.GetSelected(list.SelectedIndex) == funcionalidadesRol.GetSelected(list.SelectedIndex);
            // list.SetSelected(list.SelectedIndex, true);
            if(diccionarioActualizacion[RolesDao.AGREGAR].Contains(funcio) & list.GetSelected(list.SelectedIndex)){
                diccionarioActualizacion[RolesDao.AGREGAR].Remove(funcio);
            }
            else if (diccionarioActualizacion[RolesDao.BORRAR].Contains(funcio) & !list.GetSelected(list.SelectedIndex)){
                diccionarioActualizacion[RolesDao.BORRAR].Remove(funcio);
            } else if (rolActual.funcionalidades.Contains(funcio)) {
                // DEBO BORRAR DICHA FUNCIONALIDAD
                if (!diccionarioActualizacion[RolesDao.BORRAR].Contains(funcio) & rolActual.funcionalidades.Contains(funcio))
                    diccionarioActualizacion[RolesDao.BORRAR].Add(funcio);
            }
            else if (!diccionarioActualizacion[RolesDao.AGREGAR].Contains(funcio) & !rolActual.funcionalidades.Contains(funcio))
                diccionarioActualizacion[RolesDao.AGREGAR].Add(funcio);
        }
    }
}
