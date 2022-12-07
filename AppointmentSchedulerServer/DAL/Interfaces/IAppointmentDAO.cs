using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories.Interfaces
{
    public interface IAppointmentDAO : ICrudDAO<CreateAppointmentDTO, long>
    {
        public Task<IEnumerable<GetAppointmentDTO>> FindAllByAccountId(long id);
        public Task<IEnumerable<GetAppointmentDTO>> FindAllByEmployeeId(long id);
        Task<IEnumerable<EmployeeDTO>> FindAllEmployeesAndAvailableTimeSlots(DateTime dateOfAppointment);

        Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes();

    }
}
