using Microsoft.AspNetCore.Identity;

namespace Blog.Web.Identity
{
    public class MyIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Thumbnail { get; set; }

    }
}
