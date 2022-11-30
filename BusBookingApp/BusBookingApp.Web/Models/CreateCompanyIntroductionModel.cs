using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class CreateCompanyIntroductionModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string CompanyDescriptionTitle { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string CompanyDescription { get; set; }
    }
}
