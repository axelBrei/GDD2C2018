using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Exceptions
{
    public class GenericException : Exception
    {
        public int msgCode { get; set; }
        public string msgDescription { get; set; }

        public GenericException( string desc, int code = 0) {
            this.msgCode = code;
            this.msgDescription = desc;
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
