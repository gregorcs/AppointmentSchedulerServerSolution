using AppointmentSchedulerServer.DataTransferObjects;

namespace AppointmentSchedulerServer.DAL.Interfaces
{
    public interface IAppointmentDAO : ICrudDAO<CreateAppointmentDTO, long>
    {
        public Task<IEnumerable<GetAppointmentDTO>> FindAllByAccountId(long id);
        public Task<IEnumerable<GetAppointmentDTO>> FindAllByEmployeeId(long id);

        Task<IEnumerable<int>> GetTimeSlotsForEmployee(DateTime dateOfAppointment, long id);
        Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes();

    }
}
