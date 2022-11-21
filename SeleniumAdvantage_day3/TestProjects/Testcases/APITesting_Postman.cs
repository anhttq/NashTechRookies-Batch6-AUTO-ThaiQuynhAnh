using CoreFramework.APICore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjects.Services;
using TestProjects.TestSetup;

namespace TestProjects.APITesting_Postman
{
    public class APITesting_Postman : APITesting_Potsman_Setup
    {
        [Test]
        public void Id04_apiTest()
        {
            APIResponse response = new APITestingPostmanTodoService().Id04_GETRequest();
            Assert.That(response.responseStatusCode, Is.EqualTo("NotFound"));
        }
        [Test]
        public void Id05_apiTest()
        {
            APIResponse response = new APITestingPostmanTodoService().Id05_GETRequest();
            Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        }
        [Test]
        public void Id06_apiTest()
        {
            APIResponse response = new APITestingPostmanTodoService().Id06_GETRequest();
            Assert.That(response.responseStatusCode, Is.EqualTo("NotFound"));
        }
        [Test]
        public void Id07_apiTest()
        {
            APIResponse response = new APITestingPostmanTodoService().Id07_HEADRequest();
            Assert.That(response.responseStatusCode, Is.EqualTo("NotFound"));
        }
    }
}
