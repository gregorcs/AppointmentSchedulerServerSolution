using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Entities;
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

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsById(int id)
        {
            return FindById(id) != null;
        }

        public async Task<bool> ValidateAccountByEmailAndPassword(Account entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            var result = await database.QueryFirstAsync<Account>(SqlQueries.QUERY_SELECT_BY_EMAIL_AND_PASSWORD, entity);
            if (result != null)
            {
                return BCrypt.Net.BCrypt.EnhancedVerify(entity.Password, result.Password)
                        && entity.Email.Equals(result.Email);
            }
            return false;
        }

        public async Task<IEnumerable<Account>> FindAll()
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            return await database.QueryAsync<Account>(SqlQueries.SELECT_EVERYTHING_ACCOUNTS);
        }

        public Task<IEnumerable<Account>> FindAllById(IEnumerable<int> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> FindById(int id)
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
            entity.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.Password);
            int createdId;
            try
            {
                createdId = await database.ExecuteScalarAsync<int>(SqlQueries.QUERY_SAVE_ACCOUNT, entity);
            }
            catch (Exception ex)
            {
                throw new DatabaseInsertionException("There was a problem saving the account", ex);
            }
            if (createdId != 0)
            {
                return await FindById(createdId);
            }
            else
            {
                throw new DatabaseInsertionException("could not insert into database");
            }
        }

        public Task<int> SaveAll(IEnumerable<Account> entities)
        {
            throw new NotImplementedException();
        }
    }
}
