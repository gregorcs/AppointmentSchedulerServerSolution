using AppointmentSchedulerServer.DbConnections;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories.Interfaces;
using Dapper;
using System.Collections;
using System.Data;

namespace AppointmentSchedulerServer.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly SqlServerDbConnectionFactory _sqlDbConnectionFactory;

        public AppointmentRepository(SqlServerDbConnectionFactory sqlDbConnectionFactory)
        {
            _sqlDbConnectionFactory = sqlDbConnectionFactory;
        }

        public Task Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<Appointment> entities)
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

        public Task<IEnumerable<Appointment>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> FindAllByAccountId(long id)
        {
            IEnumerable<Appointment> appointmentsFound;
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            try
            {
                appointmentsFound = await database.QueryAsync<Appointment>(SqlQueries.QUERY_FIND_APPOINTMENTS_BY_ACCOUNT_ID, id);
            }
            catch(Exception ex)
            {
                throw new RetrievalFailedException(RepositoryExceptionMessages.AppointmentRetrievalFailed, ex);
            }
            return appointmentsFound;
        }

        public Task<IEnumerable<Appointment>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> Save(Appointment entity)
        {
            //Add to appointment
            //Add to account_appointment
            //for employee and also for appointment
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<Appointment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
