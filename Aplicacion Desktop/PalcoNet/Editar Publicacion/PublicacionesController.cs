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
    }
}
