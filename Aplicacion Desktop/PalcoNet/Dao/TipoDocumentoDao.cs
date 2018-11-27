using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.ConectionUtils;
using PalcoNet.Model;
using System.Data.SqlClient;

namespace PalcoNet.Dao
{
    class TipoDocumentoDao
    {

        public List<string> getTiposDeDocumento() {
            string query = "SELECT tipo_descripcion FROM TheBigBangQuery.Tipo_Documento";
            SqlDataReader reader = DatabaseConection.executeQuery(query);
            List<string> listaTiposDoc = new List<string>();
            while (reader.Read()) { 
                listaTiposDoc.Add((string)reader.GetSqlString(0));
            }
            reader.Close();
            return listaTiposDoc;
        }
    }
}
