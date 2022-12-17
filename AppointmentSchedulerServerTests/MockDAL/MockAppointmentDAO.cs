using AppointmentSchedulerServer.DAL;
using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Exceptions;
using AppointmentSchedulerServer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerServerTests.MockDAL
{
    internal class MockAppointmentDAO : IAppointmentDAO
    {
        ArrayList appointments = new ArrayList();

        public MockAppointmentDAO()
        {
            IEnumerable<long> ids = new HashSet<long>(5);
            CreateAppointmentDTO appointment = new CreateAppointmentDTO();
            appointment.Id = 1;
            appointment.Date = DateTime.Now;
            appointment.CustomerId = 6;
            appointment.EmployeeIdList = ids;
            appointment.Message = "Cannot wait for the massage!";
            appointment.IsApproved = false;
            appointment.TimeSlot = 7;
            appointment.AppointmentTypeId = 2;
            appointments.Add(appointment);
        }

        public Task Delete(CreateAppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<CreateAppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreateAppointmentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAppointmentDTO>> FindAllByAccountId(long id)
        {
            /*ArrayList appointmentsFound = new ArrayList();
            foreach (CreateAppointmentDTO appointment in appointments)
            {
                if(appointment.CustomerId == id)
                {
                    appointmentsFound.Add(new GetAppointmentDTO(appointment));
                }
            }
            return Task.FromResult(appointmentsFound);*/
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAppointmentDTO>> FindAllByEmployeeId(long id)
        {
            throw new NotImplementedException();
        } 

        public Task<IEnumerable<CreateAppointmentDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<CreateAppointmentDTO> FindById(long id)
        {
            CreateAppointmentDTO appointmentFound = null;
            foreach (CreateAppointmentDTO appointment in appointments)
            {
                if (appointment.Id == id)
                {
                    appointmentFound = appointment;
                    break;
                }
            }
            return Task.FromResult(appointmentFound);
        }

        public Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetTimeSlotsForEmployee(DateTime dateOfAppointment, long id)
        {
            throw new NotImplementedException();
        }

        public Task<CreateAppointmentDTO> Save(CreateAppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<CreateAppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
