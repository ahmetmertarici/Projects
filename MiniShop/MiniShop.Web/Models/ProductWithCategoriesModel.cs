using MiniShop.Entity;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Web.Models
{
    //View'e yollamak için model yaparız.
    //Product'la categories'i bu model ile paketleriz.
    //Validasyon işlemlerini mordel de yaparız.
    public class ProductWithCategoriesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "5 - 100")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required!")]
        [Range(0, 100000, ErrorMessage = "0 - 100,000")]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,0})?)$")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Propoerties are required!")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "10 - 300")]
        public string Properties { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public List<Category> SelectedCategories { get; set; }

    }
}
