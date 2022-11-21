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

        private String btnWebTables = "//span[text()='Web Tables']";
        public void GoToWebTablesPage()
        {
            Click(btnWebTables);
        }

    }
}
