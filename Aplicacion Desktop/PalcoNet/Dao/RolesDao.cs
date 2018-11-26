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
        public void actualizarRol(Rol rol) {
            string query = "UPDATE TheBigBangQuery.Rol " +
                "SET rol_nombre= '" + rol.nombre + "', rol_dado_baja= '" + rol.bajaLogica.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                "WHERE rol_cod = " + rol.id;
            
            DatabaseConection.executeQuery(query);

            
        }

        public void actualizarRol(Rol rol, List<Funcionalidad> funcionalidadesBorradas)
        {
            FuncionalidadesPorRolDao funcionalidadesPorRolDao = new FuncionalidadesPorRolDao();
            funcionalidadesPorRolDao.actualizarFuncionalidadesPorRol(rol, funcionalidadesBorradas);
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
    }
}
