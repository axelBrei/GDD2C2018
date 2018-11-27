using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;

namespace PalcoNet.Dao
{
    class RolesDao
    {

        public static string AGREGAR = "AGREGAR";
        public static string BORRAR = "BORRAR";

        public void actualizarRol(Rol rol) {
            string query;
            if (rol.bajaLogica.Millisecond != 0)
            {
                query = "UPDATE TheBigBangQuery.Rol " +
                "SET rol_nombre= '" + rol.nombre + "', rol_dado_baja= '" + rol.bajaLogica.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                "WHERE rol_cod = " + rol.id;
            }
            else {
                query = "UPDATE TheBigBangQuery.Rol " +
                "SET rol_nombre= '" + rol.nombre + "' " +
                "WHERE rol_cod = " + rol.id;
            }
            
            
            DatabaseConection.executeQuery(query).Close();

            
        }

        public void actualizarRol(Rol rol, List<Funcionalidad> funcionalidadesBorradas, List<Funcionalidad> funcAgregadas)
        {
            FuncionalidadesPorRolDao funcionalidadesPorRolDao = new FuncionalidadesPorRolDao();
            if(funcionalidadesBorradas.Count > 0)
                funcionalidadesPorRolDao.borrarFuncionalidadPorRol(rol, funcionalidadesBorradas);

            if (funcAgregadas.Count > 0)
                funcionalidadesPorRolDao.agregarFuncionalidadPorRol(rol, funcAgregadas);

            this.actualizarRol(rol);
            
        }

        public List<Rol> getRoles() {
            string query = "SELECT rol_cod, rol_nombre, func_id, func_desc " +
                "FROM TheBigBangQuery.Rol JOIN TheBigBangQuery.Funcionalidades_rol ON (fpr_rol = rol_cod) " +
                "JOIN TheBigBangQuery.Funcionalidad ON (func_id = fpr_id) " +
                "Order by rol_nombre ASC";
            List<Rol> rolesList = new List<Rol>();

            SqlDataReader reader = DatabaseConection.executeQuery(query);
            if (reader.HasRows) {
                Rol rol = new Rol();
                Funcionalidad fun = new Funcionalidad();

                reader.Read();
                
                rol.id = (int)reader.GetSqlDecimal(0);
                rol.nombre = (string)reader.GetSqlString(1);

                
                fun.id = (int) reader.GetSqlDecimal(2);
                fun.descripcion = (string) reader.GetSqlString(3);
                rol.agregarFuncionalidad(fun);    
                
                while(reader.Read()) {
                    string rolNombre = (string) reader.GetSqlString(1);
                    if (rolNombre.Equals(rol.nombre))
                    {
                        fun = new Funcionalidad();
                        fun.id = (int)reader.GetSqlDecimal(2);
                        fun.descripcion = (string)reader.GetSqlString(3);
                        rol.agregarFuncionalidad(fun);
                    }
                    else 
                    {
                        rolesList.Add(rol);
                        rol = new Rol();
                        rol.id = (int)reader.GetSqlDecimal(0);
                        rol.nombre = rolNombre;

                        fun = new Funcionalidad();
                        fun.id = (int)reader.GetSqlDecimal(2);
                        fun.descripcion = (string)reader.GetSqlString(3);
                        rol.agregarFuncionalidad(fun);  
                    }
                }
                rolesList.Add(rol);
            }
            reader.Close();
            return rolesList;
        }

        public Rol getRolPorId(int rolId) {
            string query = "SELECT rol_cod, rol_nombre, func_id, func_desc " +
                "FROM TheBigBangQuery.Rol JOIN TheBigBangQuery.Funcionalidades_rol ON (fpr_rol = rol_cod) " +
                "JOIN TheBigBangQuery.Funcionalidad ON (func_id = fpr_id) " +
                "WHERE rol_cod= " + rolId +
                " Order by rol_nombre ASC";

            Rol rol = new Rol();

            SqlDataReader reader = DatabaseConection.executeQuery(query);
            if (reader.HasRows) {
                Funcionalidad fun = new Funcionalidad();

                reader.Read();

                rol.id = (int)reader.GetSqlDecimal(0);
                rol.nombre = (string)reader.GetSqlString(1);


                fun.id = (int)reader.GetSqlDecimal(2);
                fun.descripcion = (string)reader.GetSqlString(3);
                rol.agregarFuncionalidad(fun);

                while (reader.Read()) {
                    fun = new Funcionalidad();
                    fun.id = (int)reader.GetSqlDecimal(2);
                    fun.descripcion = (string)reader.GetSqlString(3);
                    rol.agregarFuncionalidad(fun);
                }

            }
            reader.Close();
            return rol;
        }

        public Rol insertarNuevoRol(Rol rol) {
            string query = "INSERT INTO TheBigBangQuery.Rol (rol_nombre) VALUES ('" + rol.nombre + "')";
            DatabaseConection.executeQuery(query).Close();

            query = "SELECT rol_cod FROM TheBigBangQuery.Rol WHERE rol_nombre = '" + rol.nombre + "'";
            SqlDataReader reader = DatabaseConection.executeQuery(query);

            if (reader.HasRows && reader.Read())
                rol.id = (int)reader.GetSqlDecimal(0);

            reader.Close();

            FuncionalidadesPorRolDao dao = new FuncionalidadesPorRolDao();
            dao.agregarFuncionalidadPorRol(rol, rol.funcionalidades);
            return rol;
        }

    }
}
