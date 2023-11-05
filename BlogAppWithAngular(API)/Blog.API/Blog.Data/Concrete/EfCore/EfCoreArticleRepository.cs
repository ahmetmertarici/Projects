using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


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

        public async Task<Article> CreateArticleAsync(Article article, int[] categoryIds)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    context.Articles.Add(article);

                    // DetectChanges metodu çaðrýlýyor
                    context.ChangeTracker.DetectChanges();

                    // Category nesneleri kaydediliyor
                    foreach (var categoryId in categoryIds)
                    {
                        var category = await context.Categories.FindAsync(categoryId);
                        if (category == null)
                        {
                            // Kategori bulunamadýysa hata fýrlat
                            throw new Exception("Category not found.");
                        }

                        var articleCategory = new ArticleCategory
                        {
                            Article = article,
                            Category = category
                        };

                        context.ArticleCategories.Add(articleCategory);
                    }

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return article;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public async Task<string> SaveImageAsync(IFormFile image)
        {

            var fileName=Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
           return fileName;
        }

        public async Task CreateAsync(Article article)
        {
            await context.Articles.AddAsync(article);
            await context.SaveChangesAsync();

            article.ArticleCategories = article.ArticleCategories
                .Select(ac => new ArticleCategory
                {
                    ArticleId = article.ArticleId,
                    CategoryId = ac.CategoryId
                }).ToList();

            await context.ArticleCategories.AddRangeAsync(article.ArticleCategories);
            await context.SaveChangesAsync();
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
                .Include(a=>a.ArticleCategories)
                .ThenInclude(ac=>ac.Category)
                .ToListAsync();
        }

        public async Task<List<Article>> GetApprovedArticlesAsync()
        {
            var result = await context
                .Articles
                .Where(a => a.IsApproved == true)
                .Include(a=>a.Comments)
                .OrderByDescending(a => a.CreateDate)
                .ToListAsync();

            return result;
        }


        public async Task<Article> GetArticleDetailsAsync(int id)
        {
            return await context
                .Articles
                .Where(a => a.ArticleId == id)
                .Include(a=>a.Comments)
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

        public  int GetArticleSearchCount(string searchText)
        {
            return context
                .Articles
                .Where(p => p.IsApproved == true && (p.Title.ToLower().Contains(searchText.ToLower()) || p.Content.ToLower().Contains(searchText.ToLower())))
                .Count();
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

        public async Task<List<Article>> GetArticleWithCategoryAsync(int categoryId, int page, int pageSize)
        {
            var articles = context.Articles.AsQueryable();
                articles = articles
                    .Where(p => p.IsApproved == true)
                    .Include(p=>p.Comments)
                    .Include(p => p.ArticleCategories)
                    .ThenInclude(pc => pc.Category)
                    .Where(p => p.ArticleCategories.Any(pc => pc.Category.CategoryId == categoryId))
                    .OrderByDescending(a => a.CreateDate);

            return await articles
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public int GetCountByCategory(int categoryId)
        {
            return context
                .Articles
                .Where(a => a.IsApproved == true)
                .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
                .Where(a => a.ArticleCategories.Any(ac => ac.Category.CategoryId == categoryId))
                .Count();
        }

        public async Task<List<Article>> GetListArticlesAsync(int page, int pageSize)
        {
            var articles = context.Articles.AsQueryable();
            articles = articles
                    .Where(p => p.IsApproved == true)
                    .Include(p => p.ArticleCategories)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(a => a.CreateDate);

            return await articles
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
        }

        public async Task<List<Article>> GetSearchResultAsync(string searchText, int page, int pageSize)
        {
            var articles = context.Articles.AsQueryable();
            articles = articles
                .Include(a=>a.Comments)
                .Where(p => p.IsApproved == true && (p.Title.ToLower().Contains(searchText.ToLower()) || p.Content.ToLower().Contains(searchText.ToLower())));

            return await articles
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

           
        }

        public async Task<List<Article>> GetUnapprovedArticlesArticlesAsync()
        {
            return await context
                .Articles
                .Where(a => a.IsApproved == false)
                .ToListAsync();
        }

        public async Task<List<Article>> HighScoresArticlesAsync()
        {
            return await context
                .Articles
                .Where(a=>a.IsApproved==true)
                .OrderByDescending(a => a.Score)
                .Take(5)
                .Select(a => new Article
                {
                    Title = a.Title,
                    ArticleId = a.ArticleId,
                    ImageUrl = a.ImageUrl,
                    Score = a.Score
                })
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
                .Select(a => new Article
                {
                    Title = a.Title,
                    ArticleId = a.ArticleId,
                    ImageUrl = a.ImageUrl,
                    ViewsCount=a.ViewsCount
                })
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

        public async Task<Article> UpdateArticleAsync(int articleId, string title, string content, string imageUrl, int[] categoryIds, DateTime? publishDate)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Article bul
                    var article = await context.Articles.FindAsync(articleId);
                    if (article == null)
                    {
                        throw new Exception("Article not found.");
                    }

                    // Article güncelle
                    article.Title = title;
                    article.Content = content;
                    if (imageUrl != null)
                    {
                        article.ImageUrl = imageUrl;
                    }
                    article.PublishDate = publishDate;

                    // Eski ArticleCategory nesnelerini sil
                    var existingArticleCategories = context.ArticleCategories.Where(ac => ac.ArticleId == articleId);
                    context.ArticleCategories.RemoveRange(existingArticleCategories);

                    // Yeni ArticleCategory nesneleri ekle
                    foreach (var categoryId in categoryIds)
                    {
                        var category = await context.Categories.FindAsync(categoryId);
                        if (category == null)
                        {
                            throw new Exception("Category not found.");
                        }

                        var articleCategory = new ArticleCategory
                        {
                            Article = article,
                            Category = category
                        };

                        context.ArticleCategories.Add(articleCategory);
                    }

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return article;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public double GetArticleScore(int id)
        {
            return (double)context
                 .Articles
                 .Where(a => a.ArticleId == id)
                 .Select(a=>a.Score)
                 .FirstOrDefault();
        }

        public async Task<int> GetArticlesCountAsync()
        {
            return await context
                .Articles
                .CountAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesToPublishAsync()
        {
            var articles = await context.Articles
            .Where(a => a.PublishDate <= DateTime.Now && !a.IsApproved)
            .ToListAsync();

            return articles;
        }
    }
}