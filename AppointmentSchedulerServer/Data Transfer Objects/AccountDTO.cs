namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class AccountDTO
    {
        public AccountDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
