using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories.Interfaces
{
    public interface IAppointmentRepository : ICrudRepository<AppointmentDTO, long>
    {
        public Task<IEnumerable<AppointmentDTO>> FindAllByAccountId(long id);

    }
}
