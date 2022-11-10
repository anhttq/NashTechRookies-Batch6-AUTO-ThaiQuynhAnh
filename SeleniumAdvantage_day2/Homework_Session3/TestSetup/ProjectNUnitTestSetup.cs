using CoreFramework.DriverCore;
using CoreFramework.NUnitTestSetup;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Session3.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            _driver.Url = "https://www.google.com/";
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
