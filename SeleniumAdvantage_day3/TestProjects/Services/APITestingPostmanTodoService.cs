using CoreFramework.APICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.Services
{
    public class APITestingPostmanTodoService
    {
        public string Id04_path = "/todo";

        public APIResponse Id04_GETRequest()
        {
            APIResponse response = new APIRequest()
                   .SetUrl("https://apichallenges.herokuapp.com" + Id04_path)
                   .SendRequest();
            return response;
        }

        public string Id05_path = "/todos/574";
        public APIResponse Id05_GETRequest()
        {
            APIResponse response = new APIRequest().
                   SetUrl("https://apichallenges.herokuapp.com" + Id05_path)
                   .SendRequest();
            return response;
        }

        public string Id06_path = "/todos/00";
        public APIResponse Id06_GETRequest()
        {
            APIResponse response = new APIRequest().
                   SetUrl("https://apichallenges.herokuapp.com" + Id06_path)
                   .SendRequest();
            return response;
        }

        public string Id07_path = "/todos";
        public APIResponse Id07_HEADRequest()
        {
            APIResponse response = new APIRequest().
                   SetUrl("https://apichallenges.herokuapp.com" + Id07_path)
                   .SendRequest();
            return response;
        }
    }
}
