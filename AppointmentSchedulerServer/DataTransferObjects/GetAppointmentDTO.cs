using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;
using System.Collections;

namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class GetAppointmentDTO
    {
        public DateTime Time { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public AppointmentType Type { get; set; }
        public ArrayList EmployeeNameList { get { return EmployeeNameList; } set { EmployeeNameList.Add(value); } }
        
    }
}
