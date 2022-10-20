using AppointmentSchedulerServer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestAccountController
    {
        public IAccountRepository accountRepository;
        public TestAccountController()
        {
            
        }

        [TestMethod]
        public async void Authenticate_ShouldReturnTrue()
        {

        }
    }
}
