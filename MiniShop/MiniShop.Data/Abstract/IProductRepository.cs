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
        //Burada IRepository'de bulunun tüm imzalar Product'a göre yapılandırılmış şekilde miras alındı.
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
