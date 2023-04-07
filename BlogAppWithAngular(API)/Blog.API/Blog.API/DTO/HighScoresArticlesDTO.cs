namespace Blog.API.DTO
{
    public class HighScoresArticlesDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public double? Score { get; set; }
        public string ImageUrl { get; set; }
    }
}
