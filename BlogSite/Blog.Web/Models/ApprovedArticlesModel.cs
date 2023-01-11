using Blog.Entity;

namespace Blog.Web.Models
{
    public class ApprovedArticlesModel
    {
        public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }

    }
}
