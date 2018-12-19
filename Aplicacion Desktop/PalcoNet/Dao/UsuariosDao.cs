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
    class UsuariosDao
    {

        public void habilitarDeshabilitarUsuario(int userId, bool isHabilitado) { 
            string query = "UPDATE [TheBigBangQuery].[Usuario] " +
                            "SET usua_habilitado = @habilitado " +
                            "WHERE usua_id = @userId";
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.AddWithValue("@habilitado", isHabilitado ? 0 : 1);
                command.Parameters.AddWithValue("@userId", userId);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                throw new SqlInsertException("Error al modificar estado del usuario", 0);
            }
        }

        public void getUsuarios(Action<List<Usuario>> result)
        {

            string query = "SELECT usua_id, usua_usuario, usua_n_intentos, usua_habilitado " +
                "FROM TheBigBangQuery.Usuario";
            SqlDataReader reader = null;
            List<Usuario> usuariosList = new List<Usuario>();

            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuariosList.Add(getUsuarioDeRader(reader));
                    }
                }
                // SI EL USUARIO NO ES VALIDO RETORNO NULL
                result(usuariosList);
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("No se han encontrado usuarios registrados");
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public void actualizarContraseñaDelUsuario(string passAnterior, string nuevaPsw, int userId) {
            string query = "[TheBigBangQuery].[actualizarContraseñaUsuario]";
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@pswAnterior", passAnterior);  
                command.Parameters.AddWithValue("@nuevaPsw", nuevaPsw);
                command.Parameters.AddWithValue("@userId", userId);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (SqlException e) {
                throw new DataNotFoundException(e.Message);
            }
            catch(Exception e){}
        }

        

        private Usuario getUsuarioDeRader(SqlDataReader reader) {
            Usuario user = new Usuario();
            user.id = (int)reader.GetSqlDecimal(0);
            user.usuario = (string)reader.GetSqlString(1);
            user.intentos = (int)reader.GetSqlInt32(2);
            user.habilitado = (int)reader.GetSqlInt32(3);

            return user;
        }
    }
}
