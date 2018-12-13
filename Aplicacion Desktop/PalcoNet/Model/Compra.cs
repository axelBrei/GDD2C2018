using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Compra
    {
        public int id { get; set; }
        public Cliente cli { get; set; }
        public DateTime fechaCompra { get; set; }
        public Tarjeta medioPago { get; set; }
        public int cantidad { get; set; }
        public List<Ubicacion> ubicaciones { get; set; }
        public float total { get; set; }
        public Publicacion publicacion { get; set; }

        public Compra() {
            ubicaciones = new List<Ubicacion>();
        }
    }
}
