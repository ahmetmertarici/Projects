using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class SupportModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Topic is required!")]
        public string Topic { get; set; }
        [Required(ErrorMessage = "Text is required!")]
        public string Text { get; set; }
    }
}
