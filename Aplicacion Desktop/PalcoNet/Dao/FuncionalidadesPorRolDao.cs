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
        public void borrarFuncionalidadPorRol(Rol rol, List<Funcionalidad> funcionalidades) {
            if (funcionalidades.Count > 0)
            {
                string query = "DELETE FROM TheBigBangQuery.Funcionalidades_rol " +
                "WHERE fpr_rol = " + rol.id + " AND (";
                for (int i = 0; i < funcionalidades.Count; i++)
                {
                    query += " fpr_id = " + funcionalidades.ElementAt(i).id;
                    if (i + 1 != funcionalidades.Count) query += " OR";
                }
                query += ")";
                DatabaseConection.executeQuery(query).Close();
            }
        }

        public void agregarFuncionalidadPorRol(Rol rol, List<Funcionalidad> funcionalidades) {
            if (funcionalidades.Count > 0)
            {
                string query = "INSERT INTO TheBigBangQuery.Funcionalidades_rol " +
                "(fpr_rol, fpr_id) VALUES ";
                funcionalidades.ForEach(elem => {
                    query += " (" + rol.id + " , " + elem.id + "), ";
                });
                query = query.Remove(query.Length - 2, 1);
                DatabaseConection.executeQuery(query).Close();
            }
        }




    }
}
