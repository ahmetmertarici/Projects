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
        //Burada IRepository'de bulunun tüm imzalar Category'e göre yapılandırılmış şekilde miras alındı.
        void IsDelete(Category category);
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted);
        Task<Category> GetCategoryWithProductsAsync(int id);


    }
}
