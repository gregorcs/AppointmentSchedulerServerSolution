using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Exceptions;
using Dapper;
using System.Data;
using AppointmentSchedulerServer.Data_Transfer_Objects;

namespace AppointmentSchedulerServer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlServerDbConnectionFactory _sqlDbConnectionFactory;

        public AccountRepository(SqlServerDbConnectionFactory sqlDbConnectionFactory)
        {
            _sqlDbConnectionFactory = sqlDbConnectionFactory;
        }

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

        public async Task<bool> ExistsById(long id)
        {
            return await FindById(id) != null;
        }

        public async Task<long> ValidateAccountByEmailAndPassword(AccountDTO entity)
        {
            Account accountToValidate = new(entity);
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            var accountFound = await database.QueryFirstAsync<Account>(SqlQueries.QUERY_SELECT_BY_EMAIL_AND_PASSWORD, accountToValidate);
            if (accountFound != null 
                && (BCrypt.Net.BCrypt.EnhancedVerify(entity.Password, accountFound.Password)
                && entity.Email.Equals(accountFound.Email)))
            {
                return accountFound.PK_AccountId;
            } else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<AccountDTO>> FindAll()
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            return await database.QueryAsync<AccountDTO>(SqlQueries.SELECT_EVERYTHING_ACCOUNTS);
        }

        public Task<IEnumerable<AccountDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDTO> FindById(long id)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            AccountDTO accountFound;
            try
            {
                accountFound = await database.QueryFirstAsync<AccountDTO>(SqlQueries.FIND_ACCOUNT_BY_ID, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Search of the specified account failed", ex);
            }
            return accountFound;
        }

        public async Task<AccountDTO> Save(AccountDTO entity)
        {
            Account accountToSave = new(entity);
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            accountToSave.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(accountToSave.Password);
            long createdId;

            try
            {
                createdId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_ACCOUNT, accountToSave);
            }
            catch (Exception ex)
            {
                throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount, ex);
            }

            return createdId != 0 ? await FindById(createdId)
                : throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount);
        }

        public Task<int> SaveAll(IEnumerable<AccountDTO> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByEmail(AccountDTO entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            var result = await database.QueryFirstOrDefaultAsync<AccountDTO>(SqlQueries.FIND_ACCOUNT_BY_EMAIL, entity);
            return result != null;
        }

        //feedback would be appreciated for i am in the fog of async & repositories. amen
        public async Task Update(AccountDTO entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            entity.Email = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.Email);
            entity.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.Password);
            var updatedAccount = await database.QueryFirstAsync<AccountDTO>(SqlQueries.UPDATE_ACCOUNT_CREDENTIALS, entity);
        }
    }
}
