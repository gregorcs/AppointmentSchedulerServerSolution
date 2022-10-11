using AppointmentSchedulerServer.Entities;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IAccountRepository : ICrudRepository<Account, Guid>
    {
        public Task<bool> ExistsByNameAndPassword(Account entity);
    }
}
