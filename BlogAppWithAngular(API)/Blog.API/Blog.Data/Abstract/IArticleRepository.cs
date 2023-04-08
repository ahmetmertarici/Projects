using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;
using Microsoft.AspNetCore.Http;

namespace Blog.Data.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<List<Article>> GetApprovedArticlesAsync();
        Task<List<Article>> MostViewedArticlesAsync();
        Task<List<Article>> HighScoresArticlesAsync();
        Task<Article> GetArticleDetailsAsync(int id);
        Task<List<Article>> GetArticlesByCategoriesAsync(string category, int page, int pageSize);
        Task<List<Article>> GetSearchResultAsync(string searchText, int page , int pageSize );
        int GetCountByCategory(int categoryId);
        int GetArticleSearchCount(string searchText);
        
        void IncreaseViewsCount(int id);
        void SendScore(int score, int id);
        void UpdateIsApproved(Article article);
        Task<List<Article>> GetAllArticlesAsync();
        Task CreateAsync(Article article, int[] categoryIds);
        Task<Article> GetArticleWithCategoriesAsync(int id);
        Task<List<Article>> GetUnapprovedArticlesArticlesAsync();
        Task UpdateAsync(Article article, int[] categoryIds);


        Task<List<Article>> GetListArticlesAsync(int page, int pageSize);
        Task<List<Article>> GetArticleWithCategoryAsync(int categoryId, int page, int pageSize);

        Task<Article> CreateArticleAsync(Article article, int[] categoryIds);
        Task<string> SaveImageAsync(IFormFile image);
        Task<Article> UpdateArticleAsync(int articleId, string title, string content, string imageUrl, int[] categoryIds);

    }
}