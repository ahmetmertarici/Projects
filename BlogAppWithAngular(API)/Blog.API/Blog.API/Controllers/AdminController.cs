﻿using Blog.API.DTO;
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
    }
}
