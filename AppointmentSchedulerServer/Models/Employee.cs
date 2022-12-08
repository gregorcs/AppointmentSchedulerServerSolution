using AppointmentSchedulerServer.DataTransferObjects;

namespace AppointmentSchedulerServer.Models
{
    public class Employee : Account
    {
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public Employee(long id, string username, string password, string email, string role, int roomNumber)
            : base(id, username, password, email)
        {
            Role = role;
            RoomNumber = roomNumber;
        }

        public Employee(EmployeeDTO employeeDTO)
            : base(employeeDTO.Username, employeeDTO.Password, employeeDTO.Email, employeeDTO.Appointments)
        {
            Role = employeeDTO.Role;
            RoomNumber = employeeDTO.RoomNumber;
        }
    }
}
