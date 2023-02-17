using Microsoft.AspNetCore.Mvc;

namespace CustomersSite.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
