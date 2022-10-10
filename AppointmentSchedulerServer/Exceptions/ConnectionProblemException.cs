namespace AppointmentSchedulerServer.Exceptions
{
    public class ConnectionProblemException : Exception
    {
        public ConnectionProblemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
