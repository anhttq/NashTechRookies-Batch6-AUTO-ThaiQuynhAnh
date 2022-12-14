using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            highlightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement highlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }

        public void Click(IWebElement e)
        {
            try
            {
                highlightElement(e);
                e.Click();
                TestContext.Write("click into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + e.ToString() + " failed");
                throw ex;
            }
        }

        public void Click(string locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.Write("click into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + locator + " failed");
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.Write("sendkeys into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("sendkeys into element " + locator + " failed");
                throw ex;
            }
        }

        public void TakeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@"D:\Workspace\NashTechRookies-Batch6-AUTO-TTQA\SeleniumAdvantage_day1\AutomationTestFramework\img.png", ScreenshotImageFormat.Png);
        }

        public void CompareTitle(string expected)
        {
            try
            {
                string actual = getTitle();
                Assert.That(actual, Is.EqualTo(expected));
                TestContext.Write("CompareTitle " + expected.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("CompareTitle " + expected.ToString() + " failed");
                throw ex;
            }

        }
    }
}
