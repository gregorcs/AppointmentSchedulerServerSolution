using AppointmentSchedulerServer.Controllers;
using NUnit.Framework;
using AppointmentSchedulerServer.Repositories;
using AppointmentSchedulerServer.Data_Transfer_Objects;

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

            IEmployeeRepository MockEmployeeRepository = new MockEmployeeRepository();

            IAccountRepository MockAccountRepository = new MockAccountRepository();
            var AccountController = new AccountController(MockAccountRepository, MockEmployeeRepository);

            //act
            AccountController.Post(AccountToSave);

            //assert

            MockAccountRepository.ValidateAccountByEmailAndPassword(AccountToSave);
        }
    }
}
