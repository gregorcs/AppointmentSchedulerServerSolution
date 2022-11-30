using AppointmentSchedulerServer.Data_Transfer_Objects;

namespace AppointmentSchedulerServer.Models
{
    public class Appointment
    {
        public Appointment(CreateAppointmentDTO entity)
        {
            Id = entity.Id;
            Time = entity.Time;
            IsAccepted = entity.IsAccepted;
            Type = entity.Type;
        }

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsAccepted { get; set; }
        public AppointmentType Type { get; set; }
    }
}
