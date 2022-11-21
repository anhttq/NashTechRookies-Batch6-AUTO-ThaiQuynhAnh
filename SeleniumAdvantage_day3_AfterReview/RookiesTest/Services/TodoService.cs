using CoreFramework.APICore;
using NUnit.Framework;
using RookiesTest.TestSetup;

namespace TestProjects.Services
{
    public class TodoService
    {
        public string userLoginPath = "/userlogin";

        public APIResponse LoginRequest(string username, string password)
        {
            APIResponse response = new APIRequest()
                .SetUrl("https://602e2a204410730017c5025a.mockapi.io" + userLoginPath)
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddFormData("username", username)
                .AddFormData("password", password)
                .Post();
            return response;
        }

        public string getTodoPath = "/todos{0}";

        public APIResponse GetTodoRequest(string todoId)
        {
            string requestPath = string.Format(getTodoPath, todoId);
            TestContext.WriteLine(Constant.API_HOST + requestPath);
            APIResponse response = new APIRequest()
                   .SetUrl(Constant.API_HOST + requestPath)
                   .SendRequest();
            return response;
        }
    }
}