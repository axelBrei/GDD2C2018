using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Exceptions
{
    public class SqlInsertException : Exception
    {

        public static int CODIGO_PUBLICACION = 1;
        public static int CODIGO_UBICACION = 2;

        public int msgCode { get; set; }
        public string msgDescription { get; set; }


        public SqlInsertException() { }

        public SqlInsertException(string descripcion, int code) {
            msgDescription = descripcion;
            msgCode = code;
        }

        public override string Message
        {
            get
            {
                return this.msgDescription;
            }
        }
    }
}
