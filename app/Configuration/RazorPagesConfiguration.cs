namespace App.Configuration
{
    public static class RazorPagesConfiguration
    {
        public static void ConfigureRazorPages(this IServiceCollection services)
        {
            services.AddRazorPages((options) =>
            {
                options.Conventions.AuthorizeFolder("/Admin");
                options.Conventions.AllowAnonymousToPage("/Admin/Login");

                options.Conventions.AddPageRoute("/Voucher", "/voucher/{simulationId}");
                options.Conventions.AddPageRoute("/Admin/Simulations/List", "/admin/simulations");
                options.Conventions.AddPageRoute("/Admin/Simulations/Details", "/admin/simulations/{simulationId}");
                options.Conventions.AddPageRoute("/Admin/Institutions/List", "/admin/institutions");
                options.Conventions.AddPageRoute("/Admin/Institutions/Edit", "/admin/institutions/{institutionId}/edit");
                options.Conventions.AddPageRoute("/Admin/Institutions/Courses/List", "/admin/institutions/{institutionId}/courses");
                options.Conventions.AddPageRoute("/Admin/Institutions/Courses/Edit", "/admin/institutions/{institutionId}/courses/{courseId}/edit");
                options.Conventions.AddPageRoute("/Admin/Institutions/Courses/New", "/admin/institutions/{institutionId}/courses/new");
            });
        }
    }
}
