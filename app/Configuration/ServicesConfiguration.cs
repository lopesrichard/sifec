using App.Services;

namespace App.Configuration
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISimulationService, SimulationService>();
            services.AddScoped<IDashboardService, DashboardService>();
        }
    }
}
