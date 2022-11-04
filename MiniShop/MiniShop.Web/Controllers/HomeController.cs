using Microsoft.AspNetCore.Mvc;
using MiniShop.Business.Abstract;
using MiniShop.Entity;
using System.Diagnostics;

namespace MiniShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            //Burası ne zaman çalışıyor?
            //Productları ana sayfada göstermek istiyoruz. Home productları.
            var homeProducts = await _productService.GetHomeProductsAsync(null);
            return View(homeProducts);
        }

        public async Task<IActionResult> ProductList(string category)
        {
            var homeProducts = await _productService.GetHomeProductsAsync(category);
            return View("Index",homeProducts);
        }
    }
}