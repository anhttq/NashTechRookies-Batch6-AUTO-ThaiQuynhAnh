using CoreFramework.APICore;
using NUnit.Framework;
using RookiesTest.TestSetup;
using RookiesTest.DAO;
using Newtonsoft.Json;

namespace RookiesTest.Services
{
    public class AuthorizationService
    {
        public string loginPath = "/v1/Login";

        public APIResponse LoginRequest(string username, string password)
        {
            string body = "{'userName':" + username + ",'password': " + password + "}";
            APIResponse response = new APIRequest()
                .SetUrl(Constant.BOOK_STORE_HOST + loginPath)
                .AddHeader("Content-Type", "application/json")
                .SetBody(body)
                .Post();
            return response;
        }

        public UserDAO Login(string username, string password)
        {
            APIResponse response = LoginRequest(username, password);
            Assert.True(response.responseStatusCode.Equals("200"));

            UserDAO user = (UserDAO)JsonConvert.DeserializeObject<UserDAO>(response.responseBody);
            return user;
        }
    }
}