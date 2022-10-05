using AppointmentSchedulerServer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class AdminController : Controller
    {
        [HttpPost(Name = "create-admin")]
        public ActionResult<Admin> Post()
        {
            return View();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Admin> GetById(int id)
        {
            return View();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            
        }

        [HttpPut(Name = "update-admin")]
        public void Update(Admin admin)
        {
        }
    }
}
