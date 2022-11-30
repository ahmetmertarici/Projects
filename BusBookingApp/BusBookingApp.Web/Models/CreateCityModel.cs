using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class CreateCityModel
    {
        [Required(ErrorMessage = "City Name is required!")]
        public string CityName { get; set; }
    }
}
