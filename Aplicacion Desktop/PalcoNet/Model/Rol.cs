using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Rol
    {
        public int id{get; set;}
        public string nombre { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }
        public DateTime bajaLogica { get; set; }

        public Rol() {
            funcionalidades = new List<Funcionalidad>();
        }

        public void agregarFuncionalidad(Funcionalidad fun) {
            funcionalidades.Add(fun);
        }

        public Funcionalidad getFuncionalidad(int index) {
            return funcionalidades.ElementAt(index);
        }

        public override bool Equals(object obj)
        {
            Rol rol = (Rol) obj;
            return this.id == rol.id;
        }
    }
}
