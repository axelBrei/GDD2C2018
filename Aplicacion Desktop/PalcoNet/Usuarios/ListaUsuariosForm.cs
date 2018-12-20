using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Dao;
using PalcoNet.Model;


namespace PalcoNet.Usuarios
{
    public partial class ListaUsuariosForm : Form
    {
        private UsuariosDao userDao;

        public ListaUsuariosForm()
        {
            InitializeComponent();
            userDao = new UsuariosDao();

            this.UsuariosListView.Columns.Insert(0, "Id", 5 * (int)UsuariosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UsuariosListView.Columns.Insert(1, "userame", 20 * (int)UsuariosListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UsuariosListView.Columns.Insert(2, "Intentos de logueo", 15 * (int)UsuariosListView.Font.SizeInPoints, HorizontalAlignment.Center);

            userDao.getUsuarios(
                result => {
                    result.ForEach(elem => {
                        this.UsuariosListView.Items.Add(getItemDelUsuario(elem));
                    });
                }
            );

        }

        public ListViewItem getItemDelUsuario(Usuario user) {
            ListViewItem item = new ListViewItem();
            item.Text = user.id.ToString();
            item.SubItems.Add(user.usuario);
            item.SubItems.Add(user.intentos.ToString());

            item.Tag = user;

            item.ForeColor = user.habilitado == 1 ? Color.Black : Color.Gray;

            return item;
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                Usuario user = (Usuario)this.UsuariosListView.SelectedItems[0].Tag;
                if (user != null)
                {
                    user.roles = new RolesDao().getRolesPorUserId(user.id);
                    // TODO DATOS DEL USUARIO
                    UserDataForm form = new UserDataForm(user);
                    form.Show(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Debe seleccionar un usuario a modificar");
            }
        }

        private void onFormClosing() { }

        private void DeshabilitarButton_Click(object sender, EventArgs e)
        {
            UsuariosDao userDao = new UsuariosDao();
            try
            {
                Usuario user = (Usuario)this.UsuariosListView.SelectedItems[0].Tag;
                bool habilitado = user.habilitado == 1;
                userDao.habilitarDeshabilitarUsuario(user.id, habilitado);
                UsuariosListView.Items.Clear();
                userDao.getUsuarios(
                result =>
                {
                    result.ForEach(elem =>
                    {
                        this.UsuariosListView.Items.Add(getItemDelUsuario(elem));
                    });
                }
            );
            }
            catch (Exception ex) { }
        }

        private void UsuariosListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Usuario user = (Usuario)this.UsuariosListView.SelectedItems[0].Tag;
                if (user.habilitado == 1)
                    DeshabilitarButton.Text = "Deshabilitar";
                else
                    DeshabilitarButton.Text = "Habilidar";
            }
            catch (Exception ex) { }
        }
    }
}
