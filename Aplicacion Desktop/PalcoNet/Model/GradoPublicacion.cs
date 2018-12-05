using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class GradoPublicacion
    {
        public string nivel { get; set; }
        public Nullable<float> comision { get; set; }

        public override bool Equals(object obj)
        {
            var grado = obj as GradoPublicacion;
            return this.nivel.ToLower().Equals(grado.nivel.ToLower()) & this.comision.Equals(grado.comision);
        }
    }
}
