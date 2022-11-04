using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.CreateAsync(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> expression)
        {
            return await _categoryRepository.GetAllAsync(expression);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted)
        {
            return await _categoryRepository.GetAllCategoriesAsync(isDeleted);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> GetCategoryWithProductsAsync(int id)
        {
            return await _categoryRepository.GetCategoryWithProductsAsync(id);
        }

        public void IsDelete(Category category)
        {
            _categoryRepository.IsDelete(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
