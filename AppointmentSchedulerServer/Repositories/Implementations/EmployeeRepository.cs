using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using Dapper;
using System.Data;

namespace AppointmentSchedulerServer.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlServerDbConnectionFactory _sqlDbConnectionFactory;

        public EmployeeRepository(SqlServerDbConnectionFactory sqlDbConnectionFactory)
        {
            _sqlDbConnectionFactory = sqlDbConnectionFactory;
        }
        public Task Delete(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<EmployeeDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByEmail(EmployeeDTO entity)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            var result = await database.QueryFirstOrDefaultAsync<AccountDTO>(SqlQueries.FIND_ACCOUNT_BY_EMAIL, entity);
            return result != null;
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDTO> FindById(long id)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            EmployeeDTO employeeFound;
            try
            {
                employeeFound = await database.QueryFirstOrDefaultAsync<EmployeeDTO>(SqlQueries.FIND_EMPLOYEE_BY_ID, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Search of the specified account failed", ex);
            }
            return employeeFound;
        }

        public async Task<EmployeeDTO> Save(EmployeeDTO entity)
        {
            Employee employeeToSave = new(entity);
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            employeeToSave.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(employeeToSave.Password);
            long createdId;
            database.Open();
            using var transaction = database.BeginTransaction(IsolationLevel.RepeatableRead);
            try
            {
                createdId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_ACCOUNT, employeeToSave, transaction);
                employeeToSave.PK_AccountId = createdId;
                await database.ExecuteScalarAsync(SqlQueries.QUERY_SAVE_EMPLOYEE, employeeToSave, transaction);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount, ex);
            }

            return createdId != 0 ? await FindById(createdId)
                : throw new DatabaseInsertionException(RepositoryExceptionMessages.CouldNotSaveAccount);
        }

        public Task<int> SaveAll(IEnumerable<EmployeeDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
