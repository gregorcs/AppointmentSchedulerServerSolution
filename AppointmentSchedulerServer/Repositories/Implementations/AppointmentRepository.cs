using AppointmentSchedulerServer.Data_Transfer_Objects;
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
                throw new RetrievalFailedException(RepositoryExceptionMessages.AppointmentRetrievalFailed, ex);
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

        public Task<AppointmentDTO> Save(AppointmentDTO entity)
        {
            //Add to appointment
            //Add to account_appointment
            //for employee and also for appointment
            Appointment appointmentToSave = new(entity);
            using IDbConnection database = _sqlDbConnectionFactory.Connect();
            long createdId;
/*            try
            {
                createdId = await database.QueryAsync<long>(SqlQueries.)
            }*/
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
