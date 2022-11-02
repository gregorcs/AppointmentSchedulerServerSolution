namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class AccountDTO
    {
        public AccountDTO(string username, string email, string password)
        {
            Username = username;    
            Email = email;
            Password = password;
        }
        public AccountDTO(string email)
        {
            Email = email;
        }
        public AccountDTO()
        {
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
