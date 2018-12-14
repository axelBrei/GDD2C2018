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
        public static string TIPO_ADMIN = "ADMIN";

        private static Usuario usuario = null;
        private static Rol activeRol = null;
        private static object clieOEmpresa;

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
                            Empresa empresa = empresaDao.getEmpresaPorUserId(usuario.id);
                            usuario.usuarioRegistrable = empresa;
                            clieOEmpresa = empresa;
                            break;
                        }
                    case 2:
                        {
                            // CLIENTE
                            ClientesDao clientesDao = new ClientesDao();
                            Cliente cliente = clientesDao.getClientePorUserId(usuario.id);
                            usuario.usuarioRegistrable = cliente;
                            clieOEmpresa = cliente;
                            break;
                        }
                    case 1: {
                        usuario.usuarioRegistrable = new Administrador();
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

        public static object getClieOEmpresa() {
            return clieOEmpresa;
        }
    }
}
