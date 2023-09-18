using Microsoft.AspNetCore.Authentication.Cookies;

namespace App.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/admin/login";
                    options.ReturnUrlParameter = "origin";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                });
        }
    }
}
