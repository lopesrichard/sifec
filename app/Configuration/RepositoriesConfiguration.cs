using App.Repositories;

namespace App.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISimulationRepository, SimulationRepository>();
        }
    }
}
