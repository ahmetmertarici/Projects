using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class CreateCommentModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]
        public string Name { get; set; }
        public string CommentDate { get; set; }
    }
}
