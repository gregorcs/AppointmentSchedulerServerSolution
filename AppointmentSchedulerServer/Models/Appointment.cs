using AppointmentSchedulerServer.Data_Transfer_Objects;
using System.Collections;

namespace AppointmentSchedulerServer.Models
{
    public class Appointment
    {
        public Appointment(CreateAppointmentDTO entity)
        {
            AccountId = entity.Id;
            Date = entity.Date;
            IsApproved = entity.IsApproved;
            TimeSlot = entity.TimeSlot;
            AppointmentTypeId = entity.AppointmentTypeId;
            EmployeeIdList = entity.EmployeeIdList;
        }

        public long AccountId { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public long AppointmentTypeId { get; set; }
        public IEnumerable<long> EmployeeIdList { get; set; }
    }
}
