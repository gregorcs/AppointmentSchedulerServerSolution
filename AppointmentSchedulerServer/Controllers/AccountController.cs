﻿using AppointmentSchedulerServer.Entities;
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

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            return await AccountRepository.ValidateAccountByEmailAndPassword(new Account(email, password)) ? Ok() : NotFound();
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
