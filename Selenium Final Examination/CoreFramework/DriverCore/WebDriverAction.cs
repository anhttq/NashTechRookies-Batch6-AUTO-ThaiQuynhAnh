using NUnit.Framework;
using OpenQA.Selenium;
using CoreFramework.Reporter;
using System.Security.Policy;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.Extensions;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to Url: " + url);
        }

        public string GetUrl()
        {
            return driver.Url;
        }

        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            HighlightElement(e);
            return e;
        }

        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }

        public Boolean IsElementDisplayed(string locator)
        {
            try
            {
                FindElementByXpath(locator);
                TestContext.WriteLine("selected element is displayed");
                HtmlReport.Pass("selected element" + locator + "is displayed");
                return true;
            }
            catch (Exception ex)
            {
                return false;
                HtmlReport.Fail("selected element" + locator + "is displayed", TakeScreenshot());
                throw ex;
            }
        }

        public void Click(IWebElement e)
        {
            try
            {
                HighlightElement(e);
                e.Click();
                TestContext.Write("click into element " + e.ToString() + " passed");
                HtmlReport.Pass("click into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + e.ToString() + " failed");
                HtmlReport.Fail("click into element " + e.ToString + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void Click(string locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement e = wait.Until(ExpectedConditions.ElementToBeClickable(ByXpath(locator)));
                driver.ExecuteJavaScript("arguments[0].click();", e);
                //FindElementByXpath(locator).Click();
                TestContext.Write("click into element " + locator + " passed");
                HtmlReport.Pass("click into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("click into element " + locator + " failed");
                HtmlReport.Fail("click into element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindElementByXpath(locator).Clear();
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
