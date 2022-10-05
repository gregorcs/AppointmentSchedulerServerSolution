using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
