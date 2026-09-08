using June2026.ChartApp.Models;
using June2026.Domain.Features.Product;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace June2026.ChartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _productService.GetProductsAsync();

            var lst = model.Products.OrderByDescending(x => x.Quantity).Take(10);
            List<int> series = lst.Select(x => x.Quantity).ToList();
            List<string> labels = lst.Select(x => x.ProductName).ToList();
            ViewData["Series"] = series;
            ViewData["Labels"] = labels;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
