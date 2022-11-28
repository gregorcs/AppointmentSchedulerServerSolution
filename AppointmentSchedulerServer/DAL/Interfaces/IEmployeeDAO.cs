using AppointmentSchedulerServer.Data_Transfer_Objects;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IEmployeeDAO : ICrudDAO<EmployeeDTO, long>
    {
        Task<bool> ExistsByEmail(EmployeeDTO entity);
    }
}