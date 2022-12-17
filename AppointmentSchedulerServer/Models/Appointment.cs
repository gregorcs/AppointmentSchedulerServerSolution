using AppointmentSchedulerServer.DataTransferObjects;

namespace AppointmentSchedulerServer.Models
{
    public class Appointment
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public long AppointmentTypeId { get; set; }
        public IEnumerable<long> EmployeeIdList { get; set; }
        public string Message { get; set; }

        public Appointment(CreateAppointmentDTO entity)
        {
            AccountId = entity.CustomerId;
            Date = entity.Date;
            IsApproved = entity.IsApproved;
            TimeSlot = entity.TimeSlot;
            AppointmentTypeId = entity.AppointmentTypeId;
            EmployeeIdList = entity.EmployeeIdList;
            Message = entity.Message;
        }

        public Appointment(long id, long accountId, DateTime date, int timeSlot, bool isApproved, long appointmentTypeId, IEnumerable<long> employeeIdList, string message)
        {
            Id = id;
            AccountId = accountId;
            Date = date;
            TimeSlot = timeSlot;
            IsApproved = isApproved;
            AppointmentTypeId = appointmentTypeId;
            EmployeeIdList = employeeIdList;
            Message = message;
        }

    }
}
