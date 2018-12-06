using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Exceptions
{
    public class SqlInsertException : Exception
    {

        public int msgCode { get; set; }
        public string msgDescription { get; set; }

        public override string Message
        {
            get
            {
                return this.msgDescription;
            }
        }
    }
}
