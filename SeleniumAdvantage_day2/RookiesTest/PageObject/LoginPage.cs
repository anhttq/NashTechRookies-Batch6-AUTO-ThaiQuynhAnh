using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RookiesTest.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly string tfUserName = "//input[@name='abc']";

        public void inputUserName(string UserName)
        {
            SendKeys_(tfUserName, UserName);
        }


    }
}
