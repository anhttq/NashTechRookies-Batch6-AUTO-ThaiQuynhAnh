using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Drawing;


namespace CoreFramework.DriverCore
{
    public class WebDriverCreator
    {

        public static IWebDriver CreateLocalDriver(string Browser, int ScreenWidth, int ScreenHigh)
        {
            IWebDriver? Driver = null;
            if (Browser.SequenceEqual("firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if (Browser.SequenceEqual("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (Browser.SequenceEqual("safari"))
            {
                Driver = new SafariDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHigh);
            return Driver;
        }

        public static IWebDriver CreateBrowserStackDriver(string Browser, int ScreenWidth, int ScreenHigh)
        {
            IWebDriver? Driver = null;
            if (Browser.SequenceEqual("firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if (Browser.SequenceEqual("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (Browser.SequenceEqual("safari"))
            {
                Driver = new SafariDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Size = new Size(ScreenWidth, ScreenHigh);
            return Driver;
        }
    }
}
