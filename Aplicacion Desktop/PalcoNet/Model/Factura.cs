using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    class Factura
    {
        public int numero { get; set; }
        public string formaDePago { get; set; }
        public float total { get; set; }
        public DateTime fecha { get; set; }
        public int IdEmpresa { get; set; }
        public List<ItemFactura> items{get; set;}

        public Factura() {
            items = new List<ItemFactura>();
        }
    }
}
