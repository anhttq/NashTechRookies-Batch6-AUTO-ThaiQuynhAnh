using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Homework_Session2
{
    [TestFixture]
    public class Scenario1
    {
        protected IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _driver.Manage().Window.Maximize();
            Console.WriteLine("Website is opened successfully");

            IWebElement contactUs = _driver.FindElement(By.XPath("//*[@title='Contact us']"));
            contactUs.Click();

            IWebElement formTitle = _driver.FindElement(By.XPath("//form[@method='post']/preceding-sibling::*"));
            string actualFormTitle = formTitle.Text.ToUpper();
            string expectedFormTitle = "CUSTOMER SERVICE - CONTACT US";
            Console.WriteLine("formTitle = " + actualFormTitle);
            Assert.That(actualFormTitle, Is.EqualTo(expectedFormTitle));

            _driver.Navigate().Back();

            string actualPageTitle = _driver.Title;
            string expectedPageTitle = "My Store";
            Console.WriteLine("actualPageTitle = " + actualPageTitle);
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle));
        }
    }
}