using Blog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Components
{
    public class HighScoresArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public HighScoresArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var highScoresArticles = await _articleService.HighScoresArticlesAsync();
            return View(highScoresArticles);
        }
    }
}
