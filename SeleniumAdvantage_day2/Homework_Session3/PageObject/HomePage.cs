using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace Homework_Session3.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly string searchBoxLocator = "//*[@name='q']";
        private readonly string searchButton = "//*[@name='btnK']";

        public void SearchKeyword(string Keyword)
        {
            SendKeys_(searchBoxLocator, Keyword);
        }

        public void GoToSearchPage()
        {
            Click(searchButton);
        }
    }

}