using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Exceptions;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class ItemFacturaDao
    {
        public void insertarItem(ItemFactura item, SqlTransaction trans) {
            string procedure = "[TheBigBangQuery].[InsertarItemFactura]";

            try
            {
                SqlCommand command = new SqlCommand(procedure);
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Transaction = trans;

                command.Parameters.AddWithValue("@numFact", item.numFactura);
                command.Parameters.AddWithValue("@idUbi", item.ubicacion.id);
                command.Parameters.AddWithValue("@idPubli", item.publicacion.id);
                command.Parameters.AddWithValue("@monto", item.monto);
                command.Parameters.AddWithValue("@cantidad", item.cantidad);
                command.Parameters.AddWithValue("@desc", item.descripcion);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (Exception e) {
                throw new SqlInsertException("Error al insertar el item de factura", 0);
            }
        }
    }
}
