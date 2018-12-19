using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;
using PalcoNet.Exceptions;


namespace PalcoNet.Dao
{
    class RolusuarioDao
    {

        public void insertarRolesPorUsuario(List<Rol> roles, int userId) {
            string query = "INSERT INTO [TheBigBangQuery].[Roles_usuario](rolu_usuario, rolu_rol) VALUES (@userId, @rolId)";
            SqlTransaction trans = DatabaseConection.getInstance().BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                command.Transaction = trans;

                roles.ForEach(elem =>
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@rolId", elem.id);
                    DatabaseConection.executeNoParamFunction(command);
                });

                trans.Commit();
            }
            catch (Exception ex) {
                trans.Rollback();
                throw new SqlInsertException("Error al insertar los roles",0);
            }
        }

        public void removerRolesDelUsuario(List<Rol> roles, int userId) {
            string query = "DELETE FROM [TheBigBangQuery].[Roles_usuario] WHERE rolu_rol = @rolId AND rolu_usuario = @userId";
            SqlTransaction trans = DatabaseConection.getInstance().BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                command.Transaction = trans;

                roles.ForEach(elem =>
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@rolId", elem.id);
                    DatabaseConection.executeNoParamFunction(command);
                });

                trans.Commit();

            }
            catch (Exception e) {
                trans.Rollback();
                throw new SqlInsertException("Error al insertar los roles", 0);
            }
        }
    }
}
