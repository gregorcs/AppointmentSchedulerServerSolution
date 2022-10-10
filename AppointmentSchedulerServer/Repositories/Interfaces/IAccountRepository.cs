using AppointmentSchedulerServer.Entities;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IAccountRepository : ICrudRepository<Account, Guid>
    {
    }
}
