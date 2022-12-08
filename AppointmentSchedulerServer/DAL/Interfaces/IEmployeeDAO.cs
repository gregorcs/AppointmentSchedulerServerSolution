using AppointmentSchedulerServer.DataTransferObjects;

namespace AppointmentSchedulerServer.DAL.Interfaces
{
    public interface IEmployeeDAO : ICrudDAO<EmployeeDTO, long>
    {
        Task<bool> ExistsByEmail(EmployeeDTO entity);

        Task<IEnumerable<GetEmployeeDTO>> GetEmployeeByAppointmentType(long id);
    }
}