using AppointmentSchedulerServer.Data_Transfer_Objects;

namespace AppointmentSchedulerServer.Entities
{
    public class Account
    {
        public Account() { }


        public Account(AccountDTO account)
        {
            Email = account.Email;
            Password = account.Password;
        }
        public Account(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
