using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using CoreFramework.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RookiesTest.PageObject
{
    public class ElementsPage : WebDriverAction
    {
        public ElementsPage(IWebDriver driver) : base(driver)
        {
        }

        public void ComparePageUrl(string expected)
        {
            try
            {
                string actual = GetUrl();
                Assert.That(actual, Is.EqualTo(expected));
                TestContext.Write("CompareUrl " + expected.ToString() + " passed");
                HtmlReport.Pass("CompareUrl " + expected.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("CompareUrl " + expected.ToString() + " failed");
                HtmlReport.Fail("CompareUrl " + expected.ToString() + " failed", TakeScreenshot());
                throw ex;
            }
        }

    }
}
