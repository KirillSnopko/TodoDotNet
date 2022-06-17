using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Exceptions
{
    public class NonExistentObjectException:Exception
    {
        public NonExistentObjectException(string message, Exception innerException) : base(message, innerException) { }
    }
}
