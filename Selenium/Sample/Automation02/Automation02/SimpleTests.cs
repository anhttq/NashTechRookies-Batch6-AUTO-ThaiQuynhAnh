using Automation02;
using AutomationTest02.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Automation02
{
    [TestFixture]
    public class SimpleTests
    {
        protected WebDriverWait? _wait;
        protected IWebDriver? _driver;
        protected ExtentReports? _extentReport;
        protected ExtentTest? _extentTest;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _extentReport = new ExtentReports();
            string reportPath = TestContext.CurrentContext.TestDirectory;
            var reporter = new ExtentHtmlReporter($"{reportPath}\\Reports\\Report-{DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss")}");
            _extentReport.AttachReporter(reporter);
        }

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _extentTest = _extentReport.CreateTest($"{TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                _extentTest?.Pass($"[Passed] Test {TestContext.CurrentContext.Test.Name}");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                _extentTest?.Fail($"[Failed] Test {TestContext.CurrentContext.Test.Name} because the error \n -{TestExecutionContext.CurrentContext.}");

            }

            _extentReport.Flush();
        }

        [TestCase(1)]
        [TestCase(2)]

        public void Equals1Comparation(int comparedNumber)
        {
            _extentTest?.CreateNode($"Step 1 is doing smt").Info("Step 1 is implemented");
            _extentTest?.CreateNode($"Step 2 is doing smt").Info("Step 2 is implemented");
            _extentTest?.CreateNode($"Step 3 is doing smt").Info("Step 3 is implemented");
            Assert.IsTrue(comparedNumber == 1);
        }

        [Test]
        public void USerCanSearchVideos()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.InputSearchBox("ABC")
                .ClickSearchButton()
                .OpenVideo("Sư Thích Chánh Định #thichchanhdinh");
        }

        public int? GetRandomNumber()
        {
            return null;
        }

        public void CalculateAbc(string a)
        {
            Console.WriteLine(a);
        }

        [Test]
        public void ElementsCommandTests()
        {
            //Element commands
            _driver.Navigate().GoToUrl("https://youtube.com");
            IList<IWebElement> tags = _driver.FindElements(By.XPath("//yt-chip-cloud-chip-renderer"));
            Console.WriteLine($"There are [{tags.Count}] tags:");
            for (int i = 0; i < tags.Count; i++)
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
                Console.WriteLine("Search button is not displayed");

            if (searchButton.Enabled)
                Console.WriteLine("Search button is enabled");
            else
                Console.WriteLine("Search button is not enabled");
            Console.WriteLine($"Search box has text as [{searchBox.Text}] and name attribute as" +
                $" [{searchBox.GetAttribute("name")}] and [{searchBox.GetAttribute("value")}]");
            searchButton.Click();

            Assert.That(searchButton.GetAttribute("value"), Is.EqualTo("Waiting for you 2"));
        }

        public void Click(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            e.Click();
        }
    }
}