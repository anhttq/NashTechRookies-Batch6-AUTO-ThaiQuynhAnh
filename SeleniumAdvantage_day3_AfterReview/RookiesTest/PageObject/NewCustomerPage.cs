using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using RookiesTest.DAO;

namespace RookiesTest.PageObject
{
    public class NewCustomerPage : WebDriverAction
    {
        public NewCustomerPage(IWebDriver driver) : base(driver)
        {
        }

        private String tfName = "//input[@name='name']";
        private String tfAddress = "//textarea[@name='addr']";

        public void InputCustomerInfor(CustomerDAO customer)
        {
            SendKeys_(tfName, customer.Name);
            SendKeys_(tfAddress, customer.Address);
        }

    }
}
