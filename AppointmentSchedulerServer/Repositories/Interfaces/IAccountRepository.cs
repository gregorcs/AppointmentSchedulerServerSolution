using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IAccountRepository : ICrudRepository<Account, long>
    {
        public Task<bool> ValidateAccountByEmailAndPassword(Account entity);
    }
}
