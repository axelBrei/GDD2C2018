using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Dao;

namespace PalcoNet.UserData
{
    class UserData
    {

        public static string TIPO_EMPRESA = "EMPRESA";
        public static string TIPO_CLIENTE = "CLIENTE";

        private static Usuario usuario = null;
        private static Rol activeRol = null;

        public UserData() { }



        public static void setUsuario(Usuario user){
            usuario = user;
        }
        public static void setRolActivo(Rol rol) {
            try
            {
                switch (rol.id)
                {
                    case 0:
                        {
                            // empresa
                            EmpresasDao empresaDao = new EmpresasDao();
                            usuario.usuarioRegistrable = empresaDao.getEmpresaPorUserId(usuario.id);
                            break;
                        }
                    case 2:
                        {
                            // CLIENTE
                            ClientesDao clientesDao = new ClientesDao();
                            usuario.usuarioRegistrable = clientesDao.getClientePorUserId(usuario.id);
                            break;
                        }
                }
            }
            catch (Exception e) { }
            activeRol = rol;
        }

        public static Usuario getUsuario() {
            return usuario;
        }

        public static int getUsuarioId() {
            return usuario.id;
        }

        public static string getUserName() {
            return usuario.usuario;
        }

        public static List<Rol> getUser() {
            return usuario.roles;
        }

        public static int getIntentosUsuario() {
            return usuario.intentos;
        }

        public static Rol getRolActivo() {
            return activeRol;
        }

        public static void actualizarRolActual() {
            RolesDao rolesDao = new RolesDao();
            activeRol = rolesDao.getRolPorId(activeRol.id);
        }
    }
}
