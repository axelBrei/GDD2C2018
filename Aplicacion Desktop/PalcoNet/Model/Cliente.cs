using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;

namespace PalcoNet.Model
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string documento { get; set; }
        public string cuil { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public Direccion direccion { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string numeroTarjeta { get; set; }
    }
}
