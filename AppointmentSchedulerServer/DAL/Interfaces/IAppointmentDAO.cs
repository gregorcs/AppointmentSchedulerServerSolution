using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories.Interfaces
{
    public interface IAppointmentDAO : ICrudDAO<AppointmentDTO, long>
    {
        public Task<IEnumerable<AppointmentDTO>> FindAllByAccountId(long id);

    }
}
