using Blog.Business.Abstract;
using Blog.Core;
using Blog.Entity;
using Blog.Web.Identity;
using Blog.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ICategoryService _categoryService;
        private IArticleService _articleService;
        private IWriterService _writerService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IArticleService articleService, UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ICategoryService categoryService, IWriterService writerService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        #region UserActions
        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            return View(userList);
        }
        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            _userManager.DeleteAsync(user);
            return RedirectToAction("UserList");
        }
        
        public async Task<IActionResult> WriterCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WriterCreate(UserModel userModel, string[] selectedRoles)
        {
            Writer writer = new Writer()
            {
                WriterName = userModel.FirstName,
                WriterSurname = userModel.LastName,
                Mail = userModel.Email,
                Nickname = userModel.UserName,
                Thumbnail = ""
            };
            await _writerService.CreateAsync(writer);
            MyIdentityUser user = new MyIdentityUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                Email = userModel.Email
            };
            var result = await _userManager.CreateAsync(user, "123Qwe.");
            if (result.Succeeded)
            {
                selectedRoles = selectedRoles ?? new string[] { };
                await _userManager.AddToRolesAsync(user, selectedRoles);
                TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kullanıcı başarıyla oluşturuldu!", "success");
                return RedirectToAction("UserList");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> UserCreate()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel, string[] selectedRoles)
        {
            MyIdentityUser user = new MyIdentityUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserName = userModel.UserName,
                Email = userModel.Email
            };
            var result = await _userManager.CreateAsync(user, "123Qwe.");
            if (result.Succeeded)
            {
                selectedRoles = selectedRoles ?? new string[] { };
                await _userManager.AddToRolesAsync(user, selectedRoles);
                TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kullanıcı başarıyla oluşturuldu!", "success");
                return RedirectToAction("UserList");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return RedirectToAction("UserList"); }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                if (user != null)
                {
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.UserName = userModel.UserName;
                    user.Email = userModel.Email;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        userModel.SelectedRoles = userModel.SelectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, userModel.SelectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userModel.SelectedRoles).ToArray<string>());
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarıyla düzenlenmiştir.", "success");
                        return RedirectToAction("UserList");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                    return View(userModel);
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("Hata!", "Böyle bir kullanıcı bulunamadı!", "danger");
            }
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> ChangeUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = user.Id };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
            var userPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, userPassToken, changePasswordModel.NewPassword);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
                return RedirectToAction("UserList");
            }
            return View(changePasswordModel);
        }
        #endregion


        #region RoleActions
        public async Task<IActionResult> RoleList()
        {
            var roleList = await _roleManager.Roles.ToListAsync();
            return View(roleList);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = roleModel.Name };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Role başarıyla oluşturuldu.", "success");
                    return RedirectToAction("RoleList");
                }
            }
            return View(roleModel);
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Silme Başarısız oldu!", "Bu rolde userlar bulunmaktadır, önce userları silmeniz gerekmektedir.", "danger");
                    return RedirectToAction("RoleList");
                }
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Silme işlemi tamamlandı.", "success");
            }
            return RedirectToAction("RoleList");
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var users = await _userManager.Users.ToListAsync();
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<MyIdentityUser>();
            var nonMembers = new List<MyIdentityUser>();
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            RoleDetails roleDetails = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetails);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel roleEditModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                foreach (var userId in roleEditModel.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return Redirect($"/Admin/RoleEdit/{roleEditModel.RoleId}");
        }
        #endregion


        public async Task<IActionResult> ArticleList()
        {
            List<Article> articles = await _articleService.GetAllArticlesAsync();
            return View(articles);
        }
        public async Task<IActionResult> UpdateIsApproved(int id)
        {
            Article article = await _articleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            _articleService.UpdateIsApproved(article);

            return RedirectToAction("ArticleList");
        }
        public async Task<IActionResult> UnapprovedArticles()
        {
            List<Article> articles = await _articleService.GetUnapprovedArticlesArticlesAsync();

            return View(articles);
        }
        
        public async Task<IActionResult> ArticleDelete(int id)
        {
            Article article = await _articleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            _articleService.Delete(article);
            return RedirectToAction("ArticleList");
        }

        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryModel categoryModel)
        {

            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    CategoryName = categoryModel.CategoryName
                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("CategoryList");
            }

            return View(categoryModel);
        }
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            CategoryModel categoryModel = new CategoryModel()
            {
                id = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return View(categoryModel);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetByIdAsync(categoryModel.id);
                if (category == null)
                {
                    return NotFound();
                }
                category.CategoryId = categoryModel.id;
                category.CategoryName = categoryModel.CategoryName;
                _categoryService.Update(category);
                return RedirectToAction("CategoryList");
            }
            return View(categoryModel);
        }
        public async Task<IActionResult> CategoryDelete(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.Delete(category);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> EditAdminInformation()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            EditAdminInformationModel editAdminInformationModel = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Thumbnail = user.Thumbnail
            };
            return View(editAdminInformationModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditAdminInformation(EditAdminInformationModel editAdminInformationModel, IFormFile file)
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
                    thumbnail = Jobs.UploadImage(file, editAdminInformationModel.UserName);
                }
                if (user != null)
                {
                    user.FirstName = editAdminInformationModel.FirstName;
                    user.LastName = editAdminInformationModel.LastName;
                    user.Email = editAdminInformationModel.Email;
                    user.UserName = editAdminInformationModel.UserName;
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
            return View(editAdminInformationModel);
        }

        public async Task<IActionResult> ChangeAdminPassword()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = user.Id };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeAdminPassword(ChangePasswordModel changePasswordModel)
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
