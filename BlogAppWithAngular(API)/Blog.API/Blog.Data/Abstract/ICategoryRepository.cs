using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Data.Abstract
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<Category> UpdateCategoryAsync(int categoryId, string categoryName);
        Task<int> GetCategoriesCountAsync();

    }
}