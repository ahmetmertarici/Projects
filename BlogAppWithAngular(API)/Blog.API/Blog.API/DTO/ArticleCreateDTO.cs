using System.ComponentModel.DataAnnotations;

namespace Blog.API.DTO
{
    public class ArticleCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int[] CategoryIds { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
