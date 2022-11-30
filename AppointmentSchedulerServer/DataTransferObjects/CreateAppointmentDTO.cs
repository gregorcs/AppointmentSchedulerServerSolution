using AppointmentSchedulerServer.Models;
using System.Collections;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class CreateAppointmentDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public long AppointmentTypeId { get; set; }
        public long CustomerAccountId { get; set; }
        public ArrayList EmployeeIdList { get; set; }
    }
}
