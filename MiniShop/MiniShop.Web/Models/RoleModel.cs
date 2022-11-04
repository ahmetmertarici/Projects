using Microsoft.AspNetCore.Identity;
using MiniShop.Web.Identity;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Web.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
    
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public List<MyIdentityUser> Members { get; set; }
        public List<MyIdentityUser> NonMembers { get; set; }
    }

    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}
