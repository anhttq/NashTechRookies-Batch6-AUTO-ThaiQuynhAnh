using AventStack.ExtentReports;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using RookiesTest.DAO;

namespace RookiesTest.PageObject
{
    public class WebTablesPage : WebDriverAction
    {
        public WebTablesPage(IWebDriver driver) : base(driver)
        {
        }

        private String addBtnObject = "//button[@id='addNewRecordButton']";
        private String submitButton = "//button[@id='submit']";
        private String mainHeader = "//*[@class='main-header']";
        private String listEmployeeRow = "//div[@class='rt-table']/descendant::div[@class='rt-tr-group']";
        private String listEmployeeColumn = "//div[@class='rt-td']";
        private String firstNamePath = "//input[@id='firstName']";
        private String lastNamePath = "//input[@id='lastName']";
        private String emailPath = "//input[@id='userEmail']";
        private String agePath = "//input[@id='age']";
        private String salaryPath = "//input[@id='salary']";
        private String departmentPath = "//input[@id='department']";

        public List<EmployeesDAO> UserList = new List<EmployeesDAO>();

        public void IsWebTablesDisplayed()
        {
            Assert.That(true, Is.EqualTo(IsElementDisplayed(mainHeader)));
        }

        public void ClickAddBtn()
        {
            // click on Add button
            Click(addBtnObject);
        }

        public void ClickSubmitBtn()
        {
            // click on Add button
            Click(submitButton);
        }

        public void ClickEditBtn()
        {
            // click on Add button
            Click(submitButton);
        }

        public List<EmployeesDAO> GetListUser()
        {
            // loop table and get list of user from table with row class = "rt-tr-group" and column class = "rt-td"

            // get list object of row
            IList<IWebElement> listRow = FindElementsByXpath(listEmployeeRow);
            // loop row
            foreach (IWebElement row in listRow)
            {
                string test = row.GetAttribute("innerHTML");
                // get list object of column
                IWebElement test2 = row.FindElement(ByXpath("//div[@class='rt-tr']"));

                IList<IWebElement> listColumn = test2.FindElements(By.XPath(listEmployeeColumn));
                // get value of column
                String firstName = listColumn[0].Text;
                String lastName = listColumn[1].Text;
                String age = listColumn[2].Text;
                String email = listColumn[3].Text;
                String salary = listColumn[4].Text;
                String department = listColumn[5].Text;

                // add user to list
                UserList.Add(new EmployeesDAO(firstName, lastName, age, email, salary, department));
            }
            return UserList;
        }

        public void AddNewUser(String firstName, String lastName, String age, String email, String salary, String department)
        {
            // click on Add button
            Click(addBtnObject);
            // input data to form
            SendKeys_(firstNamePath, firstName);
            SendKeys_(lastNamePath, lastName);
            SendKeys_(emailPath, email);
            SendKeys_(agePath, age);
            SendKeys_(salaryPath, salary);
            SendKeys_(departmentPath, department);
            // click on submit button
            Click(submitButton);
        }

        public void EditUser(String firstName, String lastName, String age, String email, String salary, String department)
        {
            // click on Edit button
            Click("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::span[@title='Edit']");
            // input data to form
            SendKeys_(firstNamePath, firstName);
            SendKeys_(lastNamePath, lastName);
            SendKeys_(emailPath, email);
            SendKeys_(agePath, age);
            SendKeys_(salaryPath, salary);
            SendKeys_(departmentPath, department);
            // click on Submit button
            Click(submitButton);
        }

        public void DeleteUser(String firstName)
        {
            // click on Delete button
            Click("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::span[@title='Delete']");
        }

        public bool VerifyUser(String firstName, String lastName, String age, String email, String salary, String department)
        {
            // verify user is displayed in table
            bool isTrue = false;
            if (IsElementDisplayed("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::div[2][text()='" + lastName + "']") &&
                IsElementDisplayed("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::div[3][text()='" + age + "']") &&
                IsElementDisplayed("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::div[4][text()='" + email + "']") &&
                IsElementDisplayed("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::div[5][text()='" + salary + "']") &&
                IsElementDisplayed("//div[@role='row'][descendant::div[1][text()='" + firstName + "']]/descendant::div[6][text()='" + department + "']"))
            {
                isTrue = true;
            }
            return isTrue;
        }
    }
}
