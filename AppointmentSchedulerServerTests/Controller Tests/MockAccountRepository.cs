using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerServerTests.Controller_Tests
{
    internal class MockAccountRepository : IAccountRepository
    {

        private List<Account> Accounts = new List<Account>();

        public Task Delete(AccountDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<AccountDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByEmail(AccountDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDTO> Save(AccountDTO entity)
        {
            Accounts.Add(new Account(entity));
            return Task.FromResult(entity);
            //returns a finished task ^
        }

        public Task<int> SaveAll(IEnumerable<AccountDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<long> ValidateAccountByEmailAndPassword(AccountDTO entity)
        {
            Account account = new Account(entity);
            var AccountToFind = Accounts.Find(Acc => account.Password == Acc.Password);
            return (AccountToFind != null)
                ? Task.FromResult(Convert.ToInt64(1)) 
                : Task.FromResult(Convert.ToInt64(0));
        }
    }
}
