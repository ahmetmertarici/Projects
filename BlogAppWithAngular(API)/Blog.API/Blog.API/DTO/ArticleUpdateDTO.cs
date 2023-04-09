namespace Blog.API.DTO
{
    public class ArticleUpdateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int[] CategoryIds { get; set; }
        public IFormFile? Image { get; set; }
    }
}
