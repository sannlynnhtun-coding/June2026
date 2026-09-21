using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace June2026.MiddlewareWebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(LoginRequestModel requestModel)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, requestModel.username),
                new Claim(ClaimTypes.Role, requestModel.username),
                new Claim("LastLogin", DateTime.UtcNow.ToString())
            };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true, // "Remember me" option
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return RedirectToAction("Index", "Home");
    }
}

public class LoginRequestModel
{
    public string username { get; set; }
    public string password { get; set; }
}
