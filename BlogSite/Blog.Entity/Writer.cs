using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Entity
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string Mail { get; set; }
        public string Nickname { get; set; }
        public string Thumbnail { get; set; }
        public List<Article> Articles { get; set; } 
    }
}