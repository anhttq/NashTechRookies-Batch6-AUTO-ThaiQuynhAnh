using RookiesTest.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.TestSetup;

namespace Testcases
{
    [TestFixture]
    public class SimpleTests : ProjectNUnitTestSetup
    {
        [Test]
        public void USerCanSearchVideos()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("test");
        }
    }
}