﻿using CoreFramework.DriverCore;
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
            _driver.Url = "https://demo.guru99.com/v4/index.php";
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
