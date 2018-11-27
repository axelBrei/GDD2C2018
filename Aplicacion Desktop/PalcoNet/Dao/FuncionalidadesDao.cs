using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;


namespace PalcoNet.Dao
{
    class FuncionalidadesDao
    {

        public List<Funcionalidad> getFuncionalidades() {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            string query = "SELECT * FROM TheBigBangQuery.Funcionalidad ORDER BY func_id ASC";
            SqlDataReader reader = DatabaseConection.executeQuery(query);
            if (reader.HasRows) {
                Funcionalidad func;
                while (reader.Read()) {
                    func = new Funcionalidad();
                    func.id = (int)reader.GetSqlDecimal(0);
                    func.descripcion = (string) reader.GetSqlString(1);
                    funcionalidades.Add(func);
                }
            }
            reader.Close();
            return funcionalidades;
        }
    }
}
