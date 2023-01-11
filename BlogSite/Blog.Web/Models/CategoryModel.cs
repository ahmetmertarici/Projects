using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class CategoryModel
    { 
        public int id { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
    }
}
