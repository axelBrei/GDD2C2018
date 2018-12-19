using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Filtro
    {

         public int tipo { get; set; }
            public string desc { get; set; }
            public List<Rubro> rubros{get;set;}
            public Nullable<DateTime> fechaI{get;set;}
            public Nullable<DateTime> fechaF {get;set;}

            public Filtro() {
                rubros = new List<Rubro>();
            }
    }
}
