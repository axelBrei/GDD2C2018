﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.ConectionUtils;
using PalcoNet.Model;
using System.Data.SqlClient;

namespace PalcoNet.Dao
{
    class LoginDao
    {
        
        public Usuario loginAs(string usuario, string password) {

            string query = "SELECT usua_id, usua_usuario, usua_n_intentos,rol_cod, rol_nombre,func_id, func_desc " +
                "FROM TheBigBangQuery.Usuario JOIN TheBigBangQuery.Rol ON (usua_rol = rol_cod) " +
                "JOIN TheBigBangQuery.Roles_usuario ON (rolu_rol = rol_cod AND rolu_usuario = usua_id) " +
                "JOIN TheBigBangQuery.Funcionalidades_rol ON (fpr_rol = rol_cod) " +
                "JOIN TheBigBangQuery.Funcionalidad ON (func_id = fpr_id)" +
                "WHERE usua_usuario = '" + usuario + "'" +
                "AND usua_password=HASHBYTES('SHA2_256', '" + password + "')";
            SqlDataReader reader = DatabaseConection.executeQuery(query);
            Usuario user = null;
            if(reader.HasRows){
                user = new Usuario();
                reader.Read();
                user.id = (int) reader.GetSqlDecimal(0);
                user.usuario = (string)reader.GetSqlString(1);
                user.intentos = (int) reader.GetSqlInt32(2);

                Rol rol = new Rol();
                rol.id = (int) reader.GetSqlDecimal(3);
                rol.nombre = (string) reader.GetSqlString(4);

                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.id = (int)reader.GetSqlDecimal(5);
                funcionalidad.descripcion = (string) reader.GetSqlString(6);
                rol.agregarFuncionalidad(funcionalidad);

                while (reader.Read()) {
                    funcionalidad = new Funcionalidad();
                    funcionalidad.id = (int)reader.GetSqlDecimal(5);
                    funcionalidad.descripcion = (string)reader.GetSqlString(6);
                    rol.agregarFuncionalidad(funcionalidad);
                }

                user.addRol(rol);
                reader.Close();
                return user;
                
            }
            // SI EL USUARIO NO ES VALIDO RETORNO NULL
            reader.Close();
            return null;
        }
    }
}
