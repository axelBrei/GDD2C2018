using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;

namespace PalcoNet.Dao
{
    class FuncionalidadesPorRolDao
    {
        public void actualizarFuncionalidadesPorRol(Rol rol, List<Funcionalidad> funcionalidades) {
            if (funcionalidades.Count > 0)
            {
                string query = "DELETE FROM TheBigBangQuery.Funcionalidades_rol " +
                "WHERE fpr_rol = " + rol.id + " AND (";
                for (int i = 0; i < funcionalidades.Count; i++)
                {
                    query += " fpr_id = " + funcionalidades.ElementAt(i);
                    if (i + 1 != funcionalidades.Count) query += " OR";
                }
                query += ")";
                DatabaseConection.executeQuery(query);
            }
        }
    }
}
