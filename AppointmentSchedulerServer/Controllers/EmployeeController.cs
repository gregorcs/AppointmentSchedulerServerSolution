using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServerTests.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private const string EmployeeRole = "Admin";

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRole)]
        public async Task<ActionResult<Employee>> Post(EmployeeDTO employee)
        {
            if (employee is null)
            {
                return BadRequest(ControllerErrorMessages.InvalidAccount);
            }

            if (await _employeeRepository.ExistsByEmail(employee))
            {
                return BadRequest(ControllerErrorMessages.InvalidEmail);
            }
            try
            {
                var result = await _employeeRepository.Save(employee);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                //i CW the exception since we are not implementing
                //a logger and i wanna see if there are any exceptions
                Console.WriteLine(ex);
                return StatusCode(500, ControllerErrorMessages.EncounteredError);
            }
        }
    }
}
