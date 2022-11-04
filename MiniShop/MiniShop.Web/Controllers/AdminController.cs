using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniShop.Business.Abstract;
using MiniShop.Core;
using MiniShop.Entity;
using MiniShop.Web.Identity;
using MiniShop.Web.Models;

namespace MiniShop.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(IProductService productService, ICategoryService categoryService, UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region RolesActions
        public async Task<IActionResult> RoleList()
        {
            return View(await _roleManager.Roles.ToListAsync());
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
                #region UzunYol
                //if (await _userManager.IsInRoleAsync(user, role.Name))
                //{
                //    members.Add(user);
                //}
                //else
                //{
                //    nonMembers.Add(user);
                //}
                #endregion
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
                //Seçili role eklenecek userlar
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user!=null)
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

                //Seçili rolden çıkarılacak userlar
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
        #endregion

        #region UserActions
        public async Task<IActionResult> UserList()
        {
            return View(await _userManager.Users.ToListAsync());
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
            //List<string> roles = null;
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles);
                    TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kullanıcı başarıyla oluşturuldu!","success");
                    return RedirectToAction("UserList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user==null) { return RedirectToAction("UserList"); }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
            ViewBag.Roles= await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                if (user!=null)
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
            //var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
            //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePasswordModel.NewPassword);
            //var result = await _userManager.UpdateAsync(user);
            //if (result.Succeeded)
            //{
            //    TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
            //    return RedirectToAction("UserList");
            //}
            //return View(changePasswordModel);

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


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductList(bool isDeleted=false)
        {
            var products = await _productService.GetAllAsync(p => p.IsDeleted == isDeleted);
            ViewBag.IsDeleted = isDeleted;
            return View(products);
        }
        public async Task<IActionResult> CategoryList(bool isDeleted=false)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(isDeleted);
            ViewBag.IsDeleted = isDeleted;
            return View(categories);
        }
        public async Task<IActionResult> ProductEdit(int id)
        {
            var product = await _productService.GetProductWithCategoriesAsync(id);
            ProductWithCategoriesModel productModel = new ProductWithCategoriesModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Properties = product.Properties,
                ImageUrl = product.ImageUrl,
                IsHome = product.IsHome,
                IsApproved = product.IsApproved,
                SelectedCategories = product
                    .ProductCategories
                    .Select(pc => pc.Category)
                    .ToList()
            };
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(productModel);
        }
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var category = await _categoryService.GetCategoryWithProductsAsync(id);
            CategoryModel categoryModel = new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = category
                    .ProductCategories
                    .Select(pc => pc.Product)
                    .ToList()
            };
            return View(categoryModel);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryModel categoryModel)
        {
            
            if (ModelState.IsValid)
            {
                string url = Jobs.MakeUrl(categoryModel.Id + categoryModel.Name);
                var category = await _categoryService.GetByIdAsync(categoryModel.Id);
                if (category==null)
                {
                    return NotFound();
                }
                category.Name=categoryModel.Name;
                category.Description = categoryModel.Description;
                category.Url = url;
                _categoryService.Update(category);
                return RedirectToAction("CategoryList");
            }
            return View(categoryModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductWithCategoriesModel productModel, IFormFile file, int[] categoryIds)
        {
            string imageUrl = "";
            string url = Jobs.MakeUrl(productModel.Name);
            if (ModelState.IsValid && categoryIds.Length > 0)
            {
                var product = await _productService.GetByIdAsync(productModel.Id);
                if (file==null)
                {
                    imageUrl = product.ImageUrl;
                }
                else
                {
                    imageUrl = Jobs.UploadImage(file, url);
                }
                if (product == null)
                {
                    return NotFound();
                }
                //efcore otomatik olarak ismin değişiğ değişmediğini kontrol eder.Değişirse yansıtır.
                product.Name = productModel.Name;
                product.Url = url;
                product.Price = productModel.Price;
                product.Properties = productModel.Properties;
                product.IsApproved = productModel.IsApproved;
                product.IsHome = productModel.IsHome;
                product.ImageUrl = imageUrl;

                await _productService.UpdateAsync(product, categoryIds);
                return RedirectToAction("ProductList");
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Choose a category!";
            }
            else
            {
                productModel.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    Id = catId,
                }).ToList();
            }
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(productModel);
        }
        public async Task<IActionResult> ProductCreate()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync(c=>c.IsDeleted==false);
            return View();
        }
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductWithCategoriesModel productModel, IFormFile file, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length>0)
            {
                var url = Jobs.MakeUrl(productModel.Id + productModel.Name);
                Product product = new Product()
                {
                    Name = productModel.Name,
                    Properties = productModel.Properties,
                    Price = productModel.Price,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(file,url),
                    IsApproved=productModel.IsApproved,
                    IsHome=productModel.IsHome
                };
                await _productService.CreateAsync(product, categoryIds);
                return RedirectToAction("ProductList");
            }
            //Buradan itibaren hata kontrolleri
            if (categoryIds.Length==0)
            {
                ViewBag.CategoryErrorMessage = "Lütfen bir kategori seç!";
            }
            else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }
            ViewBag.Categories= await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(productModel);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var url = Jobs.MakeUrl(categoryModel.Id + categoryModel.Name);
                Category category = new Category()
                {
                    Name = categoryModel.Name,
                    Description = categoryModel.Description,
                    Url=url
                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("CategoryList");
            }

            return View(categoryModel);
        }
        public async Task<IActionResult> ProductDelete(int id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product!=null)
            {
                product.IsDeleted = product.IsDeleted ? false : true;
                _productService.IsDelete(product);
            }
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> CategoryDelete(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            if (category==null)
            {
                return NotFound();
            }
            category.IsDeleted = category.IsDeleted ? false : true;
            _categoryService.IsDelete(category);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> UpdateIsHome(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.UpdateIsHomeAsync(product);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> UpdateIsApproved(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.UpdateIsApprovedAsync(product);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> ProductDeletePermanently(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            _productService.Delete(product);
            return Redirect("/Admin/ProductList?isDeleted=true");
        }
        public async Task<IActionResult> CategoryDeletePermanently(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.Delete(category);
            return Redirect("/Admin/CategoryList?isDeleted=true");
        }

    }
}