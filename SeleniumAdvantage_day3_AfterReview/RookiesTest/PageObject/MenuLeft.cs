using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RookiesTest.PageObject
{
    public class MenuLeft : WebDriverAction
    {
        public MenuLeft(IWebDriver driver) : base(driver)
        {
        }

        private String btnNewCustomer = "//a[text()='New Customer']";
        public void GoToCreateCustomerPage()
        {
            Click(btnNewCustomer);
        }

    }
}
