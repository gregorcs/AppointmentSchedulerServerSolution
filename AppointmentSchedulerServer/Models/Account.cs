using AppointmentSchedulerServer.Data_Transfer_Objects;
using System.Collections;

namespace AppointmentSchedulerServer.Models
{
    public class Account
    {
        public Account() { }

        public Account(AccountDTO account)
        {
            Email = account.Email;
            Password = account.Password;
            Username = account.Username;
            Appointments = account.Appointments;
        }
        public Account(long pk_AccountId, string username, string password, string email)
        {
            Id = pk_AccountId;
            Username = username;
            Password = password;
            Email = email;
        }
        public Account(string username, string password, string email, IEnumerable<int> appointments)
        {
            Username = username;
            Password = password;
            Email = email;
            Appointments = appointments;
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> Appointments { get; set; }
    }
}
