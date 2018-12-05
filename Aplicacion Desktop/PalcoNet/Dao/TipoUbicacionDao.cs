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
    class TipoUbicacionDao
    {
        public List<TipoUbicacion> getTipoUbicaciones() {
            List<TipoUbicacion> tiposUbicaciones = new List<TipoUbicacion>();
            string query = "SELECT * FROM [TheBigBangQuery].[TipoUbicacion]";
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tiposUbicaciones.Add(getTipoUbicacionFromReader(reader));
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {

            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
            return tiposUbicaciones;
        }

        private TipoUbicacion getTipoUbicacionFromReader(SqlDataReader reader) {
            TipoUbicacion tipoUbicacion = null;
            try
            {
                tipoUbicacion = new TipoUbicacion();
                tipoUbicacion.id = (int)(reader.IsDBNull(0) ? null : (Nullable<int>) reader.GetSqlDecimal(0));
                tipoUbicacion.descripcion = (reader.IsDBNull(1) ? null : reader.GetSqlString(1).ToString());
            }
            catch (Exception ex) {
                throw new ObjectDisposedException("Error al parsear el tipo de ubicacion");
            }


            return tipoUbicacion;
        }
    }
}
