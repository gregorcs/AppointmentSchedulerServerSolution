using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentDAO _appointmentDAO;

        //todo move these to config, since they are used in multiple controllers
        private const string EmployeeRole = "Admin";
        private const string UserRole = "User";
        private const string UserAndEmployeeRoles = UserRole + ", " + EmployeeRole;

        public AppointmentController(IAppointmentDAO appointmentDAO)
        {
            _appointmentDAO = appointmentDAO;
        }

        [HttpGet("/customer/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(int id)
        {
            var result = await _appointmentDAO.FindAllByAccountId(id);
            return result == null
                ? BadRequest(ControllerErrorMessages.AppointmentError)
                : Ok(result);
        }

        [HttpGet("/employee/{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByEmployeeIdAsync(int id)
        {
            var result = await _appointmentDAO.FindAllByEmployeeId(id);
            return result == null
                ? BadRequest(ControllerErrorMessages.AppointmentError)
                : Ok(result);
        }

        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/


        //todo figure out how to get appointment, employee, account into controller -> repository
        [HttpPost]
        [Authorize(Roles = UserAndEmployeeRoles)]
        public async Task<IActionResult> Post([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            CreateAppointmentDTO result;
            if (appointmentDTO == null)
            {
                return BadRequest(ControllerErrorMessages.InvalidAppointment);
            }
            try
            {
                result = await _appointmentDAO.Save(appointmentDTO);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployeesAndAvailableTimeSlots(DateTime dateOfAppointment)
        {
            IEnumerable<EmployeeDTO> result;

            if (dateOfAppointment == null)
            {
                return BadRequest(ControllerErrorMessages.InvalidAppointment);
            }
            try
            {
                 result = await _appointmentDAO.FindAllEmployeesAndAvailableTimeSlots(dateOfAppointment);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
            return Ok(result);
        }
    }
}
