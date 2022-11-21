using RookiesTest.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.DAO;
using RookiesTest.TestSetup;
using RookiesTest.Common;

namespace Testcases
{
    [TestFixture]
    public class Scenario3Test : NUnitWebTestSetup
    {

        [TestCase("Kierra", "Gentry", "30", "kierra@example.com", "1999", "Legal")]
        public void ID3_UpdateAndDeleteEmployee(String firstName, String lastName, String age, String email, String salary, String department)
        {
            CommonFlow.GetWebTablesFlow(_driver);
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            webTablesPage.EditUser(firstName, lastName, age, email, salary, department);

            Assert.IsTrue(webTablesPage.VerifyUser(firstName, lastName, age, email, salary, department));

            webTablesPage.DeleteUser(firstName);
            Assert.IsFalse(webTablesPage.VerifyUser(firstName, lastName, age, email, salary, department));
        }
    }
}