using OpenQA.Selenium;
using RookiesTest.PageObject;
using RookiesTest.TestSetup;

namespace RookiesTest.Common
{
    public class CommonFlow
    {
        public static void LoginFlow(IWebDriver _driver)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.doLogin(Constant.ADMIN_USERNAME, Constant.ADMIN_PASSWORD);
        }
    }
}
