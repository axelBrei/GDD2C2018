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

        public List<Compra> getPaginaComprasCliente(int clieId, int pagina) {
            string function = "SELECT * FROM [TheBigBangQuery].[getComprasPorPagina](@pagina, @clieId)";
            SqlDataReader reader = null;
            List<Compra> compras = new List<Compra>();
            try
            {
                SqlCommand command = new SqlCommand(function);

                command.Parameters.AddWithValue("@pagina", pagina);
                command.Parameters.AddWithValue("@clieId", clieId);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        compras.Add(parsearCompraDelReader(reader));
                    }
                }
                return compras;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("Error al buscar la pagina " + pagina + "de compras");
            }
            finally {
                if (reader != null && !reader.IsClosed) {
                    reader.Close();
                }
            }
        }

        public int getLastPaginaComprasCliente(int clieId) {
            string function = "SELECT [TheBigBangQuery].[getLastPaginaCompras](@clieId)";
            try
            {
                SqlCommand command = new SqlCommand(function);
                command.CommandText = function;

                command.Parameters.AddWithValue("clieId", clieId);

                return DatabaseConection.executeParamFunction<int>(command);
            }
            catch (Exception e) {
                throw new DataNotFoundException("No se ha podido encontrar la ultima pagina de compras");
            }
        }

        public void getComprasPorEmpresa(int empId, int canitdad, Action<List<Compra>> lambdaEmpresas) {
            string query = "SELECT * FROM [TheBigBangQuery].[getComprasDeEmpresaPorCantidad] (@empeId, @cantidad)";
            SqlDataReader reader = null;
            try
            {
                List<Compra> comprasList = new List<Compra>();
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.AddWithValue("@empeId", empId);
                command.Parameters.AddWithValue("@cantidad", canitdad);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comprasList.Add(parsearCompraDelReader(reader));
                    }
                }
                lambdaEmpresas(comprasList);
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se encontraron compras para el cliente selecionado");
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public Compra getDetalleCompraPorId(int id) {
            string query = "SELECT comp_id, comp_fecha_y_hora,comp_medio_de_pago, comp_cantidad,comp_total, " +
                                "publ_id, espe_descripcion, publ_fecha_hora_espectaculo, publ_estado, empr_razon_social, rub_descripcion " +
                            "FROM TheBigBangQuery.Compras " +
                                "JOIN TheBigBangQuery.Publicacion ON (publ_id = comp_publicacion) " +
                                "JOIN TheBigBangQuery.Espectaculo ON (publ_espectaculo = espe_id) " +
                                "JOIN TheBigBangQuery.Empresa ON (espe_empresa = empr_id) " +
                                "JOIN TheBigBangQuery.Rubro ON (espe_rubro = rub_id) " +
                            "WHERE comp_id = @compID";
            SqlDataReader reader = null;
            try
            {
                Compra compra = new Compra();
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.Add("@compID", id);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    reader.Read();
                    compra = parsearCompraDelReader(reader);
                    compra.publicacion.fechaEvento = reader.IsDBNull(7) ? Generals.getFechaMinima() : (DateTime)reader.GetSqlDateTime(7);
                    compra.publicacion.estado = reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString();
                    Empresa emp = new Empresa();
                    emp.razonSocial = reader.IsDBNull(9) ? null : reader.GetSqlString(9).ToString();
                    Rubro rub = new Rubro();
                    rub.descripcion = reader.IsDBNull(10) ? null : reader.GetSqlString(10).ToString();
                    compra.publicacion.espectaculo.rubro = rub;
                    compra.publicacion.espectaculo.empresa = emp;

                    return compra;

                }
                return compra;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se ha encontrado los detalles de la compra seleccionada");
            }
            finally { 
                if(reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }

        private Compra parsearCompraDelReader(SqlDataReader reader) {
            Compra compra = new Compra();

            compra.id = (int)reader.GetSqlDecimal(0);
            compra.fechaCompra = reader.IsDBNull(1) ? Generals.getFechaMinima() : (DateTime)reader.GetSqlDateTime(1);
            string medioPago = reader.IsDBNull(2) ? null : reader.GetSqlString(2).ToString();
            List<string> medios = medioPago.Split('/').ToList();
            Tarjeta tarjeta = new Tarjeta();
            if (medios.Count == 3)
            {
                tarjeta.titular = medios[0];
                tarjeta.numero = medios[1];
                tarjeta.vencimiento = medios[2];
            }
            else {
                tarjeta.numero = medioPago;
            }
            compra.medioPago = tarjeta;
            compra.cantidad = reader.IsDBNull(3) ? 0 : (int) reader.GetSqlDecimal(3);
            compra.total = reader.IsDBNull(4) ? 0 : (float)reader.GetSqlDecimal(4).ToDouble();
            Publicacion publi = new Publicacion();
            publi.id =  reader.IsDBNull(5) ? -1 : (int) reader.GetSqlDecimal(5);
            Espectaculo espe = new Espectaculo();
            espe.descripcion = reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString();
            publi.espectaculo = espe;
            compra.publicacion = publi;


            return compra;

        }
    }
}
