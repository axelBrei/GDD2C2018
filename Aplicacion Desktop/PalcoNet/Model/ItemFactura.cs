using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class ItemFactura
    {
        public int id { get; set; }
        public int numFactura { get; set; }
        public Ubicacion ubicacion { get; set; }
        public Publicacion publicacion { get; set; }
        public float monto { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }

        

    }
}
