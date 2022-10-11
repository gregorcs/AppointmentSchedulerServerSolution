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

        [HttpPost("create-admin")]
        public async Task<int> Post(Account account)
        {
            if (account is null)
            {
                return -1;
            }

            await AccountRepository.Save(account);
            return 1;    
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            bool isInDatabase = await AccountRepository.ExistsByNameAndPassword(new Account(username, password));
            return (isInDatabase) ? Ok() : NotFound();
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
