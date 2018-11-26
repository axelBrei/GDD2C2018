using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public int intentos { get; set; }
        public List<Rol> roles { get; set; }

        public Usuario() { 
            roles = new List<Rol>();
        }

        public Rol getRol(int positioin) {
            return (Rol) roles.ElementAt(positioin);
        }

        public void addRol(Rol rol) {
            roles.Add(rol);
        }
    }
}
