using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories
{
    public interface IAccountDAO : ICrudDAO<AccountDTO, long>
    {
        public Task<long> ValidateAccountByEmailAndPassword(AccountDTO entity);
        public Task<bool> ExistsByEmail(AccountDTO entity);
    }
}
