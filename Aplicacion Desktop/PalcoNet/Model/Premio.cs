using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class Premio
    {
        public int id{get;set;}
        public string nombre { get; set; }
        public int puntosNecesarios { get; set; }
        public DateTime fechaVencimiento { get; set; }
    }
}
