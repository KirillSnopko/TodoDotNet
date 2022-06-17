using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Exceptions
{
    /*
    Type exception for Data Access layer
    */
    public class DataAccessLayerException : Exception
    {
        public DataAccessLayerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
