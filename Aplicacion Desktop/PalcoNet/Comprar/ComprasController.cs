using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Dao;
using PalcoNet.Exceptions;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;
using PalcoNet.UserData;

namespace PalcoNet.Comprar
{
    class ComprasController
    {
        public void insertarCompraConItems(Compra compra, Publicacion publi) {
            ComprasDao comprasDao = new ComprasDao();
            PuntosDao puntosDao = new PuntosDao();
            SqlTransaction tansaction = DatabaseConection.getInstance().BeginTransaction();
            try
            {
                comprasDao.insertarCompra(compra, publi, tansaction);
                puntosDao.actualizarPuntosPorCompra(compra, tansaction);
                tansaction.Commit();
            }
            catch (Exception e) {
                tansaction.Rollback();
                throw e;
            }

        }
    }
}
