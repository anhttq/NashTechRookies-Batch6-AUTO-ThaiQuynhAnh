using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace Homework_Session3.PageObject
{
    public class SearchResultPage : WebDriverAction
    {
        public SearchResultPage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly string firstResultLocator = "(//div[@id='rso']/descendant::a[h3])[1]";

        public void GetFirstResultPage()
        {
            Click(firstResultLocator);
        }
        public void ComparePageTitle(string actualTitle)
        {
            CompareTitle(actualTitle);
        }

    }

}