﻿using System;
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
        private string baseQuery = "SELECT ubi_id, ubi_fila, ubi_asiento, ubi_sin_enumerar, tipu_id, tipu_descripcion ";

        private string baseFrom = "FROM TheBigBangQuery.Ubicacion ";
        public List<Ubicacion> getUbicaciones() {
            
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            SqlDataReader reader = null;
            string query = baseQuery + ", ubpu_precio" + baseFrom + " JOIN TheBigBangQuery.TipoUbicacion ON (tipu_id = ubi_tipo_codigo)";
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

        public List<Ubicacion> getUbicacionesDeLaPublicacion(int idPubli) {
            string query = baseQuery + ", ubpu_precio " + baseFrom + "JOIN [TheBigBangQuery].[Ubicaciones_publicacion] ON (ubpu_id_ubicacion = ubi_id) " +
                                       "JOIN [TheBigBangQuery].[TipoUbicacion] ON (tipu_id = ubi_tipo_codigo) " +
                                       "WHERE ubpu_id_publicacion = @idPublicacion ORDER BY 2 ASC, 3 ASC";
            SqlDataReader reader = null;
            List<Ubicacion> ubicaciones;
            try
            {
                ubicaciones = new List<Ubicacion>();

                SqlCommand command = new SqlCommand();
                command.CommandText = query;

                SqlParameter param = new SqlParameter("@idPublicacion", SqlDbType.Decimal);
                param.Value = idPubli;
                command.Parameters.Add(param);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ubicaciones.Add(new Ubicacion(reader));
                    }
                    return ubicaciones;
                }
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                throw new DataNotFoundException(
                    "No se han podido encontrar las ubicaciones para la publicacion con id {idPubli}"
                        .Replace("{idPubli}", idPubli.ToString()
                ));
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}
