using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class AccountDTO
    {
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountDTO(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
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
