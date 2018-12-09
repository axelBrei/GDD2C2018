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
        string baseQuery = "SELECT * FROM [TheBigBangQuery].[Publicacion]";


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


        public List<Publicacion> getPublicaciones() {
            List<Publicacion> publicaciones = new List<Publicacion>();
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(baseQuery);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        publicaciones.Add(ParserPublicaciones.parsearPublicacionDelReader(reader));
                    }
                }
                return publicaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }    
        }


        public Publicacion getPublicacionPorId(int id) {
            Publicacion publicacion;
            SqlDataReader reader = null;
            string query = baseQuery + "WHERE publ_id = @id";
            try
            {
                publicacion = new Publicacion();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;

                SqlParameter param = new SqlParameter("@id", SqlDbType.Decimal);
                param.Value = id;
                command.Parameters.Add(param);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    reader.Read();
                    return ParserPublicaciones.parsearPublicacionDelReader(reader);
                }
                else {
                    throw new Exception();
                }

            }
            catch (Exception ex) {
                throw new DataNotFoundException("Error al buscar la publicacion con id {id}".Replace("{id}", id.ToString()));
            }
            finally
            {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }

        }

        public List<Publicacion> getPublicacionesConInfoBasica() {
            string query = "SELECT publ_id, publ_espectaculo, publ_grad_nivel, publ_fecha_publicacion, publ_fecha_hora_espectaculo," +
                    "publ_estado, espe_descripcion, espe_direccion ,grad_nivel " +
                "FROM [TheBigBangQuery].[Publicacion] JOIN [TheBigBangQuery].[Espectaculo] ON (espe_id = publ_espectaculo) " +
                    "JOIN [TheBigBangQuery].[GradoPublicaciones] ON (grad_id = publ_grad_nivel)";

            List<Publicacion> publicaciones = new List<Publicacion>();
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Publicacion publicacion = ParserPublicaciones.parsearPublicacionDelReader(reader);
                        publicacion.espectaculo.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
                        publicacion.espectaculo.direccion = reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString();
                        publicacion.gradoPublicacion.nivel = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();

                        publicaciones.Add(publicacion);
                    }
                }
                return publicaciones;
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("Error al buscar las publicaciones");
            }
            finally
            {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }


        public void actualizarPublicacion(Publicacion publicacion, SqlTransaction transaction) {
            string procedure = "[TheBigBangQuery].[ActualizarPublicacion]";
            try
            {
                SqlCommand command = new SqlCommand(procedure);
                command.CommandText = procedure;
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@publId", publicacion.id.ToString());
                command.Parameters.AddWithValue("@espeId", publicacion.espectaculo.id.ToString());
                command.Parameters.AddWithValue("@rubroEspe", publicacion.espectaculo.rubro.id.ToString());
                command.Parameters.AddWithValue("@descipcion", publicacion.espectaculo.descripcion.ToString());
                command.Parameters.AddWithValue("@direccion", publicacion.espectaculo.direccion.ToString());
                command.Parameters.AddWithValue("@idGradoPublicacion", publicacion.gradoPublicacion.id.ToString());

                SqlParameter fechaPubliParam = new SqlParameter("@fechaPublicacion", SqlDbType.DateTime);
                fechaPubliParam.Value = publicacion.fechaPublicacion;

                SqlParameter fechaEventoParam = new SqlParameter("@fechaEvento", SqlDbType.DateTime);
                fechaEventoParam.Value = publicacion.fechaEvento;

                command.Parameters.Add(fechaPubliParam);
                command.Parameters.Add(fechaEventoParam);
                command.Parameters.AddWithValue("@estado", publicacion.estado);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                throw new SqlInsertException("No se ha podido actualizar la publicacion.", SqlInsertException.CODIGO_PUBLICACION);
            }
        }

        private class ParserPublicaciones
        {

            public static Publicacion parsearPublicacionDelReader(SqlDataReader reader)
            {
                Publicacion publicacion;

                try
                {
                    publicacion = new Publicacion();

                    publicacion.id = (int)(reader.IsDBNull(0) ? null : (Nullable<int>)reader.GetSqlDecimal(0));
                    Espectaculo espesctaculo = new Espectaculo();

                    espesctaculo.id = (int)(reader.IsDBNull(1) ? null : (Nullable<int>)reader.GetSqlDecimal(1));
                    publicacion.espectaculo = espesctaculo;

                    GradoPublicacion grado = new GradoPublicacion();
                    grado.id = (int)(reader.IsDBNull(2) ? null : (Nullable<int>)reader.GetSqlDecimal(2));
                    publicacion.gradoPublicacion = grado;

                    publicacion.fechaPublicacion = reader.IsDBNull(3) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(3);
                    publicacion.fechaEvento = reader.IsDBNull(4) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(4);
                    publicacion.estado = reader.IsDBNull(5) ? null : reader.GetSqlString(5).ToString();

                    return publicacion;
                }
                catch (Exception e)
                {
                    throw new ObjectParseException("Error al parsear publicacion");
                }
            }
        }
    }
}
