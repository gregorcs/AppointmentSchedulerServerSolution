using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IAccountRepository : ICrudRepository<AccountDTO, long>
    {
        public Task<long> ValidateAccountByEmailAndPassword(AccountDTO entity);
        public Task<bool> ExistsByEmail(AccountDTO entity);
        public Task<AccountDTO> Update(AccountDTO entity);
    }
}
