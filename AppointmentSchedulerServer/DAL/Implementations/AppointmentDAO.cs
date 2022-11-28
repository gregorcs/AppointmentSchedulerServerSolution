using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;

namespace AppointmentSchedulerServer.Repositories.Implementations
{
    public class AppointmentDao : IAppointmentDAO
    {
        private readonly SqlServerDbConnectionFactory _sqlDbConnectionFactory;

        public AppointmentDao(SqlServerDbConnectionFactory sqlDbConnectionFactory)
        {
            _sqlDbConnectionFactory = sqlDbConnectionFactory;
        }

        public Task Delete(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentDTO>> FindAllByAccountId(long id)
        {
            IEnumerable<AppointmentDTO> appointmentsFound;
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            try
            {
                appointmentsFound = await database.QueryAsync<AppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENTS_BY_ACCOUNT_ID, id);
            }
            catch(Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.AppointmentRetrievalFailed, ex);
            }
            return appointmentsFound;
        }

        public Task<IEnumerable<AppointmentDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentDTO> Save([FromBody] AppointmentDTO entity)
        {
            Appointment appointmentToSave = new(entity);
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            using var transaction = database.BeginTransaction(IsolationLevel.ReadUncommitted);
            long createdId;
            long createdAppointmentId;
            try
            {
                transaction.Connection?.Open();
                createdAppointmentId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_APPOINTMENT, transaction);
                await database.ExecuteScalarAsync(SqlQueries.QUERY_SAVE_ACCOUNT_JOIN_APPOINTMENT, transaction);
                await database.ExecuteScalarAsync(SqlQueries.QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT, transaction);
                transaction.Commit();
            } catch (Exception ex)
            {
                transaction?.Rollback();
                //todo
                Console.WriteLine(ex);
            }
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
