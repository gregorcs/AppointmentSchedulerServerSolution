using System.Runtime.Serialization;

namespace AppointmentSchedulerServer.Exceptions
{
    public class RetrievalFailedException : Exception
    {
        public RetrievalFailedException()
        {
        }

        public RetrievalFailedException(string? message) : base(message)
        {
        }

        public RetrievalFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RetrievalFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
