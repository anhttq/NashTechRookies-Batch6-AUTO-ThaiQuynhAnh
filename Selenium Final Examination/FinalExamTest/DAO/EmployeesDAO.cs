using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.DAO
{
    public class EmployeesDAO
    {
        public string FirstName { get; set; }
        // lastname, age, email, salary, department
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
        public EmployeesDAO(string firstName, string lastName, string age, string email, string salary, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Salary = salary;
            Department = department;
        }
    }
}
