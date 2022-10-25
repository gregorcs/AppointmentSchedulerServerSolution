using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class AdminController : Controller
    {
        [HttpPut(Name = "update-admin")]
        public void Update(Admin admin)
        {
        }
    }
}
