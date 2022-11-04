namespace MiniShop.Web.Models
{
    public class ChangePasswordModel
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }
    }
}
