using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects.Services
{
    public class TodoList
    {
        public partial class TodoItem
        {
            public int id { get; set; }
            public string title { get; set; }
            public int doneStatus { get; set; }
            public string description { get; set; }
        }
    }
}
