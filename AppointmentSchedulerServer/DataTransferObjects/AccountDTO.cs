namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class AccountDTO
    {
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<int>? Appointments { get; set; }

        public AccountDTO(string username, string email, string password, IEnumerable<int> appointments)
        {
            Username = username;
            Email = email;
            Password = password;
            Appointments = appointments;
        }

        public AccountDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public AccountDTO()
        {
        }
    }
}
