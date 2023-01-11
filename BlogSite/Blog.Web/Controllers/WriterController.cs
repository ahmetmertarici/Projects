using Blog.Business.Abstract;
using Blog.Core;
using Blog.Entity;
using Blog.Web.Identity;
using Blog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class WriterController : Controller
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private IWriterService _writerService;
        private readonly UserManager<MyIdentityUser> _userManager;

        public WriterController(IArticleService articleService, UserManager<MyIdentityUser> userManager, ICategoryService categoryService, IWriterService writerService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public async Task<IActionResult> ArticleCreate()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            CreateArticleModel createArticleModel = new CreateArticleModel();
            return View(createArticleModel);
        }
        [HttpPost]
        public async Task<IActionResult> ArticleCreate(CreateArticleModel createArticleModel, int[] categoryIds, IFormFile file)
        {

            var username = User.Identity.Name;
            var email = _userManager.Users.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            var writerId = _writerService.GetWriterId(email);


            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                createArticleModel.ImageUrl = Jobs.UploadImage(file, createArticleModel.Title);
                Article article = new()
                {
                    Title = createArticleModel.Title,
                    Content = createArticleModel.Content,
                    IsApproved = false,
                    ImageUrl = createArticleModel.ImageUrl,
                    CreateDate = DateTime.Now.ToString("G"),
                    ViewsCount = 0,
                    WriterId = writerId
                };
                await _articleService.CreateAsync(article, categoryIds);
                TempData["AlertMessage"] = Jobs.CreateMessage("Add Article", "Article is ok!", "success");
                return RedirectToAction("ManageAccount", "Account");
            }

            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Choose category!";
            }
            else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }

            if (file == null)
            {
                ViewBag.ImageErrorMessage = "Choose an image!";
            }
            ViewBag.Categories = _categoryService.GetAllAsync();
            return View(createArticleModel);
        }
        public async Task<IActionResult> ArticleDelete(int id)
        {
            Article article = await _articleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            _articleService.Delete(article);
            return RedirectToAction("ManageAccount", "Account");
        }

        public async Task<IActionResult> ArticleDetailsEdit(int id)
        {
            var article = await _articleService.GetArticleWithCategoriesAsync(id);
            ArticleWithCategoriesModel articleWithCategoriesModel = new()
            {
                id=article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                ImageUrl = article.ImageUrl,
                SelectedCategories = article
                    .ArticleCategories
                    .Select(ac=>ac.Category)
                    .ToList()
            };
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(articleWithCategoriesModel);
        }
        [HttpPost]
        public async Task<IActionResult> ArticleDetailsEdit(ArticleWithCategoriesModel articleWithCategoriesModel, IFormFile file, int[] categoryIds)
        {
            string imageUrl = "";
            if (ModelState.IsValid && categoryIds.Length > 0)
            {
                var article = await _articleService.GetByIdAsync(articleWithCategoriesModel.id);
                if (file == null)
                {
                    imageUrl = article.ImageUrl;
                }
                else
                {
                    imageUrl = Jobs.UploadImage(file, articleWithCategoriesModel.Title);
                }
                if (article == null)
                {
                    return NotFound();
                }
                article.Title = articleWithCategoriesModel.Title;
                article.Content = articleWithCategoriesModel.Content;
                article.IsApproved = false;
                article.ImageUrl = imageUrl;

                await _articleService.UpdateAsync(article, categoryIds);
                return RedirectToAction("ManageAccount", "Account");
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Choose a category!";
            }
            else
            {
                articleWithCategoriesModel.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    CategoryId = catId,
                }).ToList();
            }
            ViewBag.Categories = await _categoryService.GetAllAsync();
            return View(articleWithCategoriesModel);
        }

        public async Task<IActionResult> EditWriterInformation()
        {
            var username = User.Identity.Name;
            var writerinformation = await _writerService.GetTheWriterAsync(username);

            EditWriterInformationModel editWriterInformationModel = new()
            {
                WriterId = writerinformation.WriterId,
                WriterName = writerinformation.WriterName,
                WriterSurname = writerinformation.WriterSurname,
                Mail = writerinformation.Mail,
                Nickname = writerinformation.Nickname,
                Thumbnail = writerinformation.Thumbnail
            };
            return View(editWriterInformationModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditWriterInformation(EditWriterInformationModel editWriterInformationModel, IFormFile file)
        {
            string thumbnail = ""; 
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var writer = await _writerService.GetTheWriterAsync(username);
                if (file == null)
                {
                    thumbnail = writer.Thumbnail;
                }
                else
                {
                    thumbnail = Jobs.UploadImage(file, editWriterInformationModel.Nickname);
                }
                writer.WriterSurname= editWriterInformationModel.WriterSurname;
                writer.WriterName= editWriterInformationModel.WriterName;
                writer.Nickname= editWriterInformationModel.Nickname;
                writer.Mail= editWriterInformationModel.Mail;
                writer.Thumbnail=thumbnail;


                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user != null)
                {
                    user.FirstName = editWriterInformationModel.WriterName;
                    user.LastName = editWriterInformationModel.WriterSurname;
                    user.UserName = editWriterInformationModel.Nickname;
                    user.Email = editWriterInformationModel.Mail;
                    user.Thumbnail= thumbnail;
                    var result = await _userManager.UpdateAsync(user);
                    _writerService.Update(writer);

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
            return View(editWriterInformationModel);
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
