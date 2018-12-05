using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using System.Data.SqlClient;

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
    }
}
