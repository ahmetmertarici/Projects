using Blog.API.DTO;
using Blog.Business.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private ICommentService _commentService;

        public AdminController(IArticleService articleService, ICategoryService categoryService, ICommentService commentService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        //Article related actions
        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetAllArticles()
        {
            var articles = await _articleService.GetAllAsync();
            var articleListDTO = new List<AdminArticleListDTO>();
            foreach (var article in articles)
            {
                articleListDTO.Add(new AdminArticleListDTO()
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    CreateDate = article.CreateDate,
                    ViewsCount = article.ViewsCount,
                    Score = article.Score,
                    ImageUrl = article.ImageUrl,
                    IsApproved = article.IsApproved


                });
            }
            return Ok(articleListDTO);
        }

        [HttpGet("GetArticle/{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _articleService.GetArticleDetailsAsync(id);

            if (article == null)
            {
                return NotFound();
            }

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
                CommentCount = article.Comments.Count(),
                CategoryIds = article.ArticleCategories.Select(ac => ac.CategoryId).ToList()
            };
            return Ok(articleDetailDTO);
        }

        [HttpPost]
        [Route("SaveArticlePicture")]
        public async Task<IActionResult> SaveArticlePicture(IFormFile image)
        {
            var imageUrl = await _articleService.SaveImageAsync(image);
            var result = new
            {
                path = "https://" + Request.Host + "/images/" + imageUrl
            };
            return Ok(result);
        }
        
        [HttpPost]
        [Route("CreateArticle")]
        public async Task<IActionResult> CreateArticle([FromForm] ArticleCreateDTO createArticleDto)
        {
            // Article oluştur
            var article = new Article
            {
                Title = createArticleDto.Title,
                Content = createArticleDto.Content,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ViewsCount = 0,
                ImageUrl = createArticleDto.ImageUrl,
                Score = null,
                ScoreCount = null,
                IsApproved = false
            };

            // Article ve kategorileri kullanarak Article ve ArticleCategory nesnelerini kaydet
            var createdArticle = await _articleService.CreateArticleAsync(article, createArticleDto.CategoryIds.ToArray());

            var articleListDTO = new ArticleListDTO()
            {
                ArticleId = createdArticle.ArticleId,
                Title = createdArticle.Title,
                CreateDate = createdArticle.CreateDate,
                ViewsCount = createdArticle.ViewsCount,
                Score = createdArticle.Score
            };

            return Ok(articleListDTO);
        }
       
        [HttpPost]
        [Route("UpdateIsApproved/{id}")]
        public async Task<IActionResult> UpdateIsApproved(int id)
        {
            Article article = await _articleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            _articleService.UpdateIsApproved(article);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateArticle/{articleId}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] int articleId, [FromForm] ArticleUpdateDTO updateArticleDto)
        {

            var imageUrl = string.IsNullOrEmpty(updateArticleDto.ImageUrl) ? null : updateArticleDto.ImageUrl;
            // Article ve kategorileri kullanarak Article ve ArticleCategory nesnelerini güncelle
            var updatedArticle = await _articleService.UpdateArticleAsync(articleId, updateArticleDto.Title, updateArticleDto.Content, imageUrl, updateArticleDto.CategoryIds);

            var articleListDTO = new ArticleListDTO()
            {
                ArticleId = articleId,
                Title = updatedArticle.Title,
                CreateDate = updatedArticle.CreateDate,
                ViewsCount = updatedArticle.ViewsCount,
                Score = updatedArticle.Score,
                ImageUrl = updatedArticle.ImageUrl
            };

            return Ok(articleListDTO);
        }

        [HttpDelete]
        [Route("DeleteArticle/{articleId}")]
        public async Task<IActionResult> DeleteArticle(int articleId)
        {
            Article article = await _articleService.GetByIdAsync(articleId);
            if (article == null)
            {
                return BadRequest();
            }
            _articleService.Delete(article);
            return Ok();
        }


        //Category related actions
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryCreateDTO categoryCreateDTO)
        {
            // Category oluştur
            var newCategory = new Category
            {
                CategoryName= categoryCreateDTO.CategoryName
            };

            await _categoryService.CreateAsync(newCategory);

            return Ok();
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return BadRequest();
            }

            CategoryCreateDTO categoryDTO = new()
            {
                CategoryName=category.CategoryName
            };
            return Ok(categoryDTO);
        }

        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromForm] CategoryCreateDTO categoryDTO)
        {
            var updatedArticle = await _categoryService.UpdateCategoryAsync(categoryId, categoryDTO.CategoryName);

            return Ok(updatedArticle);
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            Category category = await _categoryService.GetByIdAsync(categoryId);
            if (category == null)
            {
                return BadRequest();
            }
            _categoryService.Delete(category);
            return Ok();
        }

        [HttpGet]
        [Route("Statistics")]
        public async Task<IActionResult> Statistics()
        {
            int articlesCount =await _articleService.GetArticlesCountAsync();
            int categoriesCount = await _categoryService.GetCategoriesCountAsync();
            int commentsCount = await _commentService.GetCommentsCountAsync();

            var statistics = new StatisticsDTO()
            {
                ArticlesCount= articlesCount,
                CategoriesCount= categoriesCount,
                CommentsCount= commentsCount
            };

            return Ok(statistics);
        }







    }
}




