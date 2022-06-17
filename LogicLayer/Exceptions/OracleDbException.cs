using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Exceptions
{
   public class OracleDbException : Exception
    {
        public OracleDbException(string message, Exception innerException) : base(message, innerException) { }
    }
}
