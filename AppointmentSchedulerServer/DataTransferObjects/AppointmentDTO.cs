using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsAccepted { get; set; }
        public AppointmentType Type { get; set; }
        public AccountDTO Account { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
