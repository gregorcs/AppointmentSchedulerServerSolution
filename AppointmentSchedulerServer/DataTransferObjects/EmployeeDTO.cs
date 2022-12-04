using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerServer.Data_Transfer_Objects
{
    public class EmployeeDTO : AccountDTO
    {
        public long Accounts_Id { get; set; }
        public string Role { get; set; }
        public int RoomNumber { get; set; }

        public EmployeeDTO()
        {
        }

        public EmployeeDTO(long id, string role, int roomNumber)
        {
            Accounts_Id = id;
            Role = role;
            RoomNumber = roomNumber;
        }

        public EmployeeDTO(string username, string email, string password, string role, int roomNumber, IEnumerable<int> appointments)
            : base(username, email, password, appointments)
        {
            Role = role;
            RoomNumber = roomNumber;
        }
    }
}
