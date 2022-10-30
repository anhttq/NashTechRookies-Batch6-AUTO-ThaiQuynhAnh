using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Homework_Session2
{
    [TestFixture]
    public class Scenario1
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void Test()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.Manage().Window.Maximize();
            Console.WriteLine("Website is opened successfully");

            IWebElement contactUs = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@title='Contact us']")));
            contactUs.Click();

            IWebElement formTitle = _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//form[@method='post']/preceding-sibling::*")));
            string actualFormTitle = formTitle.Text.ToUpper();
            string expectedFormTitle = "CUSTOMER SERVICE - CONTACT US";
            //Console.WriteLine($"formTitle: {actualFormTitle}");
            Assert.That(actualFormTitle, Is.EqualTo(expectedFormTitle));

            _driver.Navigate().Back();

            string actualPageTitle = _driver.Title;
            string expectedPageTitle = "My Store";
            //Console.WriteLine($"actualPageTitle: {actualPageTitle}");
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle));

            _driver.Navigate().Forward();

            _driver.Quit();
        }

        [Test]
        public void WaitMethod()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.Manage().Window.Maximize();
            IWebElement contactUs = _driver.FindElement(By.XPath("//*[@title='Contact us']"));
            contactUs.Click();

            IWebElement sHeading = _driver.FindElement(By.Id("id_contact"));
            SelectElement oSelect = new SelectElement(sHeading);
            oSelect.SelectByIndex(1);
            _wait.Until(ExpectedConditions.ElementToBeSelected(By.CssSelector("[value='2']")));

            Thread.Sleep(3000);

            _driver.Quit();
    
        }

    }
}