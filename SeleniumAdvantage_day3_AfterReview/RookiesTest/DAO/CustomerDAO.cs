using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesTest.DAO
{
    public class CustomerDAO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public CustomerDAO(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
