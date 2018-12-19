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

namespace PalcoNet.Usuarios
{
    public partial class UserDataForm : Form
    {

        private RolesDao rolesDao;
        private Usuario usuario;
        private List<Rol> roles;
        private List<Rol> rolesEliminar;
        private List<Rol> rolesTotales = new List<Rol>();

        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public UserDataForm(Usuario user)
        {
            InitializeComponent();
            usuario = user;
            UsuarioLabel.Text =  user.usuario;
            IdLabel.Text =  user.id.ToString();

            rolesDao = new RolesDao();
            roles = new List<Rol>();
            rolesEliminar = new List<Rol>();

            //this.ModificarRolesButton.Enabled = false;

            rolesTotales = rolesDao.getRoles();
            actualizarRolesDelUsuario();

            if (user.usuarioRegistrable != null && user.usuarioRegistrable.getTipo() != UserData.UserData.TIPO_ADMIN) {
                RolesListView.Enabled = false;
                ModificarRolesButton.Visible = false;
                RolesListView.BackColor = Color.White;
                VolverButton.Visible = false;
            }
        }

        private void actualizarRolesDelUsuario() {
            rolesTotales.ForEach(elem =>
            {
                bool check = usuario.roles.Contains(elem);
                this.RolesListView.Items.Add(getItemDelRol(elem, check));

            });
        }

        private ListViewItem getItemDelRol(Rol rol,bool check) {
            ListViewItem item = new ListViewItem();
            item.Text = rol.id.ToString();
            item.SubItems.Add(rol.nombre);

            item.Checked = check;

            item.Tag = rol;

            return item;
        }

        private void RolesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Rol rol = (Rol) e.Item.Tag;
            if (e.Item.Checked && !usuario.roles.Contains(rol))
            {
                roles.Add(rol);
            }
            else if(!e.Item.Checked && usuario.roles.Contains(rol)){
                rolesEliminar.Add(rol);
            }
        }

        private void ModificarRolesButton_Click(object sender, EventArgs e)
        {
            // CHECQUEAR QUE HAYA ITEMS NUEVOS EN LA LISTA
            RolusuarioDao rolesPorUsuarioDao = new RolusuarioDao();
            try
            {
                bool insertados = false;
                if (roles.Count > 0) {
                    rolesPorUsuarioDao.insertarRolesPorUsuario(roles, usuario.id);
                    insertados = true;
                }

                if (rolesEliminar.Count > 0) {
                    rolesPorUsuarioDao.removerRolesDelUsuario(rolesEliminar, usuario.id);
                    insertados = true;
                }

                if (insertados)
                {
                    RolesListView.Items.Clear();
                    usuario.roles = new RolesDao().getRolesPorUserId(usuario.id);
                    actualizarRolesDelUsuario();
                    MessageBox.Show("Rol/es asignado/s correactamente");
                }
                else
                    MessageBox.Show("No hay nuevos roles para añadir");
                    
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserDataForm_Load(object sender, EventArgs e)
        {
            this.rolesEliminar.Clear();
            this.roles.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuariosDao userDao = new UsuariosDao();
            try
            {
                if (getCamposRequeridosContraseña().Length == 0)
                {
                    if (ContraseñaActualTextBox.Text != NuevaContraseñaTextBox.Text)
                    {
                        userDao.actualizarContraseñaDelUsuario(
                                ContraseñaActualTextBox.Text.Trim(),
                                NuevaContraseñaTextBox.Text.Trim(),
                                usuario.id
                        );
                        MessageBox.Show("Contraseña modificada con exito!");
                    }
                    else
                        MessageBox.Show("La nueva contraseña debe ser distinta de la actual");
                }
                else
                    MessageBox.Show("Debe llenar los campos requeridos: \n\n" + getCamposRequeridosContraseña());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        // VALIDACIONES DE CAMPOS
        private string getCamposRequeridosContraseña() {
            string req = "";
            if (ContraseñaActualTextBox.Text.Length == 0) req += " Contraseña actual \n";
            if (NuevaContraseñaTextBox.Text.Length == 0) req += " Nueva contraseña \n";

            return req;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
