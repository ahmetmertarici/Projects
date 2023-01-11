using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Business.Abstract
{
    public interface IArticleService
    {
        #region Generics
        Task CreateAsync(Article article);
        Task<Article> GetByIdAsync(int id);
        Task<List<Article>> GetAllAsync();
        void Update(Article article);
        void Delete(Article article);
        #endregion
        Task<List<Article>> GetAllArticlesAsync();
        Task<List<Article>> GetApprovedArticlesAsync();
        Task<List<Article>> MostViewedArticlesAsync();
        Task<List<Article>> HighScoresArticlesAsync();
        Task<Article> GetArticleDetailsAsync(int id);
        Task<List<Article>> GetArticlesByCategoriesAsync(string category, int page, int pageSize);
        Task<List<Article>> GetSearchResultAsync(string searchString);
        int GetCountByCategory(string category);
        void IncreaseViewsCount(int id);
        void SendScore(int score, int id);
        void UpdateIsApproved(Article article);
        Task CreateAsync(Article article, int[] categoryIds);
        Task<List<Article>> ArticlesByWriterAsync(int writerId);
        Task<Article> GetArticleWithCategoriesAsync(int id);
        Task UpdateAsync(Article article, int[] categoryIds);
        Task<List<Article>> GetUnapprovedArticlesArticlesAsync();

    }
}