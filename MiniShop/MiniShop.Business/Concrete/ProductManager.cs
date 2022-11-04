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
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateAsync(Product product)
        {
            await _productRepository.CreateAsync(product);
        }

        public async Task CreateAsync(Product product, int[] categoryIds)
        {
            await _productRepository.CreateAsync(product, categoryIds);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> expression)
        {
            return await _productRepository.GetAllAsync(expression);
        }

        public async Task<List<Product>> GetApprovedProductsAsync()
        {
            return await _productRepository.GetApprovedProductsAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetHomeProductsAsync(string category)
        {
            return await _productRepository.GetHomeProductsAsync(category);
        }

        public async Task<Product> GetProductWithCategoriesAsync(int id)
        {
            return await _productRepository.GetProductWithCategoriesAsync(id);
        }

        public void IsDelete(Product product)
        {
            _productRepository.IsDelete(product);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product product, int[] categoryIds)
        {
            await _productRepository.UpdateAsync(product, categoryIds);
        }

        public async Task UpdateIsApprovedAsync(Product product)
        {
            await _productRepository.UpdateIsApprovedAsync(product);
        }

        public async Task UpdateIsHomeAsync(Product product)
        {
            await _productRepository.UpdateIsHomeAsync(product);
        }
    }
}
