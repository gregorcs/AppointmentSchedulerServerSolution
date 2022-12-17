using System.Collections;

namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class GetAppointmentDTO
    {
        public long? Id { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GetEmployeeDTO> Employees { get; set; }

        public GetAppointmentDTO()
        {

        }

        public GetAppointmentDTO(long id, DateTime date, int timeSlot, bool isApproved, string name, string description)
        {
            Id = id;
            Date = date;
            TimeSlot = timeSlot;
            IsApproved = isApproved;
            Name = name;
            Description = description;
        }

        public GetAppointmentDTO(CreateAppointmentDTO entity)
        {
            Id = entity.Id;
            Date = entity.Date;
            TimeSlot = entity.TimeSlot;
            IsApproved = entity.IsApproved;
        }
    }
}
