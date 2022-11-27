namespace AppointmentSchedulerServer.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsAccepted { get; set; }
        public AppointmentType Type { get; set; }
    }
}
