using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniShop.API.DTO;
using MiniShop.Business.Abstract;
using MiniShop.Entity;

namespace MiniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync(p => p.IsApproved == true);
            var productDTOs = new List<ProductDTO>();
            foreach (var product in products)
            {
                productDTOs.Add(new ProductDTO()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Properties = product.Properties,
                    ImageUrl = product.ImageUrl,
                    Url = product.Url
                });
            }

            return Ok(productDTOs);
        }
        [HttpGet("{id}")] //localhost/api/product/15
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productService.CreateAsync(product);
            return Ok(product); 
        }
    }
}
