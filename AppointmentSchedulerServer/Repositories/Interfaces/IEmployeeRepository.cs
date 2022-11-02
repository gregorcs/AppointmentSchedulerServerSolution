using AppointmentSchedulerServer.Data_Transfer_Objects;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IEmployeeRepository : ICrudRepository<EmployeeDTO, long>
    {
        Task<bool> ExistsByEmail(EmployeeDTO entity);
    }
}