using System;
// using nunit

namespace Dotnet.Docker
{
    class Program
    {

        static string host = "https://apichallenges.herokuapp.com";

        static void Main(string[] args)
        {
            TestGetRequest();
            TestHeadRequest();
            TestPostRequest();
        }

        // using nunit test get requets to /todo check if response is 200
        public static void TestGetRequest()
        {
            APIRequest request = new APIRequest(host + "/todos", "GET", "");
            request.sendRequest();
            Console.WriteLine(request.responseCode);
            Console.WriteLine(request.responseBody);

        }

        // test HEAD request to /todos 
        public static void TestHeadRequest()
        {
            APIRequest request = new APIRequest(host + "/todos", "HEAD", "");
            request.sendRequest();
            Console.WriteLine(request.responseCode);
            Console.WriteLine(request.responseBody);
        }

        // test HEAD request to /todos  
        public static void TestPostRequest()
        {
            APIRequest request = new APIRequest(host + "/todos", "POST", "{\"title\": \"test\", \"completed\": false, \"userId\": 1}");
            request.sendRequest();
            Console.WriteLine(request.responseCode);
            Console.WriteLine(request.responseBody);
        }

    }
}
