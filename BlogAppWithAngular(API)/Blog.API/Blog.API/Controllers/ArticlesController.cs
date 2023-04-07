using Blog.API.DTO;
using Blog.Business.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        private ICommentService _commentService;

        public ArticlesController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Article>>> GetApprovedArticles()
        //{
        //    var articles = await _articleService.GetApprovedArticlesAsync();

        //    var articleListDTO = new List<ArticleListDTO>();

        //    foreach (var article in articles)
        //    {
        //        articleListDTO.Add(new ArticleListDTO()
        //        {
        //            ArticleId = article.ArticleId,
        //            Title = article.Title,
        //            Content = article.Content,
        //            CreateDate = article.CreateDate,
        //            ViewsCount = article.ViewsCount,
        //            ScoreCount = article.ScoreCount,
        //            ImageUrl = article.ImageUrl,
        //            CommentCount = article.Comments.Count()
        //        });
        //    }
        //    return Ok(articleListDTO);
        //}

        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult<List<Article>>> GetApprovedArticles(int page = 1, int pageSize = 7)
        {
            var approvedArticles = await _articleService.GetApprovedArticlesAsync();
            int totalCount = approvedArticles.Count();


            var articles = await _articleService.GetListArticlesAsync(page, pageSize);
            var articleListDTO = new List<ArticleListDTO>();

            foreach (var article in articles)
            {
                articleListDTO.Add(new ArticleListDTO()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    Content = article.Content,
                    CreateDate = article.CreateDate,
                    ViewsCount = article.ViewsCount,
                    ScoreCount = article.ScoreCount,
                    Score = article.Score,
                    ImageUrl = article.ImageUrl,
                    CommentCount = article.Comments.Count()
                });
            }
            var result = new
            {
                TotalCount = totalCount,
                Articles = articleListDTO
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleDetails(int id)
        {

            var article = await _articleService.GetArticleDetailsAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            _articleService.IncreaseViewsCount(id);
            ArticleDetailDTO articleDetailDTO = new()
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                CreateDate = article.CreateDate,
                ViewsCount = article.ViewsCount,
                Score = article.Score,
                ScoreCount = article.ScoreCount,
                IsApproved = article.IsApproved,
                ImageUrl = article.ImageUrl,
                CommentCount = article.Comments.Count()
            };
            return Ok(articleDetailDTO);
        }

        [HttpGet]
        [Route("GetArticleWithCategory/{categoryId}/{page}/{pageSize}")]
        public async Task<ActionResult<List<Article>>> GetArticleWithCategory(int categoryId, int page = 1, int pageSize = 7)
        {
            var articleWithCategoryCount = _articleService.GetCountByCategory(categoryId);
            var articleWithCategory = await _articleService.GetArticleWithCategoryAsync(categoryId, page, pageSize);

            var articleWithCategoryDTO = new List<ArticleWithCategoryDTO>();

            foreach (var article in articleWithCategory)
            {
                articleWithCategoryDTO.Add(new ArticleWithCategoryDTO()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    Content = article.Content,
                    CreateDate = article.CreateDate,
                    ViewsCount = article.ViewsCount,
                    ScoreCount = article.ScoreCount,
                    Score = article.Score,
                    ImageUrl = article.ImageUrl,
                    CommentCount = article.Comments != null ? article.Comments.Count() : 0
                });
            }
            var result = new
            {
                TotalCount = articleWithCategoryCount,
                Articles = articleWithCategoryDTO
            };
            return Ok(result);
        }
        [HttpGet]
        [Route("Search/{searchText}/{page}/{pageSize}")]
        public async Task<ActionResult<List<Article>>> Search(string searchText, int page = 1, int pageSize = 7)
        {

            var articles= await _articleService.GetSearchResultAsync(searchText, page, pageSize);
            var articlesCount = _articleService.GetArticleSearchCount(searchText);
            var articleWithCategoryDTO = new List<ArticleWithCategoryDTO>();

            foreach (var article in articles)
            {
                articleWithCategoryDTO.Add(new ArticleWithCategoryDTO()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    Content = article.Content,
                    CreateDate = article.CreateDate,
                    ViewsCount = article.ViewsCount,
                    ScoreCount = article.ScoreCount,
                    Score = article.Score,
                    ImageUrl = article.ImageUrl,
                    CommentCount = article.Comments != null ? article.Comments.Count() : 0
                });
            }
            var result = new
            {
                TotalCount = articlesCount,
                Articles = articleWithCategoryDTO
            };
            return Ok(result);

        }
        [HttpGet]
        [Route("GetArticlesByMostView")]
        public async Task<ActionResult<List<Article>>> GetArticlesByMostView()
        {
            var articles =await _articleService.MostViewedArticlesAsync();
            var articlesByMostViewDTO = new List<ArticlesByMostViewDTO>();

            foreach (var article in articles)
            {
                articlesByMostViewDTO.Add(new ArticlesByMostViewDTO()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    ViewsCount = article.ViewsCount,
                    ImageUrl = article.ImageUrl
                });
            }
            return Ok(articlesByMostViewDTO);
        }
        [HttpGet]
        [Route("GetHighScoresArticles")]
        public async Task<ActionResult<List<Article>>> GetHighScoresArticles()
        {
            var articles = await _articleService.HighScoresArticlesAsync();
            var highScoresArticlesDTO = new List<HighScoresArticlesDTO>();

            foreach (var article in articles)
            {
                highScoresArticlesDTO.Add(new HighScoresArticlesDTO()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    Score = article.Score,
                    ImageUrl = article.ImageUrl
                });
            }
            return Ok(highScoresArticlesDTO);

        }


    }
}
