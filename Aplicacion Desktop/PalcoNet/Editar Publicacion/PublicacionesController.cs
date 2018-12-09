using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.Exceptions;
using System.Data;
using System.Data.SqlClient;
using PalcoNet.Dao;
using PalcoNet.Constants;

namespace PalcoNet.Editar_Publicacion
{
    class PublicacionesController
    {
        private PublicacionesDao publicacionesDao;
        private EspectaculosDao espectaculosDao;
        private RubrosDao rubrosDao;
        private UbicacionesDao ubicacionesDao;
        private TipoUbicacionDao tipoUbicacionDao;
        private UbicacionesPublicacionDao ubicacionesPorPublicacionDao;
        private GradoDePublicacionDao gradoPublicacionDao;
        private EmpresasDao empresasDao;

        public PublicacionesController() {
            publicacionesDao = new PublicacionesDao();
            rubrosDao = new RubrosDao();
            ubicacionesDao = new UbicacionesDao();
            tipoUbicacionDao = new TipoUbicacionDao();
            ubicacionesPorPublicacionDao = new UbicacionesPublicacionDao();
            gradoPublicacionDao = new GradoDePublicacionDao();
            espectaculosDao = new EspectaculosDao();
            empresasDao = new EmpresasDao();
        }

        public int insertarPublicacionEnDB(Publicacion publi, SqlTransaction transaction)
        {
            try
            {
                publi.id = publicacionesDao.insertarPublicacion(publi, transaction);
                if (publi.id != -1)
                {
                    publi.ubicaciones.ForEach(elem =>
                    {
                        elem.id = ubicacionesDao.insertarUbicacion(elem, transaction);
                        if (elem.id != -1)
                            ubicacionesPorPublicacionDao.insertarUbicacionPorPublicacion(elem, publi, transaction);
                    });
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw new SqlInsertException();
            }


        }

        public Publicacion getPublicacionPorId(int id) {
            try
            {
                Publicacion publicacion = publicacionesDao.getPublicacionPorId(id);
                publicacion.gradoPublicacion = gradoPublicacionDao.getGradoPorId(publicacion.gradoPublicacion.id);
                // busco el espectaculo asociado a la publicacion
                publicacion.espectaculo = espectaculosDao.getEspectaculoPorId((int)publicacion.espectaculo.id);
                publicacion.espectaculo.rubro = rubrosDao.getRubroPorId((int)publicacion.espectaculo.rubro.id);
                publicacion.espectaculo.empresa = empresasDao.getEmpresaPorId((int)publicacion.espectaculo.empresa.id);
                // busco las ubicaciones pertenecientes a la ubicacion
                publicacion.ubicaciones.AddRange(ubicacionesDao.getUbicacionesDeLaPublicacion((int)publicacion.id));

                return publicacion;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void actualizarPublicacion(Publicacion publicacion, SqlTransaction transaction,
                                             List<Ubicacion> agregados = null, List<Ubicacion>eliminados = null) {
            try
            {
                publicacionesDao.actualizarPublicacion(publicacion,transaction);
                if(agregados != null){
                    agregados.ForEach(elem => {
                        elem.id = ubicacionesDao.insertarUbicacion(elem,transaction);
                        if (elem.id != -1)
                            ubicacionesPorPublicacionDao.insertarUbicacionPorPublicacion(elem, publicacion, transaction);
                    });
                }
                if(eliminados != null){

                    eliminados.ForEach(elem => {
                        ubicacionesPorPublicacionDao.eliminarUbicacionPorPublicacion(elem, publicacion, transaction);
                        //ubicacionesDao.eliminarUbicacion(elem, transaction);
                    });
                }
            }
            catch (Exception ex) {
                if(ex.GetType() == typeof(SqlInsertException)){
                    throw ex;
                }else if(ex.GetType() == typeof(SqlException)){
                    throw ex;
                }else{
                    throw new GenericException("Ha ocurrido un error inesperado");
                }
                
            }
        }
    }
}
