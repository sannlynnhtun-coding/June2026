using Microsoft.AspNetCore.Mvc;

namespace June2026.MvcApp3.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
