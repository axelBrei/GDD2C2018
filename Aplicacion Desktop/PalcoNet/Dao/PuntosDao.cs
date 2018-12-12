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
    }
}
