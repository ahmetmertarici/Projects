using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task CreateAsync(Product product, int[] categoryIds);
        Task<List<Product>> GetApprovedProductsAsync();
        Task<List<Product>> GetHomeProductsAsync(string category);
        Task UpdateIsHomeAsync(Product product);
        Task UpdateIsApprovedAsync(Product product);
        Task<Product> GetProductWithCategoriesAsync(int id);
        Task UpdateAsync(Product product, int[] categoryIds);
        void IsDelete(Product product);
    }
}
