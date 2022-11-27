using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories.Interfaces
{
    public interface IAppointmentRepository : ICrudRepository<Appointment, long>
    {
        public Task<IEnumerable<Appointment>> FindAllByAccountId(long id);

    }
}
