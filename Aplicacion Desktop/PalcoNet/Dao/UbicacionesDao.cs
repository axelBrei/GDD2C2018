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
    class UbicacionesDao
    {

        public List<Ubicacion> getUbicaciones() {
            string query = "SELECT ubi_id, ubi_fila, ubi_asiento, ubi_sin_enumerar, tipu_id, tipu_descripcion " +
                           "FROM TheBigBangQuery.Ubicacion JOIN TheBigBangQuery.TipoUbicacion ON (tipu_id = ubi_tipo_codigo)";
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ubicaciones.Add(new Ubicacion(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("Ha ocurrido un error al traer los datos de la base de datos");
            }
            finally {
                if (reader != null & !reader.IsClosed) {
                    reader.Close();
                }
            }
            return ubicaciones;
        }

        public int insertarUbicacion(Ubicacion ubic, SqlTransaction transaction) {
            string procedure = "[TheBigBangQuery].[InsertarUbicacion]";
            try
            {
                SqlCommand command = new SqlCommand();

                command.Transaction = transaction != null ? transaction : null;
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fila", ubic.fila);
                command.Parameters.AddWithValue("@asiento", ubic.asiento.ToString());
                // TODO CAMBIAR OPCION PARA GENERAR UBICACIONES SIN ENUMERAR
                command.Parameters.AddWithValue("@sinEnumerar", "1");
                command.Parameters.AddWithValue("@tipoUbi", ubic.tipoUbicaciones.id.ToString());

                SqlParameter outId = new SqlParameter("@newId", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                command.Parameters.Add(outId);

                DatabaseConection.executeNoParamFunction(command);


                return int.Parse(outId.Value.ToString());
            }
            catch (Exception ex) {
                return -1;
            }
        }
    }
}
