using RookiesTest.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.DAO;
using RookiesTest.TestSetup;
using RookiesTest.Common;

namespace Testcases
{
    [TestFixture]
    public class CreateCustomerTest : NUnitWebTestSetup
    {

        public void VerifyCreatedCustomer(CustomerDAO customer)
        {
            //creatSuccessPage = new CustomerSuccessPage(_driver);
            //assert createSuccessPage.GetName() = customer.Name;
            //assert createSuccessPage.GetAddress() = customer.Address;
        }

        [Test]
        public void ID1_CreateCustomer()
        {
            CommonFlow.LoginFlow(_driver);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsWelcomeMessageDisplayed(), "Login failed");
            MenuLeft menuLeft = new MenuLeft(_driver);
            menuLeft.GoToCreateCustomerPage();

            CustomerDAO validCustomer = new CustomerDAO("Tu Nguyen", "Hanoi");
            NewCustomerPage newCustomerPage = new NewCustomerPage(_driver);
            newCustomerPage.InputCustomerInfor(validCustomer);

            //verify in createSuccessPage
            //VerifyCreatedCustomer(validCustomer)
        }
    }
}