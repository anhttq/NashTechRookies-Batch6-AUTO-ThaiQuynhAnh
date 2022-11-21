using RookiesTest.PageObject;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest.DAO;
using RookiesTest.TestSetup;
using RookiesTest.Common;

namespace Testcases
{
    [TestFixture]
    public class Scenario1Test : NUnitWebTestSetup
    {

        [TestCase("Cierra", "Vega", "39", "cierra@example.com", "10000", "Insurance")]
        [TestCase("Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance")]
        [TestCase("Kierra", "Gentry", "29", "kierra@example.com", "2000", "Legal")]
        public void ID1_VerifyEmployeesInformtaion(String firstName, String lastName, String age, String email, String salary, String department)
        {
            CommonFlow.GetWebTablesFlow(_driver);
            WebTablesPage webTablesPage = new WebTablesPage(_driver);
            Assert.IsTrue(webTablesPage.VerifyUser(firstName, lastName, age, email, salary, department));
        }


        //I have no idea why function GetListUser() doesn't work :(((
        public void ID2_VerifyEmployeesInformtaion(String firstName, String lastName, String age, String email, String salary, String department)
        {
            List<EmployeesDAO> listUser = new List<EmployeesDAO>();
            CommonFlow.GetWebTablesFlow(_driver);
            WebTablesPage webTablesPage = new WebTablesPage(_driver);

            listUser = webTablesPage.GetListUser();
            // check if user is existed in listUser Object
            bool isExisted = false;
            foreach (EmployeesDAO user in listUser)
            {
                if (firstName.Equals(user.FirstName) && lastName.Equals(user.LastName) && age.Equals(user.Age) && email.Equals(user.Email) && salary.Equals(user.Salary) && department.Equals(user.Department))
                {
                    isExisted = true;
                    break;
                }
            }
            Assert.IsTrue(isExisted);
        }
    }
}