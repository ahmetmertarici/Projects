namespace MiniShop.Web.Identity
{
    public class MyIdentityAddress
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string AddressText { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public string MyIdentityUserId { get; set; }
        public MyIdentityUser MyIdentityUser { get; set; }

    }
}
