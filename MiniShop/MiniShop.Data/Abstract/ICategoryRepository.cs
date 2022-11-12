using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void IsDelete(Category category);
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted);
        Task<Category> GetCategoryWithProductsAsync(int id);


    }
}
