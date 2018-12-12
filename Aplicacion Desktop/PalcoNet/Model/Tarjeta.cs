using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Model
{
    public class Tarjeta
    {
        public int id { get; set; }
        public string titular { get; set; }
        public string numero { get; set; }
        public string vencimiento { get; set; }
        public string vcc { get; set; }

        public override string ToString()
        {
            return titular + "/" + numero + "/" + vencimiento;
        }
    }
}
