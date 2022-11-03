using AutomationTest02.Pages;
using OpenQA.Selenium;

namespace Automation02.Pages
{
    public class HeaderPage
    {
        protected readonly IWebDriver? _driver;
        public HeaderPage(IWebDriver? driver)
        {
            _driver = driver;
        }

        private readonly By searchBox = By.XPath("//input[@id='search']");
        private readonly By searchButton = By.XPath("//*");

        public IWebElement? GetSearchBox()
        {
            return _driver?.FindElement(searchBox);
        }
        public IWebElement? GetSearchButton()
        {
            return _driver?.FindElement(searchButton);
        }

        public HeaderPage InputSearchBox(string keyword)
        {
            GetSearchBox()?.Clear();
            GetSearchBox()?.SendKeys(keyword);

            return this;
        }

        public VideosPage ClickSearchButton()
        {
            GetSearchButton()?.Click();

            return new VideosPage(_driver);
        }
    }
}
