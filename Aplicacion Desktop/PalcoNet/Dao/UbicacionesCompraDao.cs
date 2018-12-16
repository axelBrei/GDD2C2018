using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class UbicacionesCompraDao
    {

        public void getUbicacionesDeLaCompra(Compra compra, Action<List<Ubicacion>> ubicacionesFun, SqlTransaction trans = null) {
            SqlDataReader reader = null;
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            string query = "SELECT ubi_id, ubi_fila, ubi_asiento, ubi_sin_enumerar, tipu_id, tipu_descripcion, ubpu_precio " +
                            "FROM [TheBigBangQuery].[Compras]" +
                                " JOIN [TheBigBangQuery].[Ubicaciones_Compra] ON (comp_id = ubco_compra)" +
                                " JOIN [TheBigBangQuery].[Ubicacion] ON (ubi_id = ubco_ubicacion)" +
                                " JOIN [TheBigBangQuery].[Ubicaciones_publicacion] ON (ubpu_id_ubicacion = ubi_id AND ubpu_id_publicacion = comp_publicacion)" +
                                " JOIN [TheBigBangQuery].[TipoUbicacion] ON (ubi_tipo_codigo = tipu_id)" +
                                " WHERE comp_id = @compraId";
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                if (trans != null)
                    command.Transaction = trans;

                command.Parameters.AddWithValue("@compraId", compra.id);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ubicaciones.Add(new Ubicacion(reader));
                    }
                }
                ubicacionesFun(ubicaciones);
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han encontrado ubicaciones para la compra solicitada");
            }
            finally {
                if (reader != null & !reader.IsClosed) {
                    reader.Close();
                }
            }
        }
    }
}
