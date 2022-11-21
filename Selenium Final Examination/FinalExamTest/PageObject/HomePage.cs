using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RookiesTest.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private String sectionElements = "//div[@class='category-cards']/descendant::h5[text()='Elements']";
        public void GoToElementsPage() => Click(sectionElements);

    }
}
