namespace AppointmentSchedulerServer.Data_Transfer_Objects
{//AccountId, System.String Username, System.String Password, System.String Email) 
    public class AccountDTO
    {
        public AccountDTO(string username, string email, string password, bool isAdmin, string role)
        {
            Username = username;    
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Role = role;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }
    }
}
