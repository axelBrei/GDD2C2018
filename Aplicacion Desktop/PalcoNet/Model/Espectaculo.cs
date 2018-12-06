using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Espectaculo
    {
        public int id{get; set;}
        public Rubro rubro { get; set; }
        public Empresa empresa { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }


    }
}
