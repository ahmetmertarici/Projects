using Blog.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace Blog.Web.Models
{
    public class CreateArticleModel
    {
        public int ArticleId { get; set; }
        public string? Title { get; set; }
        [AllowHtml]
        public string? Content { get; set; }
        public bool? IsApproved { get; set; }
        public string? ImageUrl { get; set; }
        [AllowNull]
        public List<Category>? SelectedCategories { get; set; }

    }
}
