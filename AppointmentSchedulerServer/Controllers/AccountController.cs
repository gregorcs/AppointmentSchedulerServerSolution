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

        [HttpPost("create-account")]
        public async Task<ActionResult<Account>> Post(Account account)
        {
            if (account is null)
            {
                return NotFound();
            }
            //change to dto
            var result = await AccountRepository.Save(account);
            if (result == null)
            {
                return NotFound();
            } else
            {
                return Ok(result);
            }
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
            if (accountFound != null)
            {
                return Ok(accountFound);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            
        }

        [HttpPut(Name = "update-admin")]
        public void Update(Account admin)
        {
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<Account> accountsFound = await AccountRepository.FindAll();
            if (accountsFound != null) {
                return Ok(accountsFound);
            } else
            {
                return NotFound();
            }
        }
    }
}
