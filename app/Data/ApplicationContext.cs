using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities => Set<City>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Institution> Institutions => Set<Institution>();
        public DbSet<Simulation> Simulations => Set<Simulation>();

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                var path = Directory.GetCurrentDirectory();
                var config = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("appsettings.json").Build();
                builder.UseNpgsql(config.GetConnectionString("App"));
            }
        }
    }
}
