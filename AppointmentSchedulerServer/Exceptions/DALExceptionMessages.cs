namespace AppointmentSchedulerServer.Exceptions
{
    public class DALExceptionMessages
    {
        public const string CouldNotSaveAccount = "There was a problem saving the account";
        public const string CouldNotSaveAppointment = "There was a problem saving the appointment";
        public const string AppointmentRetrievalFailed = "Failed to retrieve appointments from database";
        public const string SingleAppointmentRetrievalFailed = "Failed to find specific appointment";
    }
}
