namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class DeleteAppointmentDTO
    {
        public long AppointmentId { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<long> EmployeeIds { get; set; }
    }
}
