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


        public List<Factura> getFacturasDeEmpresaPorpagina(int idEmpresa, int pagina) {
            string function = "SELECT * FROM [TheBigBangQuery].[getFacturasDeLaEmpresaPorPagina](@empresaId, @pagina)";
            SqlDataReader reader = null;
            try
            {
                List<Factura> facturasList = new List<Factura>();
                SqlCommand command = new SqlCommand(function);
                command.CommandText = function;


                command.Parameters.AddWithValue("@empresaId", idEmpresa);
                command.Parameters.AddWithValue("@pagina", pagina);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read()) {
                        facturasList.Add(getItemDelReader(reader, idEmpresa));
                    }
                }

                return facturasList;
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("No se han encontrado facturas asociadas");
            }
            finally { 
                if (reader != null & !reader.IsClosed)
                {
                    reader.Close();
                }
            
            }
        }

        public int getUltimaPaginaFacturasPorEmpresa(int emprId) {
            string query = "SELECT [TheBigBangQuery].[getLastPaginaFacturasPorEmpresa](@idEmpresa)";

            try
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@idEmpresa", emprId);
                return DatabaseConection.executeParamFunction<int>(command);
            }
            catch (Exception ex) {
                throw new DataNotFoundException("No se ha podido cargar la ultima pagina de facturas");
            }
        }

        private Factura getItemDelReader(SqlDataReader reader, int idEmpresa) {
            Factura fact = new Factura();

            fact.numero = (int)reader.GetSqlDecimal(0);
            fact.formaDePago = reader.GetSqlString(1).ToString();
            fact.IdEmpresa = idEmpresa;
            fact.total = float.Parse(reader["total"].ToString());
            fact.fecha = (DateTime) reader.GetSqlDateTime(3);

            return fact;
        }
    }
}
