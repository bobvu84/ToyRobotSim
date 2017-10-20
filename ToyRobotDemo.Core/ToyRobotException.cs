using System;
using System.Runtime.Serialization;

namespace ToyRobotDemo.Core
{
    [Serializable]
    public class ToyRobotException : Exception
    {
        
        public ToyRobotException()
        {
        }

        public ToyRobotException(string message) : base(message)
        {

        }

        public ToyRobotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToyRobotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}