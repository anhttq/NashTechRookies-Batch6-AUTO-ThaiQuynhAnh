using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Runtime.Intrinsics.X86;

namespace Automation02
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class ParallelTests
    {
        [Test]

        public void TestWithFirefox()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();

            WebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444"), firefoxOptions);
            driver.Navigate().GoToUrl("https://google.com");
            var searchBox = driver.FindElement(By.CssSelector("[name='q']"));
            if (searchBox != null)
            {
                searchBox.SendKeys("ABC");
            }
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile($"E://Firefox.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }

        [Test]
        public void TestWithChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--ignore-ssl-errors=yes");
            chromeOptions.AddArgument("--ignore-certificate-errors");

            WebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444"), chromeOptions);
            driver.Navigate().GoToUrl("https://google.com");
            var searchBox = driver.FindElement(By.CssSelector("[name='q']"));
            if (searchBox != null)
            {
                searchBox.SendKeys("ABC");
            }
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile($"E://Firefox.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }
    }
}