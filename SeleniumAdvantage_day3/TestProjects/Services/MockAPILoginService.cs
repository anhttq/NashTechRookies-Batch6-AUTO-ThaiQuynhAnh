using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.APICore;

namespace TestProjects.Services
{
    public class MockAPILoginService
    {
        public string userLoginPath = "/userlogin";

        public APIResponse LoginRequest(string username, string password)
        {
            APIResponse response = new APIRequest()
                .SetUrl("https://602e2a204410730017c5025a.mockapi.io" + userLoginPath)
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddFormData("username", username)
                .AddFormData("password", password)
                .SendRequest();
            return response;
        }
    }
}