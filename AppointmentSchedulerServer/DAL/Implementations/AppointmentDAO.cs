using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AppointmentSchedulerServer.DAL.Implementations
{
    public class AppointmentDAO : IAppointmentDAO
    {
        private readonly SqlServerDbConnection _sqlDbConnection;

        public AppointmentDAO(SqlServerDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
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
            using IDbConnection database = _sqlDbConnection.Connect();
            try
            {
                appointmentsFound = await database.QueryAsync<GetAppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENTS_BY_CUSTOMER_ID, new { Id = id});
            }
            catch (Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.AppointmentRetrievalFailed, ex);
            }
            return appointmentsFound;
        }

        public async Task<IEnumerable<GetAppointmentDTO>> FindAllByEmployeeId(long id)
        {
            IEnumerable<GetAppointmentDTO> appointmentsFound;
            using IDbConnection database = _sqlDbConnection.Connect();
            try
            {
                appointmentsFound = await database.QueryAsync<GetAppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENTS_BY_EMPLOYEE_ID, new { Id = id});
                foreach(GetAppointmentDTO appointment in appointmentsFound)
                {
                    appointment.Employees = await database.QueryAsync<GetEmployeeDTO>(SqlQueries.QUERY_FIND_EMPLOYEES_FOR_APPOINTMENT, new { Id = appointment.Id });
                }
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
            using IDbConnection database = _sqlDbConnection.Connect();
            CreateAppointmentDTO appointmentFound;
            try
            {
                appointmentFound = await database.QueryFirstAsync<CreateAppointmentDTO>(SqlQueries.QUERY_FIND_APPOINTMENT_BY_ID, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.SingleAppointmentRetrievalFailed, ex);
            }
            return appointmentFound;
        }


         // ---------------------------------TRANSACTION---------------------------------------

        public async Task<CreateAppointmentDTO> Save([FromBody] CreateAppointmentDTO entity)
        {
            Appointment appointmentToSave = new(entity);

            using IDbConnection database = _sqlDbConnection.Connect();
            database.Open();
            using var transaction = database.BeginTransaction(IsolationLevel.Serializable);
            long createdAppointmentId = -1;
            try
            {
                //READ
                foreach (long EmployeeId in appointmentToSave.EmployeeIdList)
                {
                    int amount = await database.QueryFirstAsync<int>(SqlQueries.QUERY_COUNT_APPOINTMENTS_FOR_EMPLOYEE_TIME_AND_DATE, new { Id = EmployeeId, Date = appointmentToSave.Date, TimeSlot = appointmentToSave.TimeSlot }, transaction);
                    Thread.Sleep(2000);
                    if (amount > 0)
                    {
                        throw new DatabaseInsertionException(DALExceptionMessages.EmployeeUnavailable);
                    }
                }

                //SAVE
                createdAppointmentId = await database.ExecuteScalarAsync<long>(SqlQueries.QUERY_SAVE_APPOINTMENT, appointmentToSave, transaction);

                foreach(long EmployeeId in appointmentToSave.EmployeeIdList)
                {
                    await database.ExecuteScalarAsync(SqlQueries.QUERY_SAVE_EMPLOYEE_JOIN_APPOINTMENT, new { employeeId = EmployeeId, appointmentId = createdAppointmentId }, transaction);
                }

                transaction.Commit();
            }
            catch (Exception ex)
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

        public async Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes()
        {
            using IDbConnection database = _sqlDbConnection.Connect();
            IEnumerable<AppointmentTypeDTO> appointmentTypesFound;
            try
            {
                appointmentTypesFound = await database.QueryAsync<AppointmentTypeDTO>(SqlQueries.QUERY_FIND_ALL_APPOINTMENT_TYPES);
            }
            catch (Exception ex)
            {
                throw new RetrievalFailedException(DALExceptionMessages.SingleAppointmentRetrievalFailed, ex);
            }
            return appointmentTypesFound;
        }

        public async Task<IEnumerable<int>> GetTimeSlotsForEmployee(DateTime dateOfAppointment, long id)
        {
            const int startingHour = 7;
            const int finishingHour = 17;

            using IDbConnection database = _sqlDbConnection.Connect();

            IEnumerable<int> bookedAppointments;

            bookedAppointments = await database.QueryAsync<int>(SqlQueries.QUERY_FIND_UNAVAILABLE_TIMESLOTS_BY_EMPLOYE_AND_DATE, new { Date = dateOfAppointment.Date, Id = id });

            ICollection<int> availableHours = new List<int>();

            for(int i = startingHour; i<finishingHour; i++)
            {
                if (!bookedAppointments.Contains(i))
                {
                    availableHours.Add(i);
                }
            }
            return availableHours;
        }

        public Task<IEnumerable<EmployeeDTO>> FindAllEmployeesAndAvailableTimeSlots(DateTime dateOfAppointment)
        {
            throw new NotImplementedException();
        }
    }
}