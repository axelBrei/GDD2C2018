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
using System.Data;

namespace PalcoNet.Dao
{
    class GradoDePublicacionDao
    {

        public List<GradoPublicacion> getGradosDePublicacion() {
            List<GradoPublicacion> gradosPublicacion = new List<GradoPublicacion>();
            string query = "SELECT * " +
                           "FROM TheBigBangQuery.GradoPublicaciones " +
                           "ORDER BY 3 DESC";
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
                grado.id = (int)(reader.IsDBNull(0) ? null : (Nullable<int>)reader.GetSqlDecimal(0));
                grado.nivel = reader.IsDBNull(1) ? null : reader.GetSqlString(1).ToString();
                grado.comision = reader.IsDBNull(2) ? null : (Nullable<float>)float.Parse(reader["grad_comision"].ToString());
                grado.bajaLogica = (Nullable<DateTime>) (reader.IsDBNull(3) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(3));
            }
            catch (Exception e) {
                throw new ObjectParseException("Error al recuperar los datos de los grados de publicacion");
            }
            return grado;
        }

        public void insertGradoDePublicacion(GradoPublicacion grado) {
            string query = "INSERT INTO [TheBigBangQuery].[GradoPublicaciones](grad_nivel,grad_comision) " +
                            "VALUES (@descripcion, @comision)";
            SqlCommand command = new SqlCommand(query);

            SqlParameter descParam = new SqlParameter("@descripcion", System.Data.SqlDbType.NVarChar);
            descParam.Value = grado.nivel;

            SqlParameter comsionParam = new SqlParameter("@comision", System.Data.SqlDbType.Decimal);
            comsionParam.Value = (decimal)grado.comision;

            command.Parameters.Add(descParam);
            command.Parameters.Add(comsionParam);

            try
            {
                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                Console.Write(e.Message);
            }
        }

        public void actualizarGradoDePublicacion(GradoPublicacion grado) {
            string query = "UPDATE [TheBigBangQuery].[GradoPublicaciones] " +
                           "SET [grad_nivel] = '" + grado.nivel + 
                           "', [grad_comision] = " + grado.comision.ToString() +
                           " WHERE [grad_id] = " + grado.id;
            SqlCommand command = new SqlCommand(query);

            try
            {
                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) { }
        }

        public void habilitarODeshabilitarGrado(GradoPublicacion grado) {
            string fecha = grado.bajaLogica == null ? "NULL" : "'" + ((DateTime)grado.bajaLogica).Date.ToString("yyyy-dd-MM") + "'";
            string query = "UPDATE [TheBigBangQuery].[GradoPublicaciones] " +
                           "SET [grad_baja] = " + fecha + " " +
                           "WHERE [grad_id] = @id";
            SqlCommand command = new SqlCommand(query);

            SqlParameter param = new SqlParameter("@id", System.Data.SqlDbType.Decimal);
            param.Value = grado.id;
            command.Parameters.Add(param);

            try
            {
                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public GradoPublicacion getGradoPorId(int id) {
            GradoPublicacion grado;
            string query = "SELECT * FROM [TheBigBangQuery].[GradoPublicaciones] WHERE grad_id = @id";
            SqlDataReader reader = null;
            try
            {
                grado = new GradoPublicacion();
                SqlCommand command = new SqlCommand();

                command.CommandText = query;

                SqlParameter param = new SqlParameter("@id", SqlDbType.Decimal);
                param.Value = id;
                command.Parameters.Add(param);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    reader.Read();
                    return getGradoFromReader(reader);
                }
                else
                    throw new DataNotFoundException("Los datos traidos de la base de datos estan vacios.");
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("Error al obtener el grado con id " + id);
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }


    }
}
