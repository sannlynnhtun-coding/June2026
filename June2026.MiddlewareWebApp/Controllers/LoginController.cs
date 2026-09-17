using Microsoft.AspNetCore.Mvc;

namespace June2026.MiddlewareWebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginRequestModel requestModel)
    {
        Response.Cookies.Append("username", requestModel.username);
        return Redirect("/home");
    }
}

public class LoginRequestModel
{
    public string username { get; set; }
    public string password { get; set; }
}
