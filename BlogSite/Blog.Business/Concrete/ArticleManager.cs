using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Abstract;
using Blog.Data.Abstract;
using Blog.Entity;

namespace Blog.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleManager(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<List<Article>> ArticlesByWriterAsync(int writerId)
        {
            return await _articleRepository.ArticlesByWriterAsync(writerId);
        }

        public Task CreateAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Article article, int[] categoryIds)
        {
            await _articleRepository.CreateAsync(article, categoryIds);
        }

        public void Delete(Article article)
        {
            _articleRepository.Delete(article);
        }

        public Task<List<Article>> GetAllArticlesAsync()
        {
            return _articleRepository.GetAllArticlesAsync();
        }

        public Task<List<Article>> GetAllAsync()
        {
            return _articleRepository.GetAllAsync();
        }

        public Task<List<Article>> GetApprovedArticlesAsync()
        {
            return _articleRepository.GetApprovedArticlesAsync();
        }

        public Task<Article> GetArticleDetailsAsync(int id)
        {
            return _articleRepository.GetArticleDetailsAsync(id);
        }

        public Task<List<Article>> GetArticlesByCategoriesAsync(string category, int page, int pageSize)
        {
            return _articleRepository.GetArticlesByCategoriesAsync(category, page, pageSize);
        }

        public async Task<Article> GetArticleWithCategoriesAsync(int id)
        {
            return await _articleRepository.GetArticleWithCategoriesAsync(id);
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _articleRepository.GetByIdAsync(id);
        }

        public int GetCountByCategory(string category)
        {
            return _articleRepository.GetCountByCategory(category);
        }

        public Task<List<Article>> GetSearchResultAsync(string searchString)
        {
            return _articleRepository.GetSearchResultAsync(searchString);
        }

        public async Task<List<Article>> GetUnapprovedArticlesArticlesAsync()
        {
            return await _articleRepository.GetUnapprovedArticlesArticlesAsync();
        }

        public Task<List<Article>> HighScoresArticlesAsync()
        {
            return _articleRepository.HighScoresArticlesAsync();
        }

        public void IncreaseViewsCount(int id)
        {
            _articleRepository.IncreaseViewsCount(id);
        }

        public Task<List<Article>> MostViewedArticlesAsync()
        {
            return _articleRepository.MostViewedArticlesAsync();
        }

        public void SendScore(int score, int id)
        {
            _articleRepository.SendScore(score, id);
        }

        public void Update(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Article article, int[] categoryIds)
        {
            await _articleRepository.UpdateAsync(article, categoryIds);
        }

        public void UpdateIsApproved(Article article)
        {
            _articleRepository.UpdateIsApproved(article);
        }
    }
}