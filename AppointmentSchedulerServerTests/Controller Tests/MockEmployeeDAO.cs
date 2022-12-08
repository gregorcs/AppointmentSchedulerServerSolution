using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentSchedulerServerTests.Controller_Tests
{
    internal class MockEmployeeDAO : IEmployeeDAO
    {
        public Task Delete(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<EmployeeDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByEmail(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> Save(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<EmployeeDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
