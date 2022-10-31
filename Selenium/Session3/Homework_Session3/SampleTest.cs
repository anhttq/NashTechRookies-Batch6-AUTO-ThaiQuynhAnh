using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Homework_Session3
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
        public void Test()
        {
            string expectedFormTitle = "test text - Tìm trên Google";
            GooglePage googlePage = new GooglePage(_driver);
            googlePage.GoTo();

            googlePage.Search("test text");

            string searchTitle = googlePage.GetTitle();

            Assert.That(searchTitle, Is.EqualTo(expectedFormTitle));

            googlePage.ClickFirstResult();
            string expectedItemTitle = "TypingTest.com - Complete a Typing Test in 60 Seconds!";
            string itemTitle = googlePage.GetTitle();
            //Console.WriteLine($"actualPageTitle: {actualPageTitle}");
            Assert.That(itemTitle, Is.EqualTo(expectedItemTitle));

            //_driver.Quit();
        }

    }
}