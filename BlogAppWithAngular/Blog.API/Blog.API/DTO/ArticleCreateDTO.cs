using System.ComponentModel.DataAnnotations;

namespace Blog.API.DTO
{
    public class ArticleCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int[] CategoryIds { get; set; }
        public IFormFile? Image { get; set; }
    }
}
