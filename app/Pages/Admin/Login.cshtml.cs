using App.Components;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin
{
    public class Login : Page
    {
        [BindProperty]
        public required string Username { get; set; }

        [BindProperty]
        public required string Password { get; set; }

        public string? Message { get; set; }

        private readonly ILoginService _service;

        public Login(ILoginService service) : base("Login")
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _service.Login(Username, Password);

            if (result.Success)
            {
                return RedirectToPage("/Admin/Dashboard");
            }

            Message = result.Exception.Message;

            return Page();
        }
    }
}