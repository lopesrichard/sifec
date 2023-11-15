using App.Components;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin
{
    public class Logout : Page
    {
        private readonly ILoginService _service;

        public Logout(ILoginService service) : base("Logout")
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _service.Logout();
            return RedirectToPage("/Admin/Login");
        }
    }
}

