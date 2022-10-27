using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework_Session2
{
    [TestFixture]
    public class SimpleTests
    {
        protected WebDriverWait? _wait;
        protected IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void BrowserCommandTests()
        {
            //Browser commands
            _driver.Navigate().GoToUrl("https://youtube.com");
            _driver.Navigate().Back();
            _driver.Navigate().Forward();
            _driver.Navigate().Refresh();
            Console.WriteLine($"Driver title is: [{_driver.Title}]");
            Console.WriteLine($"Page source is: [{_driver.PageSource}]");
            (_driver as IJavaScriptExecutor).ExecuteScript("window.open('about:blank','_blank');");
            (_driver as IJavaScriptExecutor).ExecuteScript("window.open('about:blank','_blank');");
            _driver.Navigate().GoToUrl("https://youtube.com");
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            _driver.Close();
            _driver.Quit();
        }

        [Test]
        public void ElementsCommandTest()
        {
            //Element commands
            _driver.Navigate().GoToUrl("https://youtube.com");
            IList<IWebElement> tags = _driver.FindElements(By.XPath("//yt-chip-cloud-chip-renderer"));
            Console.WriteLine($"There are [{tags.Count}] tags:");
            for (int i=0; i < tags.Count; i++)
            {
                Console.WriteLine($"- Tag ({i + 1}): [{tags[i]}] tags:");
            }
            IWebElement searchBox = _driver.FindElement(By.CssSelector("input[id='search']"));
            searchBox.SendKeys("Waiting for you");
            searchBox.Clear();
            Thread.Sleep(3000);
            searchBox.SendKeys("Waiting for you 2");
            IWebElement searchButton = _driver.FindElement(By.CssSelector("[id='search-icon-legacy']"));
            if (searchButton.Displayed)
                Console.WriteLine($"Search button is displayed with tag name [{searchButton.TagName}]");
            else
                Console.WriteLine($"Search button is not displayed.");

            if (searchButton.Enabled)
                Console.WriteLine($"Search button is enable.");
            else
                Console.WriteLine($"Search button is not enable.");
            Console.WriteLine($"Search button has text as [{searchBox.Text}] and name attribute as" + 
                $" [{searchBox.GetAttribute("name")}] and [{searchBox.GetAttribute("value")}]");
            searchButton.Click();

        }

        public void Click(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            e.Click();
        }

    }
}