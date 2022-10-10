namespace AppointmentSchedulerServer.Entities
{
    public class Account
    {
        public Account(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
