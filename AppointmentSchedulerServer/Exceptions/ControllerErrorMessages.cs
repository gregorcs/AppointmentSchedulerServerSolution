namespace AppointmentSchedulerServer.Exceptions
{
    public class ControllerErrorMessages
    {
        public const string InvalidEmail = "Email was used previoulsy";
        public const string InvalidAccount = "Account to be saved doesn't have all details";
        public const string EncounteredError = "Encountered an error saving the account";
        public const string AppointmentError = "Encountered an error while recieving list of appointments";
        public const string CouldNotLogin = "There was a problem logging in";
    }
}
