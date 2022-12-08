using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Interfaces
{
    public interface IAppointmentBLL
    {
        public Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(int id);
        public Task<ActionResult<IEnumerable<Appointment>>> FindAllByEmployeeIdAsync(int id);
        public Task<ActionResult> Save(CreateAppointmentDTO appointmentDTO);
        public Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployeesAndAvailableTimeSlots(DateTime dateOfAppointment);
        public Task<ActionResult<IEnumerable<AppointmentTypeDTO>>> GetAllAppointmentTypes();
        public Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeeByAppointmentType(long id);
    }
}
