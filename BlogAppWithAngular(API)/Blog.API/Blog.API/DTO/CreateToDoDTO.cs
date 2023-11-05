namespace Blog.API.DTO
{
    public class CreateToDoDTO
    {
        public string Title { get; set; }
        public string? Text { get; set; }
        public string? Comment { get; set; }
        public bool? Completed { get; set; }
        public bool? Status { get; set; }
    }
}
