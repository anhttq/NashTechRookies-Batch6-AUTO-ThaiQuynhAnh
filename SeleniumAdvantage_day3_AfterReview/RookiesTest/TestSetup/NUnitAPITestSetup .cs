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
    public class NUnitAPITestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
