using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Implementation
{
    public interface IEmployeeBLL
    {
        public Task<ActionResult<Employee>> Save(EmployeeDTO employee);
    }
}