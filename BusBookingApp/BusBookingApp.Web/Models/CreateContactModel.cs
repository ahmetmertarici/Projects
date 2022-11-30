using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Web.Models
{
    public class CreateContactModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "Phone is required!")]
        public string BranchPhone { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        public string BranchAddress { get; set; }
    }
}
