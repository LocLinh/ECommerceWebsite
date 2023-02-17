using CustomersSite.Models;
using CustomersSite.Services;
using Microsoft.AspNetCore.Mvc;
using Solution.Data.Models.ProductModels;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace CustomersSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        public HomeController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productApiClient.GetAllProducts();
            return View(products);
        }
        public async Task<IActionResult> ProductDetail(int id)
        {
            var products = await _productApiClient.GetProductById(id);
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}