using RookiesTest.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.DAO;
using RookiesTest.TestSetup;
using RookiesTest.Common;

namespace Testcases
{
    [TestFixture]
    public class Scenario2Test : NUnitWebTestSetup
    {

        [TestCase("Selena", "Gomez", "29", "selena@example.com", "2000", "Legal")]
        public void ID2_AddNewEmployee(String firstName, String lastName, String age, String email, String salary, String department)
        {
            CommonFlow.GetWebTablesFlow(_driver);
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            webTablesPage.ClickAddBtn();
            webTablesPage.AddNewUser(firstName, lastName, age, email, salary, department);

            Assert.IsTrue(webTablesPage.VerifyUser(firstName, lastName, age, email, salary, department));
        }
    }
}