using June2026.Database.AppDbContextModels;
using June2026.Domain.Features.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace June2026.WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string connectionString =
                "Server=.;Database=June2026Db;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<UserService>();
            services.AddScoped<FrmUser>();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            using IServiceScope scope = serviceProvider.CreateScope();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(scope.ServiceProvider.GetRequiredService<FrmUser>());
        }
    }
}
