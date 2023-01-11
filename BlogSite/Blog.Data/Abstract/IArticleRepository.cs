using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Data.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
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
        Task<List<Article>> GetAllArticlesAsync();
        Task CreateAsync(Article article, int[] categoryIds);
        Task<List<Article>> ArticlesByWriterAsync(int writerId);
        Task<Article> GetArticleWithCategoriesAsync(int id);
        Task<List<Article>> GetUnapprovedArticlesArticlesAsync();
        Task UpdateAsync(Article article, int[] categoryIds);


    }
}