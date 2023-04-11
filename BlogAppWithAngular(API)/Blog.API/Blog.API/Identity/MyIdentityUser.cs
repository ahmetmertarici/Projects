using Microsoft.AspNetCore.Identity;

namespace Blog.API.Identity
{
    public class MyIdentityUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Thumbnail { get; set; }
    }
}
