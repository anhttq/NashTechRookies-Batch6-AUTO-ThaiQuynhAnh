using CoreFramework.NUnitTestSetup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.TestSetup
{
    public class APITesting_Potsman_Setup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://apichallenges.herokuapp.com/todos";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
