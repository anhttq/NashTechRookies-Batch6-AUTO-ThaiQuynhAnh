using RookiesTest.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using CoreFramework.NUnitTestSetup;
using RookiesTest.TestSetup;

namespace Testcases
{
    [TestFixture]
    public class LoginTest : ProjectNUnitTestSetup
    {
        [Test]
        public void Id1_login()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("test");
        }

        [Test]
        public void Id2_login()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("test");
        }
    }
}