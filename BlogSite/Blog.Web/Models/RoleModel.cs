using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
}
