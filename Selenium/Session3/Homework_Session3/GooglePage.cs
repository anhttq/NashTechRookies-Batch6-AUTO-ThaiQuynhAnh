using OpenQA.Selenium;

namespace Homework_Session3
{
    class GooglePage
    {
        IWebDriver driver;
        public GooglePage(IWebDriver driverTest)
        {
            this.driver = driverTest;
        }
        IWebElement searchBox => driver.FindElement(By.Name("q"));
        IWebElement searchButton => driver.FindElement(By.Name("btnK"));
        IWebElement firstResult => driver.FindElement(By.XPath("(//div[@id='rso']/descendant::a[h3])[1]"));

        //go to Google page
        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        public void Search(string text)
        {
            searchBox.SendKeys(text);
            searchButton.Click();
            Thread.Sleep(3000);
        }
        public void ClickFirstResult()
        {
            firstResult.Click();
            Thread.Sleep(3000);
        }

        public string GetTitle()
        {
            return driver.Title;
        }
    }
}