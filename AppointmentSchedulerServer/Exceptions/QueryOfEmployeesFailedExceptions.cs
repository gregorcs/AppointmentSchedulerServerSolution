using System.Runtime.Serialization;

namespace AppointmentSchedulerServer.Exceptions
{
    [Serializable]
    internal class QueryOfEmployeesFailedExceptions : Exception
    {
        private DALExceptionMessages dALExceptionMessages;

        public QueryOfEmployeesFailedExceptions()
        {
        }

        public QueryOfEmployeesFailedExceptions(DALExceptionMessages dALExceptionMessages)
        {
            this.dALExceptionMessages = dALExceptionMessages;
        }

        public QueryOfEmployeesFailedExceptions(string? message) : base(message)
        {
        }

        public QueryOfEmployeesFailedExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected QueryOfEmployeesFailedExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}