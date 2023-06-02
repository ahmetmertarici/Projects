namespace Blog.API.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string CommentDate { get; set; }
        public int? CommentLike { get; set; }
        public int? CommentDislike { get; set; }
        public string ArticleTitle { get; set; }
    }
}
