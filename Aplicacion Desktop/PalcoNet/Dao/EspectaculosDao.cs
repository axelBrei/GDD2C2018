﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Constants;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;
using System.Data;
using PalcoNet.Exceptions;

namespace PalcoNet.Dao
{
    class EspectaculosDao
    {

        public int insertarEspectaculo(Espectaculo espec, SqlTransaction trans) {
            string query = "[TheBigBangQuery].[InsertarEspectaculo]";
            try
            {
                SqlCommand command = new SqlCommand(query);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = query;
                command.Transaction = trans;

                SqlParameter outId = new SqlParameter("@newId", SqlDbType.Decimal) { Direction = ParameterDirection.Output };

                command.Parameters.AddWithValue("@empresa", espec.empresa == null ?  "0" : espec.empresa.id.ToString());
                command.Parameters.AddWithValue("@rubro", espec.rubro.id);
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

        public Espectaculo getEspectaculoPorId(int id, SqlTransaction trans = null) {
            string query = "SELECT * FROM [TheBigBangQuery].[Espectaculo] WHERE espe_id = @id";
            SqlDataReader reader = null;
            Espectaculo espectaculo;
            try
            {
                espectaculo = new Espectaculo();
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                if (trans != null)
                    command.Transaction = trans;
                command.Parameters.AddWithValue("@id", id);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    reader.Read();
                    return ParserEspectaculo.parseEspectaculoFromReader(reader);
                }
                else {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("Error al intentar buscar el espectaculo con id {especId}".Replace("{especId}", id.ToString()));
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }

        }


        private class ParserEspectaculo
        {
            public static Espectaculo parseEspectaculoFromReader(SqlDataReader reader)
            {
                Espectaculo espectaculo = null;
                try
                {
                    espectaculo = new Espectaculo();
                    espectaculo.id = reader.IsDBNull(0) ? null : (Nullable<int>)reader.GetSqlDecimal(0);

                    Empresa empresa = new Empresa();
                    empresa.id = reader.IsDBNull(1) ? null : (Nullable<int>)reader.GetSqlDecimal(1);
                    espectaculo.empresa = empresa;

                    Rubro rubro = new Rubro();
                    rubro.id = reader.IsDBNull(2) ? null : (Nullable<int>)reader.GetSqlDecimal(2);
                    espectaculo.rubro = rubro;

                    espectaculo.descripcion = reader.IsDBNull(3) ? null : reader.GetSqlString(3).ToString();
                    espectaculo.direccion = reader.IsDBNull(4) ? null : reader.GetSqlString(4).ToString();

                    return espectaculo;
                }
                catch (Exception e)
                {
                    throw new ObjectParseException("Error al obtener Espectaculo");
                }
            }
        }
    }
}
