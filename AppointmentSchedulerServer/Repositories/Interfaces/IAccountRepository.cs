using AppointmentSchedulerServer.Entities;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IAccountRepository : ICrudRepository<Account, int>
    {
        public Task<bool> ValidateAccountByEmailAndPassword(Account entity);
    }
}
