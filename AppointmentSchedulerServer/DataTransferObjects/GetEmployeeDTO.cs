namespace AppointmentSchedulerServer.DataTransferObjects
{
    public class GetEmployeeDTO
    {
        public long Accounts_Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }
    }
}
