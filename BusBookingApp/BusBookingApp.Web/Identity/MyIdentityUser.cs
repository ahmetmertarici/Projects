using Microsoft.AspNetCore.Identity;

namespace BusBookingApp.Web.Identity
{
    public class MyIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
