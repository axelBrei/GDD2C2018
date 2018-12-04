using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using System.Data.SqlTypes;
using PalcoNet.Exceptions;

namespace PalcoNet.Dao
{
    class GradoDePublicacionDao
    {

        public List<GradoPublicacion> getGradosDePublicacion() {
            List<GradoPublicacion> gradosPublicacion = new List<GradoPublicacion>();
            string query = "SELECT grad_nivel, grad_comision " +
                           "FROM TheBigBangQuery.GradoPublicaciones " +
                           "ORDER BY 2 DESC";
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        gradosPublicacion.Add(getGradoFromReader(reader));
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (ObjectParseException ex) {
                throw ex;
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }

            return gradosPublicacion;
        }

        private GradoPublicacion getGradoFromReader(SqlDataReader reader) {
            GradoPublicacion grado = new GradoPublicacion();
            try
            {
                grado.nivel = reader.IsDBNull(0) ? null : reader.GetSqlString(0).ToString();
                grado.comision = reader.IsDBNull(1) ? null : (Nullable<float>)float.Parse(reader["grad_comision"].ToString());
            }
            catch (Exception e) {
                throw new ObjectParseException("Error al recuperar los datos de los grados de publicacion");
            }
            return grado;
        }
    }
}
