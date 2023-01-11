using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Concrete.EfCore
{
    public class EfCoreArticleRepository : EfCoreGenericRepository<Article>, IArticleRepository
    {
        public EfCoreArticleRepository(BlogContext _dbContext) : base(_dbContext)
        {

        }

        private BlogContext context
        {
            get { return _dbContext as BlogContext; }
        }

        public Task<List<Article>> ArticlesByWriterAsync(int writerId)
        {
            return context
                .Articles
                .Where(a => a.WriterId == writerId)
                .ToListAsync();
        }

        public async Task CreateAsync(Article article, int[] categoryIds)
        {
            await context.Articles.AddAsync(article);
            await context.SaveChangesAsync();

            article.ArticleCategories = categoryIds
                .Select(catId => new ArticleCategory()
                {
                    ArticleId = article.ArticleId,
                    CategoryId = catId
                }).ToList();
            context.SaveChangesAsync();
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await context
                .Articles
                .Include(a => a.Writer)
                .ToListAsync();
        }

        public async Task<List<Article>> GetApprovedArticlesAsync()
        {
            return await context
                .Articles
                .Where(a => a.IsApproved == true)
                .OrderByDescending(a => a.CreateDate)
                .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
                .ToListAsync();
        }

        public async Task<Article> GetArticleDetailsAsync(int id)
        {
            return await context
                .Articles
                .Where(a => a.ArticleId == id)
                .Include(a => a.Writer)
                .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Article>> GetArticlesByCategoriesAsync(string category, int page, int pageSize)
        {
            var articles = context.Articles.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                articles = articles
                    .Where(p => p.IsApproved == true)
                    .Include(p => p.ArticleCategories)
                    .ThenInclude(pc => pc.Category)
                    .Where(p => p.ArticleCategories.Any(pc => pc.Category.CategoryName == category))
                    .OrderByDescending(a => a.CreateDate);
            };

            return await articles
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Article> GetArticleWithCategoriesAsync(int id)
        {
            return await context
                .Articles
                .Where(a => a.ArticleId == id)
                .Include(a => a.ArticleCategories)
                .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync();
        }

        public int GetCountByCategory(string category)
        {
            return context
                .Articles
                .Where(a => a.IsApproved == true)
                .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
                .Where(a => a.ArticleCategories.Any(ac => ac.Category.CategoryName == category))
                .Count();
        }

        public async Task<List<Article>> GetSearchResultAsync(string searchString)
        {
            return await context
                .Articles
                .Where(p => p.IsApproved == true && (p.Title.ToLower().Contains(searchString.ToLower()) || p.Content.ToLower().Contains(searchString.ToLower()) || p.Writer.Nickname.ToLower().Contains(searchString.ToLower())))
                .ToListAsync();
        }

        public async Task<List<Article>> GetUnapprovedArticlesArticlesAsync()
        {
            return await context
                .Articles
                .Where(a => a.IsApproved == false)
                .Include(a => a.Writer)
                .ToListAsync();
        }

        public async Task<List<Article>> HighScoresArticlesAsync()
        {
            return await context
                .Articles
                .Where(a=>a.IsApproved==true)
                .OrderByDescending(a => a.Score)
                .Take(5)
                .ToListAsync();
        }

        public void IncreaseViewsCount(int id)
        {
            var article = context.Articles
                .FirstOrDefault(a => a.ArticleId == id);
            article.ViewsCount++;
            context.Update(article);
            context.SaveChanges();
        }

        public async Task<List<Article>> MostViewedArticlesAsync()
        {
            return await context
                .Articles
                .Where(a => a.IsApproved == true)
                .OrderByDescending(a => a.ViewsCount)
                .Take(5)
                .ToListAsync();
        }

        public void SendScore(int score, int id)
        {
            var article = context.Articles
                .FirstOrDefault(a => a.ArticleId == id);
            if (article.ScoreCount == null)
            {
                article.ScoreCount = 1;
                article.Score = score;
            }
            else
            {
                article.ScoreCount++;
                article.Score = (((article.Score * (article.ScoreCount - 1)) + score) / article.ScoreCount);
            }
            context.Update(article);
            context.SaveChanges();
        }

        public async Task UpdateAsync(Article article, int[] categoryIds)
        {
            var newArticle = await context
                .Articles
                .Include(a => a.ArticleCategories)
                .FirstOrDefaultAsync(a => a.ArticleId == article.ArticleId);

            newArticle.Title = article.Title;
            newArticle.Content = article.Content;
            newArticle.ImageUrl = article.ImageUrl;
            newArticle.IsApproved = article.IsApproved;
            newArticle.ArticleCategories = categoryIds
                .Select(catId => new ArticleCategory()
                {
                    ArticleId = article.ArticleId,
                    CategoryId = catId
                }).ToList();
            context.Update(newArticle);
            context.SaveChanges();
        }

        public void UpdateIsApproved(Article article)
        {
            if (article.IsApproved)
            {
                article.IsApproved = false;
            }
            else
            {
                article.IsApproved = true;
            };
            context.Entry(article).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}