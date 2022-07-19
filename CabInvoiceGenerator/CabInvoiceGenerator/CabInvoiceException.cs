using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        public ExceptionType type;

        //Custom Exception
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME, NULL_RIDES, INVALID_USER_ID, INVALID_RIDE_TYPE
        }
    }
}
