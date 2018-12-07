using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Exceptions
{
    class DataNotFoundException : Exception
    {
        public string msgCode {get; set;}
        public string msgDescription{get; set;}

        public DataNotFoundException(string message){
            msgDescription = message;
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
