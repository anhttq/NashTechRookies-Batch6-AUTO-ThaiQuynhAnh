using OpenQA.Selenium;
using RookiesTest.PageObject;
using RookiesTest.TestSetup;

namespace RookiesTest.Common
{
    public class CommonFlow
    {
        public static void GetWebTablesFlow(IWebDriver _driver)
        {
            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            ElementsPage elementsPage = new ElementsPage(_driver);
            elementsPage.ComparePageUrl(Constant.BASE_URL + Constant.elementsPagePath);

            MenuLeft menuLeft = new MenuLeft(_driver);
            menuLeft.GoToWebTablesPage();
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            webTablesPage.IsWebTablesDisplayed();
        }
    }
}
