using June2026.Database.AppDbContextModels;
using June2026.Domain.Features.Product;
using June2026.Domain.Features.Sale;
using June2026.Domain.Features.User;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/June2026.WebApi-.txt", rollingInterval: RollingInterval.Hour)
    .WriteTo
    .MSSqlServer(
        connectionString: "Server=localhost;Database=June2026Db;User ID=sa;Password=sasa@123;TrustServerCertificate=true;",
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "TblLogEvents",
            AutoCreateSqlTable = true
        })
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog(); // <-- Add this line

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}