using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using PalcoNet.Model;
using System.Data.SqlClient;
using System.Data;
using PalcoNet.Constants;

namespace PalcoNet.Dao
{
    class PuntosDao
    {

        public void actualizarPuntosPorCompra(Compra compra, SqlTransaction trans) {
            string procedure = "[TheBigBangQuery].[ActualizarPuntosDelCliente]";
            try
            {
                SqlCommand command = new SqlCommand(procedure);
                command.CommandText = procedure;
                command.Transaction = trans;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idCliente", compra.cli.id);
                command.Parameters.AddWithValue("@montoCompra", compra.total);
                command.Parameters.AddWithValue("@fechaCompra", compra.fechaCompra);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                throw new SqlInsertException("No se han podido actualizar los puntos del cliente", 0);
            }
        }

        public void insertarNuevoPremio(Premio premio) {
            string procedure = "[TheBigBangQuery].[insertarNuevoPremio] @puntos, @nombre, @vencimiento";
            try
            {
                SqlCommand command = new SqlCommand(procedure);
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@puntos", premio.puntosNecesarios);
                command.Parameters.AddWithValue("@nombre", premio.nombre);
                command.Parameters.AddWithValue("@vencimiento", premio.fechaVencimiento);

                DatabaseConection.executeNoParamFunction(command);

            }
            catch (Exception ex) {
                throw new SqlInsertException("Error al insertar el premio", 0);
            }
        }

        public List<Premio> getPremiosPorPuntos() {
            string function = "SELECT * FROM [TheBigBangQuery].[getPremiosDelPuntaje]()";
            SqlDataReader reader = null;
            List<Premio> premiosList = new List<Premio>();
            try
            {
                SqlCommand command = new SqlCommand(function);
                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows) {
                    while (reader.Read()) {
                        premiosList.Add(parsearPremioDelReader(reader));
                    }
                }

                return premiosList;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han podido encontrar premios para los puntos actuales");
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }

        public void canjearPuntos(int clieId, int puntosARestar) {
            string query = "[TheBigBangQuery].[canjearPuntos]";
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@puntosCanjeados", puntosARestar);
                command.Parameters.AddWithValue("@idCliente", clieId);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                throw new SqlInsertException("Error al actualizar los puntos del usuario", 0);
            }
        }

        private Premio parsearPremioDelReader(SqlDataReader r) {
            Premio pre = new Premio();
            pre.id = (int) r.GetSqlDecimal(0);
            pre.puntosNecesarios = (int)r.GetSqlDecimal(1);
            pre.nombre = r.IsDBNull(2) ? null : r.GetSqlString(2).ToString();
            pre.fechaVencimiento = r.IsDBNull(3) ? Utils.getFechaMinima() : (DateTime)r.GetSqlDateTime(3);


            return pre;
        }
    }
}
