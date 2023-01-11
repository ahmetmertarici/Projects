using Blog.Entity;
using Blog.Web.Identity;

namespace Blog.Web.Models
{
    public class ArticleDetailModel
    {
        public Article Article { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public CreateCommentModel createCommentModel { get; set; }
    }
}
