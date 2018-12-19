using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.ConectionUtils;
using PalcoNet.Model;
using System.Data.SqlClient;
using System.Data;
using PalcoNet.Exceptions;

namespace PalcoNet.Dao
{
    class LoginDao
    {

        public static string getHashPassword(string contraseña) {
            return "[TheBigBangQuery].[getHashPassword]('" + contraseña +"')"; 
        }
        
        public Usuario loginAs(string usuario, string password) {

            string query = "SELECT usua_id, usua_usuario, usua_n_intentos,rol_cod, rol_nombre " +
                            "FROM TheBigBangQuery.Usuario JOIN TheBigBangQuery.Roles_usuario ON (usua_id = rolu_usuario) " +
	                            "JOIN TheBigBangQuery.Rol ON (rol.rol_cod = rolu_rol) " +
                            "WHERE usua_usuario = @usuario " +
                            "AND usua_password= [TheBigBangQuery].[getHashPassword](@password)";
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@password", password);
                reader = DatabaseConection.executeQuery(command);
                Usuario user = null;

                if (reader.HasRows) {
                    user = new Usuario();
                    while (reader.Read())
                    {
                        user.id = (int)reader.GetSqlDecimal(0);
                        user.usuario = (string)reader.GetSqlString(1);
                        user.intentos = (int)reader.GetSqlInt32(2);

                        Rol rol = new Rol();
                        rol.id = (int)reader.GetSqlDecimal(3);
                        rol.nombre = reader.GetSqlString(4).ToString();
                        user.roles.Add(rol);
                    }
                
                    reader.Close();
                    string query2 = "SELECT func_id, func_desc " +
                                    "FROM TheBigBangQuery.Funcionalidades_rol JOIN TheBigBangQuery.Funcionalidad ON (fpr_id = func_id) " +
                                    "WHERE fpr_rol = @rolId";
                    user.roles.ForEach(elem => { 
                        SqlCommand funcCommand = new SqlCommand(query2);
                        funcCommand.Parameters.AddWithValue("@rolId", elem.id);

                        reader = DatabaseConection.executeQuery(funcCommand);
                        while (reader.Read()) {
                            Funcionalidad fun = new Funcionalidad();
                            fun.id = (int)reader.GetSqlDecimal(0);
                            fun.descripcion = reader.GetSqlString(1).ToString();
                            elem.funcionalidades.Add(fun);
                        }
                        reader.Close();
                    });
                }
                
                //if (reader.HasRows)
                //{
                //    user = new Usuario();
                //    reader.Read();
                //    user.id = (int)reader.GetSqlDecimal(0);
                //    user.usuario = (string)reader.GetSqlString(1);
                //    user.intentos = (int)reader.GetSqlInt32(2);

                //    Rol rol = new Rol();
                //    rol.id = (int)reader.GetSqlDecimal(3);
                //    rol.nombre = (string)reader.GetSqlString(4);

                //    Funcionalidad funcionalidad = new Funcionalidad();
                //    funcionalidad.id = (int)reader.GetSqlDecimal(5);
                //    funcionalidad.descripcion = (string)reader.GetSqlString(6);
                //    rol.agregarFuncionalidad(funcionalidad);

                //    while (reader.Read())
                //    {
                //        funcionalidad = new Funcionalidad();
                //        funcionalidad.id = (int)reader.GetSqlDecimal(5);
                //        funcionalidad.descripcion = (string)reader.GetSqlString(6);
                //        rol.agregarFuncionalidad(funcionalidad);
                //    }

                //    user.addRol(rol);
                //}
                return user;
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("Error en el logue por favor intente mas tarde.");
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public void incrementarContadorDeIntentos(string usuario) {
            string query = "EXEC [TheBigBangQuery].IncrementarIntento @usuario = @usuarioC";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@usuarioC", usuario);
            DatabaseConection.executeNoParamFunction(command);
        }

        public bool usuarioValido(string usuario) {
            string query = "SELECT TheBigBangQuery.ExisteUsuario(@usuario)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@usuario", usuario);
            int existe = DatabaseConection.executeParamFunction<int>(command);
            return existe == 1;
        }

        public bool usuarioHabilitado(string usuario) {
            string query = "SELECT [TheBigBangQuery].[UsuarioHabilitado](@usuario)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@usuario", usuario);
            int habilitado = DatabaseConection.executeParamFunction<int>(command);
            return habilitado == 1;
        }

        public void resetearIntentos(Usuario usuario) {
            string query = "UPDATE [TheBigBangQuery].[Usuario] " +
                "SET usua_n_intentos = 0 " +
                "WHERE usua_id = @idUsuario";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@idUsuario", usuario.id);
            DatabaseConection.executeNoParamFunction(command);
        }
    }
}
