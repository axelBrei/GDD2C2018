using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PalcoNet.Dao
{
    class RubrosDao
    {
        public List<Rubro> getRubros() {
            List<Rubro> rubros = new List<Rubro>();
            string query = "SELECT * " +
                           "FROM [TheBigBangQuery].[Rubro]";
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rubros.Add(getRubroFRomReader(reader));
                    }
                }
                else
                {
                    throw new DataNotFoundException("No se ha encontrado una lista de rubros");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (DataNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception e) {
                throw e;
            }
            finally {
                if (reader != null & !reader.IsClosed) 
                    reader.Close();
            }

            return rubros;
        }

        private Rubro getRubroFRomReader(SqlDataReader reader) {
            Rubro rubro = new Rubro();
            try
            {
                rubro.id = (int)(reader.IsDBNull(0) ? null : (Nullable<int>)reader.GetSqlDecimal(0));
                rubro.descripcion = reader.IsDBNull(1) ? null : reader.GetSqlString(1).ToString();
            }
            catch (Exception e) {
                throw new ObjectParseException("Error al parsear el rubro");
            }
            return rubro;
        }
    }
}
