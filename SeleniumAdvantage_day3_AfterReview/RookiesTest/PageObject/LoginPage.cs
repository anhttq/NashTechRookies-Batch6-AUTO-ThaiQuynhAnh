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

        private String tfUserName = "//input[@name='uid']";
        private String tfPassword = "//input[@name='password']";
        private String btnLogin = "//input[@name='btnLogin']";

        public void doLogin(string Username, string Password)
        {
            SendKeys_(tfUserName, Username);
            SendKeys_(tfPassword, Password);
            Click(btnLogin);
        }

    }
}
