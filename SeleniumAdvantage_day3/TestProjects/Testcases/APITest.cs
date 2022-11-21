using NUnit.Framework;
using TestProjects.TestSetup;
using CoreFramework.APICore;
using TestProjects.Services;

namespace TestProjects.APITest
{
    [TestFixture]
    public class APITest : APIProjectNUnitTestSetup
    {
        [Test]
        public void APIResquestTest()
        {
            APIResponse response = new MockAPILoginService().LoginRequest("Melvin_Abernathy34", "UFsLzTfvBEVY5aP");
            Assert.AreEqual(response.responseStatusCode, "OK");
        }

    }
}