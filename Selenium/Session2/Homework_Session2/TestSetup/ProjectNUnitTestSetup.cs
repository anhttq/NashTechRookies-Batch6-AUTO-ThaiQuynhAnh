using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "http://automationpractice.com/index.php";
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
