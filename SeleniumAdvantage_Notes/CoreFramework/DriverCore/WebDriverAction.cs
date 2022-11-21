using NUnit.Framework;
using OpenQA.Selenium;
using CoreFramework.Reporter;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to Url: " + url);
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public void CompareTitle(string expected)
        {
            try 
            {
                string actual = GetTitle();
                Assert.That(actual, Is.EqualTo(expected));
                TestContext.Write("CompareTitle " + expected.ToString() + " passed");
                HtmlReport.Pass("CompareTitle " + expected.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("CompareTitle " + expected.ToString() + " failed");
                HtmlReport.Fail("CompareTitle " + expected.ToString() + " failed", TakeScreenshot());
                throw ex;
            }
            
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
                HtmlReport.Pass("sendkeys into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("sendkeys into element " + locator + " failed");
                HtmlReport.Fail("sendkeys into element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public string TakeScreenshot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMdd")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}
