using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Exceptions
{
    class ObjectParseException: Exception
    {
        public string msgDescription { get; set; }
        public int msgCode { get; set; }

        public ObjectParseException(string descripcion) {
            msgDescription = descripcion;
        }
    }
}
