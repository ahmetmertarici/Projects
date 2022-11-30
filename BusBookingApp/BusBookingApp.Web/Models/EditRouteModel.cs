using BusBookingApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class EditRouteModel
    {
        public int id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public double Price { get; set; }
        public int PeronNumber { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public int BusId { get; set; }
    }
}
