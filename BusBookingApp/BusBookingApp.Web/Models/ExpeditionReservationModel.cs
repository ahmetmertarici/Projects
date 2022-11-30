using BusBookingApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class ExpeditionReservationModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string CustomerSurname { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public TravelDetail TravelDetail { get; set; }
    }
}
