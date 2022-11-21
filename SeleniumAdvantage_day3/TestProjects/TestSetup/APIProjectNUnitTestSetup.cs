using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework;


namespace TestProjects.TestSetup
{
    public class APIProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://602e2a204410730017c5025a.mockapi.io/userlogin";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
