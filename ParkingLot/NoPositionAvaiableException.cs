using System;
using System.Runtime.Serialization;

namespace Parking
{
    [Serializable]
    public class NoPositionAvaiableException : Exception
    {
        public NoPositionAvaiableException()
        {
        }

        public NoPositionAvaiableException(string message) : base(message)
        {
        }

        public NoPositionAvaiableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPositionAvaiableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}