using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp.Controllers
{
    public class ProductController : Controller
    {
        [ActionName("Index")] // collin
        public IActionResult ProductList() // sann lynn htun
        {
            return View("ProductList");
        }
    }
}
