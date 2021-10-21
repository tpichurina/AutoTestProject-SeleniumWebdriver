using NUnit.Framework;

namespace AutotestTestProject
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginTest()
        {
            OpenLoginPage();
            LoginAsAdmin();
        }
    }
}
