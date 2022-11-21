using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.DAO
{
    public class UserDAO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string userId { get; set; }
        public UserDAO(string username, string password, string token, string userId)
        {
            this.username = username;
            this.password = password;
            this.token = token;
            this.userId = userId;
        }
    }
}
