namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class CreateAppointmentDTO
    {
        //todo rename to customer
        public long CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public long AppointmentTypeId { get; set; }
        public IEnumerable<long>? EmployeeIdList { get; set; }
        public string Message { get; set; } 
    }
}
