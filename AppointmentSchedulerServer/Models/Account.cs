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
        }
        public Account(long id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
