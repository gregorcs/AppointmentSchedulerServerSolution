namespace AppointmentSchedulerServer.Exceptions
{
    public class DatabaseInsertionException : Exception
    {
        public DatabaseInsertionException(string? message) : base(message)
        {
        }

        public DatabaseInsertionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }


    }
}
