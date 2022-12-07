using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DataTransferObjects;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IEmployeeDAO : ICrudDAO<EmployeeDTO, long>
    {
        Task<bool> ExistsByEmail(EmployeeDTO entity);

        Task<IEnumerable<GetEmployeeDTO>> GetEmployeeByAppointmentType(long id);
    }
}