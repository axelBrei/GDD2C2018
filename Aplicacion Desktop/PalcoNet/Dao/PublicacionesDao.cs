using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class PublicacionesDao
    {
        public int insertarPublicacion(Publicacion publi, SqlTransaction transaction)
        {
            string query = "[TheBigBangQuery].[InsertarPublicacion]";
            try
            {
                SqlCommand command = new SqlCommand(query);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = query;
                command.Transaction = transaction;

                SqlParameter outId = new SqlParameter("@newId", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                SqlParameter fechaPubParam = new SqlParameter("@fechaPublicacion", SqlDbType.DateTime) { Value = publi.fechaPublicacion };
                SqlParameter fechaEveParam = new SqlParameter("@fechaEvento", SqlDbType.DateTime) { Value = publi.fechaEvento };

                command.Parameters.AddWithValue("@idEspec", publi.espectaculo.id.ToString());
                command.Parameters.AddWithValue("@gradoPublicacion", publi.gradoPublicacion.id.ToString());
                command.Parameters.Add(fechaPubParam);
                command.Parameters.Add(fechaEveParam);
                command.Parameters.AddWithValue("@estado", publi.estado);
                command.Parameters.Add(outId);

                DatabaseConection.executeNoParamFunction(command);
                return int.Parse(outId.Value.ToString());
            }
            catch (Exception ex) {
                throw ex;
            }

        }
    }
}
