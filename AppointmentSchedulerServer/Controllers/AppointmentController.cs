using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentDAO _appointmentDAO;

        public AppointmentController(IAppointmentDAO appointmentDAO)
        {
            _appointmentDAO = appointmentDAO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(int id)
        {
            var result = await _appointmentDAO.FindAllByAccountId(id);
            return result == null
                ? BadRequest(ControllerErrorMessages.AppointmentError)
                : Ok(result);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //todo figure out how to get appointment, employee, account into controller -> repository
        [HttpPost]
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
    }
}
