using NUnit.Framework;
using RookiesTest.TestSetup;
using CoreFramework.APICore;
using TestProjects.Services;

namespace RookiesTest.APITest
{
    [TestFixture]
    public class APITest : NUnitAPITestSetup
    {
        [TestCase("/406","OK")]
        [TestCase("/00","NotFound")]
        public void GetTodo(string todoId, string expectation)
        {
            TodoService service = new TodoService();
            APIResponse response = service.GetTodoRequest(todoId);
            Assert.That(response.responseStatusCode, Is.EqualTo(expectation));
        }
    }
}