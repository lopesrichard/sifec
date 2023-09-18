namespace App.Configuration
{
    public static class RazorPagesConfiguration
    {
        public static void ConfigureRazorPages(this IServiceCollection services)
        {
            services.AddRazorPages((options) =>
            {
                options.Conventions.AuthorizeFolder("/admin");
                options.Conventions.AllowAnonymousToPage("/admin/login");
            });
        }
    }
}
