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
        }
    }
}
