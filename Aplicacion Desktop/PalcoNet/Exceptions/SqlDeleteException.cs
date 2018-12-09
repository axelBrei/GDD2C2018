using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Exceptions
{
    public class SqlDeleteException : Exception
    {
        public static int CODE_UBICACION = 1;

        public int msgCode { get; set; }
        public string msgDescription { get; set; }

        public SqlDeleteException(string descripcion, int code = 0) {
            this.msgCode = code;
            this.msgDescription = descripcion;
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
