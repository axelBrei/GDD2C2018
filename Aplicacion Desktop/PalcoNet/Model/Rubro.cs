using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Rubro
    {
        public Nullable<int> id { get; set; }
        public string descripcion { get; set; }

        public override string ToString()
        {
            return descripcion;
        }

        public override bool Equals(object obj)
        {
            try
            {
                Rubro rubro = obj as Rubro;
                return rubro.id.Equals(this.id);
            }
            catch (Exception e) {
                return false;
            }
        }

    }
}
