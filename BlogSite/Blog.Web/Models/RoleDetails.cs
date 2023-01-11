using Blog.Web.Identity;
using Microsoft.AspNetCore.Identity;

namespace Blog.Web.Models
{
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public List<MyIdentityUser> Members { get; set; }
        public List<MyIdentityUser> NonMembers { get; set; }
    }
}
