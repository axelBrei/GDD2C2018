using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Dao;
using PalcoNet.Model;
using PalcoNet.Exceptions;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;

namespace PalcoNet.Generar_Publicacion
{
    public class PublicacionesController
    {
        private PublicacionesDao publicacionesDao;
        private UbicacionesDao ubicacionesDao;
        private EspectaculosDao espectaculosDao;
        private UbicacionesPublicacionDao ubicacionesPublicacionesDao;

        public PublicacionesController() {
            publicacionesDao = new PublicacionesDao();
            ubicacionesDao = new UbicacionesDao();
            espectaculosDao = new EspectaculosDao();
            ubicacionesPublicacionesDao = new UbicacionesPublicacionDao();
        }

        public int insertarPublicacionEnDB(Publicacion publi, SqlTransaction transaction) {
            try
            {
                publi.id = publicacionesDao.insertarPublicacion(publi, transaction);
                if (publi.id != -1) {
                    publi.ubicaciones.ForEach(elem => {
                        elem.id = ubicacionesDao.insertarUbicacion(elem,transaction);
                        if (elem.id != -1)
                            ubicacionesPublicacionesDao.insertarUbicacionPorPublicacion(elem, publi, transaction);
                    });
                }
                return 1;
            }
            catch (Exception ex) {
                throw new SqlInsertException();
            }

            
        }
    }
}
