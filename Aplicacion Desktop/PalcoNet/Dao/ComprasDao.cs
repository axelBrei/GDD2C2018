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
    class ComprasDao
    {

        public void insertarCompra(Compra compra,Publicacion publi, SqlTransaction transaction) {
            string procedure = "[TheBigBangQuery].[InsertarCompra]";

            DataTable table = new DataTable();
            table.Columns.Add("ubli_ubicacion", typeof(decimal));
            compra.ubicaciones.ForEach(elem => {
                table.Rows.Add(elem.id);
            });



            try
            {
                SqlCommand com = new SqlCommand(procedure);
                com.CommandText = procedure;
                com.CommandType = CommandType.StoredProcedure;
                com.Transaction = transaction;

                com.Parameters.AddWithValue("@publicacion", publi.id);
                com.Parameters.AddWithValue("@cliente", compra.cli.id);
                com.Parameters.AddWithValue("@fechaCompra", compra.fechaCompra);
                com.Parameters.AddWithValue("@medioPago", compra.medioPago.ToString());
                com.Parameters.AddWithValue("@cantidad", compra.cantidad.ToString());
                com.Parameters.AddWithValue("@total", compra.total);

                SqlParameter param = new SqlParameter("@ubicaciones", SqlDbType.Structured);
                param.TypeName = "[TheBigBangQuery].[UbicacionesList]";
                param.Value = table;
               
                com.Parameters.Add(param);

                DatabaseConection.executeNoParamFunction(com);
            }
            catch (Exception e) {
                throw new SqlInsertException("Error al insertar la compra",0);
            }
        }
    }
}
