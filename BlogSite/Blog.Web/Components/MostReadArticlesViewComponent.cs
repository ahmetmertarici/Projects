using Blog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Components
{
    public class MostReadArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public MostReadArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mostReadArticles = await _articleService.MostViewedArticlesAsync();
            return View(mostReadArticles);
        }

    }
}
