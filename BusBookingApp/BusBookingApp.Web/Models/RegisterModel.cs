using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "RePassword is required.")]
        //[DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string RePassword { get; set; }
    }
}
