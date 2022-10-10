using AppointmentSchedulerServer.Entities;
using AppointmentSchedulerServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository AccountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
        }

        [HttpPost(Name = "create-admin")]
        public ActionResult<int> Post(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            AccountRepository.Save(account);
            return 1;

        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Account> GetById(int id)
        {
            return View();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            
        }

        [HttpPut(Name = "update-admin")]
        public void Update(Account admin)
        {
        }
    }
}
