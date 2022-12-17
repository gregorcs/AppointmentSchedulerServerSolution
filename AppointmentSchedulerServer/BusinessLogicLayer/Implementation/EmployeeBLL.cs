using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Implementation
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployeeDAO _employeeDAO;
        public EmployeeBLL(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }

        public async Task<ActionResult<Employee>> Save(EmployeeDTO employee)
        {
            if (employee is null)
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidAccount);
            }

            if (await _employeeDAO.ExistsByEmail(employee))
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidEmail);
            }
            try
            {
                var result = await _employeeDAO.Save(employee);
                return result != null ? new OkObjectResult(result) : new NotFoundResult();
            }
            catch (Exception ex)
            {
                //i CW the exception since we are not implementing
                //a logger and i wanna see if there are any exceptions
                Console.WriteLine(ex);
                return new ObjectResult(ControllerErrorMessages.EncounteredError) { StatusCode = 500};
            }
        }
    }
}
