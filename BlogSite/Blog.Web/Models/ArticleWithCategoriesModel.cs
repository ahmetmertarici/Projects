using Blog.Entity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class ArticleWithCategoriesModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required!")]
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public List<Category>? SelectedCategories { get; set; }
    }
}
