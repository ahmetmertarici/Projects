using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class EditBusModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Bus Seat Capacity is required!")]
        public int BusSeatCapacity { get; set; }
    }
}
