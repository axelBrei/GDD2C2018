using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Constants;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using System.Data;

namespace PalcoNet.Dao
{
    class TarjetasDao
    {

        public List<Tarjeta> getTardejtasDelCliente(int clieId) {
            string query = "SELECT * FROM [TheBigBangQuery].[Tarjetas] WHERE tarj_cliente = @id";
            SqlDataReader reader = null;
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;

                command.Parameters.AddWithValue("@id", clieId);

                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tarjetas.Add(parsearTarjetaDeReader(reader));
                    }
                }

                return tarjetas;
            }
            catch (Exception e)
            {
                throw new DataNotFoundException("No se han encontrado tarjetas");
            }
            finally {
                if (reader != null && !reader.IsClosed) {
                    reader.Close();
                }
            }
        }

        public void insertarTarjetaDeCliente(Tarjeta tarj, int clieID) {
            string query = "INSERT INTO [TheBigBangQuery].[Tarjetas] (tarj_cliente, tarj_titular, tarj_numero, tarj_caducidad, tarj_cvv) " +
                "VALUES (@cli, @titular, @numero, @vencimiento, @cvv)";
            try {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@cli", clieID);
                command.Parameters.AddWithValue("@titular", tarj.titular);
                command.Parameters.AddWithValue("@numero", tarj.numero);
                command.Parameters.AddWithValue("@vencimiento", tarj.vencimiento);
                command.Parameters.AddWithValue("@cvv", tarj.vcc);

                DatabaseConection.executeNoParamFunction(command);
            }
            catch(Exception e){
                throw new SqlInsertException("Error al insertar tarjeta de credito", 0);
            }
        }

        public void elminarTarjetaDelCliente(int clieId, int idTarjeta) {
            string query = "DELETE FROM [TheBigBangQuery].[Tarjetas] WHERE tarj_id = @tarjId AND tarj_cliente = @clieId";
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@tarjId", idTarjeta);
                command.Parameters.AddWithValue("@clieId", clieId);

                DatabaseConection.executeQuery(command).Close();
            }
            catch (Exception ex) {
                throw new Exception("Error al intentar borrar la tarjeta");
            }
        }

        private Tarjeta parsearTarjetaDeReader(SqlDataReader reader) {
            Tarjeta tarjeta = new Tarjeta();

            tarjeta.id = (int)reader.GetSqlDecimal(0);
            tarjeta.titular = reader.IsDBNull(2) ? null : reader.GetSqlString(2).ToString();
            tarjeta.numero = reader.IsDBNull(3) ? null : reader.GetSqlString(3).ToString();
            tarjeta.vencimiento = reader.IsDBNull(4) ? null : reader.GetSqlString(4).ToString();
            tarjeta.vcc = reader.IsDBNull(5) ? null : reader.GetSqlString(5).ToString();

            return tarjeta;
        }
    }
}
