using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Exceptions;
using Dapper;
using System.Data;

namespace AppointmentSchedulerServer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlServerDbConnectionFactory _sqlDbConnectionFactory;

        public AccountRepository(SqlServerDbConnectionFactory sqlDbConnectionFactory)
        {
            _sqlDbConnectionFactory = sqlDbConnectionFactory;
        }

        public Task Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(long id)
        {
            return FindById(id) != null;
        }

        public async Task<bool> ValidateAccountByEmailAndPassword(Account entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            var result = await database.QueryFirstAsync<Account>(SqlQueries.QUERY_SELECT_BY_EMAIL_AND_PASSWORD, entity);
            return result != null 
                && (BCrypt.Net.BCrypt.EnhancedVerify(entity.Password, result.Password)
                && entity.Email.Equals(result.Email));
        }

        public async Task<IEnumerable<Account>> FindAll()
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            return await database.QueryAsync<Account>(SqlQueries.SELECT_EVERYTHING_ACCOUNTS);
        }

        public Task<IEnumerable<Account>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> FindById(long id)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            Account accountFound;
            try
            {
                accountFound = await database.QueryFirstAsync<Account>(SqlQueries.FIND_BY_ID, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Search of the specified account failed", ex);
            }
            return accountFound;
        }

        public async Task<Account> Save(Account entity)
        {
            //maybe this should be a transaction since we are saving and searching for it?
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            database.Open();
            entity.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.Password);
            long createdId;

            if (entity.IsAdmin)
            {
                using var transaction = database.BeginTransaction(IsolationLevel.RepeatableRead);
                try
                {
                    createdId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_ACCOUNT, entity, transaction);
                    createdId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_EMPLOYEE, new { Id = createdId, entity.Role }, transaction);
                    transaction.Commit();
                    transaction.Dispose();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount, ex);
                }
            }
            else
            {
                try
                {
                    createdId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_ACCOUNT, entity);
                }
                catch (Exception ex)
                {
                    throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount, ex);
                }
            }
            return createdId != 0 ? await FindById(createdId)
                : throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount);
        }

        public Task<int> SaveAll(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }
    }
}
