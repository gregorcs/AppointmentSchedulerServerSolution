using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulerServer.BusinessLogicLayer.Implementation;
using AppointmentSchedulerServer.BusinessLogicLayer.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using AppointmentSchedulerServer.Models;
using AppointmentSchedulerServerTests.MockDAL;
using Microsoft.AspNetCore.Mvc;
using NUnit;
using NUnit.Framework;

namespace AppointmentSchedulerServerTests.Tests
{
    public class AppointmentTests
    {
        MockAppointmentDAO appointmentDAO;
        MockEmployeeDAO employeeDAO;
        AppointmentBLL appointmentBLL;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            appointmentDAO = new MockAppointmentDAO();
            employeeDAO = new MockEmployeeDAO();
            appointmentBLL = new AppointmentBLL(appointmentDAO, employeeDAO);
        }

        [Test]
        public async Task TestShouldFindOneAppointment()
        {
            long customerId = 6;
            //Act
            ActionResult<IEnumerable<Appointment>> appointmentsFound = await appointmentBLL.FindAllByAccountIdAsync(customerId);

            //Assert
            Assert.AreEqual(appointmentsFound.Value.Count(), 1);
        }

        [Test]
        public async void TestShouldFindZeroAppointment()
        {
            long customerId = 2;
            //Act
            ActionResult<IEnumerable<Appointment>> appointmentsFound = await appointmentBLL.FindAllByAccountIdAsync(customerId);
            ICollection<Appointment> appointments = (ICollection<Appointment>)appointmentsFound.Value;

            //Assert
            Assert.Equals(appointments.Count, 0);
        }
    }
}
