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
    public class NUnitWebTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToUrl(Constant.BASE_URL);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
