using AppointmentSchedulerServer.BusinessLogicLayer.Interfaces;
using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerServer.BusinessLogicLayer.Implementation
{
    public class AppointmentBLL : IAppointmentBLL
    {
        private readonly IAppointmentDAO _appointmentDAO;
        private readonly IEmployeeDAO _employeeDAO;

        public AppointmentBLL(IAppointmentDAO appointmentDAO, IEmployeeDAO employeeDAO)
        {
            _appointmentDAO = appointmentDAO;
            _employeeDAO = employeeDAO;
        }

        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByAccountIdAsync(int id)
        {
            var result = await _appointmentDAO.FindAllByAccountId(id);
            return result == null
                ? new BadRequestObjectResult(ControllerErrorMessages.AppointmentError)
                : new OkObjectResult(result);
        }
        public async Task<ActionResult<IEnumerable<Appointment>>> FindAllByEmployeeIdAsync(int id)
        {
            var result = await _appointmentDAO.FindAllByEmployeeId(id);
            return result == null
                ? new BadRequestObjectResult(ControllerErrorMessages.AppointmentError)
                : new OkObjectResult(result);
        }

        public async Task<ActionResult> Save(CreateAppointmentDTO appointmentDTO)
        {
            CreateAppointmentDTO result;
            if (appointmentDTO == null)
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidAppointment);
            }
            try
            {
                result = await _appointmentDAO.Save(appointmentDTO);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
            return new OkObjectResult(result);
        }

        public async Task<ActionResult<IEnumerable<int>>> GetTimeSlotsForEmployee(DateTime dateOfAppointment, long id)
        {
            IEnumerable<int> result;

            if(dateOfAppointment == null)
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidAppointment);
            }
            bool employeeExists = await _employeeDAO.ExistsById(id);
            if (!employeeExists)
            {
                return new BadRequestObjectResult(ControllerErrorMessages.EmployeeDoesNotExist);
            }
            try
            {
                result = await _appointmentDAO.GetTimeSlotsForEmployee(dateOfAppointment, id);
            }
            catch(Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode=500 };
            }
            return new OkObjectResult(result);
        }

        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployeesAndAvailableTimeSlots(DateTime dateOfAppointment)
        {
            IEnumerable<EmployeeDTO> result;

            if (dateOfAppointment == null)
            {
                return new BadRequestObjectResult(ControllerErrorMessages.InvalidAppointment);
            }
            try
            {
                result = await _appointmentDAO.FindAllEmployeesAndAvailableTimeSlots(dateOfAppointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
            return new OkObjectResult(result);
        }
        public async Task<ActionResult<IEnumerable<AppointmentTypeDTO>>> GetAllAppointmentTypes()
        {
            IEnumerable<AppointmentTypeDTO> result;

            try
            {
                result = await _appointmentDAO.GetAllAppointmentTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
            return new OkObjectResult(result);
        }

        public async Task<ActionResult<IEnumerable<GetEmployeeDTO>>> GetEmployeeByAppointmentType(long id)
        {
            IEnumerable<GetEmployeeDTO> result;

            try
            {
                result = await _employeeDAO.GetEmployeeByAppointmentType(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ObjectResult(ex.Message) { StatusCode = 500 };
            }
            return new OkObjectResult(result);
        }
    }
}
