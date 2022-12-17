using AppointmentSchedulerServer.BusinessLogicLayer.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentBLL _appointmentBLL;

        //todo move these to config, since they are used in multiple controllers
        private const string EmployeeRole = "Admin";
        private const string UserRole = "User";
        private const string UserAndEmployeeRoles = UserRole + ", " + EmployeeRole;

        public AppointmentController(IAppointmentBLL appointmentBLL)
        {
            _appointmentBLL = appointmentBLL;
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(int id)
        {
            return await _appointmentBLL.FindAllByAccountIdAsync(id);
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByEmployeeIdAsync(int id)
        {
            return await _appointmentBLL.FindAllByEmployeeIdAsync(id);
        }

        //todo figure out how to get appointment, employee, account into controller -> repository
        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Roles = UserAndEmployeeRoles)]
        public async Task<IActionResult> Post([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            return await _appointmentBLL.Save(appointmentDTO);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("{dateOfAppointment}/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<int>>> GetTimeSlotsForEmployee(DateTime dateOfAppointment, int id)
        {
            return await _appointmentBLL.GetTimeSlotsForEmployee(dateOfAppointment, id);
        }

        [HttpGet]
        [Route("types")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppointmentTypeDTO>>> GetAllAppointmentTypes()
        {
            return await _appointmentBLL.GetAllAppointmentTypes();
        }

        [HttpGet]
        [Route("type/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeeByAppointmentType(long id)
        {
            return await _appointmentBLL.GetEmployeeByAppointmentType(id);
        }
    }
}
