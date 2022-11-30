using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class CreateBusModel
    {
        [Required(ErrorMessage = "Bus Seat Capacity is required!")]
        public int BusSeatCapacity { get; set; }
    }
}

