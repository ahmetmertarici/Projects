namespace Blog.API.DTO
{
    public class CreateCommentDTO
    {
        public int? CommentId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string? CommentDate { get; set; }
        public int? CommentLike { get; set; }
        public int? CommentDislike { get; set; }
        public int ArticleId { get; set; }
    }
}
