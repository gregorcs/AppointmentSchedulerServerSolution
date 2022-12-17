using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Interfaces
{
    public interface IAccountBLL
    {
        public Task<ActionResult<Account>> Save(AccountDTO account);
        public Task<ActionResult> Authenticate(AccountDTO account);
        public Task<ActionResult> GetById(long id);
        public Task<ActionResult> FindAll();
    }
}
