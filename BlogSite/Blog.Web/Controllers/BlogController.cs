using Blog.Business.Abstract;
using Blog.Entity;
using Blog.Web.Identity;
using Blog.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        private IArticleService _articleService;
        private ICommentService _commentService;


        public BlogController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }
        public async Task<IActionResult> ArticleDetails(int id)
        {
            
            var article = await _articleService.GetArticleDetailsAsync(id);
            var comments = await _commentService.GetCommentsByArticleAsync(id);
            _articleService.IncreaseViewsCount(id);
            ArticleDetailModel articleDetailModel = new()
            {
                Article = article,
                Comments = comments,
                Categories = article.ArticleCategories.Select(ac => ac.Category).ToList()
            };

            return View(articleDetailModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ArticleDetails(CreateCommentModel createCommentModel, int id, int star)
        {

            Comment comment = new()
            {
                Name = createCommentModel.Name,
                Text = createCommentModel.Text,
                ArticleId = id,
                CommentDate = DateTime.Now.ToString("G")
            };

            _articleService.SendScore(star, id);


            await _commentService.CreateAsync(comment);

            return RedirectToAction("ArticleDetails");
        }
        [Authorize]
        public IActionResult CommentLike(int commentId, int articleId)
        {
            _commentService.IncreaseCommentLikeCount(commentId);
            return RedirectToAction("ArticleDetails", new { id = articleId });
        }
        [Authorize]
        public IActionResult CommentDislike(int commentId, int articleId)
        {
            _commentService.IncreaseCommentDislikeCount(commentId);
            return RedirectToAction("ArticleDetails", new { id = articleId });
        }
        public async Task<IActionResult> Search(string q)
        {
            List<Article> searchResult = await _articleService.GetSearchResultAsync(q);
            return View(searchResult);
        }
    }
}
