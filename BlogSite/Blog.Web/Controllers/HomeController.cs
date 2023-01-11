using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Blog.Web.Models;
using Blog.Business.Abstract;

namespace Blog.Web.Controllers;

public class HomeController : Controller
{
    private IArticleService _articleService;
    private ICategoryService _categoryService;

    public HomeController(IArticleService articleService, ICategoryService categoryService)
    {
        _articleService = articleService;
        _categoryService = categoryService;
    }


    public async Task<IActionResult> Index()
    {
        var articles = await _articleService.GetApprovedArticlesAsync();
        return View(articles);
    }
    public async Task<IActionResult> ArticlesByCategories(string category, int page = 1)
    {
        int pageSize = 6;
        var articles = await _articleService.GetArticlesByCategoriesAsync(category, page, pageSize);
        PageInfo pageInfo = new PageInfo()
        {
            TotalItems = _articleService.GetCountByCategory(category),
            CurrentPage = page,
            ItemsPerPage = pageSize,
            CurrentCategory = category
        };

        ArticleModel articleModel = new()
        {
            Articles = articles,
            PageInfo = pageInfo
        };
        return View(articleModel);
    }
}
