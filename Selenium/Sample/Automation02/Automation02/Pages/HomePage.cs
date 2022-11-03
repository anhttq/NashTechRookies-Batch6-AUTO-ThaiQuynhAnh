using Automation02.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutomationTest02.Pages
{
    public class HomePage : HeaderPage
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly By videoTitles = By.XPath("//*[@id='video-title']");

        public IList<IWebElement>? GetVideoTitles()
        {
            return _driver?.FindElements(videoTitles);
        }


    }
}
