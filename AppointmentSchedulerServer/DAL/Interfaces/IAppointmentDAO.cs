using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Models;

namespace AppointmentSchedulerServer.Repositories.Interfaces
{
    public interface IAppointmentDAO : ICrudDAO<CreateAppointmentDTO, long>
    {
        public Task<IEnumerable<CreateAppointmentDTO>> FindAllByAccountId(long id);

    }
}
