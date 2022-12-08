using AppointmentSchedulerServer.BusinessLogicLayer.Implementation;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBLL _employeeBLL;
        private const string EmployeeRole = "Admin";
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRole)]
        public async Task<ActionResult<Employee>> Post(EmployeeDTO employee)
        {
            return await _employeeBLL.Save(employee);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAppointmentTypes()
        {
            throw new NotImplementedException();
        }
    }
}
