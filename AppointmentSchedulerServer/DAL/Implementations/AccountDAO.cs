using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using Dapper;
using System.Data;

namespace AppointmentSchedulerServer.DAL.Implementations
{
    public class AccountDAO : IAccountDAO
    {
        private readonly SqlServerDbConnection _sqlDbConnection;

        public AccountDAO(SqlServerDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
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
            using IDbConnection database = _sqlDbConnection.Connect();
            var accountFound = await database.QueryFirstAsync<Account>(SqlQueries.QUERY_SELECT_BY_EMAIL_AND_PASSWORD, accountToValidate);
            if (accountFound != null
                && BCrypt.Net.BCrypt.EnhancedVerify(entity.Password, accountFound.Password)
                && entity.Email.Equals(accountFound.Email))
            {
                return accountFound.Id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<AccountDTO>> FindAll()
        {
            using IDbConnection database = _sqlDbConnection.Connect();
            return await database.QueryAsync<AccountDTO>(SqlQueries.QUERY_SELECT_EVERYTHING_ACCOUNTS);
        }

        public async Task<IEnumerable<GetEmployeeDTO>> FindAllEmployees()
        {
            IEnumerable<GetEmployeeDTO> employeesFound;
            using IDbConnection database = _sqlDbConnection.Connect();
            try
            {
                employeesFound = await database.QueryAsync<GetEmployeeDTO>(SqlQueries.QUERY_FIND_ALL_EMPLOYEES);
            }
            catch(Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.EmployeeRetreivalFailed, ex);
            }
            return employeesFound;
        }

        public Task<IEnumerable<AccountDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDTO> FindById(long id)
        {
            using IDbConnection database = _sqlDbConnection.Connect();
            AccountDTO accountFound;
            try
            {
                accountFound = await database.QueryFirstAsync<AccountDTO>(SqlQueries.QUERY_FIND_ACCOUNT_BY_ID, new { Id = id });
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
            using IDbConnection database = _sqlDbConnection.Connect();
            accountToSave.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(accountToSave.Password);
            long createdId;

            try
            {
                createdId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_ACCOUNT, accountToSave);
            }
            catch (Exception ex)
            {
                throw new DatabaseInsertionException(DALExceptionMessages.CouldNotSaveAccount, ex);
            }

            return createdId != 0 ? await FindById(createdId)
                : throw new DatabaseInsertionException(DALExceptionMessages.CouldNotSaveAccount);
        }

        public Task<int> SaveAll(IEnumerable<AccountDTO> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByEmail(AccountDTO entity)
        {
            using IDbConnection database = _sqlDbConnection.Connect();
            var result = await database.QueryFirstOrDefaultAsync<AccountDTO>(SqlQueries.QUERY_FIND_ACCOUNT_BY_EMAIL, entity);
            return result != null;
        }
    }
}
