using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class EditCityModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "City Name is required!")]
        public string CityName { get; set; }
    }
}
