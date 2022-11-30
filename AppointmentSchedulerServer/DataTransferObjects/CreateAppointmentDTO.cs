using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class CreateAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public AppointmentType Type { get; set; }
        public AccountDTO CustomerAccount { get; set; }
        public IEnumerable<EmployeeDTO> EmployeeList { get; set; }
    }
}
