using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Business.Abstract
{
    public interface IProductService
    {
        //Gerek generic metotların tümü, gerekse de Product'a özgü metotların tümünü çağıracak metotların imzaları burada olacak.
        #region Generics
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> expression);
        Task CreateAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        #endregion
        #region Product
        Task CreateAsync(Product product, int[] categoryIds);
        Task<List<Product>> GetHomeProductsAsync(string category);
        Task<List<Product>> GetApprovedProductsAsync();
        Task UpdateIsHomeAsync(Product product);
        Task UpdateIsApprovedAsync(Product product);
        Task<Product> GetProductWithCategoriesAsync(int id);
        Task UpdateAsync(Product product, int[] categoryIds);
        void IsDelete(Product product);
        #endregion

    }
}
