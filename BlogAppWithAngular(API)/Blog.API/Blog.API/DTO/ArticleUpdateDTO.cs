namespace Blog.API.DTO
{
    public class ArticleUpdateDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int[] CategoryIds { get; set; }
        public IFormFile? Image { get; set; }
    }
}
