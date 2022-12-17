using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Interfaces
{
    public interface IAppointmentBLL
    {
        public Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(long id);
        public Task<ActionResult<IEnumerable<Appointment>>> FindAllByEmployeeIdAsync(long id);
        public Task<ActionResult> Save(CreateAppointmentDTO appointmentDTO);
        public Task<ActionResult<IEnumerable<AppointmentTypeDTO>>> GetAllAppointmentTypes();
        public Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeeByAppointmentType(long id);
        public Task<ActionResult<IEnumerable<int>>> GetTimeSlotsForEmployee(DateTime dateOfAppointment, long id);

    }
}
