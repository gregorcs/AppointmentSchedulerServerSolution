using AppointmentSchedulerServer.BusinessLogicLayer.Interfaces;
using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.JWT;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Implementation
{
    public class AccountBLL : IAccountBLL
    {
        private readonly IAccountDAO _accountDAO;
        private readonly IEmployeeDAO _employeeDAO;
        public AccountBLL(IAccountDAO accountDAO, IEmployeeDAO employeeDAO)
        {
            _accountDAO = accountDAO;
            _employeeDAO = employeeDAO;
        }

        public async Task<ActionResult<Account>> Save(AccountDTO account)
        {
            if (account is null)
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidAccount);
            }

            if (await _accountDAO.ExistsByEmail(account))
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidEmail);
            }
            try
            {
                var result = await _accountDAO.Save(account);
                return result != null ? new OkObjectResult(result) : new NotFoundResult();
            }
            catch (Exception ex)
            {
                //i CW the exception since we are not implementing
                //a logger and i wanna see if there are any exceptions
                Console.WriteLine(ex);
                return new ObjectResult(ControllerErrorMessages.EncounteredError) { StatusCode = 500 };
            }
        }

        public async Task<ActionResult> Authenticate(AccountDTO account)
        {
            long accountIdFound;
            EmployeeDTO employeeFound;
            try
            {
                accountIdFound = await _accountDAO.ValidateAccountByEmailAndPassword(account);
                employeeFound = await _employeeDAO.FindById(accountIdFound);
            }
            catch (Exception ex)
            {
                //logger here
                Console.WriteLine(ex);
                return new ObjectResult(ControllerErrorMessages.CouldNotLogin) { StatusCode = 500 };
            }

            if (accountIdFound > 0)
            {
                var result = employeeFound == null
                    ? new OkObjectResult(new { Role = "User", JwtToken = JWTHandler.CreateUserToken(account), Id = accountIdFound })
                    : new OkObjectResult(new { Role = "Admin", JwtToken = JWTHandler.CreateAdminToken(account), Id = accountIdFound });
                return result;
            }
            return new BadRequestObjectResult("There has a problem finding your account");
        }

        public async Task<ActionResult> GetById(long id)
        {
            AccountDTO accountFound = await _accountDAO.FindById(id);
            return accountFound != null ? new OkObjectResult(accountFound) : new NotFoundResult();
        }

        public async Task<ActionResult> FindAll()
        {
            var result = await _accountDAO.FindAll();
            return result != null ? new OkObjectResult(result) : new NotFoundResult();
        }
    }
}
