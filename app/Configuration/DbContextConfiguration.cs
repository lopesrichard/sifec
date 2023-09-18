using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Configuration
{
    public static class DbContextConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(builder =>
            {
                builder.UseNpgsql(config.GetConnectionString("App"));
            });
        }
    }
}
