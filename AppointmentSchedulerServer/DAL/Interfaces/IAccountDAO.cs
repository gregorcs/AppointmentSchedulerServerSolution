using AppointmentSchedulerServer.DataTransferObjects;

namespace AppointmentSchedulerServer.DAL.Interfaces
{
    public interface IAccountDAO : ICrudDAO<AccountDTO, long>
    {
        public Task<long> ValidateAccountByEmailAndPassword(AccountDTO entity);
        public Task<bool> ExistsByEmail(AccountDTO entity);
    }
}
