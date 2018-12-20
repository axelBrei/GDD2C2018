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
using PalcoNet.Constants;

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
                reader = DatabaseConection.executeQuery(baseQuery + "ORDER BY publ_id DESC");
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


        public Publicacion getPublicacionPorId(int id, SqlTransaction trans = null) {
            Publicacion publicacion;
            SqlDataReader reader = null;
            string query = baseQuery + "WHERE publ_id = @id";
            try
            {
                publicacion = new Publicacion();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                if (trans != null)
                    command.Transaction = trans;

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

        public async Task<Publicacion> getPublicacionPorIdAsync(int id) {
            try
            {
                return await Task.FromResult<Publicacion>(getPublicacionPorId(id));
            }
            catch (Exception e) {
                throw new DataNotFoundException("Error al buscar la publicacion con id {id}".Replace("{id}", id.ToString()));
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


        public void actualizarPublicacion(bool fechaActualizda,Publicacion publicacion, SqlTransaction transaction) {
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
                command.Parameters.AddWithValue("@direccion",  publicacion.espectaculo.direccion.ToString());
                command.Parameters.AddWithValue("@idGradoPublicacion", publicacion.gradoPublicacion.id.ToString());
                command.Parameters.AddWithValue("@fechaPublicacion", publicacion.fechaPublicacion);
                command.Parameters.AddWithValue("@fechaEvento", publicacion.fechaEvento);

                command.Parameters.AddWithValue("@estado", publicacion.estado);
                command.Parameters.AddWithValue("@fechaActualizada", fechaActualizda ? 1 : 0);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                if (e.Message.Contains("Ya existe")) {
                    throw new SqlInsertException("No se puede actualizar la publicacion porque ya existe una del mismo espectaculo para la fecha seleccionada"
                        , SqlInsertException.CODIGO_PUBLICACION);
                }else
                    throw new SqlInsertException("No se ha podido actualizar la publicacion.", SqlInsertException.CODIGO_PUBLICACION);
            }
        }

        public List<Publicacion> getInfoBasicaPublicacionPorPagina(int pagina) {
            List<Publicacion> publicaciones = new List<Publicacion>();
            string query = "SELECT * FROM [TheBigBangQuery].[getPublicacionesPorPagina](@numPagina, @tabla) ";
            SqlDataReader reader = null;

            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.AddWithValue("@numPagina", pagina);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Publicacion publi = ParserPublicaciones.parsearPublicacionDelReader(reader);
                        publi.espectaculo.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
                        publi.espectaculo.direccion = reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString();
                        publi.gradoPublicacion.nivel = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();
                        publicaciones.Add(publi);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han encontrado publicaciones para la pagina " + pagina);
            }
            finally {
                if (reader != null & !reader.IsClosed) 
                    reader.Close();
            }

            return publicaciones;
        }

        public List<Publicacion> filtrarPaginasPorRubro(int pagina, List<Rubro> rubros) {
            string funcion = "SELECT * FROM [TheBigBangQuery].[getPaginaPublicacionesPorFiltroRubros](@pagina, @table, @fechaActual)";
            List<Publicacion> publis = new List<Publicacion>();
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand(funcion);
                command.CommandText = funcion;

                DataTable table = new DataTable();
                table.Columns.Add("rub_id", typeof(decimal));

                foreach (Rubro r in rubros)
                {
                    table.Rows.Add(r.id);
                }

                SqlParameter param = new SqlParameter("@table", SqlDbType.Structured);
                param.TypeName = "[TheBigBangQuery].[RubrosList]";
                param.Value = table;

                command.Parameters.AddWithValue("@pagina", pagina);
                command.Parameters.Add(param);
                command.Parameters.AddWithValue("@fechaActual", Generals.getFecha());

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Publicacion publi = ParserPublicaciones.parsearPublicacionDelReader(reader);
                        publi.espectaculo.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
                        publi.espectaculo.direccion = reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString();
                        publi.gradoPublicacion.nivel = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();
                        publis.Add(publi);
                    }
                }


                return publis;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han encontrado publicaciones pertenecientes a los rubros seleccionados");
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }

        public List<Publicacion> filtrarPaginasPorDescripcion(int pagina, string descripcion) {
            List<Publicacion> publis;
            SqlDataReader reader = null;
            string function = "SELECT * FROM [TheBigBangQuery].[getPaginaPublicacionesPorFiltroDescripcion](@pag, @desc,@fechaActual)";
            try
            {
                publis = new List<Publicacion>();
                SqlCommand command = new SqlCommand(function);
                command.CommandText = function;

                command.Parameters.AddWithValue("@pag", pagina);
                command.Parameters.AddWithValue("@desc", descripcion);
                command.Parameters.AddWithValue("@fechaActual", Generals.getFecha());

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Publicacion publi = ParserPublicaciones.parsearPublicacionDelReader(reader);
                        publi.espectaculo.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
                        publi.espectaculo.direccion = reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString();
                        publi.gradoPublicacion.nivel = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();
                        publis.Add(publi);

                    }
                }
                return publis;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han encontrado publicaciones coincidentes con la descripcion ingresada");
            }
            finally {
                if (reader != null & !reader.IsClosed) {
                    reader.Close();
                }
            }
        }

        public List<Publicacion> filtrarPaginasPorFechas(int pagina, DateTime fechaInicio, DateTime fechaFin) {
            string function = "SELECT * FROM [TheBigBangQuery].[getPaginaPublicacionesPorFiltroFecha](@pag, @fechaI, @fechaF)";
            SqlDataReader reader = null;
            List<Publicacion> publis;
            try
            {
                publis = new List<Publicacion>();
                SqlCommand command = new SqlCommand(function);
                command.CommandText = function;

                command.Parameters.AddWithValue("@pag", pagina);
                command.Parameters.AddWithValue("@fechaI", fechaInicio);
                command.Parameters.AddWithValue("@fechaF", fechaFin);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Publicacion publi = ParserPublicaciones.parsearPublicacionDelReader(reader);
                        publi.espectaculo.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
                        publi.espectaculo.direccion = reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString();
                        publi.gradoPublicacion.nivel = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();
                        publis.Add(publi);
                    }
                }
                return publis;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han encontrado publicaciones entre las fechas ingresadas");
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }

        public List<Publicacion> getPublicacionesPorPagina(int pagina, Nullable<int> empresaId = null) {
            string function = "SELECT * FROM [TheBigBangQuery].[GetPublicacionesPorPaginaSinFiltroDeEmpresa](@pagina, @empresa, @fechaActual)";
            SqlDataReader reader = null;
            List<Publicacion> publicacionesList = new List<Publicacion>();
            try
            {
                SqlCommand command = new SqlCommand(function);
                command.CommandText = function;

                command.Parameters.AddWithValue("@pagina", pagina);
                if (empresaId != null)
                    command.Parameters.AddWithValue("@empresa", empresaId);
                else
                    command.Parameters.AddWithValue("@empresa", DBNull.Value);

                command.Parameters.AddWithValue("@fechaActual", Generals.getFecha());

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Publicacion publi = ParserPublicaciones.parsearPublicacionDelReader(reader);
                        publi.espectaculo.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
                        publi.espectaculo.direccion = reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString();
                        publi.gradoPublicacion.nivel = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();
                        publicacionesList.Add(publi);
                    }
                }
                return publicacionesList;
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("No se han encontrado publicaciones para la pagina seleccionada");
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public int getUlitimaPaginaNoFiltro(Nullable<int> empresaId = null) {
            string function = "SELECT [TheBigBangQuery].[getLastPaginaPublicacionesSinFiltro](@empresa,@fechaActual)";
            try
            {
                SqlCommand command = new SqlCommand(function);
                if (empresaId == null)
                {
                    command.Parameters.AddWithValue("@empresa", DBNull.Value);
                }
                else
                    command.Parameters.AddWithValue("@empresa", (int) empresaId);
                command.Parameters.AddWithValue("@fechaActual", Generals.getFecha());
                return DatabaseConection.executeParamFunction<int>(command);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int getUltimaPaginaDesc(string desc) {
            string query = "SELECT [TheBigBangQuery].[getUltimaLineaFiltroDesc](@desc, @fechaActual)";
            try
            {
                SqlCommand com = new SqlCommand(query);
                com.Parameters.AddWithValue("@desc", desc);
                com.Parameters.AddWithValue("@fechaActual", Generals.getFecha());
                return DatabaseConection.executeParamFunction<int>(com);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public int getUltimaPaginaFecha(DateTime fechaI, DateTime fechaF) {
            string query = "SELECT [TheBigBangQuery].[getUltimaPagFiltroFecha](@fechaI, @fechaF)";
            try
            {
                SqlCommand com = new SqlCommand(query);

                com.Parameters.AddWithValue("@fechaI", fechaI);
                com.Parameters.AddWithValue("@fechaF", fechaF);

                return DatabaseConection.executeParamFunction<int>(com);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public int getUltimaPaginaRubros(List<Rubro> rubros)
        {
            string query = "SELECT [TheBigBangQuery].[getUltimaLineaFiltroRubro](@table, @fechaActual)";
            try
            {
                SqlCommand com = new SqlCommand(query);

                DataTable table = new DataTable();
                table.Columns.Add("rub_id", typeof(decimal));

                foreach (Rubro r in rubros)
                {
                    table.Rows.Add(r.id);
                }

                SqlParameter param = new SqlParameter("@table", SqlDbType.Structured);
                param.TypeName = "[TheBigBangQuery].[RubrosList]";
                param.Value = table;

                com.Parameters.Add(param);
                com.Parameters.AddWithValue("@fechaActual", Generals.getFecha());

                return DatabaseConection.executeParamFunction<int>(com);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        // -------------------------PARSER-------------------------------------------

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
