using June2026.Database.AppDbContextModels;
using June2026.Domain.Features.Product;
using June2026.Domain.Features.Sale;
using June2026.Domain.Features.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, ProductV2Service>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<UserService>();

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

app.UseAuthorization();

// http://localhost:3000
// http://localhost:3000 = http://localhost:3000/home/index
// http://localhost:3000/home = http://localhost:3000/home/index
// http://localhost:3000/product = http://localhost:3000/product/index

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
