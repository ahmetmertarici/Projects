using Microsoft.AspNetCore.Identity;

namespace MiniShop.Web.Identity
{
    public class MyIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MyIdentityAddress> MyIdentityAddresses { get; set; }
    }
}
