using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Abstract;
using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(MyAppContext _dbContext):base(_dbContext)
        {

        }
        private MyAppContext context
        {
            get
            {
                return _dbContext as MyAppContext;
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted)
        {
            return await context
            .Categories
            .Where(c => c.IsDeleted == isDeleted)
            .ToListAsync();
        }

        public async Task<Category> GetCategoryWithProductsAsync(int id)
        {
            return await context
                .Categories
                .Where(c => c.Id == id)
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .FirstOrDefaultAsync();
        }

        public void IsDelete(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
        
    }
}
