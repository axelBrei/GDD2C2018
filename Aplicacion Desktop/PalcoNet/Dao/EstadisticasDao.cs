using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Exceptions;
using PalcoNet.Constants;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class EstadisticasDao
    {
        private string errorText = "No se han podido cargar las estadisticas";

        public void getTop5EmpresasConMayorLocalidadesNoVendidas(DateTime fechaInicio, DateTime fechaFin, Action<List<Estadistico>> result) { 
            string query = "SELECT TOP 5 empr_id, COUNT(ubpu_disponible) " +
	                        "FROM [TheBigBangQuery].[Empresa] "  +
	                            "JOIN [TheBigBangQuery].[Espectaculo] ON (espe_empresa = empr_id) " +
	                            "JOIN [TheBigBangQuery].Publicacion ON (publ_espectaculo = espe_id) "  +
	                            "JOIN TheBigBangQuery.Ubicaciones_publicacion ON (ubpu_id_publicacion = publ_id) " +
	                            "JOIN [TheBigBangQuery].[GradoPublicaciones] ON (publ_grad_nivel = grad_id) " +
	                        "WHERE ubpu_disponible = 0 AND publ_fecha_hora_espectaculo BETWEEN @fechaInicio AND  @fechaFin " +
	                            "AND grad_id = @grado " +
	                        "GROUP BY empr_id, grad_comision "+
	                        "ORDER BY 2 DESC, grad_comision DESC";
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand(query);
                List<Estadistico> list = new List<Estadistico>();

                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estadistico est = new Estadistico();
                        est.nombre = reader.IsDBNull(0) ? null : reader.GetSqlString(0).ToString();
                        est.cantidad = reader.IsDBNull(1) ? -1 : (int)reader.GetSqlInt32(1);
                        list.Add(est);
                    }
                }
                result(list);
            }
            catch (Exception e)
            {
                throw new DataNotFoundException(errorText);
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }

        public void getTop5ClientesPuntosVencidos(DateTime fechaInicio, DateTime fechaFin, Action<List<Estadistico>> result){
            SqlDataReader reader = null;
            string query = "SELECT TOP 5 CONCAT(clie_nombre , ' ', clie_apellido), clie_puntos " +
	                        "FROM TheBigBangQuery.Cliente " +
	                        "WHERE  clie_prox_vencimiento_puntos BETWEEN @inicioTrimestre AND @finTrimestre " +
	                        "GROUP BY clie_nombre, clie_apellido, clie_puntos " +
	                        "ORDER BY clie_puntos DESC";
            try
            {
                List<Estadistico> list = new List<Estadistico>();
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.AddWithValue("@inicioTrimestre", fechaInicio);
                command.Parameters.AddWithValue("@finTrimestre", fechaFin);
                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estadistico est = new Estadistico();
                        est.nombre = reader.IsDBNull(0) ? null : reader.GetSqlString(0).ToString();
                        est.cantidad = reader.IsDBNull(1) ? -1 : (int)reader.GetSqlInt32(1);
                        list.Add(est);
                    }
                }
                result(list);
            }
            catch (Exception e)
            {
                throw new DataNotFoundException(errorText);
            }
            finally {
                if (reader != null && !reader.IsClosed) {
                    reader.Close();
                }
            }
        }

        public void getTop5ClientesConCompras(DateTime fechaInicio, DateTime fechaFin, Action<List<Estadistico>> result) { 
            // LAS COMPRAS QUE SE CUENTAN SON LAS COMPRAS EN SI, NO LAS UBICACIONES QUE SE COMPRARON; SINO QUE TODA LA BLSA COMPRA COMO UNA
            string query = "SELECT TOP 5 CONCAT(clie_nombre , ' ', clie_apellido), COUNT(*)" +
                    "FROM [TheBigBangQuery].[Compras] " +
	                    "JOIN [TheBigBangQuery].[Ubicaciones_Compra] ON (ubco_compra = comp_id) " +
	                    "JOIN [TheBigBangQuery].[Cliente] ON (comp_cliente = clie_id) " +
                    "WHERE comp_fecha_y_hora BETWEEN @fechaInicio AND @fechaFin " +
                    "GROUP BY CONCAT(clie_nombre , ' ', clie_apellido) " +
                    "ORDER BY 2 DESC";
            SqlDataReader reader = null;
            List<Estadistico> estList = new List<Estadistico>();
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);
                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estadistico est = new Estadistico();
                        string nombreCli = reader.IsDBNull(0) ? null : reader.GetSqlString(0).ToString();
                        int cantidad = reader.IsDBNull(1) ? -1 : (int)reader.GetSqlInt32(1);
                        est.nombre = nombreCli;
                        est.cantidad = cantidad;
                        estList.Add(est);
                    }
                }
                result(estList);
            }
            catch (Exception e)
            {
                throw new DataNotFoundException(errorText);
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }


        }
    }
}
