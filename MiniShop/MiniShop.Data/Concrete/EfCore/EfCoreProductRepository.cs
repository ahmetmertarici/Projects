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
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(MyAppContext _dbContext):base(_dbContext)
        {

        }
        private MyAppContext context { 
            get
            {
                return _dbContext as MyAppContext;
            }
        }
        public async Task CreateAsync(Product product, int[] categoryIds)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            product.ProductCategories = categoryIds
                .Select(catId => new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = catId
                }).ToList();
            await context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetApprovedProductsAsync()
        {
            return await context
                .Products
                .Where(p => p.IsApproved==true && p.IsDeleted==false)
                .ToListAsync();
        }
        public async Task<List<Product>> GetHomeProductsAsync(string category)
        {
            var products = context
                .Products
                .Where(p => p.IsHome == true && p.IsDeleted == false && p.IsApproved == true)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                    .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == category));
            }
            return await products.ToListAsync();
        }
        public async Task<Product> GetProductWithCategoriesAsync(int id)
        {
            return await context
                .Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
        }
        public void IsDelete(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }
        public async Task UpdateAsync(Product product, int[] categoryIds)
        {
            var newProduct = await context
                .Products
                .Include(p => p.ProductCategories)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            newProduct.Name = product.Name;
            newProduct.Url = product.Url;
            newProduct.Price = product.Price;
            newProduct.Properties = product.Properties;
            newProduct.ImageUrl = product.ImageUrl;
            newProduct.IsApproved = product.IsApproved;
            newProduct.IsHome = product.IsHome;
            newProduct.ProductCategories = categoryIds
                .Select(catId => new ProductCategory()
                {
                    ProductId = product.Id,
                    CategoryId = catId
                }).ToList();
            context.Update(newProduct);
            context.SaveChanges();
        }
        public async Task UpdateIsApprovedAsync(Product product)
        {
            product.IsApproved = product.IsApproved == true ? false : true;
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task UpdateIsHomeAsync(Product product)
        {
            product.IsHome = product.IsHome == true ? false : true;
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}

