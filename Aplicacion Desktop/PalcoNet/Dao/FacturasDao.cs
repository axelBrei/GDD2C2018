using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.ConectionUtils;
using PalcoNet.Model;
using PalcoNet.Exceptions;
using PalcoNet.Constants;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class FacturasDao
    {
        public void insertarFactura(SqlTransaction transaction ,string tipoPago, Compra compra, Action<int> resNuevoId) {
            string procedure = "[TheBigBangQuery].[insertarNuevaFactura]";
            try {
                SqlCommand command = new SqlCommand(procedure);
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idCompra",compra.id);
                command.Parameters.AddWithValue("@tipoPago", tipoPago);
                command.Parameters.AddWithValue("@fecha", Generals.getFecha());
                command.Parameters.AddWithValue("@idEmpresa", compra.publicacion.espectaculo.empresa.id);
                SqlParameter param = new SqlParameter("@numeroFactura", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                command.Parameters.Add(param);

                DatabaseConection.executeNoParamFunction(command);
                var newId = param.Value;
                int newIdInt;
                if(int.TryParse(newId.ToString(), out newIdInt))
                    resNuevoId(newIdInt);

            }
            catch(Exception ex){
                throw new SqlInsertException("Error al realizar la rendicion de comisiones", 0);
            }
        }
        
    }
}
