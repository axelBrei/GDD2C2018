using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Funcionalidad
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public override bool Equals(object obj)
        {
            return this.id.Equals( ((Funcionalidad)obj).id );
        }
    }
}
