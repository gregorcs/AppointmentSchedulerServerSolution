using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Entities;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServerTests.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AccountDTO accountDTO)
        {
            var isAuthenticated = await AccountRepository.ValidateAccountByEmailAndPassword(new Account(accountDTO));
            if (isAuthenticated)
            {
                var token = JWTHandler.CreateUserToken(accountDTO);
                return Ok(token);
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            Account accountFound = await AccountRepository.FindById(id);
            return accountFound != null ? Ok(accountFound) : NotFound();
        }

        [HttpDelete]
        [Authorize(Roles = "User, Admin")]
        public void Delete(int Id)
        {
            
        }

        [HttpPut(Name = "update-account")]
        [Authorize(Roles = "User, Admin")]
        public void Update(Account account)
        {
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FindAll()
        {
            var result = await AccountRepository.FindAll();
            return result != null ? Ok(result) : NotFound();
        }
    }
}
