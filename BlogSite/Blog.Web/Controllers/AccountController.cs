using Blog.Business.Abstract;
using Blog.Core;
using Blog.Entity;
using Blog.Web.Identity;
using Blog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private IArticleService _articleService;
        private IWriterService _writerService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;

        public AccountController(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, IArticleService articleService, IWriterService writerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _articleService = articleService;
            _writerService = writerService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                if (selectedRoles.Any(x=>x=="Writer"))
                {
                    Writer writer = new Writer()
                    {
                        WriterName = registerModel.FirstName,
                        WriterSurname = registerModel.LastName,
                        Mail = registerModel.Email,
                        Nickname = registerModel.UserName,
                        Thumbnail = ""
                    };
                    await _writerService.CreateAsync(writer);
                    MyIdentityUser user = new MyIdentityUser()
                    {
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        UserName = registerModel.UserName,
                        Email = registerModel.Email
                    };
                    var result = await _userManager.CreateAsync(user, "123Qwe.");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRolesAsync(user, selectedRoles);
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kullanıcı başarıyla oluşturuldu!", "success");
                        return RedirectToAction("Login");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(registerModel);
                }
                else
                {
                    MyIdentityUser myIdentityUser = new()
                    {
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        Email = registerModel.Email,
                        UserName = registerModel.UserName,
                    };
                    var result = await _userManager.CreateAsync(myIdentityUser, registerModel.Password);
                    if (result.Succeeded)
                    {
                        TempData["AlertMessage"] = Jobs.CreateMessage("BAŞARILI!", "Kayıt işlemi tamamlandı. Lütfen giriş yapınız.", "success");
                        return RedirectToAction("Login");
                    }
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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var username = User.Identity.Name;
            var email = _userManager.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerId = _writerService.GetWriterId(email);
            var writer = await _writerService.GetTheWriterAsync(username);
            List<Article> articles = await _articleService.ArticlesByWriterAsync(writerId);

            WriterModel writerModel = new WriterModel()
            {
                Articles = articles,
                Writer = writer,
                User = user,      
            };
            return View(writerModel);
        }

        public async Task<IActionResult> EditUserInformation()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            EditUserInformationModel editUserInformationModel = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Thumbnail = user.Thumbnail
            };
            return View(editUserInformationModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserInformation(EditUserInformationModel editUserInformationModel, IFormFile file)
        {
            string thumbnail = "";
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (file == null)
                {
                    thumbnail = user.Thumbnail;
                }
                else
                {
                    thumbnail = Jobs.UploadImage(file, editUserInformationModel.UserName);
                }
                if (user != null)
                {
                    user.FirstName = editUserInformationModel.FirstName;
                    user.LastName = editUserInformationModel.LastName;
                    user.Email = editUserInformationModel.Email;
                    user.UserName = editUserInformationModel.UserName;
                    user.Thumbnail = thumbnail;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarıyla düzenlenmiştir.", "success");
                        return RedirectToAction("ManageAccount", "Account");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("Hata!", "Böyle bir kullanıcı bulunamadı!", "danger");
                return RedirectToAction("ManageAccount", "Account");
            }
            return View(editUserInformationModel);
        }

        public async Task<IActionResult> ChangeUserPassword()
        { 

            var user = await _userManager.GetUserAsync(HttpContext.User);
            ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = user.Id };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, userPassToken, changePasswordModel.NewPassword);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
                return RedirectToAction("ManageAccount", "Account");
            }
            return View(changePasswordModel);
        }

    }
}
