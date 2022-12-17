using AppointmentSchedulerServer.Controllers;
using AppointmentSchedulerServer.DAL.Interfaces;
using AppointmentSchedulerServer.DataTransferObjects;
using NUnit.Framework;

namespace AppointmentSchedulerServerTests.Controller_Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public async void AccountDtoShouldSave()
        {
            //arrange

            AccountDTO AccountToSave = new AccountDTO("test", "abc@gmail.com", "abcd1234");

            IEmployeeDAO MockEmployeeDAO = new MockEmployeeDAO();

            IAccountDAO MockAccountDAO = new MockAccountDAO();
            var AccountController = new AccountController(MockAccountDAO, MockEmployeeDAO);

            //act
            AccountController.Post(AccountToSave);

            //assert

            MockAccountDAO.ValidateAccountByEmailAndPassword(AccountToSave);
        }
    }
}
