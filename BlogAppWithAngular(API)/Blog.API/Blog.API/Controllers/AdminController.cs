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

        public AdminController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

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

        //[HttpPost]
        //public async Task<IActionResult> CreateArticle([FromForm] ArticleCreateDTO createArticleDto)
        //{
        //    // Resmi kaydet ve dosya adını al
        //    string imageUrl = null;
        //    if (createArticleDto.Image != null)
        //    {
        //        imageUrl = await _articleService.SaveImageAsync(createArticleDto.Image);
        //    }

        //    // Article oluştur
        //    var article = new Article
        //    {
        //        Title = createArticleDto.Title,
        //        Content = createArticleDto.Content,
        //        CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
        //        ViewsCount = 0,
        //        Score = null,
        //        ScoreCount = 0,
        //        IsApproved = false,
        //        ImageUrl = imageUrl,
        //    };

        //    // Article ve kategorileri kullanarak Article ve ArticleCategory nesnelerini kaydet
        //    var createdArticle = await _articleService.CreateArticleAsync(article, createArticleDto.CategoryIds.ToArray());

        //    return Ok();
        //}

        [HttpPost]
        [Route("CreateArticle")]
        public async Task<IActionResult> CreateArticle([FromForm] ArticleCreateDTO createArticleDto)
        {
            // Resmi kaydet ve dosya adını al
            string imageUrl = null;
            if (createArticleDto.Image != null)
            {
                imageUrl = await _articleService.SaveImageAsync(createArticleDto.Image);
            }

            // Article oluştur
            var article = new Article
            {
                Title = createArticleDto.Title,
                Content = createArticleDto.Content,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ViewsCount = 0,
                Score = null,
                ScoreCount = null,
                IsApproved = false,
                ImageUrl = imageUrl,
            };

            // Article ve kategorileri kullanarak Article ve ArticleCategory nesnelerini kaydet
            var createdArticle = await _articleService.CreateArticleAsync(article, createArticleDto.CategoryIds.ToArray());

            var articleListDTO = new ArticleListDTO()
            {
                ArticleId = createdArticle.ArticleId,
                Title = createdArticle.Title,
                CreateDate = createdArticle.CreateDate,
                ViewsCount = createdArticle.ViewsCount,
                Score = createdArticle.Score,
                ImageUrl = createdArticle.ImageUrl
            };

            return Ok(articleListDTO);
        }




































        //[HttpPost]
        //[Route("SaveArticlePictures")]
        //public async Task<IActionResult> SaveArticlePictures(IFormFile imageUrl)
        //{
        //    var fileName=Guid.NewGuid().ToString()+Path.GetExtension(imageUrl.FileName);
        //    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/articlePicture", fileName);

        //    using(var stream=new FileStream(path, FileMode.Create))
        //    {
        //        await imageUrl.CopyToAsync(stream);
        //    };

        //    var result = new
        //    {
        //        path = "https://" + Request.Host + "/articlePicture/" + fileName
        //    };
        //    return Ok(result);
        //}

















        //[HttpPost]
        //[Route("CreateArticle")]
        //public async Task<IActionResult> CreateArticle([FromBody] ArticleCreateDTO articleDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var article = new Article
        //    {
        //        Title = articleDto.Title,
        //        Content = articleDto.Content,
        //        CreateDate = DateTime.UtcNow.ToString(),
        //        ViewsCount = 0,
        //        Score = null,
        //        ScoreCount = null,
        //        IsApproved = false,
        //        ImageUrl = null
        //    };

        //    foreach (var categoryId in articleDto.CategoryIds)
        //    {
        //        var category = await _categoryService.GetByIdAsync(categoryId);
        //        if (category == null)
        //        {
        //            return BadRequest($"Category with id {categoryId} not found.");
        //        }
        //        article.ArticleCategories = new List<ArticleCategory>();
        //        article.ArticleCategories.Add(new ArticleCategory
        //        {
        //            Article = article,
        //            Category = category
        //        });
        //    }

        //    await _articleService.CreateAsync(article, articleDto.CategoryIds);

        //    return Ok();
        //}










    }
}
