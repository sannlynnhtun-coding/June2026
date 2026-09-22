using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";          // Login page path
        options.AccessDeniedPath = "/Account/AccessDenied"; // Access denied path
        options.LogoutPath = "/Account/Logout";        // Logout path
        options.ExpireTimeSpan = TimeSpan.FromHours(8); // Cookie expiry time
        options.SlidingExpiration = true;              // Auto-refresh expiry
        options.Cookie.HttpOnly = true;                // Prevent XSS
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS only
        options.Cookie.SameSite = SameSiteMode.Strict; // CSRF protection
    });

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
