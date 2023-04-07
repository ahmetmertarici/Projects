namespace Blog.API.DTO
{
    public class ArticlesByMostViewDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int ViewsCount { get; set; }
        public string ImageUrl { get; set; }

    }
}
