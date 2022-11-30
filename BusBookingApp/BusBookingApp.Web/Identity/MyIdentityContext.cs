using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApp.Web.Identity
{
    public class MyIdentityContext : IdentityDbContext<MyIdentityUser>
    {
        public MyIdentityContext(DbContextOptions<MyIdentityContext> options) : base(options)
        {



        }
    }
}
