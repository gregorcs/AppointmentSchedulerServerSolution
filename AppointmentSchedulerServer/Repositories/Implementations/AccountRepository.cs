using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Entities;
using AppointmentSchedulerServer.Exceptions;
using System.Data;
using Dapper;

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
            return false;
        }

        public async Task<bool> ValidateAccountByEmailAndPassword(Account entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            var result = await database.QueryFirstOrDefaultAsync<Account>(SqlQueries.QUERY_SELECT_BY_EMAIL_AND_PASSWORD, entity);
            if (result != null)
            {
                bool passwordMatches = BCrypt.Net.BCrypt.EnhancedVerify(entity.Password, result.Password);
                return passwordMatches && entity.Email.Equals(result.Email);
            }
            return false;
        }

        public Task<IEnumerable<Account>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> FindAllById(IEnumerable<int> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> FindById(int id)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            return await database.QueryFirstOrDefaultAsync<Account>(SqlQueries.FIND_BY_ID, new { Id = id });
        }

        public async Task<Account> Save(Account entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            entity.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.Password);
            var result = await database.ExecuteScalarAsync<int>(SqlQueries.QUERY_SAVE_ACCOUNT, entity);
            if (result != 0)
            {
                return await FindById(result);
            } else
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
