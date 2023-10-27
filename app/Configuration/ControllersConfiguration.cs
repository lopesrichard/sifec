namespace App.Configuration
{
    public static class ControllersConfiguration
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}
