using AppointmentSchedulerServer.Data_Transfer_Objects;

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
        }
        public Account(long pk_AccountId, string username, string password, string email)
        {
            PK_AccountId = pk_AccountId;
            Username = username;
            Password = password;
            Email = email;
        }
        public Account(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public long PK_AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
