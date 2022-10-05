namespace AppointmentSchedulerServer.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Admin(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
