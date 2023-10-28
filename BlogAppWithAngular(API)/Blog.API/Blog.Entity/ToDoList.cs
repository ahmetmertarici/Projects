using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public string? Comment { get; set; }
        public bool Completed { get; set; }
        public bool Status { get; set; }
    }
}
