using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Entities;
using AppointmentSchedulerServer.Repositories;
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

        //TODO fix error not thrown when posting already registered email
        [HttpPost("create-account")]
        public async Task<ActionResult<Account>> Post(Account account)
        {
            if (account is null)
            {
                return NotFound();
            }
            //change to dto
            var result = await AccountRepository.Save(account);
            return result != null ? Ok(result) : NotFound();
        }
        //error handling when calling repo - how should it look like?
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AccountDTO accountDTO)
        {
            return await AccountRepository.ValidateAccountByEmailAndPassword(new Account(accountDTO)) 
                ? Ok() : NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Account accountFound = await AccountRepository.FindById(id);
            return accountFound != null ? Ok(accountFound) : NotFound();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            
        }

        [HttpPut(Name = "update-account")]
        public void Update(Account account)
        {
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var result = await AccountRepository.FindAll();
            return result != null ? Ok(result) : NotFound();
        }
    }
}
