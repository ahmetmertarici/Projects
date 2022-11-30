using BusBookingApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class CreateRouteModel
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        public int PeronNumber { get; set; }
        [Required(ErrorMessage = "DepartureCity is required")]
        public int DepartureCityId { get; set; }
        [Required(ErrorMessage = "ArrivalCity is required")]
        public int ArrivalCityId { get; set; }
        [Required(ErrorMessage = "Bus Seat Capacity is required")]
        public int BusId { get; set; }
    }
}
