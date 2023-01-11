using Blog.Entity;
using Blog.Web.Identity;

namespace Blog.Web.Models
{
    public class WriterModel
    {
        public List<Article> Articles { get; set; }
        public Writer Writer { get; set; }
        public MyIdentityUser User { get; set; }
    }
}
  