using BusBookingApp.Business.Abstract;
using BusBookingApp.Core;
using BusBookingApp.Web.Identity;
using BusBookingApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private ISupportService _supportService;

        public AccountController(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, ISupportService supportService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _supportService = supportService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser myIdentityUser = new()
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    UserName = registerModel.UserName
                };
                var result = await _userManager.CreateAsync(myIdentityUser, registerModel.Password);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("BAŞARILI!", "Kayıt işlemi tamamlandı. Lütfen giriş yapınız.", "success");
                    return RedirectToAction("Login");
                }
            }
            return View(registerModel);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var myIdentityUser = await _userManager.FindByEmailAsync(loginModel.Email);
                if (myIdentityUser == null)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("HATA!", "Kullanıcı adı ya da şifre hatalı!", "danger");
                    return View(loginModel);
                }
                var result = await _signInManager.PasswordSignInAsync(myIdentityUser, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Oturum Açıldı", "success");
                    return RedirectToAction("ManageAccount");
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("HATA!", "Kullanıcı adı ya da şifre hatalı!", "danger");
                return View(loginModel);
            }
            return View(loginModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["AlertMessage"] = Jobs.CreateMessage("Çıkış Yapıldı!", "", "danger");
            return Redirect("~/");
        }
        public async Task<IActionResult> ManageAccount()
        {
            var username=User.Identity.Name;
            var email = _userManager.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var supports = _supportService.GetSupportMessages(email);
            return View(supports);
        }
    }
}
