using AppointmentSchedulerServer.BusinessLogicLayer.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class AccountController : Controller
    {
        private readonly IAccountBLL _accountBLL;

        private const string EmployeeRole = "Admin";
        private const string UserRole = "User";
        private const string UserAndEmployeeRoles = UserRole + ", " + EmployeeRole;

        public AccountController(IAccountBLL accountBLL)
        {
            _accountBLL = accountBLL;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Account>> Post(AccountDTO account)
        {
            return await _accountBLL.Save(account);
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AccountDTO accountDTO)
        {
            return await _accountBLL.Authenticate(accountDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = EmployeeRole)]
        public async Task<ActionResult> GetById(int id)
        {
            return await _accountBLL.GetById(id);
        }

        [HttpDelete]
        [Authorize(Roles = UserAndEmployeeRoles)]
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize(Roles = UserAndEmployeeRoles)]
        public void Update(Account account)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Authorize(Roles = EmployeeRole)]
        public async Task<ActionResult> FindAll()
        {
            return await _accountBLL.FindAll();
        }
    }
}
