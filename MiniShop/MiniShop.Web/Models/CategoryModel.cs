using MiniShop.Entity;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name alanı zorunludur.")]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Description alanı zorunludur.")]
        [MaxLength(100)]
        [MinLength(5)]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
