namespace AppointmentSchedulerServer.Models
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AppointmentType(string name, string description, int id = -1)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}