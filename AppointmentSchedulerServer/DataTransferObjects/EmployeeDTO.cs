using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class EmployeeDTO : AccountDTO
    {
        public long Id { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public EmployeeDTO()
        {
        }

        public EmployeeDTO(long id, string role, int roomNumber)
        {
            Id = id;
            Role = role;
            RoomNumber = roomNumber;
        }

        public EmployeeDTO(string username, string email, string password, string role, int roomNumber, ArrayList appointments)
            : base(username, email, password, appointments)
        {
            Role = role;
            RoomNumber = roomNumber;
        }
    }
}
