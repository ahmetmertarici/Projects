namespace Blog.API.DTO
{
    public class AdminArticleListDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string CreateDate { get; set; }
        public int? ViewsCount { get; set; }
        public double? Score { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; }
    }
}
