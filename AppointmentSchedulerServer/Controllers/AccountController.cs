﻿using AppointmentSchedulerServer.Data_Transfer_Objects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private const string EmployeeRole = "Admin";
        private const string UserRole = "User";
        private const string UserAndEmployeeRoles = UserRole + ", " + EmployeeRole;

        public AccountController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Account>> Post(AccountDTO account)
        {
            if (account is null)
            {
                return BadRequest(ControllerErrorMessages.InvalidAccount);
            }

            if (await _accountRepository.ExistsByEmail(account))
            {
                return BadRequest(ControllerErrorMessages.InvalidEmail);
            }
            try
            {
                var result = await _accountRepository.Save(account);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                //i CW the exception since we are not implementing
                //a logger and i wanna see if there are any exceptions
                Console.WriteLine(ex);
                return StatusCode(500, ControllerErrorMessages.EncounteredError);
            }
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AccountDTO accountDTO)
        {
            var accountIdFound = await _accountRepository.ValidateAccountByEmailAndPassword(accountDTO);
            var employeeFound = await _employeeRepository.FindById(accountIdFound);
            if (accountIdFound > 0)
            {
                return employeeFound == null 
                    ? Ok(new {Role = "User", JwtToken = JWTHandler.CreateUserToken(accountDTO) }) 
                    : Ok(new {Role = "Admin" , JwtToken = JWTHandler.CreateAdminToken(accountDTO) });
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = EmployeeRole)]
        public async Task<IActionResult> GetById(int id)
        {
            AccountDTO accountFound = await _accountRepository.FindById(id);
            return accountFound != null ? Ok(accountFound) : NotFound();
        }

        [HttpDelete]
        [Authorize(Roles = UserAndEmployeeRoles)]
        public void Delete(int Id)
        {

        }

        [HttpPut]
        [Authorize(Roles = UserAndEmployeeRoles)]
        public async Task<IActionResult> UpdateAccount(AccountDTO accountDTO)
        {
            AccountDTO accountToUpdate = await _accountRepository.Update(entity);
            return accountToUpdate != null ? Ok(accountToUpdate) : NotFound();
        }

        [HttpGet]
        [Authorize(Roles = EmployeeRole)]
        public async Task<IActionResult> FindAll()
        {
            var result = await _accountRepository.FindAll();
            return result != null ? Ok(result) : NotFound();
        }
    }
}
