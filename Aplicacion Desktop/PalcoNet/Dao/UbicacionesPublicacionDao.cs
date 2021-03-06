﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using PalcoNet.Constants;
using System.Data.SqlClient;

namespace PalcoNet.Dao
{
    class UbicacionesPublicacionDao
    {

        public decimal gerIdUbiPubi(int ubiId, int publiId) {
            string function = "SELECT [TheBigBangQuery].[getIdPubluUbi]('" + ubiId + "', '" + publiId + "')";
            try
            {
                SqlCommand command = new SqlCommand(function);
                command.CommandText = function;

                return DatabaseConection.executeParamFunction<decimal>(command);
            }
            catch (Exception e) {
                throw new DataNotFoundException("No se ha encontrado una ubicacion para esta publicacion");
            }
        }

        public int insertarUbicacionPorPublicacion(Ubicacion ubi, Publicacion pub, SqlTransaction transaction) {
            // REVISAR PORQ NO INSERTA LAS UBICACIONES DE LA PUBLICACION QUE LE ESTOY PASANDO
            string procedure = "[TheBigBangQuery].[InsertarUbicacionPorPublicacion]";
            try
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = transaction;

                command.Parameters.AddWithValue("@ubicacion", ubi.id.ToString());
                command.Parameters.AddWithValue("@publicacion", pub.id.ToString());
                command.Parameters.AddWithValue("@precio", ubi.precio.ToString());
                // POR DEFAULT TODAS LAS UBICACIONES ESTAN DISPONIBLES
                command.Parameters.AddWithValue("@disponible", "0");

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception ex) {
                return -1;
            }

            return 1;
        }

        public void eliminarUbicacionPorPublicacion(Ubicacion ubi, Publicacion publi, 
                                                        SqlTransaction transaction) 
        {
            string query = "DELETE FROM [TheBigBangQuery].[Ubicaciones_publicacion] " +
                "WHERE [ubpu_id_ubicacion] = '" + ubi.id.ToString() + "' AND [ubpu_id_publicacion] = '" + publi.id.ToString() + "'";

            try
            {
                SqlCommand command = new SqlCommand();

                command.Transaction = transaction;
                command.CommandText = query;

                DatabaseConection.executeQuery(command).Close();
            }
            catch (Exception ex) {
                throw new SqlDeleteException("Error al borrar ubicacion", SqlDeleteException.CODE_UBICACION);
            }
        }

    }
}
