using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Exception
{
    public class ParkingException : SystemException
    {
        public ParkingException()
        {
        }

        public ParkingException(string message) : base(message)
        {
        }

        public ParkingException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ParkingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
