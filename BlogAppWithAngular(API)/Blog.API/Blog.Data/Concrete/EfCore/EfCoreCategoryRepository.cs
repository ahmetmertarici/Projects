using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Abstract;
using Blog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(BlogContext _dbContext) : base(_dbContext)
        {

        }

        private BlogContext context
        {
            get { return _dbContext as BlogContext; }
        }

        public async Task<int> GetCategoriesCountAsync()
        {
            return await context
                .Categories
                .CountAsync();
        }

        public async Task<Category> UpdateCategoryAsync(int categoryId, string categoryName)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Category bul
                    var category = await context.Categories.FindAsync(categoryId);
                    if (category == null)
                    {
                        throw new Exception("Article not found.");
                    }

                    // Category güncelle
                    category.CategoryName = categoryName;

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return category;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}