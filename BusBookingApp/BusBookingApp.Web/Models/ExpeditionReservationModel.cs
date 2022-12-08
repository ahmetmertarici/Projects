using BusBookingApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class ExpeditionReservationModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string CustomerSurname { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvc { get; set; }
        public TravelDetail TravelDetail { get; set; }
    }
}
