using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class AccountDTO
    {
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ArrayList Appointments { get; set; }

        public AccountDTO(string username, string email, string password, ArrayList appointments)
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
