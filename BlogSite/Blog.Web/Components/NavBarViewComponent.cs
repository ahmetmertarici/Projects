using Blog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        public readonly ICategoryService _categoryService;

        public NavBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["category"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["category"];
            }

            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
