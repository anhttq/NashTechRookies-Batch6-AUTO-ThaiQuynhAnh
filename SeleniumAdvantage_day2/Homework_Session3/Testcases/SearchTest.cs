using Homework_Session3.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using CoreFramework.NUnitTestSetup;
using Homework_Session3.TestSetup;

namespace Testcases
{
    [TestFixture]
    public class SearchTest : ProjectNUnitTestSetup
    {
        [Test]
        public void UserCanSearchKeyword()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.SearchKeyword("test text");
            homePage.GoToSearchPage();
        }

        [Test]
        public void Id1_VerifySearchResultPageTitle()
        {
            UserCanSearchKeyword();
            SearchResultPage searchResultPage = new SearchResultPage(_driver);
            searchResultPage.ComparePageTitle("test text - Google Search");
        }

        [Test]
        public void Id2_VerifyFirstResultTitle()
        {
            UserCanSearchKeyword();
            SearchResultPage searchResultPage = new SearchResultPage(_driver);
            searchResultPage.GetFirstResultPage();
            searchResultPage.ComparePageTitle("TypingTest.com - Complete a Typing Test in 60 Seconds!");
        }
    }
}