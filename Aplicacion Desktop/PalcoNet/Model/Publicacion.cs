using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Publicacion
    {

        public int id { get; set; }
        public GradoPublicacion gradoPublicacion { get; set; }
        public Espectaculo espectaculo { get; set; }
        public Nullable<DateTime> fechaPublicacion { get; set; }
        public Nullable<DateTime> fechaEvento { get; set; }
        public string estado { get; set; }
        public List<Ubicacion> ubicaciones;


        public Publicacion() {
            ubicaciones = new List<Ubicacion>();
        }
    }
}
