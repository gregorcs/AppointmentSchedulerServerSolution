namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class AccountDTO
    {
        public AccountDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
