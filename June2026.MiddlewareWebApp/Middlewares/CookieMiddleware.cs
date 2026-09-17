using System.Globalization;

namespace June2026.MiddlewareWebApp.Middlewares;

public class CookieMiddleware
{
    private readonly ILogger<CookieMiddleware> _logger;
    private readonly RequestDelegate _next;

    public CookieMiddleware(RequestDelegate next, ILogger<CookieMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("CookieMiddleware => {path}", context.Request.Path);
        if (context.Request.Path.ToString().ToLower() != "/login" &&
            context.Request.Path.ToString().ToLower() != "/login/index")
        {
            if (!context.Request.Cookies.Any(x => x.Key == "username"))
            {
                context.Response.Redirect("/login");
            }
        }

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public static class CookieMiddlewareExtension
{
    public static void UseCookieMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CookieMiddleware>();
    }
}
