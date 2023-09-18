using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin
{
    public class Index : Page
    {
        public Index() : base("Index")
        {
        }

        public IActionResult OnGet()
        {
            return RedirectToPagePermanent("/admin/dashboard");
        }
    }
}

