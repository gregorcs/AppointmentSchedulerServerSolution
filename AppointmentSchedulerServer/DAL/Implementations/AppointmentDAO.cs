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
    public class AppointmentDAO : IAppointmentDAO
    {
        private readonly SqlServerDbConnectionFactory _sqlDbConnectionFactory;

        public AppointmentDAO(SqlServerDbConnectionFactory sqlDbConnectionFactory)
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

        public async Task<CreateAppointmentDTO> FindById(long id)
        {
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            CreateAppointmentDTO appointmentFound;
            try
            {
                appointmentFound = await database.QueryFirstAsync<CreateAppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENT_BY_ID, new {Id = id});
            }
            catch (Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.SingleAppointmentRetrievalFailed, ex);
            }
            return appointmentFound;
        }

        public async Task<CreateAppointmentDTO> Save([FromBody] CreateAppointmentDTO entity)
        {
            Appointment appointmentToSave = new(entity);

            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            database.Open();
            using var transaction = database.BeginTransaction(IsolationLevel.RepeatableRead);
            long createdAppointmentId = -1;
            try
            {
                //todo handle edge cases for posting the same date twice
                //todo handle exceptions in general
                //todo handle find by id on return
                createdAppointmentId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_APPOINTMENT, appointmentToSave, transaction);
                
                foreach(long EmployeeId in appointmentToSave.EmployeeIdList)
                {
                    await database.ExecuteScalarAsync(SqlQueries.QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT, new { employeeId = EmployeeId, appointmentId = createdAppointmentId }, transaction);
                }

                transaction.Commit();
            } catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine(ex);
                throw new DatabaseInsertionException(DALExceptionMessages.CouldNotSaveAppointment, ex);
            }
            return await FindById(createdAppointmentId);
        }

        public Task<int> SaveAll(IEnumerable<CreateAppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}