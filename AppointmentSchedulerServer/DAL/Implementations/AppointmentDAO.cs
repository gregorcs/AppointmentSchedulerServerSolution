using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DataTransferObjects;
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

        public Task Delete(CreateAppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<CreateAppointmentDTO> entities)
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

        public Task<IEnumerable<CreateAppointmentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAppointmentDTO>> FindAllByAccountId(long id)
        {
            IEnumerable<GetAppointmentDTO> appointmentsFound;
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            try
            {
                appointmentsFound = await database.QueryAsync<GetAppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENTS_BY_CUSTOMER_ID, id);
            }
            catch(Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.AppointmentRetrievalFailed, ex);
            }
            return appointmentsFound;
        }

        public async Task<IEnumerable<GetAppointmentDTO>> FindAllByEmployeeId(long id)
        {
            IEnumerable<GetAppointmentDTO> appointmentsFound;
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            try
            {
                appointmentsFound = await database.QueryAsync<GetAppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENTS_BY_EMPLOYEE_ID, id);
            }
            catch (Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.AppointmentRetrievalFailed, ex);
            }
            return appointmentsFound;
        }

        public Task<IEnumerable<CreateAppointmentDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<CreateAppointmentDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateAppointmentDTO> Save([FromBody] CreateAppointmentDTO entity)
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

        public Task<int> SaveAll(IEnumerable<CreateAppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
