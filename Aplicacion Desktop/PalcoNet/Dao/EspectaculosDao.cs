using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Constants;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class EspectaculosDao
    {

        public int insertarEspectaculo(Espectaculo espec) {
            string query = "[TheBigBangQuery].[InsertarEspectaculo]";
            try
            {
                SqlCommand command = new SqlCommand(query);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = query;

                SqlParameter outId = new SqlParameter("@newId", SqlDbType.Decimal) { Direction = ParameterDirection.Output };

                command.Parameters.AddWithValue("@empresa", "1");
                command.Parameters.AddWithValue("@rubro", espec.rubro.id.ToString());
                command.Parameters.AddWithValue("@descripcion", espec.descripcion);
                command.Parameters.AddWithValue("@direccion", espec.direccion);
                command.Parameters.Add(outId);


                DatabaseConection.executeNoParamFunction(command);
                
                var returnV = outId.Value;

                return int.Parse(returnV.ToString());
            }
            catch (Exception e) {
                return -1;
            }
        }
    }
}
