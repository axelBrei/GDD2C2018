using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Constants;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;

namespace PalcoNet.Dao
{
    class FormasDePagoDao
    {
        public List<string> getFormasDePago() {
            string query = "SELECT form_nombre FROM TheBigBangQuery.FormaDePago";
            SqlDataReader reader = null;
            List<string> response = new List<string>();
            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response.Add(reader.GetSqlString(0).ToString());
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("No se han encontrado metodos de pago");
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}
